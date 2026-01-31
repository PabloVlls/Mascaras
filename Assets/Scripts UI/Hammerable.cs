using UnityEngine;

public class Hammerable : MonoBehaviour
{
    public enum MaterialType { Carne, MascaraDura, Metal, Vidrio }

    [Header("Propiedades del Material")]
    public MaterialType tipoMaterial;
    public AudioClip sonidoGolpe; // Arrastra aquí el sonido específico (ej. "TocToc.wav")

    // Un pequeño efecto visual al golpear (Opcional: Partículas)
    public ParticleSystem particulasGolpe;

    public void RecibirGolpe()
    {
        // Aquí podrías añadir lógica extra, como que la máscara se rompa visualmente
        Debug.Log("¡Golpeaste " + tipoMaterial + "!");

        if (particulasGolpe != null) particulasGolpe.Play();
    }
}