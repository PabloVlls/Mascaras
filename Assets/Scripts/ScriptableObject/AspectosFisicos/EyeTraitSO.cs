using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevosRasgoOjo", menuName = "Discoteca/Rasgo de Ojo")]
public class EyeTraitSO : ScriptableObject
{
    public string idInterno; 
    public Sprite spritePupila;
    public Color colorOjo = Color.white;
    public bool esLuminiscente; //Para activar un shader de brillo

    [Header("Lógica de Deducción")]
    // Esto es lo que el juego usa para saber si el jugador acertó
    public bool esRasgoHumano;

    [TextArea]
    public string descripcionParaManual; // Lo que el jugador leerá
}
