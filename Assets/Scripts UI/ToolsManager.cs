using UnityEngine;

public class ToolsManager : MonoBehaviour
{
    [Header("Mis Herramientas")]
    public MagnifyingGlass toolLupa;      // Arrastra [TOOL_LUPA]
    public RealisticUVTool toolUV;        // Arrastra [TOOL_CONTROLLER_UV]
    public FlashlightTool toolLinterna;   // Arrastra [TOOL_LINTERNA]
    public HammerTool toolMartillo;
    public ScannerTool toolEscaner;

    // Estado actual
    private int currentToolID = 0; // 0=Nada, 1=Lupa, 2=UV, 3=Linterna

    void Update()
    {
        // Tecla 1: LUPA
        if (Input.GetKeyDown(KeyCode.Alpha1)) ToggleSpecificTool(1);
        
        // Tecla 2: UV
        if (Input.GetKeyDown(KeyCode.Alpha2)) ToggleSpecificTool(2);

        // Tecla 3: LINTERNA
        if (Input.GetKeyDown(KeyCode.Alpha3)) ToggleSpecificTool(3);

        if (Input.GetKeyDown(KeyCode.Alpha4)) ToggleSpecificTool(4);

        if (Input.GetKeyDown(KeyCode.Alpha5)) ToggleSpecificTool(5);

        // Clic Derecho: APAGAR TODO
        if (Input.GetMouseButtonDown(1)) DeactivateAll();
    }

    void ToggleSpecificTool(int id)
    {
        // Si presiono la misma tecla de la herramienta activa, la apago.
        if (currentToolID == id)
        {
            DeactivateAll();
            return;
        }

        // 1. Primero apagamos TODO
        DeactivateAll();

        // 2. Luego encendemos solo la elegida
        switch (id)
        {
            case 1: // Lupa
                if (toolLupa != null) toolLupa.ToggleTool(true);
                break;
            case 2: // UV
                if (toolUV != null) toolUV.ToggleTool(true);
                break;
            case 3: // Linterna
                if (toolLinterna != null) toolLinterna.ToggleTool(true);
                break;

            case 4: // Martillo
                if (toolMartillo != null) toolMartillo.ToggleTool(true);
                break;

            case 5: if (toolEscaner != null) toolEscaner.ToggleTool(true); break;
        }

        // 3. Actualizamos el ID
        currentToolID = id;
    }

    void DeactivateAll()
    {
        if (toolLupa != null) toolLupa.ToggleTool(false);
        if (toolUV != null) toolUV.ToggleTool(false);
        if (toolLinterna != null) toolLinterna.ToggleTool(false);
        if (toolMartillo != null) toolMartillo.ToggleTool(false);
        if (toolEscaner != null) toolEscaner.ToggleTool(false);

        currentToolID = 0;

        // Aseguramos que el cursor vuelva si todo est� apagado
        Cursor.visible = true;
    }
}