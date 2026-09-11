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
using System.Text.RegularExpressions;
using RM = ReductiveMetallurgy;
using TS = TrueSalt.TrueSalt;   
using System.Reflection;
using System.Runtime.CompilerServices;
using PrimaMateria;
using Noble = OMNobleElements.NobleElementsAtoms;

namespace MiraculumEdere;

public static class MiraculumGlyphs
{
    public static PartType Conjurgation, Ascent, Deconstruction, Convolution, Fragmentation, Derivation, Judgement, Shattering, Refraction, Subjection;

    private static readonly HexIndex conjurgationInput = new(-1, 0);
    private static readonly HexIndex conjurgationOutput = new(1, 0);
    private static readonly HexIndex conjurgationBuffer = new(0, 0);

    private static readonly HexIndex convolutionInput = new(-1, 2);
    private static readonly HexIndex convolutionBowl = new(0, 0);
    private static readonly HexIndex convolutionOutputGel = new(1, 0);
    private static readonly HexIndex convolutionOutputFrix = new(-1, 0);
    private static readonly HexIndex convolutionBlockerA = new(0, 1);
    private static readonly HexIndex convolutionBlockerB = new(-1, 1);

    private static readonly HexIndex fragmentationInput = new(1, 0);
    private static readonly HexIndex fragmentationOutputCW = new(0, -1);
    private static readonly HexIndex fragmentationOutputCCW = new(-1, 1);
    private static readonly HexIndex fragmentationBowl = new(-1, 0);
    private static readonly HexIndex fragmentationBlocker = new(0, 0);

    private static readonly HexIndex derivationInputA = new(1, -1);
    private static readonly HexIndex derivationInputB = new(0, -1);
    private static readonly HexIndex derivationOutput = new(0, 0);

    private static readonly HexIndex ascentBowl = new(0, 0);

    private static readonly HexIndex judgementBowlIn = new(-1, 0);
    private static readonly HexIndex judgementBowlOut = new(1, 0);
    private static readonly HexIndex judgementBlocker = new(0, 0);

    private static readonly HexIndex deconMediate = new(-1, 0);
    private static readonly HexIndex deconOutput= new(1, 0);
    private static readonly HexIndex deconInput = new(0, 0);

    private static readonly HexIndex shatterInput = new(0, 0);
    private static readonly HexIndex shatterOutLead = new(2, 0);
    private static readonly HexIndex shatterOutAnti = new(-2, 0);
    private static readonly HexIndex shatterBlockA = new(-2, 1);
    private static readonly HexIndex shatterBlockB = new(-1, 1);
    private static readonly HexIndex shatterBlockC = new(1, -1);
    private static readonly HexIndex shatterBlockD = new(2, -1);

    private static readonly HexIndex refractCenter = new(0, 0);
    private static readonly HexIndex refractIrisA = new(-1, 0);
    private static readonly HexIndex refractIrisB = new(0, 1);
    private static readonly HexIndex refractIrisC = new(1, -1);

    private static readonly HexIndex SubjectionHigh = new(0, 0);
    private static readonly HexIndex SubjectionLow = new(-1, 0);


    public static void AddGlyphs() 
    {
        Conjurgation = Brimstone.API.CreateSimpleGlyph(
            ID: "miraculum-edere-reodering", // old name + misspelled = mark of shame
            name: "Glyph of Conjurgation",
            description: "The Glyph of Conjurgation converts atoms between the first- and second-order. When given a first order metal, it returns the second-order conjugate, or the atom whos metallicity add with the input to reach gold. When given a second-order metal, it returns the first-order conjugate. Requires a buffer metal to draw or dump excess metallicity.",
            cost: 30,
            glow: Brimstone.API.GetTexture("textures/parts/MiraculumEdere/conjurgation/glow"),
            stroke: Brimstone.API.GetTexture("textures/parts/MiraculumEdere/conjurgation/stroke"),
            icon: Textures.placeholder,
            hoveredIcon: Textures.placeholder,
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
            icon: Textures.placeholder,
            hoveredIcon: Textures.placeholder,
            usedHexes: new HexIndex[] { ascentBowl },
            customPermission: "Miraculum:Ascent"
        );
        Deconstruction = Brimstone.API.CreateSimpleGlyph(
            ID: "miraculum-edere-deconstruction",
            name: "Glyph of Deconstruction",
            description: "The Glyph of Deconstruction takes Elemental Gold or Elemental Titanium and splits it into a metal and its opposite-order conjugate. Requires an additional metal to mediate what paring is made.",
            cost: 30 ,
            glow: Brimstone.API.GetTexture("textures/parts/MiraculumEdere/deconstruction/glow"),
            stroke: Brimstone.API.GetTexture("textures/parts/MiraculumEdere/deconstruction/stroke"),
            icon: Textures.placeholder,
            hoveredIcon: Textures.placeholder,
            usedHexes: new HexIndex[] { deconMediate, deconOutput, deconInput },
            customPermission: "Miraculum:Deconstruction"
        );
        Convolution = Brimstone.API.CreateSimpleGlyph(
            ID: "miraculum-edere-convolution",
            name: "Glyph of Convolution",
            description: "The Glyph of Convolution takes 2 neumetals, rotates the second towards the first, and converts the first into the volic that would rotate it towards the second.",
            cost: 25,
            glow: Brimstone.API.GetTexture("textures/parts/MiraculumEdere/convolution/glow"),
            stroke: Brimstone.API.GetTexture("textures/parts/MiraculumEdere/convolution/stroke"),
            icon: Textures.placeholder,
            hoveredIcon: Textures.placeholder,
            usedHexes: new HexIndex[] { convolutionInput, convolutionOutputGel, convolutionOutputFrix, convolutionBowl, convolutionBlockerA, convolutionBlockerB },
            customPermission: "Miraculum:Convolution"
        );
        Fragmentation = Brimstone.API.CreateSimpleGlyph(
            ID: "miraculum-edere-fragmentation",
            name: "Glyph of Fragmentation",
            description: "The Glyph of Fragmentation converts Zephiron into the neumetals adjacent to the ones in the bowl. It will also attempt to do so with Gelaron and Frixon, with predicable results.",
            cost: 25,
            glow: Brimstone.API.GetTexture("textures/parts/MiraculumEdere/fragmentation/glow"),
            stroke: Brimstone.API.GetTexture("textures/parts/MiraculumEdere/fragmentation/stroke"),
            icon: Textures.placeholder,
            hoveredIcon: Textures.placeholder,
            usedHexes: new HexIndex[] { fragmentationBlocker, fragmentationBowl, fragmentationInput, fragmentationOutputCCW, fragmentationOutputCW },
            customPermission: "Miraculum:Fragmentation"
        );
        Derivation = Brimstone.API.CreateSimpleGlyph(
            ID: "miraculum-edere-derivation",
            name: "Glyph of Derivation",
            description: "The Glyph of Derivation combines two atoms of the tri primae to create a new atom. (Certain combinations return an atom with a missing texture, this is intentional and placeholder behaviour.)",
            cost: 45,
            glow: Brimstone.API.GetTexture("textures/parts/MiraculumEdere/derivation/glow"),
            stroke: Brimstone.API.GetTexture("textures/parts/MiraculumEdere/derivation/stroke"),
            icon: Textures.placeholder,
            hoveredIcon: Textures.placeholder,
            usedHexes: new HexIndex[] { derivationInputA, derivationInputB, derivationOutput },
            customPermission: "Miraculum:Derivation"
        );
        Judgement = Brimstone.API.CreateSimpleGlyph(
            ID: "miraculum-edere-judgement",
            name: "Glyph of Judgement",
            description: "The Glyph of Judgement rotates Mortality and Morality clockwise around salt, and transfers it from one atom into another. The inverse process is impossible as it violates the natural order.",
            cost: 35,
            glow: Brimstone.API.GetTexture("textures/parts/MiraculumEdere/judgement/glow"),
            stroke: Brimstone.API.GetTexture("textures/parts/MiraculumEdere/judgement/stroke"),
            icon: Textures.placeholder,
            hoveredIcon: Textures.placeholder,
            usedHexes: new HexIndex[] { judgementBowlIn, judgementBlocker, judgementBowlOut },
            customPermission: "Miraculum:Judgement"
        );
        Shattering = Brimstone.API.CreateSimpleGlyph(
            ID: "miraculum-edere-shattering",
            name: "Glyph of Shattering",
            description: "The Glyph of Shattering shears Vaca in twain, creating Lead and Anti-Lead from the remains. Despite the impossibility of it all, all metallicity is preserved.",
            cost: 35,
            glow: Brimstone.API.GetTexture("textures/parts/MiraculumEdere/shattering/glow"),
            stroke: Brimstone.API.GetTexture("textures/parts/MiraculumEdere/shattering/stroke"),
            icon: Textures.placeholder,
            hoveredIcon: Textures.placeholder,
            usedHexes: new HexIndex[] { shatterBlockA, shatterBlockB, shatterBlockC, shatterBlockD, shatterInput, shatterOutAnti, shatterOutLead },
            customPermission: "Miraculum:Shattering"
        );
        Refraction = Brimstone.API.CreateSimpleGlyph(
            ID: "miraculum-edere-refraction",
            name: "Glyph of Refraction",
            description: "The Glyph of Refraction combines a Volatile atom and its opposite into the respective Noble.",
            cost: 35,
            glow: Brimstone.API.GetTexture("textures/parts/MiraculumEdere/refraction/glow"),
            stroke: Brimstone.API.GetTexture("textures/parts/MiraculumEdere/refraction/stroke"),
            icon: Textures.placeholder,
            hoveredIcon: Textures.placeholder,
            usedHexes: new HexIndex[] { refractCenter, refractIrisA, refractIrisB, refractIrisC },
            customPermission: "Miraculum:Refraction"
        );
        Subjection = Brimstone.API.CreateSimpleGlyph(
            ID: "miraculum-edere-subjection",
            name: "Glyph of Subjection",
            description: "The Glyph of Subjection promotes or demotes metals, depending on which bowl is used. If attempting to translate a metal away from Vaca, additional quix will need to be supplied into the other bowl.",
            cost: 45,
            glow: Brimstone.API.GetTexture("textures/parts/MiraculumEdere/subjection/glow"),
            stroke: Brimstone.API.GetTexture("textures/parts/MiraculumEdere/subjection/stroke"),
            icon: Textures.placeholder,
            hoveredIcon: Textures.placeholder,
            usedHexes: new HexIndex[] { SubjectionHigh, SubjectionLow },
            customPermission: "Miraculum:Subjection"
        );

        QApi.AddPartTypeToPanel(Conjurgation, false);
        QApi.AddPartTypeToPanel(Ascent, false);
        QApi.AddPartTypeToPanel(Deconstruction, false);
        QApi.AddPartTypeToPanel(Convolution, false);
        QApi.AddPartTypeToPanel(Fragmentation, false);
        QApi.AddPartTypeToPanel(Derivation, false);
        QApi.AddPartTypeToPanel(Judgement, false);
        QApi.AddPartTypeToPanel(Shattering, false);
        QApi.AddPartTypeToPanel(Refraction, false);
        QApi.AddPartTypeToPanel(Subjection, false);

        QApi.AddPartType(Conjurgation, static (part, pos, editor, renderer) =>
        {
            renderer.method_523(Textures.baseConjurgation, new Vector2(1f, 1f), new Vector2(125f, 48f), 0);
            Brimstone.API.GetRenderingHelpers(part, pos, editor, out PartSimState pss, out PartDataWrapper pdw, out float time);
            Brimstone.API.DrawIris(renderer, pdw, conjurgationOutput, time, pss.field_2743 ? Brimstone.API.ConvertToMaybe(pss.field_2744[0]) : struct_18.field_1431);
            renderer.method_528(Textures.Bowl, conjurgationBuffer, Vector2.Zero);
            Helpers.DrawHole(conjurgationInput, renderer);
        });
        QApi.AddPartType(Derivation, static (part, pos, editor, renderer) =>
        {
            renderer.method_523(Textures.baseDerivation, new Vector2(0f, 0f), new Vector2(92f, 120f), 0);
            Helpers.DrawHole(derivationInputA, renderer);
            Helpers.DrawHole(derivationInputB, renderer);
            Brimstone.API.GetRenderingHelpers(part, pos, editor, out PartSimState pss, out PartDataWrapper pdw, out float time);
            Brimstone.API.DrawIris(renderer, pdw, derivationOutput, time, pss.field_2743 ? Brimstone.API.ConvertToMaybe(pss.field_2744[0]) : struct_18.field_1431);


        });
        QApi.AddPartType(Ascent, static (part, pos, editor, renderer) =>
        {
            renderer.method_523(Textures.baseAscent, new Vector2(0f, 0f), new Vector2(41f, 48f), 0);
            renderer.method_528(Textures.Bowl, ascentBowl, Vector2.Zero);


        });
        QApi.AddPartType(Deconstruction, static (part, pos, editor, renderer) =>
        {
            renderer.method_523(Textures.baseDeconstruction, new Vector2(0f, 0f), new Vector2(125f, 48f), 0);
            renderer.method_528(Textures.Bowl, deconInput, Vector2.Zero);
            renderer.method_528(Textures.Bowl, deconMediate, Vector2.Zero);
            Brimstone.API.GetRenderingHelpers(part, pos, editor, out PartSimState pss, out PartDataWrapper pdw, out float time);
            Brimstone.API.DrawIris(renderer, pdw, deconOutput, time, pss.field_2743 ? Brimstone.API.ConvertToMaybe(pss.field_2744[0]) : struct_18.field_1431);
        });
        QApi.AddPartType(Convolution, static (part, pos, editor, renderer) =>
        {
            renderer.method_523(Textures.baseConvolution, new Vector2(0f, 0f), new Vector2(125f, 190f), 0);
            Helpers.DrawHole(convolutionInput, renderer);
            Brimstone.API.GetRenderingHelpers(part, pos, editor, out PartSimState pss, out PartDataWrapper pdw, out float time);
            renderer.method_528(Textures.Bowl, convolutionBowl, Vector2.Zero);
            renderer.method_529(Neuvolics.Textures.BowlSymbol.Neumetal, convolutionBowl, Vector2.Zero);
            Brimstone.API.DrawIris(renderer, pdw, convolutionOutputFrix, time,Neuvolics.Textures.Irises.Frixon, pss.field_2743 ? pss.field_2744[0] == NV.AtomExports.GetFrixon() ? Brimstone.API.ConvertToMaybe(pss.field_2744[0]) : struct_18.field_1431 : struct_18.field_1431);
            Brimstone.API.DrawIris(renderer, pdw, convolutionOutputGel, time, Neuvolics.Textures.Irises.Gelaron, pss.field_2743 ? pss.field_2744[0] == NV.AtomExports.GetGelaron() ?  Brimstone.API.ConvertToMaybe(pss.field_2744[0]) : struct_18.field_1431 : struct_18.field_1431);

        });
        QApi.AddPartType(Fragmentation, static (part, pos, editor, renderer) =>
        {
            renderer.method_523(Textures.baseFragmentation, new Vector2(0f, 0f), new Vector2(123f, 119f), 0);
            Helpers.DrawHole(fragmentationInput, renderer);
            Brimstone.API.GetRenderingHelpers(part, pos, editor, out PartSimState pss, out PartDataWrapper pdw, out float time);
            renderer.method_528(Textures.Bowl, fragmentationBowl, Vector2.Zero);
            renderer.method_529(Neuvolics.Textures.BowlSymbol.Neumetal, fragmentationBowl, Vector2.Zero);
            Brimstone.API.DrawIris(renderer, pdw, fragmentationOutputCW, time, Neuvolics.Textures.Irises.Neumetal,   pss.field_2743 ? Brimstone.API.ConvertToMaybe(pss.field_2744[0]) : struct_18.field_1431);
            Brimstone.API.DrawIris(renderer, pdw, fragmentationOutputCCW, time, Neuvolics.Textures.Irises.Neumetal, pss.field_2743 ? Brimstone.API.ConvertToMaybe(pss.field_2744[1]) : struct_18.field_1431);



        });
        QApi.AddPartType(Judgement, static (part, pos, editor, renderer) =>
        {
            renderer.method_523(Textures.baseJudgement, new Vector2(0f, 0f), new Vector2(125f, 48f), 0);
            renderer.method_528(Textures.Bowl, judgementBowlIn, Vector2.Zero);
            renderer.method_528(Textures.Bowl, judgementBowlOut, Vector2.Zero);
        });
        QApi.AddPartType(Shattering, static (part, pos, editor, renderer) =>
        {
            renderer.method_523(Textures.baseShattering, new Vector2(0f, 0f), new Vector2(205f, 113f), 0);
            renderer.method_528(Textures.Bowl, shatterInput, Vector2.Zero);
            Brimstone.API.GetRenderingHelpers(part, pos, editor, out PartSimState pss, out PartDataWrapper pdw, out float time);
            Brimstone.API.DrawIris(renderer, pdw, shatterOutAnti, time, pss.field_2743 ? Brimstone.API.ConvertToMaybe(pss.field_2744[1]) : struct_18.field_1431);
            Brimstone.API.DrawIris(renderer, pdw, shatterOutLead, time, pss.field_2743 ? Brimstone.API.ConvertToMaybe(pss.field_2744[0]) : struct_18.field_1431);
        });
        QApi.AddPartType(Refraction, static (part, pos, editor, renderer) =>
        {
            renderer.method_523(Textures.baseRefraction, new Vector2(0f, 0f), new Vector2(123f, 118.5f), 0);
            Brimstone.API.GetRenderingHelpers(part, pos, editor, out PartSimState pss, out PartDataWrapper pdw, out float time);
            if (pss.field_2744 != null)
            {
                if (pss.field_2744[0] != Vanilla.mors)
                {
                    Brimstone.API.DrawIris(renderer, pdw, refractIrisA, time, pss.field_2743 ? Brimstone.API.ConvertToMaybe(pss.field_2744[0]) : struct_18.field_1431);
                }
                else
                {
                    Helpers.DrawHole(refractIrisA, renderer);
                }
                if (pss.field_2744[1] != Vanilla.mors)
                {
                    Brimstone.API.DrawIris(renderer, pdw, refractIrisB, time, pss.field_2743 ? Brimstone.API.ConvertToMaybe(pss.field_2744[1]) : struct_18.field_1431);
                }
                else
                {
                    Helpers.DrawHole(refractIrisB, renderer);
                }
                if (pss.field_2744[2] != Vanilla.mors)
                {
                    Brimstone.API.DrawIris(renderer, pdw, refractIrisC, time, pss.field_2743 ? Brimstone.API.ConvertToMaybe(pss.field_2744[2]) : struct_18.field_1431);
                }
                else
                {
                    Helpers.DrawHole(refractIrisC, renderer);
                }
            } else
            {
                Helpers.DrawHole(refractIrisA, renderer);
                Helpers.DrawHole(refractIrisB, renderer);
                Helpers.DrawHole(refractIrisC, renderer);
            }
        });
        QApi.AddPartType(Subjection, static (part, pos, editor, renderer) =>
            {
                renderer.method_523(Textures.baseSubjection, new Vector2(0f, 0f), new Vector2(123f, 48f), 0);
                renderer.method_528(Textures.MetalBowl, SubjectionHigh, Vector2.Zero);
                renderer.method_528(Textures.MetalBowl, SubjectionLow, Vector2.Zero);
                renderer.method_529(Textures.subjectUp, SubjectionHigh, Vector2.Zero);
                renderer.method_529(Textures.subjectDown, SubjectionLow, Vector2.Zero);
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
                        if (inputAtom.field_2280 != Vanilla.iron && inputAtom.field_2280 != MiraculumAtoms.Ferrum) //ferrum <-> iron is free, anyway
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

                    if (!API.metaltodoubledmetallicity.TryGetValue(inputAtom.field_2280, out inputMetallicity)) //not first order
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
                        if (!API.metaltodoubledmetallicity.TryGetValue(bufferAtom.field_2280, out bufferMetallicity))
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
                            if (!API.doubledmetalicitytometal.TryGetValue(outputMetallicity, out outputAtom))
                            {
                                return;
                            }
                        }
                    }
                    if (bufferExists) //for the buffer, if it exists
                    {
                        if (bufferIsFirstOrder)
                        {
                            if (!API.doubledmetalicitytometal.TryGetValue(bufferMetallicity - deltaMetallicity, out newBufferAtom))
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
                    if (bufferExists)
                    {
                        Helpers.RunTransmuteAnimation(SEB, bufferAtom);
                    }
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
                    AtomType outputAtom = API.ReadDeviationRecipe(inputAtomA.field_2280, inputAtomB.field_2280);
                    Brimstone.API.DrawFallingAtom(SEB, inputAtomA);
                    Brimstone.API.DrawFallingAtom(SEB, inputAtomB);
                    Brimstone.API.RemoveAtom(inputAtomA);
                    Brimstone.API.RemoveAtom(inputAtomB);
                    pss.field_2743 = true;
                    pss.field_2744 = new AtomType[1] { outputAtom };
                    Brimstone.API.AddSmallCollider(sim, part, derivationOutput);
                }
                else if (pss.field_2743)
                {
                    Brimstone.API.AddAtom(sim, part, derivationOutput, pss.field_2744[0]);
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
                        if (!API.chargeToAtom.TryGetValue(chargeString, out outputAtom))
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
                Brimstone.API.ChangeAtom(sourceAtom, newSourceAtom);
                Brimstone.API.ChangeAtom(targetAtom, outputAtom);
            }
            else if (type == Shattering)
            {
                if (first)
                {
                    if (!sim.FindAtomRelative(part, shatterInput).method_99(out AtomReference inputAtom))
                    {
                        return;
                    }
                    // its a bowl, dont care if its held
                    if (inputAtom.field_2280 != Vacancy.VacaAtom)
                    {
                        return;
                    }
                    if (sim.FindAtomRelative(part, shatterOutLead).method_1085())
                    {
                        return;
                    }
                    if (sim.FindAtomRelative(part, shatterOutAnti).method_1085())
                    {
                        return;
                    }
                    Brimstone.API.RemoveAtom(inputAtom);
                    pss.field_2743 = true;
                    pss.field_2744 = new AtomType[2] { Vanilla.lead, AlchemicalInversions.Atoms.AntiLead };
                    Texture[] disposalFlashAnimation = class_238.field_1989.field_90.field_240;
                    Vector2 animationPosition = RM.MainClass.hexGraphicalOffset(part.method_1161() + new HexIndex(0, 0).Rotated(part.method_1163())) + new Vector2(80f, 0f);
                    SEB.field_3936.Add(new class_228(SEB, (enum_7)1, animationPosition, disposalFlashAnimation, 30f, Vector2.Zero, 0f));
                }
                else if (pss.field_2743)
                {
                    Brimstone.API.AddAtom(sim, part, shatterOutLead, pss.field_2744[0]);
                    Brimstone.API.AddAtom(sim, part, shatterOutAnti, pss.field_2744[1]);
                }
            }
            else if (type == Refraction)
            {
                if (first)
                {
                    AtomReference inputA;
                    AtomReference inputB;
                    string emptyIris = "C";
                    bool hasA = sim.FindAtomRelative(part, refractIrisA).method_1085();
                    bool hasB = sim.FindAtomRelative(part, refractIrisB).method_1085();
                    bool hasC = sim.FindAtomRelative(part, refractIrisC).method_1085();
                    if (hasA && hasB && !hasC)
                    {
                        pss.field_2744 = new AtomType[3] { Vanilla.mors, Vanilla.mors, Vanilla.vitae };
                        sim.FindAtomRelative(part, refractIrisA).method_99(out inputA);
                        sim.FindAtomRelative(part, refractIrisB).method_99(out inputB);
                        emptyIris = "C";
                    }
                    else if (hasA && !hasB && hasC)
                    {
                        pss.field_2744 = new AtomType[3] { Vanilla.mors, Vanilla.vitae, Vanilla.mors };
                        sim.FindAtomRelative(part, refractIrisA).method_99(out inputA);
                        sim.FindAtomRelative(part, refractIrisC).method_99(out inputB);
                        emptyIris = "B";
                    }
                    else if (!hasA && hasB && hasC)
                    {
                        pss.field_2744 = new AtomType[3] { Vanilla.vitae, Vanilla.mors, Vanilla.mors };
                        sim.FindAtomRelative(part, refractIrisB).method_99(out inputA);
                        sim.FindAtomRelative(part, refractIrisC).method_99(out inputB);
                    }
                    else
                    {
                        return;
                    }
                    if (inputA.field_2281 || inputA.field_2282)
                    {
                        return;
                    }
                    if (inputB.field_2281 || inputB.field_2282)
                    {
                        return;
                    }
                    foreach (PrimaMateria.API.InversionRecipe recipe in PrimaMateria.API.InversionTransmutation)
                    {
                        if (recipe.input == inputA.field_2280 && recipe.output == inputB.field_2280)
                        {
                            pss.field_2743 = true;
                            pss.field_2744 = Helpers.RefractionGlyphBehaviour(emptyIris, inputA.field_2280, inputB.field_2280);
                            Brimstone.API.DrawFallingAtom(SEB, inputA);
                            Brimstone.API.DrawFallingAtom(SEB, inputB);
                            Brimstone.API.RemoveAtom(inputA);
                            Brimstone.API.RemoveAtom(inputB);
                            if (emptyIris == "A")
                            {
                                Brimstone.API.AddSmallCollider(sim, part, refractIrisA);
                            }
                            else if (emptyIris == "B")
                            {
                                Brimstone.API.AddSmallCollider(sim, part, refractIrisB);
                            }
                            else
                            {
                                Brimstone.API.AddSmallCollider(sim, part, refractIrisC);
                            }
                        }
                    }
                }
                else if (pss.field_2743)
                {
                    AtomType[] A = new AtomType[3] { Noble.Alpha, Noble.Beta, Noble.Gamma };
                    if (A.Contains(pss.field_2744[0]))
                    {
                        Brimstone.API.AddAtom(sim, part, refractIrisA, pss.field_2744[0]);
                    }
                    else if (A.Contains(pss.field_2744[1]))
                    {
                        Brimstone.API.AddAtom(sim, part, refractIrisB, pss.field_2744[1]);
                    }
                    else
                    {
                        Brimstone.API.AddAtom(sim, part, refractIrisC, pss.field_2744[2]);
                    }
                }
            }
            else if (type == Subjection)
            {
                bool hasHigh = sim.FindAtomRelative(part, SubjectionHigh).method_99(out AtomReference atomHigh);
                bool hasLow = sim.FindAtomRelative(part, SubjectionLow).method_99(out AtomReference atomLow);
                if (hasHigh)
                {
                    if (!Helpers.PromoteAtom(atomHigh.field_2280, 0, out _)) //check if metal
                    {
                        return;
                    }
                    if (!hasLow)
                    {
                        return;
                    }
                    if (!API.Quixinary.TryGetValue(atomLow.field_2280, out int metallicity))
                    { //not quix
                        return;
                    }
                    if (Helpers.PromoteAtom(atomHigh.field_2280, metallicity, out AtomType output))
                    {
                        Brimstone.API.RemoveAtom(atomLow);
                        Helpers.DisposeAnimation(SubjectionLow, part, SEB);
                        Brimstone.API.ChangeAtom(atomHigh, output);
                        Helpers.RunTransmuteAnimation(SEB, atomHigh);
                    }

                }
                else if (hasLow)
                {
                    if (!Helpers.PromoteAtom(atomLow.field_2280, 0, out _)) //smh not coding by first principles
                    {
                        return;
                    }
                    if (API.negativeMetals.Contains(atomLow.field_2280))
                    {
                        if (!Helpers.PromoteAtom(atomLow.field_2280, 2, out AtomType output))
                        {
                            return;
                        }
                        Brimstone.API.ChangeAtom(atomLow, output);
                        Brimstone.API.AddAtom(sim, part, SubjectionHigh, MiraculumAtoms.Quicktin);
                    }
                    else
                    {
                        if (!Helpers.PromoteAtom(atomLow.field_2280, -2, out AtomType output))
                        {
                            return;
                        }
                        Brimstone.API.ChangeAtom(atomLow, output);
                        Brimstone.API.AddAtom(sim, part, SubjectionHigh, Vanilla.quicksilver);
                    }
                    Helpers.DisposeAnimation(SubjectionHigh, part, SEB);
                    Helpers.RunTransmuteAnimation(SEB, atomLow);
                }
            }
            else if (type == class_191.field_1776) // calcification
            {
                if (!sim.FindAtomRelative(part, new HexIndex(0, 0)).method_99(out AtomReference atom))
                {
                    return;
                }
                AtomType A = atom.field_2280;
                if (A != MiraculumAtoms.Ignis && A != MiraculumAtoms.Aqua && A != MiraculumAtoms.Caelum && A != MiraculumAtoms.Terra)
                {
                    return;
                }
                TrueSalt.API.saltAtoms.TryGetValue(2, out AtomType calcite);
                Brimstone.API.ChangeAtom(atom, calcite);
            }
            else if (type == class_191.field_1777) // duplication
            {
                MethodInfo RM_RUN = Brimstone.API.PrivateMethod<Sim>("method_1850");
                Maybe<AtomReference> maybeSource = (Maybe<AtomReference>)RM_RUN.Invoke(sim, new object[] { part, new HexIndex(0, 0), new List<Part>(), true });
                if (!maybeSource.method_99(out AtomReference source))
                {
                    return;
                }
                if (!sim.FindAtomRelative(part, new HexIndex(1, 0)).method_99(out AtomReference target))
                {
                    return;
                }
                if (!API.ReadDupeRecipe(target.field_2280, source.field_2280, out AtomType output))
                {
                    return;
                }
                Brimstone.API.ChangeAtom(target, output);
                Helpers.RunTransmuteAnimation(SEB, target);
            }
            else if (type == class_191.field_1778) // projection
            {
                if (!sim.FindAtomRelative(part, new HexIndex(0,0)).method_99(out AtomReference quix))
                {
                    return;
                }
                if (!sim.FindAtomRelative(part, new HexIndex(1, 0)).method_99(out AtomReference metal))
                {
                    return;
                }
                if (!API.Quixinary.TryGetValue(quix.field_2280, out int value))
                {
                    return;
                }
                if (value == 0 || value == 1 || value == 2)
                {
                    return; // already handled
                }
                if (!Helpers.PromoteAtom(metal.field_2280, value, out AtomType output))
                {
                    return;
                }
                Brimstone.API.RemoveAtom(quix);
                Brimstone.API.DrawFallingAtom(SEB, quix);
                Brimstone.API.ChangeAtom(metal, output);
                Helpers.RunTransmuteAnimation(SEB, metal);
            }
        });
        QApi.RunAfterCycle((sim, first) => {
            SolutionEditorBase SEB = sim.field_3818;
            List<Part> parts = SEB.method_502().field_3919;
            bool shouldFire = !first;
            foreach (Part part in parts)
            {
                PartType type = part.method_1159();
                if (type == Refraction)
                {
                    bool hasA = sim.FindAtomRelative(part, refractIrisA).method_1085();
                    bool hasB = sim.FindAtomRelative(part, refractIrisB).method_1085();
                    bool hasC = sim.FindAtomRelative(part, refractIrisC).method_1085();
                    Brimstone.API.GetRenderingHelpers(part, new Vector2 (0,0), SEB, out PartSimState pss, out PartDataWrapper pdw, out float time);
                    if (hasA && hasB && !hasC)
                    {
                        pss.field_2744 = new AtomType[3] { Vanilla.mors, Vanilla.mors, Vanilla.vitae };
                    }
                    else if (hasA && !hasB && hasC)
                    {
                        pss.field_2744 = new AtomType[3] { Vanilla.mors, Vanilla.vitae, Vanilla.mors };
                    }
                    else if (!hasA && hasB && hasC)
                    {
                        pss.field_2744 = new AtomType[3] { Vanilla.vitae, Vanilla.mors, Vanilla.mors };
                    }
                    // do nothing. this is just for render.
                }
            }
        });
    }

}

