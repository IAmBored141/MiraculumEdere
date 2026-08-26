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

namespace MiraculumEdere;

public static class API
{
    public static readonly Dictionary<AtomType, int> secondordertodoubledmetallicity = new();
    public static readonly Dictionary<int, AtomType> doubledmetalicitytosecondordermetal = new();
    public static void AddSecondOrderToDictionary(AtomType metal, int doubledmetallicity)
    {
        secondordertodoubledmetallicity.Add(metal, doubledmetallicity);
        doubledmetalicitytosecondordermetal.Add(doubledmetallicity, metal);
    }

    public static readonly Dictionary<Pair<AtomType, AtomType>, AtomType> derivationRecipe = new();
    public static void AddDerivationRecipe(AtomType input1, AtomType input2, AtomType output)
    {
        if (input1 == Brimstone.API.VanillaAtoms.salt)
        {
            derivationRecipe.Add(new Pair<AtomType, AtomType>(input1, input2), output);
        }
        else if (input2 == Brimstone.API.VanillaAtoms.salt)
        {
            derivationRecipe.Add(new Pair<AtomType, AtomType>(input2, input1), output);
        }
        else if (input1 == Brimstone.API.VanillaAtoms.quicksilver)
        {
            derivationRecipe.Add(new Pair<AtomType, AtomType>(input1, input2), output);
        }
        else if (input2 == Brimstone.API.VanillaAtoms.quicksilver)
        {
            derivationRecipe.Add(new Pair<AtomType, AtomType>(input2, input1), output);
        }
        else if (input1 == PM.Sulfur && input2 == PM.Sulfur)
        { //neither are salt or quicksilver, so both sulfur is the only remaining valid option
            derivationRecipe.Add(new Pair<AtomType, AtomType>(input1, input2), output);
        }
        else
        {
            Logger.Log("Derivation recipe invalid.");
        }
    }
    public static AtomType ReadDeviationRecipe(AtomType input1, AtomType input2)
    {
        AtomType output = MiraculumAtoms.Ignotum; //the default is the unknown atom
        AtomType Ainput = null;
        AtomType Binput = null;
        if (input1 == Brimstone.API.VanillaAtoms.salt)
        {
            Ainput = input1;
            Binput = input2;
        }
        else if (input2 == Brimstone.API.VanillaAtoms.salt)
        {
            Ainput = input2;
            Binput = input1;
        }
        else if (input1 == Brimstone.API.VanillaAtoms.quicksilver)
        {
            Ainput = input1;
            Binput = input2;
        }
        else if (input2 == Brimstone.API.VanillaAtoms.quicksilver)
        {
            Ainput = input1;
            Binput = input2;
        }
        else if (input1 == PM.Sulfur && input2 == PM.Sulfur)
        { //neither are salt or quicksilver, so both sulfur is the only remaining valid option
            Ainput = input1;
            Binput = input2;
        }
        else
        {
            Logger.Log("This should've been blocked before you got here.");
            Ainput = input1;
            Binput = input2;
        }
        if (!derivationRecipe.TryGetValue(new Pair<AtomType, AtomType>(Ainput, Binput), out output))
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
        int[] animCharge = new int[] { mortality, morality};
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
        } else
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
}
