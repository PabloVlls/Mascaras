using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevaReaccion", menuName = "Discoteca/Comportamiento/Reaccion")]
public class ReactionSO : MonoBehaviour
{
    public string nombreReaccion;
    public float multiplicadorTemblor; // Cuánto aumenta la vibración
    public string animacionTrigger; // Nombre del trigger en el animator
}
