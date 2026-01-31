using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevoCliente", menuName = "Discoteca/NPC")]
public class NPCDataSO : ScriptableObject
{
    [Header("Verdad Biológica")]
    public RaceDataSO razaReal;
    public EyeTraitSO rasgoOcularAsignado;
    
    [Header("Identidad Presentada")]
    public string nombreEnDocumento;
    public string razaEnDocumento; //Aquí el humano pondrá Demonio para engañar

    [Header("Instancia de Comportamiento")]
    public ReactionSO reaccionAsignada; // La reacción que eligió el generador para este NPC

    [Header("Máscara")]
    public MaskSO mascaraEquipada;
}
