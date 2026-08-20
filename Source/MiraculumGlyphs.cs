using Brimstone;
using Quintessential;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalvingMetallurgy;
using PartType = class_139;
using Texture = class_256;

namespace MiraculumEdere;

public static class MiraculumGlyphs
{
    public static PartType Reordering;


    public static readonly HexIndex reorderingInput = new(-1, 0);
    public static readonly HexIndex reorderingOutput = new(1, 0);
    public static readonly HexIndex reorderingBuffer = new(0, 0);

    public static Texture placeholder = Brimstone.API.GetTexture();

    public static void AddPartTypes()
    {
        Reordering = Brimstone.API.CreateSimpleGlyph(
            ID: "miraculum-edere-reodering",
            name: "Glyph of Reordering",
            description: "Given a first order metal, returns the second-order conjugate, or the atom whos metallicity add with the input to reach gold. Given a second-order metal, returns the first-order conjugate. Requires a buffer metal to draw or dump excess metallicity.",
            cost: 30,
            glow: Brimstone.API.GetTexture("textures/parts/MiraculumEdere/reordering/glow"),
            stroke: Brimstone.API.GetTexture("textures/parts/MiraculumEdere/reordering/stroke"),
            icon: placeholder,
            hoveredIcon: placeholder,
            usedHexes: new HexIndex[] { reorderingInput, reorderingOutput, reorderingBuffer },
            customPermission: "Miraculum:Reordering"
        );  
        QApi.AddPartTypeToPanel(Reordering, false);

        QApi.AddPartType(Reordering, static (part, pos, editor, renderer) =>
        {
            renderer.method_523(Brimstone.API.GetTexture("textures/parts/MiraculumEdere/reordering/base"), new Vector2(0f, 0f), new Vector2(126f, 48f), 0);

        });

        QApi.RunDuringCycle(static (sim, part, pss, first) =>
        {
            SolutionEditorBase SEB = sim.field_3818;
            List<Part> parts = SEB.method_502().field_3919;
            PartType type = part.method_1159();
            if (type == Reordering)
            {
                if (first)
                {
                    if (sim.FindAtomRelative(part, reorderingOutput).method_1085())
                    {
                        return;
                    }
                    if (!sim.FindAtomRelative(part, reorderingBuffer).method_99(out AtomReference bufferAtom))
                    {
                        return;
                    }
                    if (!sim.FindAtomRelative(part, reorderingInput).method_99(out AtomReference inputAtom))
                    {
                        return;
                    }
                    HexIndex input = part.method_1184(reorderingInput);
                    HexIndex buffer = part.method_1184(reorderingBuffer);
                    HexIndex output = part.method_1184(reorderingOutput);

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
                    if (outputMetallicity == 0)
                    {
                        return; //TO DO: add vaca here
                    }
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
                    Brimstone.API.RemoveAtom(inputAtom);
                    Brimstone.API.DrawFallingAtom(SEB, inputAtom);
                    Brimstone.API.ChangeAtom(bufferAtom, newBufferAtom);
                    pss.field_2743 = true;
                    pss.field_2744 = new AtomType[1] { outputAtom };
                    Brimstone.API.AddSmallCollider(sim, part, output);
                }
                else if (pss.field_2743)
                {

                    Brimstone.API.AddAtom(sim, part, reorderingOutput, pss.field_2744[0]);
                }
            }
        });
    }
}
