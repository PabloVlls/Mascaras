using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvaluationManager : MonoBehaviour
{
    [Header("Strikes")]
    public int maxStrikes = 3;
    public int currentStrikes = 0;

    [Header("Debug")]
    public bool debugLogs = true;

    // Este método lo llama el botón de Aprobar o Denegar
    public void EvaluateDecision(bool approved, MaskedCharacterData characterData)
    {
        bool isHuman = characterData.race == CharacterRace.Human;
        bool isDemon = characterData.race == CharacterRace.Demon;

        bool mistake =
            (approved && isHuman) ||      // Dejaste pasar a un humano
            (!approved && isDemon);       // Rechazaste a un demonio

        if (mistake)
        {
            AddStrike(characterData);
        }
        else
        {
            CorrectDecision(characterData);
        }
    }

    void AddStrike(MaskedCharacterData characterData)
    {
        currentStrikes++;

        if (debugLogs)
        {
            Debug.Log("? ERROR. Strikes: " + currentStrikes + "/" + maxStrikes);
        }

        if (currentStrikes >= maxStrikes)
        {
            GameOver();
        }
    }

    void CorrectDecision(MaskedCharacterData characterData)
    {
        if (debugLogs)
        {
            Debug.Log("? Decisión correcta");
        }
    }

    void GameOver()
    {
        Debug.Log("?? GAME OVER: DESPEDIDO DEL INFIERNO");
        // Aquí luego conectan UI, animación, escena, etc.
    }
}

