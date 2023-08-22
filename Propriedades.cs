using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidEdgeFramework;
using SolidEdgeAssembly;
using SolidEdgeCommunity;
using System.Threading;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Net;

namespace ProjeMacro
{
    class Propriedades
    {


        public static string[] LerTodasCustom(SolidEdgeFramework.SolidEdgeDocument doc)
        {
            string[] props = new string[12];
            props[11] = "";
            props[10] = "";

            SolidEdgeFramework.PropertySets propertySets;
            SolidEdgeFramework.Properties propriedades;
            SolidEdgeFramework.Property prop;

            propertySets = (PropertySets)doc.Properties;
            propriedades = (SolidEdgeFramework.Properties)propertySets.Item("Custom");

            for (int z = 1; z <= propriedades.Count; z++)
            {
                prop = propriedades.Item(z);
                //Console.WriteLine("Lendo props de  " + prop.Name);

                switch (prop.Name)
                {
                    case "Nome":
                        props[0] = prop.get_Value().ToString();
                        break;
                    case "Projeto":
                        props[1] = prop.get_Value().ToString();
                        break;
                    case "Descrição 1":
                        props[2] = prop.get_Value().ToString();
                        break;
                    case "Descrição 2":
                        props[3] = prop.get_Value().ToString();
                        break;
                    case "Descrição 3":
                        props[4] = prop.get_Value().ToString();
                        break;
                    case "Operação 1":
                        props[5] = prop.get_Value().ToString();
                        break;
                    case "Operação 2":
                        props[6] = prop.get_Value().ToString();
                        break;
                    case "Operação 3":
                        props[7] = prop.get_Value().ToString();
                        break;
                    case "Operação 4":
                        props[8] = prop.get_Value().ToString();
                        break;
                    case "Operação 5":
                        props[9] = prop.get_Value().ToString();
                        break;
                    case "Tempo":
                        props[10] = prop.get_Value().ToString();
                        break;
                    case "Pcp":
                        props[11] = prop.get_Value().ToString();
                        break;
                    case "PCP":
                        props[11] = prop.get_Value().ToString();
                        break;
                    case "pcp":
                        props[11] = prop.get_Value().ToString();
                        break;
                    default:
                        // code block
                        break;
                }

            }

            return props;
        }



        public static double[] LerFisicas(SolidEdgePart.Model model)
        {
            double[] props = new double[3];

            double density = 0;
            double accuracy = 0;
            double volume = 0;
            double area = 0;
            double mass = 0;
            Array cetnerOfGravity = Array.CreateInstance(typeof(double), 3);
            Array centerOfVolumne = Array.CreateInstance(typeof(double), 3);
            Array globalMomentsOfInteria = Array.CreateInstance(typeof(double), 6);     // Ixx, Iyy, Izz, Ixy, Ixz and Iyz 
            Array principalMomentsOfInteria = Array.CreateInstance(typeof(double), 3);  // Ixx, Iyy and Izz
            Array principalAxes = Array.CreateInstance(typeof(double), 9);              // 3 axes x 3 coords
            Array radiiOfGyration = Array.CreateInstance(typeof(double), 9);            // 3 axes x 3 coords
            double relativeAccuracyAchieved = 0;
            int status = 0;

            //model = parte.Models.Item(1);
            model.GetPhysicalProperties(
                 Status: out status,
                 Density: out density,
                 Accuracy: out accuracy,
                 Volume: out volume,
                 Area: out area,
                 Mass: out mass,
                 CenterOfGravity: ref cetnerOfGravity,
                 CenterOfVolume: ref centerOfVolumne,
                 GlobalMomentsOfInteria: ref globalMomentsOfInteria,
                 PrincipalMomentsOfInteria: ref principalMomentsOfInteria,
                 PrincipalAxes: ref principalAxes,
                 RadiiOfGyration: ref radiiOfGyration,
                 RelativeAccuracyAchieved: out relativeAccuracyAchieved);

            //Console.WriteLine(volume);
            //Console.WriteLine(area);
            //Console.WriteLine(mass);

            props[0] = volume;
            props[1] = area;
            props[2] = mass;

            return props;

        }

        public static double[] ChecarArquivoEAbrirFisicas(SolidEdgeAssembly.Occurrence occurrencee)
        {
            double[] props = new double[3];

            if (occurrencee.Type.ToString() != "igSubAssembly")
            {
                SolidEdgePart.SheetMetalDocument sheet = null;
                SolidEdgePart.PartDocument part = null;
                SolidEdgePart.Model model;

                if(occurrencee.PartFileName.Substring(occurrencee.PartFileName.Length - 3) == "psm")
                {
                    sheet = occurrencee.PartDocument as SolidEdgePart.SheetMetalDocument;
                    model = sheet.Models.Item(1);
                    props = LerFisicas(model);
                }

                if (occurrencee.PartFileName.Substring(occurrencee.PartFileName.Length - 3) == "par")
                {
                    // part = seApp.ActiveDocument as SolidEdgePart.PartDocument;
                    part = occurrencee.PartDocument as SolidEdgePart.PartDocument;
                    model = part.Models.Item(1);
                    props = LerFisicas(model);
                }
            }
            return props;
        }


    }
}
