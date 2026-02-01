using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionUIController : MonoBehaviour
{
    [Header("References")]
    public EvaluationManager evaluationManager;
    public NPCController currentNPC;
    public InspectionForm inspectionForm;
    public NightManager nightManager;
    public QueueManager queueManager;


    public void Approve()
    {
        evaluationManager.EvaluateDecision(true, currentNPC.characterData);
        inspectionForm.ResetForm();
        Debug.Log("?? APROBADO - siguiente NPC");

        nightManager.RegisterDecision(true, currentNPC.characterData);
        inspectionForm.ResetForm();
        queueManager.NextNPC();

    }

    public void Deny()
    {
        evaluationManager.EvaluateDecision(false, currentNPC.characterData);
        inspectionForm.ResetForm();
        Debug.Log("?? DENEGADO - siguiente NPC");

        nightManager.RegisterDecision(false, currentNPC.characterData);
        inspectionForm.ResetForm();
        queueManager.NextNPC();
    }
}

