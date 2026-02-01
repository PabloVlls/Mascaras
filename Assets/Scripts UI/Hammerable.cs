using UnityEngine;

public class Hammerable : MonoBehaviour
{
    //public enum MaterialType { Carne, MascaraDura, Metal, Vidrio }
    private NPCController npcController;

    /*[Header("Propiedades del Material")]
    public MaterialType tipoMaterial;
    public AudioClip sonidoGolpe; // Arrastra aqu� el sonido espec�fico (ej. "TocToc.wav")

    // Un peque�o efecto visual al golpear (Opcional: Part�culas)
    public ParticleSystem particulasGolpe;

    */

    void Start()
    {
        //Buscamos el controlador
        npcController = GetComponentInParent<NPCController>();
    }

    public void RecibirGolpe(out AudioClip sonidoAReproducir, out string tipoReaccion)
    {
        //Por defecto si algo sale mal
        sonidoAReproducir = null;
        tipoReaccion = "None";

        if (npcController != null && npcController.characterData != null)
        {
            sonidoAReproducir = npcController.GetHitSound();
            tipoReaccion = npcController.characterData.ToString();

            Debug.Log($"Impacto en {npcController.characterData.race}. Reacción: {tipoReaccion}");

            //Ejecutar animación de reacción del NPC
            npcController.PlayHammerAnimation();
        }
    }
}