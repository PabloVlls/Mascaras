using UnityEngine;

public class Scannable : MonoBehaviour
{
    [Header("Datos del Escáner")]
    [TextArea]
    public string composicion = "DESCONOCIDO"; // El texto que saldrá en la pantalla

    public bool esSospechoso = false; // Si es true, el texto saldrá en ROJO
}