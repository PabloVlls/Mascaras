using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IDPanelController : MonoBehaviour
{
    [Header("UI")]
    public GameObject panel;
    public Image idImage;

    [Header("References")]
    public NPCController npcController;

    public void ShowID()
    {
        if (npcController == null || npcController.characterData == null)
        {
            Debug.LogWarning("?? No hay NPC para mostrar ID");
            return;
        }

        panel.SetActive(true);
        idImage.sprite = npcController.characterData.idSprite;
    }

    public void HideID()
    {
        panel.SetActive(false);
    }
}

