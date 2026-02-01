using UnityEngine;
using UnityEngine.UI;

public class MagnifyingGlass : MonoBehaviour
{
    [Header("Referencias")]
    public Camera lensCamera;
    public RectTransform toolUI;
    public Camera mainUI_Camera;

    // --- NUEVA VARIABLE ---
    public GameObject backgroundPanel; // Aqu� meteremos el [FONDO_NEGRO_LUPA]

    [Header("Configuraci�n de Zoom")]
    public float currentZoom = 2f;
    public float minZoom = 0.5f;
    public float maxZoom = 3f;
    public float scrollSensitivity = 2f;

    [Header("Ajustes Visuales")]
    public Vector3 offsetUI = new Vector3(50, -50, 0);

    private bool isActive = false;

    void Start()
    {
        lensCamera.orthographicSize = currentZoom;
        ToggleTool(false); // Esto apagar� todo al inicio
    }

    void Update()
    {
        // YA NO HAY INPUTS AQU�. El Manager se encarga.

        if (isActive)
        {
            // Solo mantenemos la l�gica de movimiento
            MoveMagnifyingGlass();
            HandleZoom();
            // (Opcional) Puedes dejar el clic derecho aqu� como seguridad, 
            // pero el Manager ya lo hace. Mejor b�rralo tambi�n.
            CheckMaterialUnderLupa(); // Función para ver los defectos.
        }
    }

    void MoveMagnifyingGlass()
    {
        Vector2 mousePos = Input.mousePosition;
        toolUI.position = mousePos + (Vector2)offsetUI;

        Vector3 worldPos = mainUI_Camera.ScreenToWorldPoint(mousePos);
        worldPos.z = lensCamera.transform.position.z;
        lensCamera.transform.position = worldPos;
    }

    void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0f)
        {
            currentZoom -= scroll * scrollSensitivity;
            currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
            lensCamera.orthographicSize = currentZoom;
        }
    }

    void CheckMaterialUnderLupa()
    {
        //Lanzamos un Raycast desde la posición de la lupa
        RaycastHit2D hit = Physics2D.Raycast(lensCamera.transform.position, Vector2.zero);

        if(hit.collider != null)
        {
            NPCController npc = hit.collider.GetComponent<NPCController>();
            if(npc != null)
            {
                string materialInfo = npc.characterData.materialVisual.ToString();
            }    
        }
    }

    // --- AQU� EST� LA MAGIA ---
    public void ToggleTool(bool status)
    {
        isActive = status;

        // 1. Encendemos/Apagamos la Lupa
        toolUI.gameObject.SetActive(status);
        lensCamera.gameObject.SetActive(status);

        // 2. Encendemos/Apagamos el FONDO NEGRO
        if (backgroundPanel != null)
        {
            backgroundPanel.SetActive(status);
        }

        Cursor.visible = !status;

        if (status) lensCamera.orthographicSize = currentZoom;
    }

    public void SwitchState()
    {
        ToggleTool(!isActive);
    }
}