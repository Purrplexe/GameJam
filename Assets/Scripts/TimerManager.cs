using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Link your TimerText object in the Inspector
    public float timeLeft = 60f; // Set the countdown time (in seconds)

    private bool _isRunning = false; // Indicates if the timer is running
    private bool _isGameOver = false; // Indicates if the game is over

    private void Update()
    {
        if (!_isRunning || _isGameOver) return;

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

    // Public method to start the timer
    public void StartTimer()
    {
        _isRunning = true; // Start the timer
        _isGameOver = false; // Reset the game-over state
    }

    private void EndGame()
    {
        _isRunning = false; // Stop the timer
        _isGameOver = true;
        Debug.Log("Game Over!");
        // Add game-over logic (e.g., show UI or stop item dragging)
    }

    // Optional: Public method to stop/reset the timer (if needed)
    public void StopTimer()
    {
        _isRunning = false; // Stop the timer
    }

    public void ResetTimer(float newTime)
    {
        timeLeft = newTime; // Reset the countdown time
        timerText.text = "Time: " + Mathf.CeilToInt(timeLeft).ToString(); // Update the display
        _isRunning = false; // Pause the timer
        _isGameOver = false; // Reset game-over state
    }
}
