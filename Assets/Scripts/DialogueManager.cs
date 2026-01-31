using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI cuadroTexto;
    private NPCController npcActual; //El cliente en la puerta

    public void Preguntar(DialoguePoolSO pool)
    {
        NPCDataSO datos = npcActual.datos;
        string r = datos.esHumano ?
            pool.respuestasInfiltrados[Random.Range(0, pool.respuestasInfiltrados.Count)]:
            pool.respuestasCorrectas[Random.Range(0, pool.respuestasCorrectas.Count)];
        cuadroTexto.text = r;
    }
}
