using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SolidEdgeFramework;

namespace ProjeMacro
{
    class AbrirAllDrafts
    {

        public static void AbrirListaCodigosLimpa()
        {
            

            string logg;

            SolidEdgeFramework.Application seApp;
            SolidEdgeFramework.Documents seDoc;

            seApp = SolidEdgeCommunity.SolidEdgeUtils.Connect(true);

            seDoc = seApp.Documents;

            logg = "Arquivos Abertos pelo aplicativo para impressao. \n\r";
            logg += "  \n\r";
            logg += "Aberto por " + Mainn.Usuario +  "  \n\r";
            logg += "  \n\r";

            int contador = 0;

            Console.WriteLine("Pular lote de folhas? S para sim, qualquer outra para não.");
            string pular = Console.ReadLine();
            if (pular == "s" || pular == "S")
            {
                contador = 9999;
                Console.WriteLine("Pulando 70 folhas...");
            }
            
            
            for (int i = 0; i < Mainn.codigosImpressao.Count; i++)
            {



                if (contador > 70)
                {

                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.WriteLine("70 desenhos abertos, aperte qualquer tecla para continuar a abrir");
                    Console.WriteLine("Ira fechar E SALVAR todos os DFTs abertos ( exceto os Read Only )");
                    Console.ReadKey();
                    FuncoesGeral.SalvarFecharTodosArquivosAbertos(true);
                    contador = 0;

                } else {

                    if (contador == 9999)
                    {
                        i = i + 70;
                    }

                    AbrirDftDaLista(seDoc, Mainn.codigosImpressao[i].Path);

                    logg += Mainn.codigosImpressao[i].Path.ToString() + " - \n\r ";

                    contador++;
                
                }
            }

            SalvarLogImpressao(logg , Mainn.nome);
        }

        public static void SalvarLogImpressao(string logg, string nome)
        {
            Random rnd = new Random();
            int rand = rnd.Next(1000, 9999);

            using (StreamWriter sw = File.CreateText(@"\\fs\e\Projetos\ProjeMacroListas\ImpressoesControle\" + nome + " - " + Mainn.Usuario + " - " + rand.ToString() + ".txt"))
            {
                sw.WriteLine("Impressao feita pelo arquivo " + nome);
                sw.Write(logg);

            }
        }

        public static void AbrirDftDaLista(SolidEdgeFramework.Documents seDoc, string pathhh)
        {

            //lista exclusao

            SolidEdgeDraft.DraftDocument docc;

            
            string dftPath = TrocarAssPorDft(pathhh);
            if (File.Exists(dftPath))
            {
                docc = (SolidEdgeDraft.DraftDocument)seDoc.Open(dftPath);
                docc.UpdateAll(false);
                Console.WriteLine("Abrindo " + dftPath + " ...");
                System.Threading.Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine("Arquivo " + dftPath + " nao existe");
            }


        }


        public static void AbrirDaAssembly()
        {
            SolidEdgeFramework.Application seApp;
            SolidEdgeFramework.Documents seDoc;
            SolidEdgeFramework.SolidEdgeDocument documento; // usando o document não precisa saber se é peça, assembly, chapa etc.

            SolidEdgeAssembly.AssemblyDocument assem;
            SolidEdgeAssembly.Occurrences arrayOccurences;


            seApp = SolidEdgeCommunity.SolidEdgeUtils.Connect(true);

            seDoc = seApp.Documents;

            assem = (SolidEdgeAssembly.AssemblyDocument)seApp.ActiveDocument;

            arrayOccurences = (SolidEdgeAssembly.Occurrences)assem.Occurrences;


            AbrirDft(seDoc, assem.FullName, assem.Name); // funcao troca o nome testa se existe e abre o dft


            foreach (SolidEdgeAssembly.Occurrence itemm in arrayOccurences)
            {
                if (itemm.IncludeInBom == true)
                {
                    AbrirDaOccurence(itemm, seDoc);
                }

            }
        }

        public static void AbrirDaOccurence(SolidEdgeAssembly.Occurrence occurrencee, SolidEdgeFramework.Documents seDoc)
        {
            if (occurrencee.Type.ToString() == "igSubAssembly")
            {
                SolidEdgeAssembly.AssemblyDocument assem2;
                SolidEdgeAssembly.Occurrences arrayOccurences2;


                assem2 = (SolidEdgeAssembly.AssemblyDocument)occurrencee.OccurrenceDocument;
                arrayOccurences2 = (SolidEdgeAssembly.Occurrences)assem2.Occurrences;

                AbrirDft(seDoc, assem2.FullName, assem2.Name);


                foreach (SolidEdgeAssembly.Occurrence itemm in arrayOccurences2)
                {
                    if (itemm.IncludeInBom == true)
                    {
                        AbrirDaOccurence(itemm, seDoc);
                    }
                        

                }
            }
            else
            {
                SolidEdgeFramework.SolidEdgeDocument documento;

                documento = (SolidEdgeFramework.SolidEdgeDocument)occurrencee.OccurrenceDocument;
                AbrirDft(seDoc, documento.FullName, documento.Name);
            }

        }

        public static string TrocarAssPorDft(string pathh)
        {
            string pathDft;

            pathDft = pathh.Substring(0, pathh.Length - 3) + "dft";

            return pathDft;
        }

        public static void AbrirDft(SolidEdgeFramework.Documents seDoc, string pathhh, string codd)
        {

            //lista exclusao

            SolidEdgeDraft.DraftDocument docc;

            codd = codd.Substring(0, codd.Length - 4) ;

            for ( int i = 0; i < Mainn.arrayExclusao.Length; i++ )
            {
                if(codd == Mainn.arrayExclusao[i])
                {
                    Console.WriteLine("Excluido item " + pathhh + " por " + Mainn.arrayExclusao[i]);
                    return;
                }
            }
            

            string dftPath = TrocarAssPorDft(pathhh);
            if (File.Exists(dftPath))
            {
                docc = (SolidEdgeDraft.DraftDocument)seDoc.Open(dftPath);
                docc.UpdateAll(false);
                Console.WriteLine("Abrindo " + dftPath + " ...");
                System.Threading.Thread.Sleep(1000);
            } else
            {
                Console.WriteLine("Arquivo " + dftPath + " nao existe");
            }


        }


    }
}
