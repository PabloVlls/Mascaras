using UnityEngine;
using UnityEngine.UI;

public class EyeReaction : MonoBehaviour
{
    [Header("Sprites")]
    public Sprite normalPupil;
    public Sprite constrictedPupil; // Pupila pequeña (reacción a la luz)

    private Image eyeImage; // O SpriteRenderer si usas World Space
    private RectTransform rectTransform;

    void Start()
    {
        eyeImage = GetComponent<Image>(); // Cambia a GetComponent<SpriteRenderer>() si no es UI
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        // 1. ¿Está la linterna encendida?
        if (FlashlightTool.IsFlashlightActive)
        {
            // 2. ¿Está la luz cerca de estos ojos?
            // Calculamos distancia entre la luz (Mouse) y los ojos
            float distance = Vector3.Distance(FlashlightTool.LightPosition, transform.position);

            // Si está cerca (ej. menos de 100 pixels)
            if (distance < 100f)
            {
                eyeImage.sprite = constrictedPupil; // ¡Reacción!
            }
            else
            {
                eyeImage.sprite = normalPupil; // Vuelve a normal
            }
        }
        else
        {
            // Si la linterna está apagada, ojos normales
            if (eyeImage.sprite != normalPupil) eyeImage.sprite = normalPupil;
        }
    }
}
