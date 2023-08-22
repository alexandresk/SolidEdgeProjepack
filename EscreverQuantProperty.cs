using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidEdgeFramework;

namespace ProjeMacro
{
    class EscreverQuantProperty
    {


        /*public static void AddNoProjeto ()
        {
            SolidEdgeFramework.Application seApp;
            SolidEdgeFramework.Documents seDoc;
            SolidEdgeFramework.SolidEdgeDocument documento; // usando o document não precisa saber se é peça, assembly, chapa etc.

            SolidEdgeAssembly.AssemblyDocument assem;
            SolidEdgeAssembly.Occurrences arrayOccurences;


            SolidEdgeFramework.PropertySets propertySets;
            SolidEdgeFramework.Properties propriedades;

            Console.WriteLine("Digite o valor com o nome do Projeto" );

            string projeto = Console.ReadLine();


            seApp = SolidEdgeCommunity.SolidEdgeUtils.Connect(true);

            seDoc = seApp.Documents;

            assem = (SolidEdgeAssembly.AssemblyDocument)seApp.ActiveDocument;

            arrayOccurences = (SolidEdgeAssembly.Occurrences)assem.Occurrences;

                //Console.WriteLine(assem.Name);
                //Class2.codigos.Add(new ListaCodigos(assem.Name.Split('.')[0], assem.Path, 1, 0, "", ""));


            foreach (SolidEdgeAssembly.Occurrence itemm in arrayOccurences)
                {
                    documento = (SolidEdgeFramework.SolidEdgeDocument)itemm.OccurrenceDocument;

                    propertySets = (PropertySets)documento.Properties;

                    propriedades = (SolidEdgeFramework.Properties)propertySets.Item("Custom");

                    //string projeto = propriedades.Item("Projeto").get_Value().ToString();

                    //Class2.codigos.Add(new ListaCodigos(itemm.Name.Split('.')[0], itemm.PartFileName, 1, 1, nomee, projeto));

                    for (int i = 0; i < Mainn.codigosUnicosLimpa.Count; i++)
                    {
                        if(Mainn.codigosUnicosLimpa[i].Path == itemm.PartFileName )
                        {
                            //if(!projeto.Contains("( Q: " + Mainn.codigosUnicosLimpa[i].Quant + ")"))
                            if(true)
                            {
                                Console.WriteLine("Adicionando quantidade a o campo projeto - " + itemm.PartFileName);
                                string projetoNovo = projeto + " ( Q: " + Mainn.codigosUnicosLimpa[i].Quant + ")";
                                propriedades.Add("Projeto", projetoNovo);
                            }

                        }

                    }


                    //TestSeAsmPrint(itemm, 2, path);

            }


        }*/


        public static string LerQuantCodigoListaUnica(string codigo)
        {
            string r = "";

            for(int i = 0; i < Mainn.codigosUnicos.Count; i++)
            {
                if( codigo == Mainn.codigosUnicos[i].Codigo)
                {
                    r = Mainn.codigosUnicos[i].Quant.ToString();
                }
            }

            return r;

        }
    }
}
