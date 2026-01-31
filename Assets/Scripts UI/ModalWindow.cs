using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class ModalWindow : MonoBehaviour
{
    [Header("Configuración")]
    [Tooltip("¿Empieza abierto al iniciar la escena?")]
    public bool startOpen = false;

    [Tooltip("Velocidad de la animación (Más alto = más rápido)")]
    public float animationSpeed = 10f;

    [Tooltip("¿Pausar el juego cuando esta ventana está abierta? (Ideal para Menús)")]
    public bool pauseGameOnOpen = false;

    // Componentes internos
    private CanvasGroup canvasGroup;
    private Coroutine currentRoutine;
    private Vector3 originalScale;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        originalScale = transform.localScale;

        // Inicialización
        if (startOpen)
        {
            OpenInstant();
        }
        else
        {
            CloseInstant();
        }
    }

    // ------------------------------------------
    // MÉTODOS PÚBLICOS (Conecta esto a los Botones)
    // ------------------------------------------

    public void Open()
    {
        if (currentRoutine != null) StopCoroutine(currentRoutine);
        gameObject.SetActive(true);
        currentRoutine = StartCoroutine(AnimateWindow(true));

        if (pauseGameOnOpen) Time.timeScale = 0f; // Pausa el tiempo
    }

    public void Close()
    {
        if (currentRoutine != null) StopCoroutine(currentRoutine);
        currentRoutine = StartCoroutine(AnimateWindow(false));

        if (pauseGameOnOpen) Time.timeScale = 1f; // Reanuda el tiempo
    }

    public void Toggle()
    {
        // Si el alpha es mayor a 0, asumimos que está abierto -> Cerramos
        if (canvasGroup.alpha > 0.1f)
            Close();
        else
            Open();
    }

    // ------------------------------------------
    // LÓGICA INTERNA (Animaciones)
    // ------------------------------------------

    private IEnumerator AnimateWindow(bool show)
    {
        float targetAlpha = show ? 1f : 0f;
        float startAlpha = canvasGroup.alpha;

        // Efecto "Pop": Si abrimos, empezamos un poco más pequeños. Si cerramos, volvemos al original.
        Vector3 targetScale = show ? originalScale : originalScale * 0.9f;
        Vector3 startScale = transform.localScale;

        // Si abrimos, reseteamos la escala a un poco más pequeño para el efecto pop
        if (show && startAlpha == 0f) transform.localScale = originalScale * 0.9f;

        // Activamos bloqueo de raycast solo si está visible
        canvasGroup.blocksRaycasts = show;
        canvasGroup.interactable = show;

        float t = 0f;
        while (t < 1f)
        {
            // Usamos unscaledDeltaTime para que la animación funcione incluso si el juego está en Pausa
            t += Time.unscaledDeltaTime * animationSpeed;

            // Interpolación suave (Lerp)
            canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, t);
            transform.localScale = Vector3.Lerp(startScale, targetScale, t);

            yield return null;
        }

        // Asegurar valores finales
        canvasGroup.alpha = targetAlpha;
        transform.localScale = targetScale;

        // Si cerramos, desactivamos el objeto para ahorrar rendimiento
        if (!show)
        {
            gameObject.SetActive(false);
        }
    }

    // Métodos para forzar estado sin animación (útil para Reset)
    private void OpenInstant()
    {
        gameObject.SetActive(true);
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;
        transform.localScale = originalScale;
    }

    private void CloseInstant()
    {
        canvasGroup.alpha = 0f;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
        gameObject.SetActive(false);
    }
}
