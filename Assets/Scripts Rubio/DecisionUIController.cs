using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionUIController : MonoBehaviour
{
    [Header("References")]
    public EvaluationManager evaluationManager;
    public NPCController currentNPC;
    public InspectionForm inspectionForm;

    public void Approve()
    {
        evaluationManager.EvaluateDecision(true, currentNPC.characterData);
        inspectionForm.ResetForm();
        Debug.Log("?? APROBADO - siguiente NPC");
    }

    public void Deny()
    {
        evaluationManager.EvaluateDecision(false, currentNPC.characterData);
        inspectionForm.ResetForm();
        Debug.Log("?? DENEGADO - siguiente NPC");
    }
}

