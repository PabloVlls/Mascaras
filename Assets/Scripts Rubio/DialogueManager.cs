using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject dialoguePanel;
    public GameObject questionPanel;
    public TextMeshProUGUI dialogueText;

    [Header("References")]
    public NPCController currentNPC;

    public void OpenDialogue()
    {
        questionPanel.SetActive(true);
        dialogueText.text = "";
    }

    public void CloseDialogue()
    {
        dialoguePanel.SetActive(false);
        questionPanel.SetActive(false);

    }

    public void AskClan()
    {
        dialogueText.text = currentNPC.GetClanAnswer();
        dialoguePanel.SetActive(true);
    }

    public void AskSmell()
    {
        dialogueText.text = currentNPC.GetSmellAnswer();
        dialoguePanel.SetActive(true);
    }

    public void AskDrink()
    {
        dialogueText.text = currentNPC.GetDrinkAnswer();
        dialoguePanel.SetActive(true);
    }
}

