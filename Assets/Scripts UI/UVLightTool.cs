using UnityEngine;
using UnityEngine.UI;

public class RealisticUVTool : MonoBehaviour
{
    [Header("Referencias UI")]
    public RectTransform mobileMaskUI; // Tu objeto [Mascara] (el que se mueve)
    public RectTransform innerImage;   // NUEVO: Arrastra aquí tu [RawImage]
    public GameObject darkBackgroundPanel;

    [Header("Referencias Cámaras")]
    public Camera uvCamera;
    public Camera mainCamera;

    [Header("Ajustes")]
    public Vector3 offsetUI = Vector3.zero;

    private bool isActive = false;

    void Start()
    {
        if (mainCamera != null && uvCamera != null)
            uvCamera.orthographicSize = mainCamera.orthographicSize;

        ToggleTool(false);
    }

    void Update()
    {
        // YA NO HAY INPUTS AQUÍ. El Manager se encarga.

        if (isActive)
        {
            // Solo mantenemos la lógica de movimiento
            MoveTheFlashlight(); // o MoveMagnifyingGlass();

            // (Opcional) Puedes dejar el clic derecho aquí como seguridad, 
            // pero el Manager ya lo hace. Mejor bórralo también.
        }
    }

    void MoveTheFlashlight()
    {
        // 1. Mover la MÁSCARA con el mouse
        if (mobileMaskUI != null)
        {
            mobileMaskUI.position = Input.mousePosition + offsetUI;
        }

        // 2. MANTENER LA IMAGEN QUIETA (El truco realista)
        // Forzamos a la imagen interna a quedarse en el centro de la pantalla
        if (innerImage != null)
        {
            innerImage.position = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        }
    }

    public void ToggleTool(bool status)
    {
        isActive = status;

        if (mobileMaskUI != null) mobileMaskUI.gameObject.SetActive(status);
        if (uvCamera != null) uvCamera.gameObject.SetActive(status);
        if (darkBackgroundPanel != null) darkBackgroundPanel.SetActive(status);

        Cursor.visible = !status;
    }

    public void SwitchState()
    {
        ToggleTool(!isActive);
    }
}