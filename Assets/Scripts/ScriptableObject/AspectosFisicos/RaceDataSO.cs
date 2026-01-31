using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevaRaza", menuName = "Discoteca/Datos de Raza")]
public class RaceDataSO : ScriptableObject
{
    public string nombreRaza; // Humano o demonio
    public List<EyeTraitSO> rasgosOcularesPosibles;

    public List<MaskSO> mascarasPosibles;

    [Header("Comportamiento Base")]
    public float vibracionBase; 
    public bool esRigido; // Para el tipo Estático total
    public List<ReactionSO> reaccionesPosibles; // Lista de reacciones que esta raza puede tener
}
