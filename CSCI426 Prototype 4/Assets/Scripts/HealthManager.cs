using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float healthAmount = 100f;

    public GameOver GameOverScreen;

    int points = 0;

    // Update is called once per frame

    public void UpdatePoints(int score) {
        points += score;
    }

    public void TakeDamage(float damage) {
        healthAmount -= damage; 

        if (healthAmount <= 0) {
            GameOverScreen.Setup(points);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(100); 
        }
    }
}
