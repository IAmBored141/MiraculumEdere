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
    private static string logPrefix = "Theory: ";
   
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


        Logger.Log(logPrefix + "Trying to add glyphs...");
        MiraculumGlyphs.AddGlyphs();
        QApi.AddPuzzlePermission("Miraculum:Conjurgation", "Glyph of Conjurgation", "Miraculum Edere");
        QApi.AddPuzzlePermission("Miraculum:Ascent", "Glyph of Ascent", "Miraculum Edere");
        QApi.AddPuzzlePermission("Miraculum:Convolution", "Glyph of Convolution", "Miraculum Edere");
        QApi.AddPuzzlePermission("Miraculum:Fragmentation", "Glyph of Fragmentation", "Miraculum Edere");
        QApi.AddPuzzlePermission("Miraculum:Derivation", "Glyph of Derivation", "Miraculum Edere");
        QApi.AddPuzzlePermission("Miraculum:Judgement", "Glyph of Judgement", "Miraculum Edere");

        Logger.Log(logPrefix + "I- I'm done! Did it work?");
        
    }
    public override void Unload()
    {
        // Blank
    }
}