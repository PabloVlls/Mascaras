using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevaMascara", menuName = "Discoteca/Mascara")]
public class MaskSO : ScriptableObject
{
    [Header("Visual y Textura")]
    public string nombreMascara;
    public Sprite spriteMascara;
    public bool esHumana; // ¿Es un disfraz?

    [Header("Detector de Materiales")]
    public string materialOutput;

    [Header("Mecanismo de Sujeción")]
    public string descripcion; // Para el manual

    [Header("Feedback de Interacción (clic)")]
    public AudioClip sonidoAlGolpear;
    public bool seAbollaAlClic; // Si es plástico/humano
    public bool muerdeAlJugador; // Si es una máscara demonio viva

    [Header("Calidad del Diseño")]
    public bool esTrazoPerfecto; 
    public Sprite spriteSimbolo; 

}
