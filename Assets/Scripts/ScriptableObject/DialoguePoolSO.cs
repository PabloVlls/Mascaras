using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevaPregunta", menuName = "Discoteca/Dialogo/Pregunta")]
public class DialoguePoolSO : ScriptableObject
{
    [TextArea]
    public string textoPregunta;

    [Header("Respuestas de Demonios")]
    public List<string> respuestasCorrectas;

    [Header("Respuestas de Humanos (Fallos)")]
    public List<string> respuestasInfiltrados;
}
