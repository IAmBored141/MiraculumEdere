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

namespace MiraculumEdere;

public static class API
{
    public static readonly Dictionary<AtomType, int> secondordertodoubledmetallicity = new();
    public static readonly Dictionary<int, AtomType> doubledmetalicitytosecondordermetal = new();
    public static readonly Dictionary<AtomType, int> metaltodoubledmetallicity = new();
    public static readonly Dictionary<int, AtomType> doubledmetalicitytometal = new();
    public static readonly List<AtomType> negativeMetals = new();
    public static readonly List<AtomType> CalicifyToCaclity = new();

    public static readonly Dictionary<string, AtomType> dupeRecipe = new();
    public static void AddDupeRecipe(AtomType target, AtomType source, AtomType output)
    {
        dupeRecipe.Add(target.field_2284 + source.field_2284, output);
    } // dont add the converse

    public static bool ReadDupeRecipe(AtomType target, AtomType source, out AtomType output)
    {
        if (!dupeRecipe.TryGetValue(target.field_2284 + source.field_2284, out output))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public static void AddSecondOrderToDictionary(AtomType metal, int doubledmetallicity)
    {
        secondordertodoubledmetallicity.Add(metal, doubledmetallicity);
        doubledmetalicitytosecondordermetal.Add(doubledmetallicity, metal);
    }

    public static void AddMetalToDictionary(AtomType metal, int doubledmetallicity)
    {
        metaltodoubledmetallicity.Add(metal, doubledmetallicity);
        doubledmetalicitytometal.Add(doubledmetallicity, metal);
        if (doubledmetallicity < 0)
        {
            negativeMetals.Add(metal);
        }
    }

    public static readonly Dictionary<string, AtomType> derivationRecipe = new();

    public static readonly Dictionary<AtomType, string> thisUselessThing = new();


    public static void AddDerivationRecipe(AtomType input1, AtomType input2, AtomType output)
    {
        thisUselessThing.TryGetValue(input1, out string A);
        thisUselessThing.TryGetValue(input2, out string B);
        derivationRecipe.Add(A + B, output);
        if (!(A == B))
        {
            derivationRecipe.Add(B + A, output);
        }
    }
    public static AtomType ReadDeviationRecipe(AtomType input1, AtomType input2)
    {
        AtomType output = MiraculumAtoms.Ignotum; //the default is the unknown atom
        if (!thisUselessThing.TryGetValue(input1, out string A))
        {
            Logger.Log("This should've been blocked.");
            return output;
        }
        if (!thisUselessThing.TryGetValue(input2, out string B))
        {
            Logger.Log("This should've been blocked.");
            return output;
        }
        if (!derivationRecipe.TryGetValue(A + B, out output))
        {
            return MiraculumAtoms.Ignotum;
        }
        else
        {
            return output;
        }
    }
    public static readonly Dictionary<AtomType, int[]> atomToCharge = new();
    public static Dictionary<string, AtomType> chargeToAtom = new();
    public static Dictionary<string, AtomType> chargeToAtomQuix = new();
    public static Dictionary<AtomType, AtomType> AnimRootAtom = new();
    public static readonly Dictionary<AtomType, int> Quixinary = new();
    public static int[] RotateCharge(int[] startingCharge)
    {
        int outMorality = 0; //right
        int outMortality = 0; //left
        if (startingCharge[0] != 0)
        {
            outMorality = -startingCharge[0];
        }
        if (startingCharge[1] != 0)
        {
            outMortality = startingCharge[1];
        }
        int[] output = new int[] { outMortality, outMorality };
        return output;

    }
    public static int[] AddCharge(int[] chargeA, int[] chargeB)
    {
        int[] output = new int[] { chargeA[0] + chargeB[0], chargeA[1] + chargeB[1] };
        return output;
    }
    public static void AddAnimismus(AtomType Atom, int mortality, int morality, AtomType RootAtom)
    {
        int[] animCharge = new int[] { mortality, morality };
        atomToCharge.Add(Atom, animCharge);
        string chargeString = ConvertIntListToStringBecauseTheIntListDoesntWorkForSomeStupidReason(animCharge);
        AnimRootAtom.Add(Atom, RootAtom);
        if (RootAtom == Vanilla.salt)
        {
            chargeToAtom.Add(chargeString, Atom);
        }
        else
        {
            chargeToAtomQuix.Add(chargeString, Atom);
        }
    }
    public static string ConvertIntListToStringBecauseTheIntListDoesntWorkForSomeStupidReason(int[] charge)
    {
        string output = "";
        if (charge[0] > 0)
        {
            output += "V";
        }
        else if (charge[0] < 0)
        {
            output += "M";
        }
        else
        {
            output += "X";
        }
        output += Math.Abs(charge[0]).ToString();
        if (charge[1] == 1)
        {
            output += "V";
        }
        else if (charge[1] == -1)
        {
            output += "M";
        }
        else
        {
            output += "X";
        }
        output += Math.Abs(charge[1]).ToString();
        return output;
    }


    // helper functions
}
