using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Brimstone;
using Quintessential;
using Texture = class_256;

namespace MiraculumEdere;

public static class MiraculumAtoms
{
    public static AtomType Aluminium, Indium, Ferrum, Cerium, Neodynium, Titanium, Ignotum;
    public static Texture placeholder = Brimstone.API.GetTexture();
    public static void AddAtomTypes()
    {
        Ignotum = Brimstone.API.CreateNormalAtom( 
            ID: 255,
            modName: "MiraculumEdere",
            name: "Ignotum",
            pathToSymbol: "Quintessential/missing",
            pathToDiffuse: "Quintessential/missing",
            pathToShade: "Quintessential/missing",
            pathToShadow: "Quintessential/missing"
        );
        Titanium = Brimstone.API.CreateMetalAtom(
            ID: 166,
            modName: "MiraculumEdere",
            name: "Titanium",
            pathToSymbol: "textures/atoms/MiraculumEdere/SOHM/titanium_symbol",
            pathToLightramp: "textures/atoms/MiraculumEdere/SOHM/titanium_lightramp",
            pathToRimlight: "textures/atoms/iron_rimlight" //PLACEHOLDER
        );
        Neodynium = Brimstone.API.CreateMetalAtom(
            ID: 165,
            modName: "MiraculumEdere",
            name: "Neodynium",
            pathToSymbol: "textures/atoms/MiraculumEdere/SOHM/neodynium_symbol",
            pathToLightramp: "textures/atoms/MiraculumEdere/SOHM/neodynium_lightramp",
            pathToRimlight: "textures/atoms/iron_rimlight", //PLACEHOLDER
            promotesTo: Titanium
        );
        Cerium = Brimstone.API.CreateMetalAtom(
            ID: 164,
            modName: "MiraculumEdere",
            name: "Cerium",
            pathToSymbol: "textures/atoms/MiraculumEdere/SOHM/cerium_symbol",
            pathToLightramp: "textures/atoms/MiraculumEdere/SOHM/cerium_lightramp",
            pathToRimlight: "textures/atoms/iron_rimlight", //PLACEHOLDER
            promotesTo: Neodynium
        );
        Ferrum = Brimstone.API.CreateMetalAtom(
            ID: 163,
            modName: "MiraculumEdere",
            name: "Ferrum",
            pathToSymbol: "textures/atoms/MiraculumEdere/SOHM/ferrum_symbol",
            pathToLightramp: "textures/atoms/iron_lightramp", // just iron
            pathToRimlight: "textures/atoms/iron_rimlight", //its just iron
            promotesTo: Cerium
        );
        Indium = Brimstone.API.CreateMetalAtom(
            ID: 162,
            modName: "MiraculumEdere",
            name: "Indium",
            pathToSymbol: "textures/atoms/MiraculumEdere/SOHM/indium_symbol",
            pathToLightramp: "textures/atoms/MiraculumEdere/SOHM/indium_lightramp",
            pathToRimlight: "textures/atoms/iron_rimlight", //PLACEHOLDER
            promotesTo: Ferrum
        );
        Aluminium = Brimstone.API.CreateMetalAtom(
            ID: 161,
            modName: "MiraculumEdere",
            name: "Aluminium",
            pathToSymbol: "textures/atoms/MiraculumEdere/SOHM/aluminium_symbol",
            pathToLightramp: "textures/atoms/MiraculumEdere/SOHM/aluminium_lightramp",
            pathToRimlight: "textures/atoms/iron_rimlight", //PLACEHOLDER
            promotesTo: Indium
        );
        QApi.AddAtomType(Aluminium);
        QApi.AddAtomType(Indium);
        QApi.AddAtomType(Ferrum);
        QApi.AddAtomType(Cerium);
        QApi.AddAtomType(Neodynium);
        QApi.AddAtomType(Titanium);
    }
    
}