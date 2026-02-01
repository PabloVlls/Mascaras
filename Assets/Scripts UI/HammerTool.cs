using UnityEngine;

public class HammerTool : MonoBehaviour
{
    [Header("Referencias Visuales")]
    public RectTransform hammerUI; // La imagen del martillo en el Canvas
    public AudioSource audioSource; // El componente de audio (puede estar en el martillo)

    [Header("Sonidos por Defecto")]
    public AudioClip defaultHitSound; // Sonido gen�rico si el objeto no tiene uno espec�fico

    [Header("Ajustes")]
    public Vector3 offsetUI = new Vector3(20, -20, 0); // Ajustar para que el cursor quede en el mango
    public float golpeRotation = -45f; // Cu�ntos grados gira al golpear
    public float velocidadGolpe = 15f;

    private bool isActive = false;
    private Quaternion rotacionOriginal;
    private bool golpeando = false;

    void Start()
    {
        if (hammerUI != null) rotacionOriginal = hammerUI.rotation;
        ToggleTool(false);
    }

    void Update()
    {
        // Nota: El Input de activar (tecla 4) lo maneja el ToolsManager.

        if (isActive)
        {
            MoveHammer();

            // CLIC IZQUIERDO = GOLPEAR
            if (Input.GetMouseButtonDown(0) && !golpeando)
            {
                StartCoroutine(AnimacionGolpe());
                DetectarImpacto();
            }
        }
    }

    void MoveHammer()
    {
        if (hammerUI != null)
        {
            hammerUI.position = Input.mousePosition + offsetUI;
        }
    }

    void DetectarImpacto()
    {
        // Lanzamos un Rayo 2D justo donde est� el mouse
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        if (hit.collider != null)
        {
            // �El objeto golpeado tiene el script "Hammerable"?
            Hammerable superficie = hit.collider.GetComponent<Hammerable>();

            if (superficie != null)
            {   
                //Variables para recibir la info del NPC
                AudioClip clipNPC;
                string reaccion;

                //Llamamos al objeto golpeado y él nos devuelve sus datos
                superficie.RecibirGolpe(out clipNPC, out reaccion);

                //1 Sonido:Prioriza el del NPC, sino el default
                AudioClip sonidoFinal = (clipNPC != null) ? clipNPC : defaultHitSound;
                if(sonidoFinal != null) audioSource.PlayOneShot(sonidoFinal);

                //2. Feedback visual extra basado en la reacción del GDD
                if(reaccion == "Desplazamiento") {/*Efecto de mover máscara*/}
            }
            else
            {
                // Golpeaste algo que no es interactuable (Mesa, fondo)
                if (defaultHitSound != null) audioSource.PlayOneShot(defaultHitSound);
            }
        }
    }

    // Animaci�n simple: Rota hacia abajo y vuelve a subir
    System.Collections.IEnumerator AnimacionGolpe()
    {
        golpeando = true;

        // Fase 1: Bajar (Golpe)
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * velocidadGolpe;
            hammerUI.rotation = Quaternion.Lerp(rotacionOriginal, Quaternion.Euler(0, 0, golpeRotation), t);
            yield return null;
        }

        // Fase 2: Subir (Recuperaci�n)
        t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * (velocidadGolpe / 2); // Sube un poco m�s lento
            hammerUI.rotation = Quaternion.Lerp(Quaternion.Euler(0, 0, golpeRotation), rotacionOriginal, t);
            yield return null;
        }

        hammerUI.rotation = rotacionOriginal;
        golpeando = false;
    }

    public void ToggleTool(bool status)
    {
        isActive = status;
        if (hammerUI != null) hammerUI.gameObject.SetActive(status);
        Cursor.visible = !status;
    }
}
