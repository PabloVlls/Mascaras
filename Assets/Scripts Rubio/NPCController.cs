using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [Header("Data")]
    public MaskedCharacterData characterData;

    [Header("Sprite Renderers (Layers)")]
    public SpriteRenderer mainRenderer;     // Sprite base
    public SpriteRenderer detailRenderer;   // Detalles (Lupa)
    public SpriteRenderer uvRenderer;       // Filtro UV
    public SpriteRenderer flashlightRenderer;

    [Header("Audios")]
    public AudioClip sonidoMadera;
    public AudioClip sonidoMetal;
    public AudioClip sonidoSquish;

    void Start()
    {
        if (characterData != null)
        {
            SetupNPC();
            ShowNormal();
        }
    }

    void Update()
    {
        GetHitSound();
    }

    // =========================
    // SETUP
    // =========================
    public void SetupNPC()
    {
        mainRenderer.sprite = characterData.normalSprite;
        uvRenderer.sprite = characterData.uvSprite;

        uvRenderer.gameObject.SetActive(false);
        detailRenderer.gameObject.SetActive(false);

        flashlightRenderer.sprite = characterData.flashlightSprite;
        flashlightRenderer.gameObject.SetActive(false);



        /*// Asignar sprites SOLO UNA VEZ desde el ScriptableObject
        mainRenderer.sprite = characterData.normalSprite;
        uvRenderer.sprite = characterData.uvSprite;

        // Capas (opcional, pero bien)
        detailRenderer.gameObject.layer = LayerMask.NameToLayer("Detalles_lupa");
        uvRenderer.gameObject.layer = LayerMask.NameToLayer("Detalles_UV");

        // Estados iniciales
        uvRenderer.gameObject.SetActive(false);
        detailRenderer.gameObject.SetActive(false);*/
    }

    public void ShowFlashlight()
    {
        flashlightRenderer.gameObject.SetActive(true);
    }

    public void HideFlashlight()
    {
        flashlightRenderer.gameObject.SetActive(false);
    }

    // =========================
    // VISUAL STATES (TOOLS)
    // =========================

    /// <summary>
    /// Estado normal: sin herramientas visuales activas
    /// </summary>
    public void ShowNormal()
    {
        uvRenderer.gameObject.SetActive(false);
        detailRenderer.gameObject.SetActive(false);
    }

    /// <summary>
    /// Activa visual UV
    /// </summary>
    public void ShowUV()
    {
        Debug.Log("🟣 ShowUV llamado");

        uvRenderer.gameObject.SetActive(true);

        Debug.Log("Sprite UV asignado: " + uvRenderer.sprite);
    }

    /// <summary>
    /// Activa detalles de lupa
    /// </summary>
    public void ShowDetails()
    {
        detailRenderer.gameObject.SetActive(true);
    }

    // =========================
    // AUDIO / FEEDBACK
    // =========================
    public AudioClip GetHitSound()
    {
        switch (characterData.clickSound)
        {
            case ClickSoundType.Hollow: return sonidoMadera;
            case ClickSoundType.Solid: return sonidoMetal;
            case ClickSoundType.Wet: return sonidoSquish;
            default: return null;
        }
    }

    public void PlayHammerAnimation()
    {
        if (characterData.race == CharacterRace.Human)
            GetComponent<Animator>().SetTrigger("NervousHit");
        else
            GetComponent<Animator>().SetTrigger("SteadyHit");
    }

    // =========================
    // DIALOGUE
    // =========================
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

/*public class NPCController : MonoBehaviour
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
}*/

