using UnityEngine;

public class MouseParallax : MonoBehaviour
{
    [Header("Configuración")]
    [Tooltip("Cuánto se mueve esta capa. 0 = Quieto, 50 = Mucho movimiento")]
    public float parallaxFactor = 10f;

    [Tooltip("Suavizado del movimiento (Más alto = más rápido)")]
    public float smoothing = 2f;

    private Vector3 startPosition;

    void Start()
    {
        // Guardamos la posición original para saber dónde volver
        startPosition = transform.position;
    }

    void Update()
    {
        // 1. Calcular la posición del mouse relativa al centro de la pantalla (-0.5 a 0.5)
        float mouseX = (Input.mousePosition.x / Screen.width) - 0.5f;
        float mouseY = (Input.mousePosition.y / Screen.height) - 0.5f;

        // 2. Calcular la nueva posición objetivo
        // Multiplicamos por -1 para que el fondo se mueva al lado contrario (Efecto profundidad)
        // Si quieres que siga al mouse, quita el signo menos.
        Vector3 targetPos = new Vector3(
            startPosition.x + (mouseX * -parallaxFactor),
            startPosition.y + (mouseY * -parallaxFactor),
            startPosition.z
        );

        // 3. Mover suavemente hacia el objetivo (Lerp)
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * smoothing);
    }
}
