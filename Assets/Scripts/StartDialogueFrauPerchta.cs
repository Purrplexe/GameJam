using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartDialogue : MonoBehaviour
{
    public GameObject dialogueBox; // Reference to the DialogueBox
    public TextMeshProUGUI dialogueText; // Reference to the Text component
    public GameObject frauPerchta; // Reference to Frau Perchta for animation
    public Animator frauAnimator; // Reference to Perchta's animator
    public TimerManager timerScript; // Reference to the Timer script
    public PointManager pointManager; // Reference to the PointManager

    private bool gameStarted = false;

    void Start()
    {
        // Show the dialogue box at the start
        dialogueBox.SetActive(true);
        dialogueText.text = "Who dares disturb my night? Do you know what I do to those who lie? To those who shirk their tasks. Show me if you truly know the difference between truth and deceit, between diligence and neglect. Fail, and I shall take my payment another way!";
    }

    public void StartGame()
    {
        if (!gameStarted)
        {
            gameStarted = true;

            // Hide dialogue and start the game
            dialogueBox.SetActive(false);

            // Play Frau Perchta's animation
            if (frauAnimator != null)
            {
                frauAnimator.SetTrigger("StartGame"); // Ensure "StartGame" trigger exists in her Animator
            }

            // Start the timer
            if (timerScript != null)
            {
                timerScript.StartTimer(); // Ensure your Timer script has a StartTimer method
            }
        }
    }
}
