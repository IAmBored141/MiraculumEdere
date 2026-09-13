using Brimstone;
using Quintessential;
using PartType = class_139;
using Permissions = enum_149;
using Texture = class_256;
using PartDataWrapper = class_236;
using PartRenderHelper = class_195;


namespace MiraculumEdere;

public class MiraculumEdere : QuintessentialMod
{
    private static readonly string logPrefix = "Theory: ";
   
    public override void Load()
    {
        Logger.Log(logPrefix + "Trying my best...");
    }

    public override void PostLoad()
    {

    }

    public override void LoadPuzzleContent() 
    {

        Logger.Log(logPrefix + "Adding atoms, maybe");
        MiraculumAtoms.AddAtomTypes();

        Logger.Log(logPrefix + "Attempting to integrate mods");

        Logger.Log(logPrefix + "Creating second-order half metals...");
        Integration.SecondOrderHalfMetals();
        Logger.Log(logPrefix + "Animismus related stuff...");
        Integration.ExtendedAnimismus();
        Logger.Log(logPrefix + "Quix...");
        Integration.Quixulurgy();
        Logger.Log(logPrefix + "More Cardinals....");
        Integration.ExtraCardinals();

        Logger.Log(logPrefix + "Trying to add glyphs...");
        MiraculumGlyphs.AddGlyphs();
        QApi.AddPuzzlePermission("Miraculum:Conjurgation", "Glyph of Conjurgation", "Miraculum Edere - Metallurgy");
        QApi.AddPuzzlePermission("Miraculum:Ascent", "Glyph of Ascent", "Miraculum Edere - Metallurgy");
        QApi.AddPuzzlePermission("Miraculum:Convolution", "Glyph of Convolution", "Miraculum Edere - Neuvolurgy");
        QApi.AddPuzzlePermission("Miraculum:Fragmentation", "Glyph of Fragmentation", "Miraculum Edere - Neuvolurgy");
        QApi.AddPuzzlePermission("Miraculum:Derivation", "Glyph of Derivation", "Miraculum Edere - Tria Primae");
        QApi.AddPuzzlePermission("Miraculum:Judgement", "Glyph of Judgement", "Miraculum Edere - Animismus");
        QApi.AddPuzzlePermission("Miraculum:Deconstruction", "Glyph of Deconstruction", "Miraculum Edere - Metallurgy");
        QApi.AddPuzzlePermission("Miraculum:Shattering", "Glyph of Shattering", "Miraculum Edere - Metallurgy");
        QApi.AddPuzzlePermission("Miraculum:Refraction", "Glyph of Refraction", "Miraculum Edere - Tria Primae");
        QApi.AddPuzzlePermission("Miraculum:Subjection", "Glyph of Subjection", "Miraculum Edere - Metallurgy");
        QApi.AddPuzzlePermission("Miraculum:Atwix", "Glyph of Atwix", "Miraculum Edere - Cardinality");
        QApi.AddPuzzlePermission("Miraculum:Zenithite", "Glyphs of Zenithite", "Miraculum Edere - Cardinality");
        QApi.AddPuzzlePermission("Miraculum:Reposition", "Glyph of Reposition", "Miraculum Edere - Cardinality");

        Logger.Log(logPrefix + "I- I'm done! Did it work?");
        
    }
    public override void Unload()
    {
        // Blank
    }
}