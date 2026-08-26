using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brimstone;
using Quintessential;
using Texture = class_256;
using HalvingMetallurgy;
using Vanilla = Brimstone.API.VanillaAtoms;
using HM = HalvingMetallurgy.Exports.AtomExports;
using UAP = UncommonPrimes.UncommonPrimesAtoms;
using Vacancy = Vaca.MainClass;
using FA = FalseAether.Atoms;
//using NV = Neuvolics.Atoms;
using TA = TrueAnimismus.ModdedAtoms;

namespace MiraculumEdere;

public static class Integration
{

    public static void SecondOrderHalfMetals()
    {
        API.AddSecondOrderToDictionary(Vacancy.VacaAtom, 0);
        API.AddSecondOrderToDictionary(UAP.Arsenic, 1);
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
        //lossful
        ReductiveMetallurgy.API.addDepositionRule(MiraculumAtoms.Indium, Vanilla.lead, HM.GetBeryl());
        ReductiveMetallurgy.API.addDepositionRule(MiraculumAtoms.Ferrum, HM.GetWolfram(), Vanilla.lead);
        ReductiveMetallurgy.API.addDepositionRule(MiraculumAtoms.Cerium, Vanilla.tin, HM.GetWolfram());
        ReductiveMetallurgy.API.addDepositionRule(MiraculumAtoms.Neodynium, HM.GetVulcan(), Vanilla.tin);
        ReductiveMetallurgy.API.addDepositionRule(MiraculumAtoms.Titanium, Vanilla.iron, HM.GetVulcan());

        //proliferation
        ReductiveMetallurgy.API.addProliferationRule(MiraculumAtoms.Aluminium);
        ReductiveMetallurgy.API.addProliferationRule(MiraculumAtoms.Indium);
        ReductiveMetallurgy.API.addProliferationRule(MiraculumAtoms.Ferrum);
        ReductiveMetallurgy.API.addProliferationRule(MiraculumAtoms.Cerium);
        ReductiveMetallurgy.API.addProliferationRule(MiraculumAtoms.Neodynium);
        ReductiveMetallurgy.API.addProliferationRule(MiraculumAtoms.Titanium);

        //halves
        HalvingMetallurgy.API.HalvesDictionary.Add(UAP.Arsenic, MiraculumAtoms.Aluminium);
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
        HalvingMetallurgy.API.OsmosisDictionary.Add(MiraculumAtoms.Aluminium, UAP.Arsenic);

        //shearing
        HalvingMetallurgy.API.ShearingDictionary.Add(MiraculumAtoms.Aluminium, new Pair<AtomType, AtomType>(UAP.Arsenic, UAP.Arsenic));
        HalvingMetallurgy.API.ShearingDictionary.Add(UAP.Zinc, new Pair<AtomType, AtomType>(MiraculumAtoms.Aluminium, UAP.Arsenic));
        HalvingMetallurgy.API.ShearingDictionary.Add(MiraculumAtoms.Indium, new Pair<AtomType, AtomType>(MiraculumAtoms.Aluminium, MiraculumAtoms.Aluminium));
        HalvingMetallurgy.API.ShearingDictionary.Add(UAP.Nickel, new Pair<AtomType, AtomType>(UAP.Zinc, MiraculumAtoms.Aluminium));
        HalvingMetallurgy.API.ShearingDictionary.Add(MiraculumAtoms.Ferrum, new Pair<AtomType, AtomType>(UAP.Zinc, UAP.Zinc));
        HalvingMetallurgy.API.ShearingDictionary.Add(UAP.Bismuth, new Pair<AtomType, AtomType>(MiraculumAtoms.Indium, UAP.Zinc));
        HalvingMetallurgy.API.ShearingDictionary.Add(MiraculumAtoms.Cerium, new Pair<AtomType, AtomType>(MiraculumAtoms.Indium, MiraculumAtoms.Indium));
        HalvingMetallurgy.API.ShearingDictionary.Add(UAP.Cobalt, new Pair<AtomType, AtomType>(UAP.Nickel, MiraculumAtoms.Indium));
        HalvingMetallurgy.API.ShearingDictionary.Add(MiraculumAtoms.Neodynium, new Pair<AtomType, AtomType>(UAP.Nickel, UAP.Nickel));
        HalvingMetallurgy.API.ShearingDictionary.Add(UAP.Platinum, new Pair<AtomType, AtomType>(MiraculumAtoms.Ferrum, UAP.Nickel));
        HalvingMetallurgy.API.ShearingDictionary.Add(MiraculumAtoms.Titanium, new Pair<AtomType, AtomType>(MiraculumAtoms.Ferrum, MiraculumAtoms.Ferrum));
    }
     public static void reductiveneuvolurgy()
    {
        //API.AddDerivationRecipe(Vanilla.salt,Vanilla.quicksilver,)
    }
    public static void ExtendedAnimismus() {
        API.AddAnimismus(Vanilla.mors, -1, 0, Vanilla.salt);
        API.AddAnimismus(FA.Inops, -1, 1, Vanilla.salt);
        API.AddAnimismus(FA.Illustra, 0, 1, Vanilla.salt);
        API.AddAnimismus(FA.Capax, 1, 1, Vanilla.salt);
        API.AddAnimismus(Vanilla.vitae, 1, 0, Vanilla.salt);
        API.AddAnimismus(FA.Phasmus, 1, -1, Vanilla.salt);
        API.AddAnimismus(FA.Turpis, 0, -1, Vanilla.salt);
        API.AddAnimismus(FA.Aegero, -1, -1, Vanilla.salt);
        API.AddAnimismus(TA.GreyMors, -2, 0, Vanilla.salt);
        API.AddAnimismus(TA.TrueMors, -3, 0, Vanilla.salt);
        API.AddAnimismus(TA.RedVitae, 2, 0, Vanilla.salt);
        API.AddAnimismus(TA.TrueVitae, 3, 0, Vanilla.salt);
        API.AddAnimismus(UAP.Muto, 1, 0, Vanilla.quicksilver);
        API.AddAnimismus(UAP.Fixus, -1, 0, Vanilla.quicksilver);
        API.AddAnimismus(UAP.PaleMuto, 2, 0, Vanilla.quicksilver);
        API.AddAnimismus(UAP.DarkFixus, -2, 0, Vanilla.quicksilver);
        API.AddAnimismus(UAP.TrueMuto, 3, 0, Vanilla.quicksilver);
        API.AddAnimismus(UAP.TrueFixus, -3, 0, Vanilla.quicksilver);
        API.AddAnimismus(Vanilla.salt, 0, 0, Vanilla.salt);
        API.AddAnimismus(Vanilla.quicksilver, 0, 0, Vanilla.quicksilver);
    }
}
