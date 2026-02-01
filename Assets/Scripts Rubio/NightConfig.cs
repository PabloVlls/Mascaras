using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NightConfig", menuName = "Game/Night Config")]
public class NightConfig : ScriptableObject
{
    [Header("Night Info")]
    public int nightNumber;

    [Header("Goal")]
    [Tooltip("Cantidad de NPC que deben ENTRAR para completar la noche")]
    public int entriesGoal = 3;

    [Header("Evaluation")]
    public int maxStrikes = 3;

    [Header("Time")]
    public float nightDuration = 180f;

    [Header("Difficulty Weights")]
    public List<DifficultyWeight> difficultyWeights;
}

[System.Serializable]
public class DifficultyWeight
{
    public MaskDifficultyLevel difficulty;
    public int weight;
}
