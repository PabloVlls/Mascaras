using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScannerTool1 : MonoBehaviour
{
    [Header("UI")]
    public GameObject scannerPanel;
    public GameObject scannerEffect;
    public TextMeshProUGUI resultText;

    [Header("Settings")]
    public float scanDuration = 3f; // tiempo necesario

    [Header("References")]
    public NPCController npcController;

    float scanTimer = 0f;
    bool scanning = false;
    bool scanCompleted = false;

    void Start()
    {
        scannerPanel.SetActive(false);
        resultText.gameObject.SetActive(false);
    }

    void Update()
    {
        // Mantener presionado 5
        if (Input.GetKey(KeyCode.Alpha5))
        {
            StartScanning();
        }
        else
        {
            CancelScanning();
        }

        if (scanning && !scanCompleted)
        {
            scanTimer += Time.deltaTime;

            if (scanTimer >= scanDuration)
            {
                CompleteScan();
            }
        }
    }

    void StartScanning()
    {
        if (scanCompleted) return;

        scanning = true;
        scannerPanel.SetActive(true);
        scannerEffect.SetActive(true);
    }

    void CancelScanning()
    {
        scanning = false;
        scanTimer = 0f;
        scanCompleted = false;

        scannerPanel.SetActive(false);
        resultText.gameObject.SetActive(false);
    }

    void CompleteScan()
    {
        scanCompleted = true;
        scanning = false;

        scannerEffect.SetActive(false);
        resultText.gameObject.SetActive(true);

        ShowResult();
    }

    void ShowResult()
    {
        if (npcController == null || npcController.characterData == null)
        {
            resultText.text = "ERROR DE LECTURA";
            return;
        }

        resultText.text =
            $"Resultado: {npcController.characterData.detectorResult}";
    }
}

