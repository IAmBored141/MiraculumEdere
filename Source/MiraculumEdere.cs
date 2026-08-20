using Brimstone;
using Quintessential;
using PartType = class_139;
using Permissions = enum_149;
using Texture = class_256;


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
        Logger.Log(logPrefix + "Trying to add glyphs...");
        MiraculumGlyphs.AddPartTypes();
        QApi.AddPuzzlePermission("Miraculum:Reordering", "Glyph of Reordering", "Miraculum Edere");
        Logger.Log(logPrefix + "Attempting to integrate mods");
        Logger.Log(logPrefix + "Creating second-order half metals...");
        Integration.SecondOrderHalfMetals();
        Logger.Log(logPrefix + "I- I'm done! Did it work?");
        
    }
    public override void Unload()
    {
        // Blank
    }
}