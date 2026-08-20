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

}
