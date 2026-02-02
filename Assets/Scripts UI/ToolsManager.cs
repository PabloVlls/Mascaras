using System;
using UnityEngine;

public class ToolsManager : MonoBehaviour
{
    [Header("Mis Herramientas")]
    public MagnifyingGlass toolLupa;
    public RealisticUVTool toolUV;
    public FlashlightTool toolLinterna;
    public HammerTool toolMartillo;
    public ScannerTool toolEscaner;

    // Estado actual
    private int currentToolID = 0; // 0=Nada, 1=Lupa, 2=UV, 3=Linterna...

    public ToolsUI toolsUI;

    // --- CORRECCIÓN 1: INICIALIZACIÓN ---
    void Start()
    {
        // Al empezar, nos aseguramos de que todo esté apagado visual y lógicamente
        DeactivateAll();
    }

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

        // --- CORRECCIÓN 2: AJUSTE DE ÍNDICE ---
        if (toolsUI != null)
        {
            // Restamos 1 porque tus IDs son 1-5 pero el Array es 0-4
            // ID 1 (Lupa) - 1 = Índice 0
            toolsUI.UpdateSelection(id - 1);
        }

        // 1. Primero apagamos las herramientas (pero no la UI todavía)
        DeactivateLogicOnly();

        // 2. Luego encendemos solo la elegida
        switch (id)
        {
            case 1: if (toolLupa != null) toolLupa.ToggleTool(true); break;
            case 2: if (toolUV != null) toolUV.ToggleTool(true); break;
            case 3: if (toolLinterna != null) toolLinterna.ToggleTool(true); break;
            case 4: if (toolMartillo != null) toolMartillo.ToggleTool(true); break;
            case 5: if (toolEscaner != null) toolEscaner.ToggleTool(true); break;
        }

        // 3. Actualizamos el ID
        currentToolID = id;
    }

    // He separado la lógica para no crear bucles infinitos
    void DeactivateLogicOnly()
    {
        if (toolLupa != null) toolLupa.ToggleTool(false);
        if (toolUV != null) toolUV.ToggleTool(false);
        if (toolLinterna != null) toolLinterna.ToggleTool(false);
        if (toolMartillo != null) toolMartillo.ToggleTool(false);
        if (toolEscaner != null) toolEscaner.ToggleTool(false);

        Cursor.visible = true;
    }

    void DeactivateAll()
    {
        DeactivateLogicOnly(); // Apaga los scripts de las herramientas

        currentToolID = 0;

        // --- CORRECCIÓN 3: APAGAR LA UI ---
        // Mandamos -1 para decirle a la UI "No hay nada seleccionado"
        if (toolsUI != null)
        {
            toolsUI.UpdateSelection(-1);
        }
    }
}