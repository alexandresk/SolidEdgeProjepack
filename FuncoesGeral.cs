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
    class FuncoesGeral
    {

        public static void LerNomeDoUsuario()
        {
            if(File.Exists(@"C:\usuarioProjeMacro.txt"))
            {
                Mainn.Usuario = System.IO.File.ReadAllText(@"C:\usuarioProjeMacro.txt").ToString();

                Console.WriteLine("Nome usuario pego do arquivo em C:\\usuarioProjeMacro.txt Usuario: " + Mainn.Usuario);
            }
            else
            {
                Mainn.Usuario = "User";

                Console.WriteLine("Arquivo em C:\\usuarioProjeMacro.txt nao existe. Crie um com o nome de usuario dentro... ");
            }

        }

        public static double SomarPesoLista()
        {
            double peso = 0;

            for (int i = 0; i < Mainn.codigos.Count; i++)
            {
                peso += Mainn.codigos[i].Mass;
            }

            return peso;
        }


  
        public static void DesejaSalvarFecharTodosArquivosAbertos()
        {
            Console.WriteLine("Salvar e Fechar todos Arquivos? Digite S para Sim ou qualquer tecla para nao");
            string check = Console.ReadLine();
            if (check == "S")
            {
                SalvarFecharTodosArquivosAbertos(false);
            }
        }


        public static void SalvarFecharTodosArquivosAbertos(bool apenasDft)
        {
            SolidEdgeFramework.Application seApp;
            SolidEdgeFramework.Documents seDoc;
            SolidEdgeFramework.SolidEdgeDocument documento; // usando o document não precisa saber se é peça, assembly, chapa etc.

            seApp = SolidEdgeCommunity.SolidEdgeUtils.Connect(true);

            seDoc = seApp.Documents;

            for (int i = seDoc.Count; i > 0; i--)
            {
                documento = (SolidEdgeFramework.SolidEdgeDocument)seDoc.Item(i);

                if(apenasDft)
                {
                    if (documento.Name.Substring( documento.Name.Length - 3).ToString() == "dft")
                    {
                        Console.WriteLine("Salvando e Fechando DFT: " + documento.Name);

                        if (!documento.ReadOnly)
                        {
                            documento.Save();
                        }
                        documento.Close();
                        
                    }
                }
                else
                {
                    Console.WriteLine("Salvando e Fechando doc: " + documento.Name);

                    if (!documento.ReadOnly)
                    {
                        documento.Save();
                    }
                    documento.Close();
                }



            }

        }


       


        public static void AbrirArquivosPasta()
        {
            Console.WriteLine("Digite ou cole o caminho da pasta");

            string caminho = Console.ReadLine();

            SolidEdgeFramework.Application seApp;
            SolidEdgeFramework.Documents seDoc;


            seApp = SolidEdgeCommunity.SolidEdgeUtils.Connect(true);

            seDoc = seApp.Documents;

            SolidEdgeDocument docc;


            string[] arquivos = Directory.GetFiles(caminho);

            for (int i = 0; i < arquivos.Length; i++)
            {
                FileInfo fi = new FileInfo(arquivos[i]);
                if (fi.Extension.ToString() == ".asm" || fi.Extension.ToString() == ".psm" || fi.Extension.ToString() == ".par" || fi.Extension.ToString() == ".asm")
                {
                    Console.WriteLine("Arquivo encontrado na pasta: " + fi.Name + "  -  " + fi.Extension);

                    docc = (SolidEdgeDocument)seDoc.Open(arquivos[i]);
                }
            }
        }




        public static void AddCampoAsm(bool quantidade) // adiciona no campo Projeto de todos as peças de um assembly. INCLUI todos os occurences ( children )
        {
            string opcao = "";

            if (!quantidade)
            {
                Console.WriteLine("Digite o numero do campo:  1) Projeto    2) Cliente    3) Nome ");

                opcao = Console.ReadLine();

                if (opcao == "1") { opcao = "Projeto"; }
                if (opcao == "2") { opcao = "Cliente"; }
                if (opcao == "3") { opcao = "Nome"; }

                Console.WriteLine("Digite o valor com campo " + opcao);
            } else
            {
                Console.WriteLine("Digite nome do projeto");
                opcao = "Projeto";
            }



            string valorNovo = Console.ReadLine();

            Console.WriteLine(opcao + ": " + valorNovo);

            SolidEdgeFramework.Application seApp;
            SolidEdgeFramework.Documents seDoc;
            SolidEdgeFramework.SolidEdgeDocument documento; // usando o document não precisa saber se é peça, assembly, chapa etc.


            SolidEdgeFramework.PropertySets propertySets;
            SolidEdgeFramework.Properties propriedades;

            SolidEdgeAssembly.AssemblyDocument assem;
            SolidEdgeAssembly.Occurrences arrayOccurences;



            seApp = SolidEdgeCommunity.SolidEdgeUtils.Connect(true);

            seDoc = seApp.Documents;

            System.Threading.Thread.Sleep(1000);

            assem = (SolidEdgeAssembly.AssemblyDocument)seApp.ActiveDocument;

            arrayOccurences = (SolidEdgeAssembly.Occurrences)assem.Occurrences;

            

            propertySets = (PropertySets)assem.Properties;

            propriedades = (SolidEdgeFramework.Properties)propertySets.Item("Custom");

            propriedades.Add(opcao, valorNovo);

            foreach (SolidEdgeAssembly.Occurrence itemm in arrayOccurences)
            {
                if(itemm.IncludeInBom == true)
                {
                    Console.WriteLine(itemm.Name);

                    documento = (SolidEdgeFramework.SolidEdgeDocument)itemm.OccurrenceDocument;

                    propertySets = (PropertySets)documento.Properties;

                    propriedades = (SolidEdgeFramework.Properties)propertySets.Item("Custom");

                    string valorNovoQuant = valorNovo + " Quant: " + EscreverQuantProperty.LerQuantCodigoListaUnica(itemm.Name.Split('.')[0]);

                    propriedades.Add(opcao, valorNovoQuant);

                    AssCampoAsmOccurences(itemm, opcao, valorNovo);
                }



            }

                //Console.ReadKey();

        }

        public static void AssCampoAsmOccurences(SolidEdgeAssembly.Occurrence occurrencee, string opcao, string valorNovo) // se documento é asm printar no console os occurences ( children )
        {
            if (occurrencee.Type.ToString() == "igSubAssembly")
            {

                Console.WriteLine(" É asm :  ");

                SolidEdgeAssembly.AssemblyDocument assem2;
                SolidEdgeAssembly.Occurrences arrayOccurences2;

                SolidEdgeFramework.SolidEdgeDocument documento;
                SolidEdgeFramework.PropertySets propertySets2;
                SolidEdgeFramework.Properties propriedades2;


                assem2 = (SolidEdgeAssembly.AssemblyDocument)occurrencee.OccurrenceDocument;
                arrayOccurences2 = (SolidEdgeAssembly.Occurrences)assem2.Occurrences;

                foreach (SolidEdgeAssembly.Occurrence itemm in arrayOccurences2)
                {
                    if (itemm.IncludeInBom == true)
                    {
                        Console.WriteLine(itemm.Name);

                        documento = (SolidEdgeFramework.SolidEdgeDocument)itemm.OccurrenceDocument;

                        propertySets2 = (PropertySets)documento.Properties;

                        propriedades2 = (SolidEdgeFramework.Properties)propertySets2.Item("Custom");

                        string valorNovoQuant = valorNovo + " Quant: " + EscreverQuantProperty.LerQuantCodigoListaUnica(itemm.Name.Split('.')[0]);

                        propriedades2.Add(opcao, valorNovoQuant);
                    }




                    AssCampoAsmOccurences(itemm, opcao, valorNovo);

                }

            }

        }



        public static void AddCampoArquivosAbertos() // adiciona no campo Cliente o nome digitado no console - isso nos DOCUMENTOS abertos no solid
        {
            Console.WriteLine("Digite o numero do campo:  1) Projeto  2) Nome ");

            string opcao = Console.ReadLine();

            if (opcao == "1") { opcao = "Projeto"; }
            if (opcao == "2") { opcao = "Nome"; }

            Console.WriteLine("Digite o valor com campo " + opcao);

            string valorNovo = Console.ReadLine();

            SolidEdgeFramework.Application seApp;
            SolidEdgeFramework.Documents seDoc;
            SolidEdgeFramework.SolidEdgeDocument documento; // usando o document não precisa saber se é peça, assembly, chapa etc.


            SolidEdgeFramework.PropertySets propertySets;
            SolidEdgeFramework.Properties propriedades;

            try
            {


                seApp = SolidEdgeCommunity.SolidEdgeUtils.Connect(true);

                seDoc = seApp.Documents;

                System.Threading.Thread.Sleep(100);

                for (int i = 1; i <= seDoc.Count; i++)
                {
                    documento = (SolidEdgeFramework.SolidEdgeDocument)seDoc.Item(i);

                    propertySets = (PropertySets)documento.Properties;

                    propriedades = (SolidEdgeFramework.Properties)propertySets.Item("Custom");

                    Console.WriteLine("Add Campo no arquivo: " + documento.Name + " o campo " + opcao + " com valor " + valorNovo);

                    propriedades.Add(opcao, valorNovo);

                    //drafff = (SolidEdgeDraft)s eDoc.dra 
                }

                DesejaSalvarFecharTodosArquivosAbertos();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {

            }
        }

        public static string PegarInfoNet(string link)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";

                string arr = client.DownloadString(link);

                return arr;
            }
        }

        public static string BancoDeDadosGet(string tabela, string selecionar, string numero)
        {
            string connStr = "server=localhost;user=root;database=pedidos;port=3306;password=proje115524;SslMode=none";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "SELECT " + selecionar + " FROM " + tabela + " WHERE numero=" + numero + "";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                string volta = rdr[0].ToString();

                rdr.Close();
                conn.Close();

                return volta;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

                return "ERRRRROO";
            }

        }
    }
}
