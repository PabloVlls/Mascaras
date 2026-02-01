using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Disco Inferno/Masked Character")]
public class MaskedCharacterData : ScriptableObject
{
    [Header("Truth (Hidden from Player)")]
    public CharacterRace race;

    [Header("Difficulty")]
    public MaskDifficultyLevel difficultyLevel;

    [Header("Flashlight")]
    public Sprite flashlightSprite;

    [Header("Visuals")]
    public Sprite normalSprite;
    public Sprite uvSprite;
    public Sprite materialSprite;

    [Header("Physical Traits")]
    public EyeType eyeType;
    public TremorIdleType tremorIdle;
    public TremorInspectType tremorInspect;

    [Header("Mask")]
    public MaskMaterialVisual materialVisual;
    public MaskMaterialDetector detectorResult;
    public MaskAttachment attachmentType;
    public MaskDesignPattern designPattern;

    [Header("Interaction")]
    public ClickSoundType clickSound;
    public ClickReactionType clickReaction;
    public HammerReactionType hammerReaction;

    [Header("UV")]
    public UVSymbolType uvSymbol;

    [Header("Dialogue")]
    [TextArea(2, 3)]
    public string clanAnswer;

    [TextArea(2, 3)]
    public string smellAnswer;

    [TextArea(2, 3)]
    public string drinkAnswer;
}

