using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteraccionMascara : MonoBehaviour
{

    public NPCDataSO datos;

    void OnMouseDown() // Al hacer clic en la máscara
    {
        // Sonido
        AudioSource.PlayClipAtPoint(datos.mascaraEquipada.sonidoAlGolpear, transform.position);

        // Reaccion Visual
        if (datos.mascaraEquipada.seAbollaAlClic)
        {
            // Ejecutar pequeña animación de defromación
        }

        if (datos.mascaraEquipada.muerdeAlJugador)
        {
            // El cursor cambia a una mano herida y el jugador pierde tiempo
        }
    }
}
