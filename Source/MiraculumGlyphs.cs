using Brimstone;
using Quintessential;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalvingMetallurgy;
using PartDataWrapper = class_236;
using PartRenderHelper = class_195;
using PartType = class_139;
using Texture = class_256;
using NV = Neuvolics.Exports;
using Vacancy = Vaca.MainClass;
using PM = PrimaMateria.PrimaMateriaAtoms;
using Vanilla = Brimstone.API.VanillaAtoms;
using FA = FalseAether.Atoms;

namespace MiraculumEdere;

public static class MiraculumGlyphs
{
    public static PartType Conjurgation, Ascent, Convolution, Fragmentation, Derivation, Judgement;



    public static readonly HexIndex conjurgationInput = new(-1, 0);
    public static readonly HexIndex conjurgationOutput = new(1, 0);
    public static readonly HexIndex conjurgationBuffer = new(0, 0);

    public static readonly HexIndex convolutionInput = new(-1, 2);
    public static readonly HexIndex convolutionBowl = new(0, 0);
    public static readonly HexIndex convolutionOutputGel = new(1, 0);
    public static readonly HexIndex convolutionOutputFrix = new(-1, 0);
    public static readonly HexIndex convolutionBlockerA = new(0, 1);
    public static readonly HexIndex convolutionBlockerB = new(-1, 1);

    public static readonly HexIndex fragmentationInput = new(1, 0);
    public static readonly HexIndex fragmentationOutputCW = new(0, -1);
    public static readonly HexIndex fragmentationOutputCCW = new(-1, 1);
    public static readonly HexIndex fragmentationBowl = new(-1, 0);
    public static readonly HexIndex fragmentationBlocker = new(0, 0);

    public static readonly HexIndex derivationInputA = new(1, -1);
    public static readonly HexIndex derivationInputB = new(0, -1);
    public static readonly HexIndex derivationOutput = new(0, 0);

    public static readonly HexIndex ascentBowl = new(0, 0);

    public static readonly HexIndex judgementBowlIn = new(-1, 0);
    public static readonly HexIndex judgementBowlOut = new(1, 0);
    public static readonly HexIndex judgementBlocker = new(0, 0);

    public static Texture placeholder = Brimstone.API.GetTexture();

    public static void AddGlyphs() 
    {
        Conjurgation = Brimstone.API.CreateSimpleGlyph(
            ID: "miraculum-edere-reodering", // old name + misspelled = mark of shame
            name: "Glyph of Conjurgation",
            description: "The Glyph of Conjurgation converts atoms between the first- and second-order. When given a first order metal, it returns the second-order conjugate, or the atom whos metallicity add with the input to reach gold. When given a second-order metal, it returns the first-order conjugate. Requires a buffer metal to draw or dump excess metallicity.",
            cost: 30,
            glow: Brimstone.API.GetTexture("textures/parts/MiraculumEdere/conjurgation/glow"),
            stroke: Brimstone.API.GetTexture("textures/parts/MiraculumEdere/conjurgation/stroke"),
            icon: placeholder,
            hoveredIcon: placeholder,
            usedHexes: new HexIndex[] { conjurgationInput, conjurgationOutput, conjurgationBuffer },
            customPermission: "Miraculum:Conjurgation"
        );
        Ascent = Brimstone.API.CreateSimpleGlyph(
            ID: "miraculum-edere-ascent",
            name: "Glyph of Ascent",
            description: "The Glyph of Ascent ascends a metallic atom to one of a higher order, and equal metallicity.",
            cost: 20,
            glow: Brimstone.API.GetTexture("textures/parts/MiraculumEdere/ascent/glow"),
            stroke: Brimstone.API.GetTexture("textures/parts/MiraculumEdere/ascent/stroke"),
            icon: placeholder,
            hoveredIcon: placeholder,
            usedHexes: new HexIndex[] { ascentBowl },
            customPermission: "Miraculum:Ascent"
        );
        Convolution = Brimstone.API.CreateSimpleGlyph(
            ID: "miraculum-edere-convolution",
            name: "Glyph of Convolution",
            description: "The Glyph of Convolution takes 2 neumetals, rotates the second towards the first, and converts the first into the volic that would rotate it towards the second.",
            cost: 45,
            glow: Brimstone.API.GetTexture("textures/parts/MiraculumEdere/convolution/glow"),
            stroke: Brimstone.API.GetTexture("textures/parts/MiraculumEdere/convolution/stroke"),
            icon: placeholder,
            hoveredIcon: placeholder,
            usedHexes: new HexIndex[] { convolutionInput, convolutionOutputGel, convolutionOutputFrix, convolutionBowl, convolutionBlockerA, convolutionBlockerB },
            customPermission: "Miraculum:Convolution"
        );
        Fragmentation = Brimstone.API.CreateSimpleGlyph(
            ID: "miraculum-edere-fragmentation",
            name: "Glyph of Fragmentation",
            description: "The Glpyh of Fragmentation converts Zephiron into the neumetals adjacent to the ones in the bowl. It will also attempt to do so with Gelaron and Frixon, with predicable results.",
            cost: 45,
            glow: Brimstone.API.GetTexture("textures/parts/MiraculumEdere/fragmentation/glow"),
            stroke: Brimstone.API.GetTexture("textures/parts/MiraculumEdere/fragmentation/stroke"),
            icon: placeholder,
            hoveredIcon: placeholder,
            usedHexes: new HexIndex[] { fragmentationBlocker, fragmentationBowl, fragmentationInput, fragmentationOutputCCW, fragmentationOutputCW },
            customPermission: "Miraculum:Fragmentation"
        );
        Derivation = Brimstone.API.CreateSimpleGlyph(
            ID: "miraculum-edere-derivation",
            name: "Glyph of Derivation",
            description: "The Glpyh of Derivation combines two atoms from the Primae Triad, and returns a resultant. (Many combinations will create an atom with a missing texture, this is intentional, placeholder behaviour.)",
            cost: 45,
            glow: Brimstone.API.GetTexture("textures/parts/MiraculumEdere/derivation/glow"),
            stroke: Brimstone.API.GetTexture("textures/parts/MiraculumEdere/derivation/stroke"),
            icon: placeholder,
            hoveredIcon: placeholder,
            usedHexes: new HexIndex[] { derivationInputA, derivationInputB, derivationOutput },
            customPermission: "Miraculum:Derivation"
        );
        Judgement = Brimstone.API.CreateSimpleGlyph(
            ID: "miraculum-edere-judgement",
            name: "Glyph of Judgement",
            description: "The Glpyh of Judgement rotates Mortality and Morality clockwise around salt, and transfers it from one atom into another. The inverse process is impossible as it violates the natural order.",
            cost: 45,
            glow: Brimstone.API.GetTexture("textures/parts/MiraculumEdere/judgement/glow"),
            stroke: Brimstone.API.GetTexture("textures/parts/MiraculumEdere/judgement/stroke"),
            icon: placeholder,
            hoveredIcon: placeholder,
            usedHexes: new HexIndex[] { judgementBowlIn, judgementBlocker, judgementBowlOut },
            customPermission: "Miraculum:Judgement"
        );

        QApi.AddPartTypeToPanel(Conjurgation, false);
        QApi.AddPartTypeToPanel(Ascent, false);
        QApi.AddPartTypeToPanel(Convolution, false);
        QApi.AddPartTypeToPanel(Fragmentation, false);
        QApi.AddPartTypeToPanel(Derivation, false);
        QApi.AddPartTypeToPanel(Judgement, false);

        QApi.AddPartType(Conjurgation, static (part, pos, editor, renderer) =>
        {
            renderer.method_523(Brimstone.API.GetTexture("textures/parts/MiraculumEdere/conjurgation/base"), new Vector2(1f, 1f), new Vector2(125f, 48f), 0);
            Brimstone.API.GetRenderingHelpers(part, pos, editor, out PartSimState pss, out PartDataWrapper pdw, out float time);
            Brimstone.API.DrawIris(renderer, pdw, conjurgationOutput, time, pss.field_2743 ? Brimstone.API.ConvertToMaybe(pss.field_2744[0]) : struct_18.field_1431);
            renderer.method_523(Brimstone.API.GetTexture("textures/parts/calcinator_bowl"), new Vector2(1f, 1f), new Vector2(43f, 48f), 0);
            renderer.method_523(Brimstone.API.GetTexture("textures/parts/input_ring"), new Vector2(1f, 1f), new Vector2(125f, 48f), 0);

        });
        QApi.AddPartType(Derivation, static (part, pos, editor, renderer) =>
        {
            renderer.method_523(Brimstone.API.GetTexture("textures/parts/MiraculumEdere/ascent/base"), new Vector2(0f, 0f), new Vector2(41f, -23f), 0);



        });
        QApi.AddPartType(Ascent, static (part, pos, editor, renderer) =>
        {
            renderer.method_523(Brimstone.API.GetTexture("textures/parts/MiraculumEdere/ascent/base"), new Vector2(0f, 0f), new Vector2(41f, 48f), 0);
            renderer.method_523(Brimstone.API.GetTexture("textures/parts/calcinator_bowl"), new Vector2(1f, 1f), new Vector2(41f, 48f), 0);


        });
        QApi.AddPartType(Convolution, static (part, pos, editor, renderer) =>
        {
            renderer.method_523(Brimstone.API.GetTexture("textures/parts/MiraculumEdere/convolution/base"), new Vector2(0f, 0f), new Vector2(125f, 190f), 0);


        });
        QApi.AddPartType(Fragmentation, static (part, pos, editor, renderer) =>
        {
            renderer.method_523(Brimstone.API.GetTexture("textures/parts/MiraculumEdere/fragmentation/base"), new Vector2(0f, 0f), new Vector2(123f, 119f), 0);


        });
        QApi.AddPartType(Judgement, static (part, pos, editor, renderer) =>
        {
            renderer.method_523(Brimstone.API.GetTexture("textures/parts/MiraculumEdere/judgement/base"), new Vector2(0f, 0f), new Vector2(125f, 48f), 0);
            renderer.method_523(Brimstone.API.GetTexture("textures/parts/calcinator_bowl"), new Vector2(1f, 1f), new Vector2(125f, 48f), 0);
            renderer.method_523(Brimstone.API.GetTexture("textures/parts/calcinator_bowl"), new Vector2(1f, 1f), new Vector2(-41f, 48f), 0);


        });

        QApi.RunDuringCycle(static (sim, part, pss, first) =>
        {
            SolutionEditorBase SEB = sim.field_3818;
            List<Part> parts = SEB.method_502().field_3919;
            PartType type = part.method_1159();
            if (type == Conjurgation)
            {
                if (first)
                {
                    bool bufferExists = true;
                    if (sim.FindAtomRelative(part, conjurgationOutput).method_1085())
                    {      
                        return;
                    }
                    if (!sim.FindAtomRelative(part, conjurgationInput).method_99(out AtomReference inputAtom))
                    {
                        return;
                    }
                    if (!sim.FindAtomRelative(part, conjurgationBuffer).method_99(out AtomReference bufferAtom))
                    {
                        if (inputAtom.field_2280 != Brimstone.API.VanillaAtoms.iron && inputAtom.field_2280 != MiraculumAtoms.Ferrum) //ferrum <-> iron is free, anyway
                        {
                            return;
                        }
                        else
                        {
                            bufferExists = false;
                        }
                    }
                    if (inputAtom.field_2281 || inputAtom.field_2282)
                    {
                        return;
                    }
                    HexIndex input = part.method_1184(conjurgationInput);
                    HexIndex buffer = part.method_1184(conjurgationBuffer);
                    HexIndex output = part.method_1184(conjurgationOutput);

                    bool inputIsFirstOrder = true;
                    bool bufferIsFirstOrder = true;

                    int inputMetallicity = 0;
                    int bufferMetallicity = 0;
                    AtomType outputAtom = null;
                    AtomType newBufferAtom = null;

                    if (!HalvingMetallurgy.API.metalToDoubledMetallicity.TryGetValue(inputAtom.field_2280, out inputMetallicity)) //not first order
                    {
                        if (!API.secondordertodoubledmetallicity.TryGetValue(inputAtom.field_2280, out inputMetallicity))
                        {
                            return; //not second order either huh???
                        }
                        else
                        {
                            inputIsFirstOrder = false;
                        }
                    }
                    //same thing but for buffer instead
                    if (bufferExists)
                    {
                        if (!HalvingMetallurgy.API.metalToDoubledMetallicity.TryGetValue(bufferAtom.field_2280, out bufferMetallicity))
                        {
                            if (!API.secondordertodoubledmetallicity.TryGetValue(bufferAtom.field_2280, out bufferMetallicity))
                            {
                                return;
                            }
                            else
                            {
                                bufferIsFirstOrder = false;
                            }
                        }
                    }
                    int outputMetallicity = 12 - inputMetallicity;
                    int deltaMetallicity = outputMetallicity - inputMetallicity;
                    if (outputMetallicity < 0 || outputMetallicity > 12) //its impossible to return 13 since -1 doesnt exist
                    {
                        return;
                    }
                    if (bufferMetallicity - deltaMetallicity < 0 || bufferMetallicity - deltaMetallicity > 13 || (bufferMetallicity - deltaMetallicity > 12 && !inputIsFirstOrder)) //now, it IS possible to return 13 here, but dont let it if not second-order
                    {
                        return;
                    }
                    if (outputMetallicity == 0) //to do: extraction check
                    {
                        outputAtom = Vacancy.VacaAtom; // doesnt matter the order. its just vaca.
                    }
                    else 
                    {
                        if (inputIsFirstOrder) // return second order
                        {
                            if (!API.doubledmetalicitytosecondordermetal.TryGetValue(outputMetallicity, out outputAtom))
                            {
                                return; //oh wait it doesnt exist
                            }
                        }
                        else // return first order
                        {
                            if (!HalvingMetallurgy.API.doubledMetallicityToMetal.TryGetValue(outputMetallicity, out outputAtom))
                            {
                                return;
                            }
                        }
                    }
                    if (bufferExists) //for the buffer, if it exists
                    {
                        if (bufferIsFirstOrder)
                        {
                            if (!HalvingMetallurgy.API.doubledMetallicityToMetal.TryGetValue(bufferMetallicity - deltaMetallicity, out newBufferAtom))
                            {
                                return;
                            }
                        }
                        else
                        {
                            if (!API.doubledmetalicitytosecondordermetal.TryGetValue(bufferMetallicity - deltaMetallicity, out newBufferAtom))
                            {
                                return;
                            }
                        }
                    }
                    Brimstone.API.RemoveAtom(inputAtom);
                    Brimstone.API.DrawFallingAtom(SEB, inputAtom);
                    if (bufferExists)
                    {
                        Brimstone.API.ChangeAtom(bufferAtom, newBufferAtom);
                    }
                    pss.field_2743 = true;
                    pss.field_2744 = new AtomType[1] { outputAtom };
                    Brimstone.API.AddSmallCollider(sim, part, output);
                }
                else if (pss.field_2743)
                {
                    Brimstone.API.AddAtom(sim, part, conjurgationOutput, pss.field_2744[0]);
                }
            }
            else if (type == Convolution)
            {
                if (first)
                {
                    AtomType output = null;
                    if (!sim.FindAtomRelative(part, convolutionInput).method_99(out AtomReference inputAtom))
                    {
                        return;
                    }
                    if (inputAtom.field_2281 || inputAtom.field_2282)
                    {
                        return;
                    }
                    if (!sim.FindAtomRelative(part, convolutionBowl).method_99(out AtomReference bowlAtom))
                    {
                        return;
                    }
                    int inputIndex = NV.AtomExports.GetNeumetalIndex(inputAtom.field_2280);
                    int bowlIndex = NV.AtomExports.GetNeumetalIndex(bowlAtom.field_2280);
                    if (inputIndex == -1 || bowlIndex == -1 || inputIndex == bowlIndex) //-1 means its not a neumetal, if the same, do nothing, since how do you rotate something to itself????
                    {
                        return;
                    }
                    if (bowlIndex < inputIndex)
                    {
                        bowlIndex += 5;
                    }
                    if (bowlIndex - inputIndex > 2)
                    {
                        output = NV.AtomExports.GetFrixon();
                        if (sim.FindAtomRelative(part, convolutionOutputFrix).method_1085())
                        {
                            // are you serious
                            // i have come all this way
                            // run all this code
                            // just for it to be blocked
                            // ...
                            // whatever
                            // probally just a comment anyway
                            return;
                        }
                            bowlIndex -= 1;
                    }
                    else
                    {
                        output = NV.AtomExports.GetGelaron();
                        if (sim.FindAtomRelative(part, convolutionOutputGel).method_1085())
                        {
                            // are you serious
                            // i have come all this way
                            // yadda yaada you get the idea
                            return;
                        }
                            bowlIndex += 1;
                    }
                    Brimstone.API.RemoveAtom(inputAtom);
                    Brimstone.API.DrawFallingAtom(SEB, inputAtom);
                    Brimstone.API.ChangeAtom(bowlAtom, NV.AtomExports.GetNeumetalAtom(bowlIndex));
                    pss.field_2743 = true;
                    pss.field_2744 = new AtomType[1] { output };
                    if (output == NV.AtomExports.GetGelaron())
                    {
                        Brimstone.API.AddSmallCollider(sim, part, convolutionOutputGel);
                    }
                    else
                    {
                        Brimstone.API.AddSmallCollider(sim, part, convolutionOutputFrix);
                    }
                }
                else if (pss.field_2743)
                {
                    if (pss.field_2744[0] == NV.AtomExports.GetGelaron())
                    {
                        Brimstone.API.AddAtom(sim, part, convolutionOutputGel, pss.field_2744[0]);
                    }
                    else
                    {
                        Brimstone.API.AddAtom(sim, part, convolutionOutputFrix, pss.field_2744[0]);
                    }
                }
            }
            else if (type == Fragmentation)
            {
                if (first)
                {
                    bool outputFrix = false;
                    bool outputGel = false;
                    if (!sim.FindAtomRelative(part, fragmentationInput).method_99(out AtomReference inputAtom))
                    {
                        return;
                    }
                    if (inputAtom.field_2281 || inputAtom.field_2282)
                    {
                        return;
                    }
                    if (!sim.FindAtomRelative(part, fragmentationBowl).method_99(out AtomReference bowlAtom))
                    {
                        return;
                    }
                    if (sim.FindAtomRelative(part, fragmentationOutputCCW).method_1085())
                    {
                        return;
                    }
                    if (sim.FindAtomRelative(part, fragmentationOutputCW).method_1085())
                    {
                        return;
                    }
                    if (inputAtom.field_2280 == NV.AtomExports.GetZephiron()) // it has to be zephiron (for now) (omnious)
                    {
                        outputFrix = true;
                        outputGel = true;
                    }
                    else if (inputAtom.field_2280 == NV.AtomExports.GetGelaron())
                    {
                        outputGel = true;
                    }
                    else if (inputAtom.field_2280 == NV.AtomExports.GetFrixon())
                    {
                        outputFrix = true;
                    }
                    else
                    {
                        return;
                    }
                    int bowlIndex = NV.AtomExports.GetNeumetalIndex(bowlAtom.field_2280);
                    if (bowlIndex == -1)
                    {
                        return;
                    }
                    int CWIndex = (bowlIndex + 1);
                    int CCWIndex = (bowlIndex - 1);
                    AtomType OutputAtomCW = NV.AtomExports.GetNeumetalAtom(CWIndex);
                    AtomType OutputAtomCCW = NV.AtomExports.GetNeumetalAtom(CCWIndex);

                    HexIndex outputCW = part.method_1184(fragmentationOutputCW);
                    HexIndex outputCCW = part.method_1184(fragmentationOutputCCW);

                    Brimstone.API.RemoveAtom(inputAtom);
                    Brimstone.API.DrawFallingAtom(SEB, inputAtom);
                    pss.field_2743 = true;
 
                    if (outputFrix && outputGel)
                    {
                        pss.field_2744 = new AtomType[2] { OutputAtomCW, OutputAtomCCW };
                        Brimstone.API.AddSmallCollider(sim, part, outputCW);
                        Brimstone.API.AddSmallCollider(sim, part, outputCCW);
                    }
                    else if (outputFrix)
                    {
                        // to do: extraction check
                        pss.field_2744 = new AtomType[2] { OutputAtomCW, Vacancy.VacaAtom }; //it tries to make both but there isnt enough mass
                        Brimstone.API.AddSmallCollider(sim, part, outputCW);
                    }
                    else //gelaron only
                    {
                        //to do: ditto
                        pss.field_2744 = new AtomType[2] { Vacancy.VacaAtom, OutputAtomCCW };
                        Brimstone.API.AddSmallCollider(sim, part, outputCCW);
                    }
                }
                else if (pss.field_2743)
                {
                    Brimstone.API.AddAtom(sim, part, fragmentationOutputCW, pss.field_2744[0]);
                    Brimstone.API.AddAtom(sim, part, fragmentationOutputCCW, pss.field_2744[1]);
                }
            }
            else if (type == Ascent)
            {
                if (!first)
                {
                    if (!sim.FindAtomRelative(part, ascentBowl).method_99(out AtomReference inputAtom))
                    {
                        return;
                    }
                    if (!API.secondordertodoubledmetallicity.TryGetValue(inputAtom.field_2280, out int metallicity))
                    {
                        return; //not second order, not like third order exists or anything
                    }
                    if (!HalvingMetallurgy.API.doubledMetallicityToMetal.TryGetValue(metallicity, out AtomType outputAtom))
                    {
                        return;
                    }
                    Brimstone.API.ChangeAtom(inputAtom, outputAtom); //aand thats it
                }
            }
            else if (type == Derivation)
            {
                if (first)
                {
                    if (sim.FindAtomRelative(part, derivationOutput).method_1085())
                    {
                        return;
                    }
                    if (!sim.FindAtomRelative(part, derivationInputA).method_99(out AtomReference inputAtomA))
                    {
                        return;
                    }
                    if (!sim.FindAtomRelative(part, derivationInputB).method_99(out AtomReference inputAtomB))
                    {
                        return;
                    }
                    if (inputAtomA.field_2281 || inputAtomA.field_2282 || inputAtomB.field_2281 || inputAtomB.field_2282)
                    {
                        return;
                    }
                    if (inputAtomA.field_2280 != Brimstone.API.VanillaAtoms.salt && inputAtomA.field_2280 != Brimstone.API.VanillaAtoms.quicksilver && inputAtomA.field_2280 != PM.Sulfur)
                    {
                        return;
                    }
                    if (inputAtomB.field_2280 != Brimstone.API.VanillaAtoms.salt && inputAtomB.field_2280 != Brimstone.API.VanillaAtoms.quicksilver && inputAtomB.field_2280 != PM.Sulfur)
                    {
                        return;
                    }
                }
            }
            else if (type == Judgement)
            { // first doesnt matter
                if (!sim.FindAtomRelative(part, judgementBowlIn).method_99(out AtomReference sourceAtom))
                {
                    return;
                }
                if (!sim.FindAtomRelative(part, judgementBowlOut).method_99(out AtomReference targetAtom))
                {
                    return;
                }
                if (!API.atomToCharge.TryGetValue(sourceAtom.field_2280, out int[] sourceCharge))
                {
                    Logger.Log("source atom not animismus");
                    return;
                }
                if (!API.atomToCharge.TryGetValue(targetAtom.field_2280, out int[] targetCharge))
                {
                    Logger.Log("target atom not animismus");
                    return;
                }
                int[] outputCharge = API.AddCharge(targetCharge, API.RotateCharge(sourceCharge));
                string chargeString = API.ConvertIntListToStringBecauseTheIntListDoesntWorkForSomeStupidReason(outputCharge);
                AtomType outputAtom;
                if (!API.AnimRootAtom.TryGetValue(targetAtom.field_2280, out AtomType outputRoot))
                {
                    return;
                }
                else
                {
                    if (outputRoot == Vanilla.quicksilver)
                    {
                        if (!API.chargeToAtomQuix.TryGetValue(chargeString, out outputAtom))
                        {
                            Logger.Log("atom with charge " + outputCharge[0].ToString() + ", " + outputCharge[1].ToString() + " doesnt exist");
                            return;
                        }
                    }
                    else
                    {
                        if (!API.chargeToAtomQuix.TryGetValue(chargeString, out outputAtom))
                        {
                            Logger.Log("atom with charge " + outputCharge[0].ToString() + ", " + outputCharge[1].ToString() + " doesnt exist");
                            return;
                        }
                    }
                }
 
                if (!API.AnimRootAtom.TryGetValue(sourceAtom.field_2280, out AtomType newSourceAtom))
                {
                    return;
                }
                Brimstone.API.ChangeAtom(sourceAtom,newSourceAtom);
                Brimstone.API.ChangeAtom(targetAtom, outputAtom);
            }
        });
    }
}

