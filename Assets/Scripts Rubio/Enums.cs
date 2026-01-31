// ===== VERDAD DEL PERSONAJE =====
public enum CharacterRace
{
    Human,
    Demon
}
public enum EyeType
{
    Round,          // Humano
    Slit,           // Demonio
    Blind,          // Demonio
    WhiteOrRed,     // Humano
    SolidBlack,     // Demonio
    GlowingNeon     // Demonio
}
public enum TremorIdleType
{
    SlightVibration,    // Humano
    Static,             // Demonio
    SlowBreathing       // Demonio
}
public enum TremorInspectType
{
    IncreasedVibration, // Humano
    Irritated,          // Demonio
    Indifferent         // Demonio
}
public enum MaskMaterialVisual
{
    Plastic,        // Humano
    Cardboard,      // Humano
    Bone,           // Demonio
    MineralMetal    // Demonio
}
public enum MaskMaterialDetector
{
    Polymer,        // Humano
    Latex,          // Humano
    Calcium,        // Demonio
    Keratin,        // Demonio
    Magma,          // Demonio
    Obsidian        // Demonio
}
public enum MaskAttachment
{
    ElasticCord,        // Humano
    Zipper,             // Humano
    GluedTape,          // Humano
    FusedToSkin,        // Demonio
    SurgicalStitch      // Demonio
}
public enum MaskDesignPattern
{
    MessyPaint,         // Humano
    PerfectEngraving,   // Demonio
    HumanSymbols,       // Humano
    ArcaneRunes         // Demonio
}
public enum ClickSoundType
{
    Hollow,     // Humano
    Solid,      // Demonio
    Wet         // Demonio
}
public enum ClickReactionType
{
    Dent,           // Humano
    Immovable,      // Demonio
    BiteCursor      // Demonio
}
public enum HammerReactionType
{
    Deforms,        // Humano
    MetallicClang, // Demonio
    FleshSquish    // Demonio
}
public enum UVSymbolType
{
    None,           // Humano
    Cracks,         // Humano
    ArcaneRune,     // Demonio
    ClanSigil       // Demonio
}
public enum DialogueTruthType
{
    Correct,
    Incorrect,
    Suspicious
}
