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

internal static class Textures
{
    public static Texture[] glyphEffect = Brimstone.API.GetAnimation("textures/parts/glyph_flash.array", "glyph_flash", 5);
    public static readonly Texture placeholder = Brimstone.API.GetTexture();

    public static readonly Texture[] transmuteCalcify = Brimstone.API.GetAnimation("textures/atoms/calcify_mask.array", "calcify", 6);
    public static readonly Texture[] transmuteDupe = Brimstone.API.GetAnimation("textures/atoms/duplicate_mask.array", "duplicate", 6);

    public static readonly Texture Input_Ring = Brimstone.API.GetTexture("textures/parts/output_ring");
    public static readonly Texture Hole_Shadow = Brimstone.API.GetTexture("textures/parts/output_shadow");
    public static readonly Texture Bowl = Brimstone.API.GetTexture("textures/parts/calcinator_bowl");

    public static readonly Texture MetalBowl = Brimstone.API.GetTexture("textures/parts/projection_glyph/metal_bowl");

    //bases
    public static readonly Texture baseConjurgation = Brimstone.API.GetTexture("textures/parts/MiraculumEdere/conjurgation/base");
    public static readonly Texture baseDerivation = Brimstone.API.GetTexture("textures/parts/MiraculumEdere/derivation/base");
    public static readonly Texture baseAscent = Brimstone.API.GetTexture("textures/parts/MiraculumEdere/ascent/base");
    public static readonly Texture baseDeconstruction = Brimstone.API.GetTexture("textures/parts/MiraculumEdere/deconstruction/base");
    public static readonly Texture baseConvolution = Brimstone.API.GetTexture("textures/parts/MiraculumEdere/convolution/base");
    public static readonly Texture baseFragmentation = Brimstone.API.GetTexture("textures/parts/MiraculumEdere/fragmentation/base");
    public static readonly Texture baseJudgement = Brimstone.API.GetTexture("textures/parts/MiraculumEdere/judgement/base");
    public static readonly Texture baseShattering = Brimstone.API.GetTexture("textures/parts/MiraculumEdere/shattering/base");
    public static readonly Texture baseRefraction = Brimstone.API.GetTexture("textures/parts/MiraculumEdere/refraction/base");
    public static readonly Texture baseSubjection = Brimstone.API.GetTexture("textures/parts/MiraculumEdere/subjection/base");
    public static readonly Texture baseAtwix = Brimstone.API.GetTexture("textures/parts/MiraculumEdere/atwix/base");
    public static readonly Texture baseDissipation = Brimstone.API.GetTexture("textures/parts/MiraculumEdere/dissipation/base");
    public static readonly Texture baseConcurrence = Brimstone.API.GetTexture("textures/parts/MiraculumEdere/concurrence/base");
    public static readonly Texture baseReposition = Brimstone.API.GetTexture("textures/parts/MiraculumEdere/reposition/base");

    public static readonly Texture subjectUp = Brimstone.API.GetTexture("textures/parts/MiraculumEdere/subjection/arrow_up");
    public static readonly Texture subjectDown = Brimstone.API.GetTexture("textures/parts/MiraculumEdere/subjection/arrow_down");
    public static readonly Texture gold_titan = Brimstone.API.GetTexture("textures/parts/MiraculumEdere/deconstruction/gold_titanium");
    public static readonly Texture second_order = Brimstone.API.GetTexture("textures/parts/MiraculumEdere/ascent/second_order");
    public static readonly Texture pos_metal = Brimstone.API.GetTexture("textures/parts/MiraculumEdere/conjurgation/pos_metal");
    public static readonly Texture pos_metal_hole = Brimstone.API.GetTexture("textures/parts/MiraculumEdere/conjurgation/pos_metal_hole");
    public static readonly Texture vaca_only = Brimstone.API.GetTexture("textures/parts/MiraculumEdere/shattering/vaca");
    public static readonly Texture judge_A = Brimstone.API.GetTexture("textures/parts/MiraculumEdere/judgement/judgeA");
    public static readonly Texture judge_B = Brimstone.API.GetTexture("textures/parts/MiraculumEdere/judgement/judgeB");
    public static readonly Texture repos_symbols = Brimstone.API.GetTexture("textures/parts/MiraculumEdere/reposition/symbolRepos");

    public static readonly Texture cardinals = Brimstone.API.GetTexture("textures/parts/MiraculumEdere/atwix/cardinals");

    public static readonly Texture triaPrimae = Brimstone.API.GetTexture("textures/parts/PrimaMateria/synthesis/prime_symbol");
}
