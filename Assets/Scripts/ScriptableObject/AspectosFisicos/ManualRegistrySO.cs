using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ManualReglas", menuName = "Discoteca/Sistema/Manual")]
public class ManualRegistrySO : ScriptableObject
{
    [Header("Reglas de Demonios")]
    public List<EyeTraitSO> rasgosLegalesDemonio;

    [Header("Amenazas Humanas")]
    public List<EyeTraitSO> rasgosDetectadosEnInfiltrados;
}
