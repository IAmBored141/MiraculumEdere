using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brimstone;
using Quintessential;
using Texture = class_256;
using HalvingMetallurgy;
using UAP = UncommonPrimes.UncommonPrimesAtoms;

namespace MiraculumEdere;

public static class Integration
{
    public static int MetallicityOffset = 64; //this is held together with hopes and dreams

    public static void SecondOrderHalfMetals()
    {
        //to do: add vaca here
        //metalicity 1 left empty for whatever wheat wants to put there
        API.AddSecondOrderToDictionary(MiraculumAtoms.Aluminium, 2);
        API.AddSecondOrderToDictionary(UAP.Zinc, 3);
        API.AddSecondOrderToDictionary(MiraculumAtoms.Indium, 4);
        API.AddSecondOrderToDictionary(UAP.Nickel, 5);
        API.AddSecondOrderToDictionary(MiraculumAtoms.Ferrum, 6);
        API.AddSecondOrderToDictionary(UAP.Bismuth, 7);
        API.AddSecondOrderToDictionary(MiraculumAtoms.Cerium, 8);
        API.AddSecondOrderToDictionary(UAP.Cobalt, 9);
        API.AddSecondOrderToDictionary(MiraculumAtoms.Neodynium, 10);
        API.AddSecondOrderToDictionary(UAP.Platinum, 11);
        API.AddSecondOrderToDictionary(MiraculumAtoms.Titanium, 12);

        //rejection
        ReductiveMetallurgy.API.addRejectionRule(MiraculumAtoms.Indium, MiraculumAtoms.Aluminium);
        ReductiveMetallurgy.API.addRejectionRule(MiraculumAtoms.Ferrum, MiraculumAtoms.Indium);
        ReductiveMetallurgy.API.addRejectionRule(MiraculumAtoms.Cerium, MiraculumAtoms.Ferrum);
        ReductiveMetallurgy.API.addRejectionRule(MiraculumAtoms.Neodynium, MiraculumAtoms.Cerium);
        ReductiveMetallurgy.API.addRejectionRule(MiraculumAtoms.Titanium, MiraculumAtoms.Neodynium);    

        //division- i mean deposition
        ReductiveMetallurgy.API.addDepositionRule(MiraculumAtoms.Indium, UAP.Zinc, MiraculumAtoms.Aluminium);
        ReductiveMetallurgy.API.addDepositionRule(MiraculumAtoms.Ferrum, MiraculumAtoms.Indium, UAP.Zinc);
        ReductiveMetallurgy.API.addDepositionRule(MiraculumAtoms.Cerium, UAP.Nickel, MiraculumAtoms.Indium);
        ReductiveMetallurgy.API.addDepositionRule(MiraculumAtoms.Neodynium, MiraculumAtoms.Ferrum, UAP.Nickel);
        ReductiveMetallurgy.API.addDepositionRule(MiraculumAtoms.Titanium, UAP.Bismuth, MiraculumAtoms.Ferrum);

        //proliferation
        ReductiveMetallurgy.API.addProliferationRule(MiraculumAtoms.Aluminium);
        ReductiveMetallurgy.API.addProliferationRule(MiraculumAtoms.Indium);
        ReductiveMetallurgy.API.addProliferationRule(MiraculumAtoms.Ferrum);
        ReductiveMetallurgy.API.addProliferationRule(MiraculumAtoms.Cerium);
        ReductiveMetallurgy.API.addProliferationRule(MiraculumAtoms.Neodynium);
        ReductiveMetallurgy.API.addProliferationRule(MiraculumAtoms.Titanium);

        //halves
        HalvingMetallurgy.API.HalvesDictionary.Add(MiraculumAtoms.Aluminium, UAP.Zinc);
        HalvingMetallurgy.API.HalvesDictionary.Add(UAP.Zinc, MiraculumAtoms.Indium);
        HalvingMetallurgy.API.HalvesDictionary.Add(MiraculumAtoms.Indium, UAP.Nickel);
        HalvingMetallurgy.API.HalvesDictionary.Add(UAP.Nickel, MiraculumAtoms.Ferrum);
        HalvingMetallurgy.API.HalvesDictionary.Add(MiraculumAtoms.Ferrum, UAP.Bismuth);
        HalvingMetallurgy.API.HalvesDictionary.Add(UAP.Bismuth, MiraculumAtoms.Cerium);
        HalvingMetallurgy.API.HalvesDictionary.Add(MiraculumAtoms.Cerium, UAP.Cobalt);
        HalvingMetallurgy.API.HalvesDictionary.Add(UAP.Cobalt, MiraculumAtoms.Neodynium);
        HalvingMetallurgy.API.HalvesDictionary.Add(MiraculumAtoms.Neodynium, UAP.Platinum);
        HalvingMetallurgy.API.HalvesDictionary.Add(UAP.Platinum, MiraculumAtoms.Titanium);

        //osmosis
        HalvingMetallurgy.API.OsmosisDictionary.Add(MiraculumAtoms.Titanium, UAP.Platinum);
        HalvingMetallurgy.API.OsmosisDictionary.Add(UAP.Platinum, MiraculumAtoms.Neodynium);
        HalvingMetallurgy.API.OsmosisDictionary.Add(MiraculumAtoms.Neodynium, UAP.Cobalt);
        HalvingMetallurgy.API.OsmosisDictionary.Add(UAP.Cobalt, MiraculumAtoms.Cerium);
        HalvingMetallurgy.API.OsmosisDictionary.Add(MiraculumAtoms.Cerium, UAP.Bismuth);
        HalvingMetallurgy.API.OsmosisDictionary.Add(UAP.Bismuth, MiraculumAtoms.Ferrum);
        HalvingMetallurgy.API.OsmosisDictionary.Add(MiraculumAtoms.Ferrum, UAP.Nickel);
        HalvingMetallurgy.API.OsmosisDictionary.Add(UAP.Nickel, MiraculumAtoms.Indium);
        HalvingMetallurgy.API.OsmosisDictionary.Add(MiraculumAtoms.Indium, UAP.Zinc);
        HalvingMetallurgy.API.OsmosisDictionary.Add(UAP.Zinc, MiraculumAtoms.Aluminium);

        //shearing
        HalvingMetallurgy.API.ShearingDictionary.Add(UAP.Zinc, new Pair<AtomType, AtomType>(MiraculumAtoms.Aluminium, MiraculumAtoms.Aluminium));
        HalvingMetallurgy.API.ShearingDictionary.Add(MiraculumAtoms.Indium, new Pair<AtomType, AtomType>(UAP.Zinc, MiraculumAtoms.Aluminium));
        HalvingMetallurgy.API.ShearingDictionary.Add(UAP.Nickel, new Pair<AtomType, AtomType>(UAP.Zinc, UAP.Zinc));
        HalvingMetallurgy.API.ShearingDictionary.Add(MiraculumAtoms.Ferrum, new Pair<AtomType, AtomType>(MiraculumAtoms.Indium, UAP.Zinc));
        HalvingMetallurgy.API.ShearingDictionary.Add(UAP.Bismuth, new Pair<AtomType, AtomType>(MiraculumAtoms.Indium, MiraculumAtoms.Indium));
        HalvingMetallurgy.API.ShearingDictionary.Add(MiraculumAtoms.Cerium, new Pair<AtomType, AtomType>(UAP.Nickel, MiraculumAtoms.Indium));
        HalvingMetallurgy.API.ShearingDictionary.Add(UAP.Cobalt, new Pair<AtomType, AtomType>(UAP.Nickel, UAP.Nickel));
        HalvingMetallurgy.API.ShearingDictionary.Add(MiraculumAtoms.Neodynium, new Pair<AtomType, AtomType>(MiraculumAtoms.Cerium, UAP.Nickel));
        HalvingMetallurgy.API.ShearingDictionary.Add(UAP.Platinum, new Pair<AtomType, AtomType>(MiraculumAtoms.Cerium, MiraculumAtoms.Cerium));
        HalvingMetallurgy.API.ShearingDictionary.Add(MiraculumAtoms.Titanium, new Pair<AtomType, AtomType>(UAP.Bismuth, MiraculumAtoms.Cerium));
    }
}
