using UnityEngine;
using UnityEngine.UI; // Necesario para controlar imagenes

public class ToolsUI : MonoBehaviour
{
    [Header("Referencias")]
    [Tooltip("Arrastra aquí las imagenes de la UI en orden: Lupa, UV, Martillo...")]
    public Image[] toolIcons;

    [Header("Configuración Visual")]
    public Color colorActivo = Color.white; // Blanco brillante (100% opacidad)
    public Color colorInactivo = new Color(0.5f, 0.5f, 0.5f, 0.7f); // Grisáceo y transparente
    public float escalaActiva = 1.2f; // El icono crece un 20% al seleccionarlo

    // Esta función la llamaremos desde tu ToolsManager
    public void UpdateSelection(int activeToolIndex)
    {
        for (int i = 0; i < toolIcons.Length; i++)
        {
            if (toolIcons[i] == null) continue;

            if (i == activeToolIndex)
            {
                // ESTILO SELECCIONADO: Brillante y Grande
                toolIcons[i].color = colorActivo;
                toolIcons[i].rectTransform.localScale = Vector3.one * escalaActiva;
            }
            else
            {
                // ESTILO INACTIVO: Oscuro y Normal
                toolIcons[i].color = colorInactivo;
                toolIcons[i].rectTransform.localScale = Vector3.one;
            }
        }
    }
}
