using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brimstone;
using Quintessential;
using Texture = class_256;
using HalvingMetallurgy;
using UncommonPrimes;
using PM = PrimaMateria.PrimaMateriaAtoms;
using Vanilla = Brimstone.API.VanillaAtoms;
using TS = TrueSalt.TrueSalt;
using Noble = OMNobleElements.NobleElementsAtoms;
using System.Drawing.Imaging;
using PartRenderHelper = class_195;
using ReductiveMetallurgy;

namespace MiraculumEdere;

public static class Helpers
{

    public static bool PromoteAtom(AtomType startingAtom, int amount, out AtomType output)
    {
        output = null;
        bool isSecondOrder = false;
        int metallicity;
        if (!API.metaltodoubledmetallicity.TryGetValue(startingAtom, out metallicity))
        {
            if (!API.secondordertodoubledmetallicity.TryGetValue(startingAtom, out metallicity))
            {
                return false;
            }
            else
            {
                isSecondOrder = true;
            }
        }
        metallicity += amount;
        if (isSecondOrder)
        {
            if (!API.doubledmetalicitytosecondordermetal.TryGetValue(metallicity, out output))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            if (!API.doubledmetalicitytometal.TryGetValue(metallicity, out output))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
    public static void RunTransmuteAnimation(SolutionEditorBase SEB, AtomReference Atom)
    {
        Atom.field_2279.field_2276 = new class_168(SEB, 0, (enum_132)1, Atom.field_2280, class_238.field_1989.field_81.field_614, 30f);
    }

    public static void DisposeAnimation(HexIndex pos, Part part, SolutionEditorBase SEB)
    {
        Texture[] disposalFlashAnimation = class_238.field_1989.field_90.field_240;
        Vector2 animationPosition = ReductiveMetallurgy.MainClass.hexGraphicalOffset(part.method_1161() + pos.Rotated(part.method_1163())) + new Vector2(80f, 0f);
        SEB.field_3936.Add(new class_228(SEB, (enum_7)1, animationPosition, disposalFlashAnimation, 30f, Vector2.Zero, 0f));
    }

    public static AtomType[] RefractionGlyphBehaviour(string emptyIris, AtomType InA, AtomType InB)
    {
        AtomType output;
        if (InA == PM.Sulfur || InB == PM.Sulfur)
        {
            output = Noble.Alpha;
        } else if (InA == PM.Potash || InB == PM.Potash) {
            output = Noble.Beta;
        } else
        {
            output = Noble.Gamma;
        }
        if (emptyIris == "A")
        {
            return new AtomType[] {output, Vanilla.mors, Vanilla.mors };
        } else if (emptyIris == "B")
        {
            return new AtomType[] { Vanilla.mors, output, Vanilla.mors };
        } else
        {
            return new AtomType[] { Vanilla.mors, Vanilla.mors, output };
        }
    }

    public static void DrawHole(HexIndex pos, PartRenderHelper renderer)
    {
        renderer.method_528(Textures.Hole_Shadow, pos, Vector2.Zero);
        renderer.method_529(Textures.Input_Ring, pos, Vector2.Zero);
    }

}
