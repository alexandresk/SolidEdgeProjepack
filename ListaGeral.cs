using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeMacro
{
    class ListaGeral
    {

        public static  double[] SomaFisicas()
        {
            double[] somas = new double[3];

            for(int i = 0; i < Mainn.codigosUnicos.Count; i++ )
            {
                somas[0] = somas[0] + Mainn.codigosUnicos[i].Volume;
                somas[1] = somas[1] + Mainn.codigosUnicos[i].Area;
                somas[2] = somas[2] + Mainn.codigosUnicos[i].Mass;
            }

            return somas;
        }

        public static void OrdenarListaUnicaLimpaPorNome()
        {
            //Class2.codigosUnicosLimpa.Sort();

            Mainn.codigosImpressao.Sort((e1, e2) =>
            {
                return e2.Nome.CompareTo(e1.Nome);
            });
        }


        public static void PassarQuantParaCodigos()
        {
            Console.WriteLine("Passar Quantidades para Codigos...");
            for (int i = 0; i < Mainn.codigos.Count; i++)
            {
                for (int x = 0; x < Mainn.codigosUnicos.Count; x++)
                {
                    if (Mainn.codigos[i].Codigo == Mainn.codigosUnicos[x].Codigo)
                    {
                        Mainn.codigos[i].Codigo = Mainn.codigosUnicos[x].Codigo;
                    }
                }

            }
            Console.WriteLine("Terminado");
        }

        public static void AbrirListaPrecos() // lista de peças de estoque
        {
            string[] precos = System.IO.File.ReadAllLines(@"\\fs\e\Projetos\ProjeMacroListas\listaPrecosChapas.txt");

            Mainn.precoCorte = float.Parse(precos[0].Split(';')[1] );
            Mainn.precoGuilhotina = float.Parse(precos[1].Split(';')[1] );
            Mainn.precoPlanas = float.Parse(precos[2].Split(';')[1] );
            Mainn.precoLaser = float.Parse(precos[3].Split(';')[1] );

            //Console.WriteLine("Exclusao lista: ");


            Console.WriteLine("Lista Precos Carregada");
            Console.WriteLine(Mainn.precoCorte);
            Console.WriteLine(Mainn.precoGuilhotina);
            Console.WriteLine(Mainn.precoPlanas);
            Console.WriteLine(Mainn.precoLaser);
        }


        public static void AbrirListaExclusoes() // lista de peças de estoque
        {
            Mainn.arrayExclusao = System.IO.File.ReadAllLines(@"\\fs\e\Projetos\ProjeMacroListas\exclusoesDft.txt");

            //Console.WriteLine("Exclusao lista: ");

            for (int x = 0; x < Mainn.arrayExclusao.Length; x++)
            {
                Mainn.arrayExclusao[x] = Mainn.arrayExclusao[x].Trim();
               // Console.WriteLine("exclusao estoque:  " + Mainn.arrayExclusao[x] + "-");
            }

            Console.WriteLine("Lista Exclusoes carregada");
        }

        public static void AbrirListaCorte() // lista de peças de estoque
        {
            Mainn.arrayCorte = System.IO.File.ReadAllLines(@"\\fs\e\Projetos\ProjeMacroListas\listaCorte.txt");

            //Console.WriteLine("Exclusao lista: ");
            for (int x = 0; x < Mainn.arrayCorte.Length; x++)
            {
                Mainn.arrayCorte[x] = Mainn.arrayCorte[x].Trim();
                //Console.WriteLine("lista corte:  " + Mainn.arrayCorte[x] + "-");
            }

            Console.WriteLine("Lista Corte carregada");
        }

        public static void AbrirListaPlanas() // lista de peças de estoque
        {
            Mainn.arrayPlanas = System.IO.File.ReadAllLines(@"\\fs\e\Projetos\ProjeMacroListas\listaPlanas.txt");

            for (int x = 0; x < Mainn.arrayPlanas.Length; x++)
            {
                Mainn.arrayPlanas[x] = Mainn.arrayPlanas[x].Trim();
                //Console.WriteLine("lista planas:  " + Mainn.arrayPlanas[x] + "-");
            }

            Console.WriteLine("Lista Planas carregada");
        }

        public static void AbrirListaLaser() // lista de peças de estoque
        {
            Mainn.arrayLaser = System.IO.File.ReadAllLines(@"\\fs\e\Projetos\ProjeMacroListas\listaLaser.txt");

            for (int x = 0; x < Mainn.arrayLaser.Length; x++)
            {
                Mainn.arrayLaser[x] = Mainn.arrayLaser[x].Trim();
               //Console.WriteLine("lista laser:  " + Mainn.arrayLaser[x] + "-");
            }

            Console.WriteLine("Lista Lasers carregada");
        }

        public static void AbrirListaGuilho() // lista de peças de estoque
        {
            Mainn.arrayGuilho = System.IO.File.ReadAllLines(@"\\fs\e\Projetos\ProjeMacroListas\listaGuilhotina.txt");

            for (int x = 0; x < Mainn.arrayGuilho.Length; x++)
            {
                Mainn.arrayGuilho[x] = Mainn.arrayGuilho[x].Trim();
                //Console.WriteLine("lista guilho:  " + Mainn.arrayGuilho[x] + "-");
            }

            Console.WriteLine("Lista Guilhotina carregada");
        }

        public static void AbrirListaCompras() // lista de peças de estoque
        {
            Mainn.arrayCompras = System.IO.File.ReadAllLines(@"\\fs\e\Projetos\ProjeMacroListas\listaCompras2.csv");

            Mainn.arrayComprasPreco = new string[Mainn.arrayCompras.Length];

            
            for (int i = 0; i < Mainn.arrayCompras.Length; i++)
            {
                if (Mainn.arrayCompras[i] != "")
                {
                    Mainn.arrayComprasPreco[i] = Mainn.arrayCompras[i].Split(';')[0].Replace('.', ',');
                    Mainn.arrayCompras[i] = Mainn.arrayCompras[i].Split(';')[1].Trim();
                    //Console.WriteLine("lista compras:  " + Mainn.arrayCompras[i] + " Preco: " + Mainn.arrayComprasPreco[i]);
                }

            }

            Console.WriteLine("Lista Compras carregada");
        }

        public static void CriarListaComprasCorteLaserEtc(bool separarExclusao) // é a usada pra gerar lista compras Completa
        {
            bool compras;
            bool laser;
            bool guilho;
            bool corte;
            bool planas;
            bool exclusao;
            bool ass;

            string contemStr = "";
            string preco = "";
            Console.WriteLine("Criando lista de Compras e colocando Precos");

            for (int i = 0; i < Mainn.codigosUnicos.Count; i++)
            {
                compras = false;
                laser = false;
                guilho = false;
                corte = false;
                planas = false;
                exclusao = false;
                ass = false;

                if (Mainn.codigosUnicos[i].Pcp != "") // se o campo PCP esta preenchido vai por ele (prioridade)
                {
                    Console.WriteLine("Codigo " + Mainn.codigosUnicos[i].Codigo + " com PCP: ");
                    if (Mainn.codigosUnicos[i].Pcp[0] == 'D' || Mainn.codigosUnicos[i].Pcp[0] == 'd') { compras = true; }
                    if (Mainn.codigosUnicos[i].Pcp[0] == 'C' || Mainn.codigosUnicos[i].Pcp[0] == 'c') { corte = true; }
                    if (Mainn.codigosUnicos[i].Pcp[0] == 'L' || Mainn.codigosUnicos[i].Pcp[0] == 'l') { laser = true; }
                    if (Mainn.codigosUnicos[i].Pcp[0] == 'G' || Mainn.codigosUnicos[i].Pcp[0] == 'g') { guilho = true; }
                    if (Mainn.codigosUnicos[i].Pcp[0] == 'P' || Mainn.codigosUnicos[i].Pcp[0] == 'p') { planas = true; }
                    if (Mainn.codigosUnicos[i].Pcp[0] == 'A' || Mainn.codigosUnicos[i].Pcp[0] == 'a') { ass = true; }
                }
                else // se o campo PCP esta vazio entao vai pelas listas
                {

                    if (Mainn.codigosUnicos[i].Path.Substring(Mainn.codigosUnicos[i].Path.Length - 3) == "asm")
                    {
                        ass = true;
                        Console.WriteLine("Assembly detectada ");
                    }

                    for (int x = 0; x < Mainn.arrayCompras.Length; x++)
                    {
                        if (!compras && Mainn.arrayCompras[x] != "")
                        {
                            compras = Mainn.codigosUnicos[i].Codigo.Equals(Mainn.arrayCompras[x]);

                            if (compras) {  
                                contemStr = Mainn.arrayCompras[x];  
                                preco = Mainn.arrayComprasPreco[x];
                                Console.WriteLine("contem ( " + contemStr + " ) codigo no array Compras ");
                            }
                        }
                    }

                    for (int x = 0; x < Mainn.arrayCorte.Length; x++)
                    {
                        if (!corte && Mainn.arrayCorte[x] != "")
                        {
                            corte = Mainn.codigosUnicos[i].Codigo.Equals(Mainn.arrayCorte[x]);
                            if (corte) { 
                                contemStr = Mainn.arrayCorte[x];
                                Console.WriteLine("contem ( " + contemStr + " ) codigo no array Corte ");
                            }
                        }
                    }

                    for (int x = 0; x < Mainn.arrayLaser.Length; x++)
                    {
                        if (!laser && Mainn.arrayLaser[x] != "")
                        {
                            laser = Mainn.codigosUnicos[i].Codigo.Equals(Mainn.arrayLaser[x]);
                            if (laser) { 
                                contemStr = Mainn.arrayLaser[x];
                                Console.WriteLine("contem ( " + contemStr + " ) codigo no array Laser ");
                            }
                        }
                    }

                    for (int x = 0; x < Mainn.arrayGuilho.Length; x++)
                    {
                        if (!guilho && Mainn.arrayGuilho[x] != "")
                        {
                            guilho = Mainn.codigosUnicos[i].Codigo.Equals(Mainn.arrayGuilho[x]);
                            if (guilho) { 
                                contemStr = Mainn.arrayGuilho[x];
                                Console.WriteLine("contem ( " + contemStr + " ) codigo no array Guilhotina ");
                            }
                        }
                    }

                    for (int x = 0; x < Mainn.arrayPlanas.Length; x++)
                    {
                        if (!planas && Mainn.arrayPlanas[x] != "")
                        {
                            planas = Mainn.codigosUnicos[i].Codigo.Equals(Mainn.arrayPlanas[x]);
                            if (planas)
                            {
                                contemStr = Mainn.arrayPlanas[x];
                                Console.WriteLine("contem ( " + contemStr + " ) codigo no array Planas ");
                            }
                        }
                    }

                    if (separarExclusao)
                    {
                        for (int x = 0; x < Mainn.arrayExclusao.Length; x++)
                        {
                            if (!exclusao && Mainn.arrayExclusao[x] != "")
                            {
                                Console.WriteLine("Testando exclusao: " + Mainn.arrayExclusao[x] + "na peca " + Mainn.codigosUnicos[i].Codigo);
                                exclusao = Mainn.codigosUnicos[i].Codigo.Equals(Mainn.arrayExclusao[x]);
                                if (exclusao)
                                {
                                    contemStr = Mainn.arrayExclusao[x];
                                    Console.WriteLine("contem ( " + contemStr + " ) codigo no array Estoque exclusao ");
                                }
                            }
                        }
                    }


                }



                if (compras)
                {
                    Console.WriteLine("contem ( " + contemStr + " ) codigo no array Compras Preco: " + preco);
                    Mainn.codigosCompras.Add(new ListaCodigos(
                        Mainn.codigosUnicos[i].Codigo,
                        Mainn.codigosUnicos[i].Path,
                        Mainn.codigosUnicos[i].Quant,
                        Mainn.codigosUnicos[i].Sub,
                        Mainn.codigosUnicos[i].Nome,
                        Mainn.codigosUnicos[i].Projeto,
                        Mainn.codigosUnicos[i].Desc1,
                        Mainn.codigosUnicos[i].Desc2,
                        Mainn.codigosUnicos[i].Desc3,
                        Mainn.codigosUnicos[i].Op1,
                        Mainn.codigosUnicos[i].Op2,
                        Mainn.codigosUnicos[i].Op3,
                        Mainn.codigosUnicos[i].Op4,
                        Mainn.codigosUnicos[i].Op5,
                        Mainn.codigosUnicos[i].Volume,
                        Mainn.codigosUnicos[i].Area,
                        Mainn.codigosUnicos[i].Mass,
                        Convert.ToDouble(preco),
                        Mainn.codigosUnicos[i].Tempo,
                        Mainn.codigosUnicos[i].Pcp
                         )
                        );

                }
                if(laser)
                {
                    Mainn.codigosLaser.Add(Mainn.codigosUnicos[i]);
                }
                if (guilho)
                {
                    Mainn.codigosGuilho.Add(Mainn.codigosUnicos[i]);
                }
                if (corte)
                {
                    Mainn.codigosCorte.Add(Mainn.codigosUnicos[i]);
                }
                if (planas)
                {
                    Mainn.codigosPlanas.Add(Mainn.codigosUnicos[i]);
                }
                if (ass)
                {
                    Mainn.codigosAss.Add(Mainn.codigosUnicos[i]);
                }
                if (exclusao && !compras)
                {
                    Mainn.codigosExclusao.Add(Mainn.codigosUnicos[i]);
                }
                if (!corte && !guilho && !laser && !corte && !compras && !planas && !exclusao && !ass)
                {
                    Mainn.codigosResto.Add(Mainn.codigosUnicos[i]);
                }

            }
        }

        public static void CriarListaUnicaLimpa() // limpa de estoque
        {
            bool contem;
            string contemStr = "";

            Console.WriteLine("Limpando Lista unica com a lista de exclusao");

            for (int i = 0; i < Mainn.codigosUnicos.Count; i++)
            {
                contem = false;
                for (int x = 0; x < Mainn.arrayExclusao.Length; x++)
                {
                    if (!contem && Mainn.arrayExclusao[x] != "")
                    {
                        contem = Mainn.codigosUnicos[i].Codigo.Equals(Mainn.arrayExclusao[x]);
                        if (contem)
                        {
                            contemStr = Mainn.arrayExclusao[x];
                        }
                    }
                }

                if (contem)
                {
                    Console.WriteLine("contem ( " + contemStr + " ) codigo no array de exclusao: " + Mainn.codigosUnicos[i].Codigo);

                }
                else
                {
                    Mainn.codigosImpressao.Add(Mainn.codigosUnicos[i]);
                }

            }
        }

        public static void CriarListaUnica()
        {
            // somando os repetidos no campo quant
            for (int i = 0; i < Mainn.codigos.Count; i++)
            {
                for (int x = 0; x < Mainn.codigos.Count; x++)
                {
                    if (i != x && Mainn.codigos[i].Codigo == Mainn.codigos[x].Codigo)
                    {
                        Mainn.codigos[i].Quant = Mainn.codigos[i].Quant + 1;
                    }
                }
            }

            for (int i = 0; i < Mainn.codigos.Count; i++)
            {
                if (!Mainn.codigosUnicos.Exists(x => x.Codigo == Mainn.codigos[i].Codigo))
                {
                    Mainn.codigosUnicos.Add(Mainn.codigos[i]);
                }
            }
        }



        public static void AssemblyOccurence() // coloca todos os documents numa lista codigos
        {
            SolidEdgeFramework.Application seApp;
            SolidEdgeFramework.Documents seDoc;

            SolidEdgeAssembly.AssemblyDocument assem;
            SolidEdgeAssembly.Occurrences arrayOccurences;


            seApp = SolidEdgeCommunity.SolidEdgeUtils.Connect(true);
            seDoc = seApp.Documents;
            //System.Threading.Thread.Sleep(1000);
            assem = (SolidEdgeAssembly.AssemblyDocument)seApp.ActiveDocument;
            arrayOccurences = (SolidEdgeAssembly.Occurrences)assem.Occurrences;
            //string path = @"" + assem.Path + "/" + assem.Name.Remove(assem.Name.LastIndexOf(".asm")) + "Arvore.txt"; // arquivo
            string path = @"" + assem.Path + "/" + assem.Name.Substring(0, assem.Name.Length - 4) + "Lista.csv"; // arquivo
            Mainn.nome = assem.Name.Substring(0, assem.Name.Length - 4);

            Console.WriteLine(assem.Name);
            Mainn.codigos.Add(new ListaCodigos(assem.Name.Split('.')[0], assem.Path, 1, 0, "", "", "", "", "", "", "", "", "", "", 0, 0, 0, 0, "", ""));


            foreach (SolidEdgeAssembly.Occurrence itemm in arrayOccurences)
            {
                if (itemm.IncludeInBom == true)
                {
                    LerAddOcurrence(itemm);
                    TestSeAsmPrint(itemm, 2, path);
                }


            }

            Mainn.pathh = path;
            Mainn.codigo = assem.Name;

        }

        public static void TestSeAsmPrint(SolidEdgeAssembly.Occurrence occurrencee, int espaco, string path) // se documento é asm printar no console os occurences
        {
            if (occurrencee.Type.ToString() == "igSubAssembly")
            {

                SolidEdgeAssembly.AssemblyDocument assem2;
                SolidEdgeAssembly.Occurrences arrayOccurences2;


                assem2 = (SolidEdgeAssembly.AssemblyDocument)occurrencee.OccurrenceDocument;
                arrayOccurences2 = (SolidEdgeAssembly.Occurrences)assem2.Occurrences;


                foreach (SolidEdgeAssembly.Occurrence itemm in arrayOccurences2)
                {
                    
                    if (itemm.IncludeInBom == true)
                    {
                        LerAddOcurrence(itemm);
                        TestSeAsmPrint(itemm, espaco + 1, path);
                    }


                }
            }
        }


        public static void LerAddOcurrence(SolidEdgeAssembly.Occurrence itemm)
        {

            SolidEdgeFramework.SolidEdgeDocument documento;

            Console.WriteLine("testSeAsmPrint: " + itemm.Name + " - " + itemm.PartFileName);

            string[] p = new string[12];
            double[] f = new double[3];


            if (!Mainn.leituraRapidaSemCampos)
            {
                documento = (SolidEdgeFramework.SolidEdgeDocument)itemm.OccurrenceDocument;
                p = Propriedades.LerTodasCustom(documento);
                f = Propriedades.ChecarArquivoEAbrirFisicas(itemm);
            }

            //double[] f = new double[p.Length];
            Mainn.codigos.Add(new ListaCodigos(
                itemm.Name.Split('.')[0],
                itemm.PartFileName,
                1, 1, p[0], p[1], p[2], p[3], p[4], p[5], p[6], p[7], p[8], p[9], f[0], f[1], f[2], 0, p[10], p[11])
                );
        }


        public static string SomarPesosListaCompleta ()
        {
            string resultado = "";
            double corte = 0;
            double laser = 0;
            double guilho = 0;
            double planas = 0;

            foreach (ListaCodigos cod in Mainn.codigosCorte)
            {
                corte = corte + cod.Mass * cod.Quant;
            }
            foreach (ListaCodigos cod in Mainn.codigosLaser)
            {
                laser = laser + cod.Mass * cod.Quant;
            }
            foreach (ListaCodigos cod in Mainn.codigosGuilho)
            {
                guilho = guilho + cod.Mass * cod.Quant;
            }
            foreach (ListaCodigos cod in Mainn.codigosPlanas)
            {
                planas = planas + cod.Mass * cod.Quant;
            }

            float pCorte = Mainn.precoCorte;
            float pLaser = Mainn.precoLaser;
            float pGui = Mainn.precoGuilhotina;
            float pPlanas = Mainn.precoPlanas;


            resultado = " - ; Peso total Corte ; " + corte.ToString() + " ; " + pCorte.ToString() + " ; " + (corte*pCorte) + " \r\n";
            resultado += " - ; Peso total Laser ; " + laser.ToString() + " ; " + pLaser.ToString() + " ; " + (laser * pLaser) + " \r\n";
            resultado += " - ; Peso total Guilhotina ; " + guilho.ToString() + " ; " + pGui.ToString() + " ; " + (guilho * pGui) + " \r\n";
            resultado += " - ; Peso total Planas ; " + planas.ToString() + " ; " + pPlanas.ToString() + " ; " + (planas * pPlanas) + " \r\n";

            return resultado;
        }
    }


   
}
