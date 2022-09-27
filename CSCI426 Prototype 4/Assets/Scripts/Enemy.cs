using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 3f;

    [SerializeField] float moveSpeed = 5f;
    Rigidbody2D rb; 
    Transform target;
    Vector2 moveDirection;

    int points = 0;

    public GameOver GameOverScreen;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;   
        target = GameObject.Find("Player").transform;
        GameOverScreen = GameObject.FindGameObjectWithTag("GameOverTag").GetComponent<GameOver>();
    }

    private void Update() 
    {
        if(target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            float Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = Angle;
            moveDirection = direction;
        }
    }

    private void FixedUpdate() 
    {
        if(target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
    }

    public void UpdatePoints(int score)
    {
        points += score;
    }

    public void TakeDamage(float damageAmount) 
    {
        health -= damageAmount;

        if(health <=0)
        {
            GameOverScreen.AddScore(1);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.gameObject.CompareTag("Player"))
        {
            GameOverScreen.Setup(); 
        }
    }
}
