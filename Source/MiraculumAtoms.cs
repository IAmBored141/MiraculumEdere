using Brimstone;
using Quintessential;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Texture = class_256;

namespace MiraculumEdere;

public static class MiraculumAtoms
{
    public static AtomType Aluminium, Indium, Ferrum, Cerium, Neodynium, Titanium, Ignotum;
    public static AtomType Quickgold, Quickiron, Quicktin, Quicklead;
    public static AtomType Humita, Temperum, Ignis, Aqua, Terra, Caelum;
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

        // quix
        Quicklead = Brimstone.API.CreateNormalAtom(
            ID: 167,
            modName: "MiraculumEdere",
            name: "Quicklead",
            pathToSymbol: "textures/atoms/MiraculumEdere/quix/quicklead_symbol",
            pathToDiffuse: "textures/atoms/MiraculumEdere/quix/quicklead_diffuse",
            pathToShade: "textures/atoms/MiraculumEdere/quix/quicklead_shade",
            pathToShadow: "textures/atoms/shadow"
        );
        //quicktin
        Quicktin = Brimstone.API.CreateNormalAtom(
            ID: 168,
            modName: "MiraculumEdere",
            name: "Quicktin",
            pathToSymbol: "textures/atoms/MiraculumEdere/quix/quicktin_symbol",
            pathToDiffuse: "textures/atoms/MiraculumEdere/quix/quicktin_diffuse",
            pathToShade: "textures/atoms/salt_shade",
            pathToShadow: "textures/atoms/shadow"
        );
        Quickiron = Brimstone.API.CreateNormalAtom(
            ID: 169,
            modName: "MiraculumEdere",
            name: "Quickiron",
            pathToSymbol: "textures/atoms/MiraculumEdere/quix/quickiron_symbol",
            pathToDiffuse: "textures/atoms/MiraculumEdere/quix/quickiron_diffuse",
            pathToShade: "textures/atoms/salt_shade",
            pathToShadow: "textures/atoms/shadow"
        );
        Quickgold = Brimstone.API.CreateNormalAtom(
            ID: 170,
            modName: "MiraculumEdere",
            name: "Quickgold",
            pathToSymbol: "textures/atoms/MiraculumEdere/quix/quickgold_symbol",
            pathToDiffuse: "textures/atoms/MiraculumEdere/quix/quickgold_diffuse",
            pathToShade: "textures/atoms/MiraculumEdere/quix/quickgold_shade",
            pathToShadow: "textures/atoms/shadow"
        );
        Humita = Brimstone.API.CreateNormalAtom(
            ID: 171,
            modName: "MiraculumEdere",
            name: "Humita",
            pathToSymbol: "textures/atoms/MiraculumEdere/cardinals/humita_symbol",
            pathToDiffuse: "textures/atoms/salt_diffuse",
            pathToShade: "textures/atoms/salt_shade",
            pathToShadow: "textures/atoms/shadow"
        );
        Temperum = Brimstone.API.CreateNormalAtom(
            ID: 172,
            modName: "MiraculumEdere",
            name: "Temperum",
            pathToSymbol: "textures/atoms/MiraculumEdere/cardinals/temperum_symbol",
            pathToDiffuse: "textures/atoms/salt_diffuse",
            pathToShade: "textures/atoms/salt_shade",
            pathToShadow: "textures/atoms/shadow"
        );
        Ignis = Brimstone.API.CreateQuintessenceAtom(
            ID: 173,
            modName: "MiraculumEdere",
            name: "Ignis",
            pathToSymbol: "textures/atoms/MiraculumEdere/cardinals/ignis_symbol",
            pathToBase: "textures/atoms/elements/fire_base",
            pathToColors: "textures/atoms/elements/fire_base",
            pathToShadow: "textures/atoms/elements/fire_shadow"
        );
        Aqua = Brimstone.API.CreateQuintessenceAtom(
            ID: 174,
            modName: "MiraculumEdere",
            name: "Aqua",
            pathToSymbol: "textures/atoms/MiraculumEdere/cardinals/aqua_symbol",
            pathToBase: "textures/atoms/elements/water_base",
            pathToColors: "textures/atoms/elements/water_base",
            pathToShadow: "textures/atoms/elements/water_shadow"
        );
        Terra = Brimstone.API.CreateQuintessenceAtom(
            ID: 175,
            modName: "MiraculumEdere",
            name: "Terra",
            pathToSymbol: "textures/atoms/MiraculumEdere/cardinals/terra_symbol",
            pathToBase: "textures/atoms/elements/earth_base",
            pathToColors: "textures/atoms/elements/earth_base",
            pathToShadow: "textures/atoms/elements/earth_shadow"
        );
        Caelum = Brimstone.API.CreateQuintessenceAtom(
            ID: 176,
            modName: "MiraculumEdere",
            name: "Caelum",
            pathToSymbol: "textures/atoms/MiraculumEdere/cardinals/caelum_symbol",
            pathToBase: "textures/atoms/elements/air_base",
            pathToColors: "textures/atoms/elements/air_fog",
            pathToRimlight: "textures/atoms/elements/air_base2",
            pathToShadow: "textures/atoms/elements/air_shadow"
        );

        QApi.AddAtomType(Aluminium);
        QApi.AddAtomType(Indium);
        QApi.AddAtomType(Ferrum);
        QApi.AddAtomType(Cerium);
        QApi.AddAtomType(Neodynium);
        QApi.AddAtomType(Titanium);
        QApi.AddAtomType(Quicklead);
        QApi.AddAtomType(Quicktin);
        QApi.AddAtomType(Quickiron);
        QApi.AddAtomType(Quickgold);

        QApi.AddAtomType(Humita);
        QApi.AddAtomType(Temperum);
        QApi.AddAtomType(Ignis);
        QApi.AddAtomType(Aqua);
        QApi.AddAtomType(Terra);
        QApi.AddAtomType(Caelum);
    }
    
}