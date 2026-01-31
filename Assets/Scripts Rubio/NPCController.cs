using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [Header("Data")]
    public MaskedCharacterData characterData;

    [Header("References")]
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        ShowNormal();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            FindObjectOfType<EvaluationManager>()
                .EvaluateDecision(true, characterData);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            FindObjectOfType<EvaluationManager>()
                .EvaluateDecision(false, characterData);
        }
    }


    // ===== VISUALS =====
    public void ShowNormal()
    {
        spriteRenderer.sprite = characterData.normalSprite;
    }

    public void ShowUV()
    {
        spriteRenderer.sprite = characterData.uvSprite;
    }

    // ===== DIALOGUE =====
    public string GetClanAnswer()
    {
        return characterData.clanAnswer;
    }

    public string GetSmellAnswer()
    {
        return characterData.smellAnswer;
    }

    public string GetDrinkAnswer()
    {
        return characterData.drinkAnswer;
    }
}

