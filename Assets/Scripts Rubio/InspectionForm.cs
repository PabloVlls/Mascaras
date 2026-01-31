using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectionForm : MonoBehaviour
{
    [Header("Observed Data (Player Input)")]

    public EyeType observedEyes;
    public MaskMaterialVisual observedMaterial;
    public MaskAttachment observedAttachment;
    public UVSymbolType observedUVSymbol;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            observedEyes = EyeType.Round;

        if (Input.GetKeyDown(KeyCode.Alpha2))
            observedMaterial = MaskMaterialVisual.Bone;

        if (Input.GetKeyDown(KeyCode.P))
            PrintForm();
    }

    // Llamar cuando entra un NPC nuevo
    public void ResetForm()
    {
        observedEyes = default;
        observedMaterial = default;
        observedAttachment = default;
        observedUVSymbol = default;

        Debug.Log("?? Formulario reiniciado");
    }

    // DEBUG: muestra lo que el jugador marcó
    public void PrintForm()
    {
        Debug.Log(
            $"FORM:\n" +
            $"Eyes: {observedEyes}\n" +
            $"Material: {observedMaterial}\n" +
            $"Attachment: {observedAttachment}\n" +
            $"UV: {observedUVSymbol}"
        );
    }
}

