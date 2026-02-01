using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class ModalWindow : MonoBehaviour
{
    [Header("Configuración General")]
    public bool startOpen = false;
    public float animationSpeed = 10f;
    public bool pauseGameOnOpen = false;

    [Header("Control de Input")]
    public KeyCode shortcutKey = KeyCode.Tab; // Por defecto TAB

    // Componentes internos
    private CanvasGroup canvasGroup;
    private Coroutine currentRoutine;
    private Vector3 originalScale;

    public bool IsOpen { get; private set; }

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        originalScale = transform.localScale;

        if (startOpen) OpenInstant();
        else CloseInstant();
    }

    private void Update()
    {
        // Como el objeto sigue activo (solo invisible), ahora SÍ escucha la tecla
        if (shortcutKey != KeyCode.None && Input.GetKeyDown(shortcutKey))
        {
            Toggle();
        }
    }

    public void Open()
    {
        if (IsOpen) return;
        if (currentRoutine != null) StopCoroutine(currentRoutine);

        // Nos aseguramos que esté activo antes de animar
        // (Por si acaso se desactivó externamente)
        gameObject.SetActive(true);

        currentRoutine = StartCoroutine(AnimateWindow(true));
        if (pauseGameOnOpen) Time.timeScale = 0f;
    }

    public void Close()
    {
        if (!IsOpen) return;
        if (currentRoutine != null) StopCoroutine(currentRoutine);
        currentRoutine = StartCoroutine(AnimateWindow(false));
        if (pauseGameOnOpen) Time.timeScale = 1f;
    }

    public void Toggle()
    {
        if (IsOpen) Close();
        else Open();
    }

    private IEnumerator AnimateWindow(bool show)
    {
        IsOpen = show;

        float targetAlpha = show ? 1f : 0f;
        float startAlpha = canvasGroup.alpha;

        Vector3 targetScale = show ? originalScale : originalScale * 0.9f;
        Vector3 startScale = transform.localScale;

        if (show && startAlpha == 0f) transform.localScale = originalScale * 0.9f;

        // Bloqueamos clicks solo si se va a mostrar
        canvasGroup.blocksRaycasts = show;
        canvasGroup.interactable = show;

        float t = 0f;
        while (t < 1f)
        {
            t += Time.unscaledDeltaTime * animationSpeed;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, t);
            transform.localScale = Vector3.Lerp(startScale, targetScale, t);
            yield return null;
        }

        canvasGroup.alpha = targetAlpha;
        transform.localScale = targetScale;

        // ---------------------------------------------------------
        // CAMBIO IMPORTANTE: YA NO HACEMOS gameObject.SetActive(false)
        // El objeto se queda encendido pero invisible (Alpha 0).
        // Así el Update() sigue escuchando la tecla TAB.
        // ---------------------------------------------------------
    }

    private void OpenInstant()
    {
        gameObject.SetActive(true);
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;
        transform.localScale = originalScale;
        IsOpen = true;
    }

    private void CloseInstant()
    {
        canvasGroup.alpha = 0f;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
        // gameObject.SetActive(false); <--- ESTO LO QUITAMOS
        IsOpen = false;
    }
}