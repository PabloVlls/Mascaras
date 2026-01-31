using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Creador de clientes

public class NPCGenerator : MonoBehaviour
{

    public RaceDataSO razaHumana;
    public RaceDataSO razaDemonio; 
    public NPCController npcVisual; //Referencia al obejto de la escena 

    public void GenerarNuevoCliente()
    {
        //Decidir identidad real (50% de probabilidad de infiltrado)
        bool seraHumano = Random.value > 0.5f;
        RaceDataSO razaReal = seraHumano ? razaHumana : razaDemonio;

        //Crear instancia de datos para este cliente
        NPCDataSO nuevoNPC = ScriptableObject.CreateInstance<NPCDataSO>();
        nuevoNPC.razaReal = razaReal;
        nuevoNPC.esHumano = seraHumano;

        //Asignar rasgos basados en la rasa real
        nuevoNPC.rasgoOcularAsignado = razaReal.rasgosOcularesPosibles[Random.Range(0, razaReal.rasgosOcularesPosibles.Count)];
        nuevoNPC.mascaraEquipada = razaReal.mascarasPosibles[Random.Range(0, razaReal.mascarasPosibles.Count)];
        nuevoNPC.reaccionAsignada = razaReal.reaccionesPosibles[Random.Range(0, razaReal.reaccionesPosibles.Count)];

        //Configurar la mentira (Documentación)
        nuevoNPC.nombreEnDocumento = "Sujeto" + Random.Range(100,999);
        nuevoNPC.razaEnDocumento = "Demonio"; //todos dirán que son demonios

        //Enviar datos al controlador visual
        npcVisual.Configurar(nuevoNPC);
    }
}
