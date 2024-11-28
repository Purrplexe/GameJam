using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public float timeRemaining = 60f;
    public TextMeshProUGUI timerText; // Reference to Timer UI Text
    public PointManager pointManager; // Reference to the PointManager
    public GameObject dialogueBox; // Reference to the DialogueBox
    public TextMeshProUGUI dialogueText; // Reference to the Text component
    public GameObject frauPerchta; // Reference to Frau Perchta
    public Animator frauAnimator; // Reference to the Animator component on Frau Perchta

    private bool timerRunning = false;
    private bool animationPlayed = false; // New variable to ensure animation plays once

    public void StartTimer()
    {
        timerRunning = true; // Start the timer
        dialogueBox.SetActive(false); // Hide the dialogue box when the game starts

        // Play Frau Perchta animation once
        if (!animationPlayed)
        {
            frauAnimator.Play("YourAnimationName"); // Replace "YourAnimationName" with the name of your animation clip
            animationPlayed = true;
        }
    }

    void Update()
    {
        if (timerRunning && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = Mathf.CeilToInt(timeRemaining).ToString();
        }
        else if (timerRunning && timeRemaining <= 0)
        {
            timerRunning = false;
            EndGame();
        }
    }

    private void EndGame()
    {
        dialogueBox.SetActive(true); // Show dialogue box at the end

        if (pointManager.GetPoints() >= 50)
        {
            dialogueText.text = "Hmm. Perhaps there is hope for you yet. I grant you my favor, but tread carefully - the others may not be so kind.";
        }
        else
        {
            dialogueText.text = "Pathetic. I expected nothing less. The weak do not reach home unscathed. Run, and pray the next trial grants you mercy.";
        }
    }
}
