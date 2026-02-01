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
        npcController.SetupNPC();   // ?? CLAVE
        npcController.ShowNormal();

        Debug.Log("?? Nuevo NPC cargado: " + next.name);
    }


    MaskedCharacterData GetRandomCharacter()
    {
        // 1. Elegir nivel según pesos de la noche
        MaskDifficultyLevel selectedLevel = GetRandomDifficultyLevel();

        // 2. Filtrar personajes disponibles de ese nivel
        List<MaskedCharacterData> filtered = availableCharacters.FindAll(
            c => c.difficultyLevel == selectedLevel
        );

        MaskedCharacterData selected;

        // 3. Elegir personaje
        if (filtered.Count > 0)
        {
            selected = filtered[Random.Range(0, filtered.Count)];
        }
        else
        {
            Debug.LogWarning($"?? No hay personajes de nivel {selectedLevel}, usando random total");
            selected = availableCharacters[Random.Range(0, availableCharacters.Count)];
        }

        // 4. ELIMINAR del pool para que no se repita
        availableCharacters.Remove(selected);

        Debug.Log($"? Eliminado del pool: {selected.name} | Restantes: {availableCharacters.Count}");

        return selected;
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

