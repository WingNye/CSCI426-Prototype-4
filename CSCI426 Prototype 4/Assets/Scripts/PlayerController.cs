using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject speedPowerup; 

    [SerializeField]
    private float powerupInterval = 10f;

    [SerializeField] 
    private GameObject slowEnemies; 

    [SerializeField]
    private float slowInterval = 10f;

    public Rigidbody2D rb;
    public Weapon weapon;

    public float moveSpeed = 5f;
    Vector2 moveDirection;
    Vector2 mousePosition;

    public Enemy enemy; 

    void Start() 
    {
        StartCoroutine(spawnPowerup(powerupInterval, speedPowerup));
        StartCoroutine(spawnPowerup(slowInterval, slowEnemies));
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if(Input.GetMouseButtonDown(0)) {
            weapon.Fire();
        }

        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate() 
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }

    private IEnumerator spawnPowerup(float interval, GameObject powerup)
    {
        yield return new WaitForSeconds(interval);
        GameObject newPowerup = Instantiate(powerup, new Vector3(Random.Range(-9f, 9), Random.Range(-4f, 4), 0), Quaternion.identity);
        StartCoroutine(spawnPowerup(interval, powerup));
    }

    void OnTriggerEnter2D (Collider2D other) 
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
            moveSpeed = moveSpeed * 1.25f;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Slow"))
        {
            Enemy.moveSpeed = Enemy.moveSpeed - 0.5f;
            Destroy(other.gameObject);
        }
    }
}
