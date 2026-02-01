using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueManager : MonoBehaviour
{
    [Header("Pools")]
    public List<MaskedCharacterData> allCharacters;

    [Header("References")]
    public NPCController npcController;
    public NightManager nightManager;

    List<MaskedCharacterData> availableCharacters = new List<MaskedCharacterData>();

    public void SetupNightPool()
    {
        availableCharacters = new List<MaskedCharacterData>(allCharacters);
    }

    public void NextNPC()
    {
        MaskedCharacterData next = GetRandomCharacter();
        npcController.characterData = next;
        npcController.ShowNormal();

        Debug.Log("?? Nuevo NPC en la entrada");
    }

    MaskedCharacterData GetRandomCharacter()
    {
        // 1. Elegir nivel según pesos de la noche
        MaskDifficultyLevel selectedLevel = GetRandomDifficultyLevel();

        // 2. Filtrar personajes de ese nivel
        List<MaskedCharacterData> filtered = availableCharacters.FindAll(
    c => c.difficultyLevel == selectedLevel
        );

        // Seguridad por si no hay personajes de ese nivel
        if (filtered.Count == 0)
        {
            Debug.LogWarning($"?? No hay personajes de nivel {selectedLevel}, usando random total");
            return availableCharacters[Random.Range(0, availableCharacters.Count)];

        }

        // 3. Elegir uno al azar de ese nivel
        return filtered[Random.Range(0, filtered.Count)];

    }

    MaskDifficultyLevel GetRandomDifficultyLevel()
    {
        List<DifficultyWeight> weights = nightManager.CurrentNight.difficultyWeights;

        int totalWeight = 0;
        foreach (var w in weights)
        {
            totalWeight += w.weight;
        }

        int randomValue = Random.Range(0, totalWeight);
        int currentSum = 0;

        foreach (var w in weights)
        {
            currentSum += w.weight;
            if (randomValue < currentSum)
            {
                return w.difficulty;
            }
        }

        // Fallback (no debería pasar)
        return weights[0].difficulty;
    }

}

