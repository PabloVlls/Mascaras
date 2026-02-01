using UnityEngine;
using UnityEngine.UI;

public class RealisticUVTool : MonoBehaviour
{
    [Header("Referencias UI")]
    public RectTransform mobileMaskUI; // Tu objeto [Mascara] (el que se mueve)
    public RectTransform innerImage;   // NUEVO: Arrastra aqu� tu [RawImage]
    public GameObject darkBackgroundPanel;

    [Header("Referencias C�maras")]
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
        // YA NO HAY INPUTS AQU�. El Manager se encarga.

        if (isActive)
        {
            // Solo mantenemos la l�gica de movimiento
            MoveTheFlashlight(); // o MoveMagnifyingGlass();

            // (Opcional) Puedes dejar el clic derecho aqu� como seguridad, 
            // pero el Manager ya lo hace. Mejor b�rralo tambi�n.
        }
    }

    void MoveTheFlashlight()
    {
        Vector3 mousePos = Input.mousePosition;

        // 1. Mover la M�SCARA con el mouse
        if (mobileMaskUI != null)
        {
            mobileMaskUI.position = Input.mousePosition + offsetUI;
        }

        // 2. LA cámara UV debe seguir al mouse en el mundo para que vea lo que hay debajo del filtro
        if(uvCamera != null)
        {
            Vector3 worldPos = mainCamera.ScreenToWorldPoint(mousePos);
            worldPos.z = uvCamera.transform.position.z;
            uvCamera.transform.position = worldPos;
        }


        // 3. MANTENER LA IMAGEN QUIETA (El truco realista)
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