using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public DialogueManager dialogueManager;  // Reference to DialogueManager

    private void Start()
    {
        // Dialogue lines
        string[] introDialogues = {
            "Welcome to the game!",
            "You will face many challenges in this adventure.",
            "Your first challenge is against Frau Perchta!"
        };

        // Start the dialogue
        dialogueManager.StartDialogue(introDialogues);
    }
}
