using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;  // Reference to the TextMeshProUGUI
    public Button nextButton;  // Reference to the Next button
    public GameObject dialogueBox;  // Dialogue box UI object

    private string[] dialogues;
    private int currentDialogueIndex = 0;

    private void Start()
    {
        nextButton.onClick.AddListener(ShowNextDialogue);
        nextButton.gameObject.SetActive(false);  // Hide the button at the start
    }

    public void StartDialogue(string[] dialogueLines)
    {
        dialogues = dialogueLines;
        currentDialogueIndex = 0;
        dialogueBox.SetActive(true);  // Show the dialogue box
        ShowNextDialogue();  // Start the first line of dialogue
    }

    private void ShowNextDialogue()
    {
        if (currentDialogueIndex < dialogues.Length)
        {
            dialogueText.text = dialogues[currentDialogueIndex];
            nextButton.gameObject.SetActive(false);  // Hide the button for now
            currentDialogueIndex++;
            StartCoroutine(ShowNextButtonAfterDelay());
        }
        else
        {
            EndDialogue();
        }
    }

    private IEnumerator ShowNextButtonAfterDelay()
    {
        yield return new WaitForSeconds(0.5f);  // Wait before showing the "Next" button
        nextButton.gameObject.SetActive(true);  // Show the "Next" button
    }

    private void EndDialogue()
    {
        dialogueBox.SetActive(false);  // Hide the dialogue box
        // Here, you can start the next scene, game, or event, for example:
        // LevelLoader.Instance.LoadLevel("FrauPerchtaGame");
    }
}
