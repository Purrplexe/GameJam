using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Link your TimerText object in the Inspector
    public float timeLeft = 60f; // Set the countdown time (in seconds)

    private bool _isGameOver = false;

    private void Update()
    {
        if (_isGameOver) return;

        // Countdown logic
        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0)
        {
            timeLeft = 0;
            EndGame();
        }

        // Update the timer display
        timerText.text = "Time: " + Mathf.CeilToInt(timeLeft).ToString();
    }

    private void EndGame()
    {
        _isGameOver = true;
        Debug.Log("Game Over!");
        // Add game-over logic (e.g., show UI or stop item dragging)
    }
}
