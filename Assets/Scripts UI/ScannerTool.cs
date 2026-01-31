using UnityEngine;
using UnityEngine.UI; // Necesario para controlar el Texto

public class ScannerTool : MonoBehaviour
{
    [Header("Referencias Visuales")]
    public RectTransform scannerUI; // El aparato entero
    public Text screenText;         // El componente Texto dentro de la pantallita
    public GameObject darkPanel;    // Fondo negro (Opcional, estilo 'Focus')

    [Header("Ajustes")]
    public Vector3 offsetUI = new Vector3(30, -30, 0);
    public string textoBuscando = "ESCANEANDO...";

    [Header("Colores")]
    public Color colorNormal = Color.green;
    public Color colorSospechoso = Color.red;

    private bool isActive = false;

    void Start()
    {
        ToggleTool(false);
    }

    void Update()
    {
        // El Input lo maneja el ToolsManager (Tecla 5)

        if (isActive)
        {
            MoveScanner();
            ScanSurface();
        }
    }

    void MoveScanner()
    {
        if (scannerUI != null)
        {
            scannerUI.position = Input.mousePosition + offsetUI;
        }
    }

    void ScanSurface()
    {
        // Lanzamos rayo donde esté el mouse
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        if (hit.collider != null)
        {
            // Buscamos si tiene la etiqueta "Scannable"
            Scannable data = hit.collider.GetComponent<Scannable>();

            if (data != null)
            {
                // ¡Encontramos datos!
                screenText.text = data.composicion;

                // Cambiamos color si es sospechoso (ej. Látex = Rojo)
                screenText.color = data.esSospechoso ? colorSospechoso : colorNormal;
            }
            else
            {
                // Es un objeto físico pero sin datos (ej. la ropa normal)
                screenText.text = "SIN DATOS";
                screenText.color = colorNormal;
            }
        }
        else
        {
            // No estamos apuntando a nada (Aire)
            screenText.text = textoBuscando;
            screenText.color = colorNormal;
        }
    }

    public void ToggleTool(bool status)
    {
        isActive = status;
        if (scannerUI != null) scannerUI.gameObject.SetActive(status);
        if (darkPanel != null) darkPanel.SetActive(status); // Opcional
        Cursor.visible = !status;
    }
}