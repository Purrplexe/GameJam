using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpiritManager : MonoBehaviour
{
    public Slider spiritSlider; // Drag your slider here in the Inspector
    public float maxSpirit = 100f;
    public float currentSpirit;
    public GameObject dialogueBox;
    public TextMeshProUGUI dialogueText; // Reference to the dialogue box text component
    public int totalGifts = 5; // Total number of gifts to collect
    private int giftsCollected = 0;

    public void StartGame()
    {
        dialogueBox.SetActive(false); // Hide the dialogue box
        Time.timeScale = 1f; // Resume game time
    }

    private void Start()
    {
        Time.timeScale = 0f; // Pause the game at the start
        dialogueBox.SetActive(true); // Show the dialogue box
        // Set the initial slider values
        currentSpirit = maxSpirit;
        spiritSlider.maxValue = maxSpirit;
        spiritSlider.value = currentSpirit;

        ShowPreGameDialogue();
    }
    private void ShowPreGameDialogue()
    {
        dialogueText.text = "Another soul, trudging through the snow, clinging to the hope of warmth and light. But tell me… Do you deserve it? You carry sins as surely as those chains I drag. Tell me, mortal, do you think punishment shapes the soul - or merely crushes it?";
        // Optionally, you can set the text here and add more details for the pre-game scenario.
    }
    public void AddSpirit(float amount)
    {
        currentSpirit += amount;
        if (currentSpirit > maxSpirit) currentSpirit = maxSpirit;
        spiritSlider.value = currentSpirit;
    }

    public void SubtractSpirit(float amount)
    {
        currentSpirit -= amount;
        if (currentSpirit < 0) currentSpirit = 0;
        spiritSlider.value = currentSpirit;

        if (currentSpirit <= 0)
        {
            LoseGame(); // Call game over logic
        }
    }

    public void CollectGift()
    {
        giftsCollected++;
        if (giftsCollected >= totalGifts)
        {
            WinGame(); // Call win condition
        }
    }

    private void LoseGame()
    {
        Time.timeScale = 0f; // Pause the game
        dialogueBox.SetActive(true);
        dialogueText.text = "Weakness. It’s a wonder you’ve made it this far. Go on, crawl to your fate. Perhaps others will have mercy where I will not.";
        Debug.Log("Game Over! Your spirit has run out.");
    }

    private void WinGame()
    {
        Time.timeScale = 0f; // Pause the game
        dialogueBox.SetActive(true);
        dialogueText.text = "You stand tall, even under the lash. Perhaps there’s strength in you yet. Go… but know that the weight you carry is far from lifted.";
        Debug.Log("You won the game!");
    }
}
