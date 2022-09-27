using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI pointsText;

    public GameObject screen;

    int score = 0;

    void Start() {

    }

    public void AddScore(int x) {
        score += x;
    }

    public void Setup() {
        screen.SetActive(true);
        pointsText.text = score.ToString() + " POINTS";
    }

    public void RestartButton() {
        SceneManager.LoadScene("Game");
    }
}
