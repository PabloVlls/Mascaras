using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [Header("Data")]
    public MaskedCharacterData characterData;

    [Header("References")]
    public SpriteRenderer mainRenderer; // Capa Dafault
    public SpriteRenderer detailRenderer; // Capa Detalles Lupa
    public SpriteRenderer uvRenderer; // Capa Fitro UV
    public SpriteRenderer spriteRenderer;

    [Header("Audios")]
    public AudioClip sonidoMadera;
    public AudioClip sonidoMetal;
    public AudioClip sonidoSquish;


    void Start()
    {
        ShowNormal();
        if (characterData != null) SetupNPC();
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


    public void SetupNPC()
    {
        //Imagen base
        mainRenderer.sprite = characterData.normalSprite;

        //Imagen de detalles
        detailRenderer.gameObject.layer = LayerMask.NameToLayer("Detalles_lupa");

        //Configuración para el filtro UV
        uvRenderer.sprite = characterData.uvSprite;
        uvRenderer.gameObject.layer = LayerMask.NameToLayer("Detalles_UV");

        
    }




    public void ShowUV()
    {
        spriteRenderer.sprite = characterData.uvSprite;
    }

    // ===== VISUALS =====
    public void ShowNormal()
    {
        mainRenderer.sprite = characterData.normalSprite;
    }
    

    public AudioClip GetHitSound()
    {
        switch(characterData.clickSound)
        {
            case ClickSoundType.Hollow : return sonidoMadera;
            case ClickSoundType.Solid : return sonidoMetal;
            case ClickSoundType.Wet :return sonidoSquish;
            default: return null;
        }
    }

    public void PlayHammerAnimation()
    {
        if(characterData.race == CharacterRace.Human)
            GetComponent<Animator>().SetTrigger("NervousHit");
        else
            GetComponent<Animator>().SetTrigger("SteadyHit");
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

