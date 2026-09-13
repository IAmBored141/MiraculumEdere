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
using NV = Neuvolics.Atoms;
using TA = TrueAnimismus.ModdedAtoms;
using AlcInv = AlchemicalInversions.Atoms;
using TS = TrueSalt;
using NE = OMNobleElements.NobleElementsAtoms;
using ME = MiraculumEdere.MiraculumAtoms;
using CE = ComplicatedElements.ComplicatedElementsAtoms;
namespace MiraculumEdere;

public static class Integration
{

    public static void SecondOrderHalfMetals()
    {
        API.AddSecondOrderToDictionary(Vacancy.VacaAtom, 0);
        API.AddSecondOrderToDictionary(UAP.Arsenic, 1);
        API.AddSecondOrderToDictionary(ME.Aluminium, 2);
        API.AddSecondOrderToDictionary(UAP.Zinc, 3);
        API.AddSecondOrderToDictionary(ME.Indium, 4);
        API.AddSecondOrderToDictionary(UAP.Nickel, 5);
        API.AddSecondOrderToDictionary(ME.Ferrum, 6);
        API.AddSecondOrderToDictionary(UAP.Bismuth, 7);
        API.AddSecondOrderToDictionary(ME.Cerium, 8);
        API.AddSecondOrderToDictionary(UAP.Cobalt, 9);
        API.AddSecondOrderToDictionary(ME.Neodynium, 10);
        API.AddSecondOrderToDictionary(UAP.Platinum, 11);
        API.AddSecondOrderToDictionary(ME.Titanium, 12);
        //rejection
        ReductiveMetallurgy.API.addRejectionRule(ME.Indium, ME.Aluminium);
        ReductiveMetallurgy.API.addRejectionRule(ME.Ferrum, ME.Indium);
        ReductiveMetallurgy.API.addRejectionRule(ME.Cerium, ME.Ferrum);
        ReductiveMetallurgy.API.addRejectionRule(ME.Neodynium, ME.Cerium);
        ReductiveMetallurgy.API.addRejectionRule(ME.Titanium, ME.Neodynium);
        //division- i mean deposition
        //lossful
        ReductiveMetallurgy.API.addDepositionRule(ME.Indium, Vanilla.lead, HM.GetBeryl());
        ReductiveMetallurgy.API.addDepositionRule(ME.Ferrum, HM.GetWolfram(), Vanilla.lead);
        ReductiveMetallurgy.API.addDepositionRule(ME.Cerium, Vanilla.tin, HM.GetWolfram());
        ReductiveMetallurgy.API.addDepositionRule(ME.Neodynium, HM.GetVulcan(), Vanilla.tin);
        ReductiveMetallurgy.API.addDepositionRule(ME.Titanium, Vanilla.iron, HM.GetVulcan());
        //proliferation
        ReductiveMetallurgy.API.addProliferationRule(ME.Aluminium);
        ReductiveMetallurgy.API.addProliferationRule(ME.Indium);
        ReductiveMetallurgy.API.addProliferationRule(ME.Ferrum);
        ReductiveMetallurgy.API.addProliferationRule(ME.Cerium);
        ReductiveMetallurgy.API.addProliferationRule(ME.Neodynium);
        ReductiveMetallurgy.API.addProliferationRule(ME.Titanium);

        //halves
        HalvingMetallurgy.API.HalvesDictionary.Add(UAP.Arsenic, ME.Aluminium);
        HalvingMetallurgy.API.HalvesDictionary.Add(ME.Aluminium, UAP.Zinc);
        HalvingMetallurgy.API.HalvesDictionary.Add(UAP.Zinc, ME.Indium);
        HalvingMetallurgy.API.HalvesDictionary.Add(ME.Indium, UAP.Nickel);
        HalvingMetallurgy.API.HalvesDictionary.Add(UAP.Nickel, ME.Ferrum);
        HalvingMetallurgy.API.HalvesDictionary.Add(ME.Ferrum, UAP.Bismuth);
        HalvingMetallurgy.API.HalvesDictionary.Add(UAP.Bismuth, ME.Cerium);
        HalvingMetallurgy.API.HalvesDictionary.Add(ME.Cerium, UAP.Cobalt);
        HalvingMetallurgy.API.HalvesDictionary.Add(UAP.Cobalt, ME.Neodynium);
        HalvingMetallurgy.API.HalvesDictionary.Add(ME.Neodynium, UAP.Platinum);
        HalvingMetallurgy.API.HalvesDictionary.Add(UAP.Platinum, ME.Titanium);

        //osmosis
        HalvingMetallurgy.API.OsmosisDictionary.Add(ME.Titanium, UAP.Platinum);
        HalvingMetallurgy.API.OsmosisDictionary.Add(UAP.Platinum, ME.Neodynium);
        HalvingMetallurgy.API.OsmosisDictionary.Add(ME.Neodynium, UAP.Cobalt);
        HalvingMetallurgy.API.OsmosisDictionary.Add(UAP.Cobalt, ME.Cerium);
        HalvingMetallurgy.API.OsmosisDictionary.Add(ME.Cerium, UAP.Bismuth);
        HalvingMetallurgy.API.OsmosisDictionary.Add(UAP.Bismuth, ME.Ferrum);
        HalvingMetallurgy.API.OsmosisDictionary.Add(ME.Ferrum, UAP.Nickel);
        HalvingMetallurgy.API.OsmosisDictionary.Add(UAP.Nickel, ME.Indium);
        HalvingMetallurgy.API.OsmosisDictionary.Add(ME.Indium, UAP.Zinc);
        HalvingMetallurgy.API.OsmosisDictionary.Add(UAP.Zinc, ME.Aluminium);
        HalvingMetallurgy.API.OsmosisDictionary.Add(ME.Aluminium, UAP.Arsenic);
        //shearing
        HalvingMetallurgy.API.ShearingDictionary.Add(ME.Aluminium, new Pair<AtomType, AtomType>(UAP.Arsenic, UAP.Arsenic));
        HalvingMetallurgy.API.ShearingDictionary.Add(UAP.Zinc, new Pair<AtomType, AtomType>(ME.Aluminium, UAP.Arsenic));
        HalvingMetallurgy.API.ShearingDictionary.Add(ME.Indium, new Pair<AtomType, AtomType>(ME.Aluminium, ME.Aluminium));
        HalvingMetallurgy.API.ShearingDictionary.Add(UAP.Nickel, new Pair<AtomType, AtomType>(UAP.Zinc, ME.Aluminium));
        HalvingMetallurgy.API.ShearingDictionary.Add(ME.Ferrum, new Pair<AtomType, AtomType>(UAP.Zinc, UAP.Zinc));
        HalvingMetallurgy.API.ShearingDictionary.Add(UAP.Bismuth, new Pair<AtomType, AtomType>(ME.Indium, UAP.Zinc));
        HalvingMetallurgy.API.ShearingDictionary.Add(ME.Cerium, new Pair<AtomType, AtomType>(ME.Indium, ME.Indium));
        HalvingMetallurgy.API.ShearingDictionary.Add(UAP.Cobalt, new Pair<AtomType, AtomType>(UAP.Nickel, ME.Indium));
        HalvingMetallurgy.API.ShearingDictionary.Add(ME.Neodynium, new Pair<AtomType, AtomType>(UAP.Nickel, UAP.Nickel));
        HalvingMetallurgy.API.ShearingDictionary.Add(UAP.Platinum, new Pair<AtomType, AtomType>(ME.Ferrum, UAP.Nickel));
        HalvingMetallurgy.API.ShearingDictionary.Add(ME.Titanium, new Pair<AtomType, AtomType>(ME.Ferrum, ME.Ferrum));
    }
     public static void ReductiveNeuvolurgy()
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
    public static void Quixulurgy()
    {
        //have to do it somewhere
        API.thisUselessThing.Add(Vanilla.salt, "S");
        API.thisUselessThing.Add(Vanilla.quicksilver, "Q");
        API.thisUselessThing.Add(PrimaMateria.PrimaMateriaAtoms.Sulfur, "X");

        //metals
        foreach (KeyValuePair<AtomType, int> atom in HalvingMetallurgy.API.metalToDoubledMetallicity)
        {
            API.AddMetalToDictionary(atom.Key, atom.Value);
        }
        API.AddMetalToDictionary(AlcInv.AntiLead, -2);
        API.AddMetalToDictionary(AlcInv.AntiTin, -4);
        API.AddMetalToDictionary(AlcInv.AntiIron, -6);
        API.AddMetalToDictionary(AlcInv.AntiCopper, -8);
        API.AddMetalToDictionary(AlcInv.AntiSilver, -10);
        API.AddMetalToDictionary(AlcInv.AntiGold, -12);
        

        // quix
        API.Quixinary.Add(ME.Quicklead, -4);
        API.Quixinary.Add(ME.Quicktin, -2);
        API.Quixinary.Add(ME.Quickiron, -1);
        API.Quixinary.Add(HM.GetQuicklime(), 0);
        API.Quixinary.Add(HM.GetQuickCopper(), 1);
        API.Quixinary.Add(Vanilla.quicksilver, 2);
        API.Quixinary.Add(ME.Quickgold, 4);
        //shearing quix
        HalvingMetallurgy.API.ShearingDictionary.Add(ME.Quickgold, new Pair<AtomType, AtomType>(Vanilla.quicksilver, Vanilla.quicksilver));
        HalvingMetallurgy.API.ShearingDictionary.Add(ME.Quicklead, new Pair<AtomType, AtomType>(ME.Quicktin, ME.Quicktin));
        HalvingMetallurgy.API.ShearingDictionary.Add(ME.Quicktin, new Pair<AtomType, AtomType>(ME.Quickiron, ME.Quickiron));

        // alchemical inversions?1
        AlchemicalInversions.API.transpositionTable.Add(ME.Quicklead, ME.Quickgold);
        AlchemicalInversions.API.transpositionTable.Add(ME.Quicktin, Vanilla.quicksilver);
        AlchemicalInversions.API.transpositionTable.Add(ME.Quickiron, HM.GetQuickCopper());
        AlchemicalInversions.API.transpositionTable.Add(HM.GetQuickCopper(), ME.Quickiron);
        AlchemicalInversions.API.transpositionTable.Add(Vanilla.quicksilver, ME.Quicktin);
        AlchemicalInversions.API.transpositionTable.Add(ME.Quickgold, ME.Quicklead);

        // derivation! finally!
        TrueSalt.API.saltAtoms.TryGetValue(2, out AtomType calcite);
        API.AddDerivationRecipe(Vanilla.salt, Vanilla.salt, calcite); //why is it not public :<
        API.AddDerivationRecipe(Vanilla.salt, Vanilla.quicksilver, NV.Zephiron);
        API.AddDerivationRecipe(Vanilla.quicksilver, Vanilla.quicksilver, ME.Quickgold);
        API.AddDerivationRecipe(PrimaMateria.PrimaMateriaAtoms.Sulfur, PrimaMateria.PrimaMateriaAtoms.Sulfur, NE.Nobilis);
    }

    public static void ExtraCardinals()
    {
        TrueSalt.API.saltAtoms.TryGetValue(2, out AtomType calcite);
        API.AddDupeRecipe(calcite, Vanilla.fire, ME.Ignis);
        API.AddDupeRecipe(calcite, Vanilla.water, ME.Aqua);
        API.AddDupeRecipe(calcite, Vanilla.earth, ME.Terra);
        API.AddDupeRecipe(calcite, Vanilla.air, ME.Caelum);
        API.AddDupeRecipe(ME.Ignis, Vanilla.water, CE.Vaprorine);
        API.AddDupeRecipe(ME.Ignis, Vanilla.earth, CE.Pyrolite);
        API.AddDupeRecipe(ME.Ignis, Vanilla.air, CE.Ignistal);
        API.AddDupeRecipe(ME.Aqua, Vanilla.fire, CE.Vaprorine);
        API.AddDupeRecipe(ME.Aqua, Vanilla.earth, CE.Terramarine);
        API.AddDupeRecipe(ME.Aqua, Vanilla.air, CE.Mistaline);
        API.AddDupeRecipe(ME.Terra, Vanilla.fire, CE.Pyrolite);
        API.AddDupeRecipe(ME.Terra, Vanilla.water, CE.Terramarine);
        API.AddDupeRecipe(ME.Terra, Vanilla.air, CE.Aerolith);
        API.AddDupeRecipe(ME.Caelum, Vanilla.fire, CE.Ignistal);
        API.AddDupeRecipe(ME.Caelum, Vanilla.water, CE.Mistaline);
        API.AddDupeRecipe(ME.Caelum, Vanilla.earth, CE.Aerolith);
        API.AddDupeRecipe(Vanilla.salt, ME.Ignis, Vanilla.fire);
        API.AddDupeRecipe(Vanilla.salt, ME.Aqua, Vanilla.water);
        API.AddDupeRecipe(Vanilla.salt, ME.Terra, Vanilla.earth);
        API.AddDupeRecipe(Vanilla.salt, ME.Caelum, Vanilla.air);

        TrueSalt.API.addSalinizationRule(CE.Ignistal, 2);
        TrueSalt.API.addSalinizationRule(CE.Mistaline, 2);
        TrueSalt.API.addSalinizationRule(CE.Aerolith, 2);
        TrueSalt.API.addSalinizationRule(CE.Terramarine, 2);
        TrueSalt.API.addSalinizationRule(CE.Pyrolite, 2);
        TrueSalt.API.addSalinizationRule(CE.Vaprorine, 2);

        //so like I could do it myself ooor i could use other people code
        TrueSalt.API.addSalinizationRule(ME.Aqua, 2);
        TrueSalt.API.addSalinizationRule(ME.Ignis, 2);
        TrueSalt.API.addSalinizationRule(ME.Terra, 2);
        TrueSalt.API.addSalinizationRule(ME.Caelum, 2);

        API.AddReposition(ME.Temperum, Vanilla.fire, UAP.Bellum, Vanilla.earth);
        API.AddReposition(ME.Temperum, Vanilla.air, UAP.Bellum, Vanilla.water);
        API.AddReposition(ME.Temperum, Vanilla.water, UAP.Pax, Vanilla.air);
        API.AddReposition(ME.Temperum, Vanilla.earth, UAP.Pax, Vanilla.fire);

        API.AddReposition(ME.Humita, Vanilla.fire, UAP.Lux, Vanilla.air);
        API.AddReposition(ME.Humita, Vanilla.air, UAP.Lux, Vanilla.fire);
        API.AddReposition(ME.Humita, Vanilla.water, UAP.Obscurum, Vanilla.earth);
        API.AddReposition(ME.Humita, Vanilla.earth, UAP.Obscurum, Vanilla.water);

        API.AddReposition(ME.Temperum, ME.Ignis, UAP.Bellum, ME.Terra);
        API.AddReposition(ME.Temperum, ME.Caelum, UAP.Bellum, ME.Aqua);
        API.AddReposition(ME.Temperum, ME.Aqua, UAP.Pax, ME.Caelum);
        API.AddReposition(ME.Temperum, ME.Terra, UAP.Pax, ME.Ignis);

        API.AddReposition(ME.Humita, ME.Ignis, UAP.Lux, ME.Caelum);
        API.AddReposition(ME.Humita, ME.Caelum, UAP.Lux, ME.Ignis);
        API.AddReposition(ME.Humita, ME.Aqua, UAP.Obscurum, ME.Terra);
        API.AddReposition(ME.Humita, ME.Terra, UAP.Obscurum, ME.Aqua);

        

    }
}
