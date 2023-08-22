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
    class Arquivo
    {



        public static void PrintLista(bool arquivo, string lista) // se arquivo == true printa a lista
        {
            if (arquivo == true)
            {

                double[] somas = ListaGeral.SomaFisicas();

                string pathh = Mainn.pathh;

                if (lista == "codigosUnicos") { pathh = pathh.Substring(0, pathh.Length - 4) + "-Unica.csv"; }
                if (lista == "codigosUnicosLimpa") { pathh = pathh.Substring(0, pathh.Length - 4) + "-Unica-Limpa.csv"; }
                if (lista == "codigosCompras") { pathh = pathh.Substring(0, pathh.Length - 4) + "-Compras.csv"; }
                if (lista == "codigosCorte") { pathh = pathh.Substring(0, pathh.Length - 4) + "-Corte.csv"; }
                if (lista == "codigosLaser") { pathh = pathh.Substring(0, pathh.Length - 4) + "-Laser.csv"; }
                if (lista == "codigosGuilho") { pathh = pathh.Substring(0, pathh.Length - 4) + "-Guilhotina.csv"; }
                if (lista == "codigosResto") { pathh = pathh.Substring(0, pathh.Length - 4) + "-Resto.csv"; }

                Console.WriteLine("Salvando no arquivo  " + pathh);

                using (StreamWriter sw = File.CreateText(pathh))
                {
                    sw.WriteLine("Exportando todos os arquivos de uma Assembly");
                    sw.WriteLine("Arquivo " + pathh + " ");
                    sw.WriteLine(" ");
                    sw.WriteLine("  ");

                    if (lista == "codigosUnicos")
                    {
                        sw.WriteLine("Lista das pecas com quantidades ");
                        sw.WriteLine("  ");
                        sw.WriteLine(" Quant; Codigo; Nome; Desc1; Desc2; Desc3; Op1; Op2; Op3; Op4; Op5; Projeto; Path; Volume; Area; Mass;  ");
                        sw.WriteLine("  ");
                        foreach (ListaCodigos cod in Mainn.codigosUnicos)
                        {
                            sw.WriteLine(
                             " "
                             + cod.Quant
                             + "; "
                             + cod.Codigo
                             + "; "
                             + cod.Nome
                             + "; "
                             + cod.Desc1
                             + "; "
                             + cod.Desc2
                             + "; "
                             + cod.Desc3
                             + "; "
                             + cod.Op1
                             + "; "
                             + cod.Op2
                             + "; "
                             + cod.Op3
                             + "; "
                             + cod.Op4
                             + "; "
                             + cod.Op5
                             + "; "
                             + cod.Projeto
                             + "; "
                             + cod.Path
                             + "; "
                             + cod.Volume.ToString()
                             + "; "
                             + cod.Area.ToString()
                             + "; "
                             + cod.Mass.ToString()
                             + "; "
                             + cod.Tempo
                             + " ");

                        }
                        sw.WriteLine("  ");
                        sw.WriteLine("  ");
                        sw.WriteLine("  ");
                        sw.WriteLine(" ;  ; ; ; ; ; ; ; ; ; ; ; ; " + somas[0] + "; " + somas[1] + "; " + somas[2]);

                    }
                    if (lista == "codigos")
                    {
                        sw.WriteLine("Lista da arvore completa ");
                        sw.WriteLine("  ");
                        foreach (ListaCodigos cod in Mainn.codigos)
                        {
                            sw.WriteLine(
                             " "
                            + cod.Quant
                            + "; "
                            + String.Concat(Enumerable.Repeat(";       ", cod.Sub))
                            + cod.Codigo
                            + String.Concat(Enumerable.Repeat(";       ", 8 - cod.Sub))
                            + "; "
                            + cod.Nome
                            + "; "
                            + cod.Desc1
                             + "; "
                            + cod.Desc2
                            + "; "
                            + cod.Desc3
                            + "; "
                            + cod.Op1
                            + "; "
                            + cod.Op2
                            + "; "
                            + cod.Op3
                            + "; "
                            + cod.Op4
                            + "; "
                            + cod.Op5
                            + "; "
                            + cod.Projeto
                            + "; '"
                            + cod.Path
                            + "'");

                        }
                    }
                    if (lista == "codigosUnicosImpressao")
                    {
                        sw.WriteLine("Lista da specas e Limpa usando a lista de exclusoes ");
                        sw.WriteLine("  ");
                        sw.WriteLine(" Quant; Codigo; Nome; Desc1; Desc2; Desc3; Op1; Op2; Op3; Op4; Op5; Projeto; Path; Volume; Area; Mass;  ");
                        sw.WriteLine("  ");
                        foreach (ListaCodigos cod in Mainn.codigosImpressao)
                        {
                            sw.WriteLine(
                            " "
                            + cod.Quant
                            + "; "
                            + cod.Codigo
                            + "; "
                            + cod.Nome
                            + "; "
                            + cod.Desc1
                             + "; "
                            + cod.Desc2
                            + "; "
                            + cod.Desc3
                            + "; "
                            + cod.Op1
                            + "; "
                            + cod.Op2
                            + "; "
                            + cod.Op3
                            + "; "
                            + cod.Op4
                            + "; "
                            + cod.Op5
                            + "; "
                            + cod.Projeto
                            + "; "
                            + cod.Path
                            + "; "
                            + cod.Volume.ToString()
                            + "; "
                            + cod.Area.ToString()
                            + "; "
                            + cod.Mass.ToString()
                            + " ");

                        }
                    }

                    if (lista == "codigosCompras")
                    {
                        sw.WriteLine("Lista da specas e Limpa usando a lista de exclusoes ");
                        sw.WriteLine("  ");
                        sw.WriteLine(" Quant; Codigo; Nome; Desc1; Desc2; Desc3; Op1; Op2; Op3; Op4; Op5; Projeto; Path; Volume; Area; Mass; Preco;  ");
                        sw.WriteLine("  ");
                        foreach (ListaCodigos cod in Mainn.codigosCompras)
                        {
                            sw.WriteLine(
                            " "
                            + cod.Quant
                            + "; "
                            + cod.Codigo
                            + "; "
                            + cod.Nome
                            + "; "
                            + cod.Desc1
                             + "; "
                            + cod.Desc2
                            + "; "
                            + cod.Desc3
                            + "; "
                            + cod.Op1
                            + "; "
                            + cod.Op2
                            + "; "
                            + cod.Op3
                            + "; "
                            + cod.Op4
                            + "; "
                            + cod.Op5
                            + "; "
                            + cod.Projeto
                            + "; "
                            + cod.Path
                            + "; "
                            + cod.Volume.ToString()
                            + "; "
                            + cod.Area.ToString()
                            + "; "
                            + cod.Mass.ToString()
                            + "; "
                            + cod.Preco.ToString()
                            + " ");

                        }
                    }

                    if (lista == "codigosCorte")
                    {
                        sw.WriteLine("Lista de Corte");
                        sw.WriteLine("  ");
                        sw.WriteLine(" Quant; Codigo; Nome; Desc1; Desc2; Desc3; Op1; Op2; Op3; Op4; Op5; Projeto; Path; Volume; Area; Mass; Preco;  ");
                        sw.WriteLine("  ");
                        foreach (ListaCodigos cod in Mainn.codigosCorte)
                        {
                            sw.WriteLine(
                            " "
                            + cod.Quant
                            + "; "
                            + cod.Codigo
                            + "; "
                            + cod.Nome
                            + "; "
                            + cod.Desc1
                             + "; "
                            + cod.Desc2
                            + "; "
                            + cod.Desc3
                            + "; "
                            + cod.Op1
                            + "; "
                            + cod.Op2
                            + "; "
                            + cod.Op3
                            + "; "
                            + cod.Op4
                            + "; "
                            + cod.Op5
                            + "; "
                            + cod.Projeto
                            + "; "
                            + cod.Path
                            + "; "
                            + cod.Volume.ToString()
                            + "; "
                            + cod.Area.ToString()
                            + "; "
                            + cod.Mass.ToString()
                            + "; "
                            + cod.Preco.ToString()
                            + " ");

                        }
                    }

                    if (lista == "codigosLaser")
                    {
                        sw.WriteLine("Lista de Laser");
                        sw.WriteLine("  ");
                        sw.WriteLine(" Quant; Codigo; Nome; Desc1; Desc2; Desc3; Op1; Op2; Op3; Op4; Op5; Projeto; Path; Volume; Area; Mass; Preco;  ");
                        sw.WriteLine("  ");
                        foreach (ListaCodigos cod in Mainn.codigosLaser)
                        {
                            sw.WriteLine(
                            " "
                            + cod.Quant
                            + "; "
                            + cod.Codigo
                            + "; "
                            + cod.Nome
                            + "; "
                            + cod.Desc1
                             + "; "
                            + cod.Desc2
                            + "; "
                            + cod.Desc3
                            + "; "
                            + cod.Op1
                            + "; "
                            + cod.Op2
                            + "; "
                            + cod.Op3
                            + "; "
                            + cod.Op4
                            + "; "
                            + cod.Op5
                            + "; "
                            + cod.Projeto
                            + "; "
                            + cod.Path
                            + "; "
                            + cod.Volume.ToString()
                            + "; "
                            + cod.Area.ToString()
                            + "; "
                            + cod.Mass.ToString()
                            + "; "
                            + cod.Preco.ToString()
                            + " ");

                        }

                        

                    }

                    if (lista == "codigosGuilho")
                    {
                        sw.WriteLine("Lista de Guilho");
                        sw.WriteLine("  ");
                        sw.WriteLine(" Quant; Codigo; Nome; Desc1; Desc2; Desc3; Op1; Op2; Op3; Op4; Op5; Projeto; Path; Volume; Area; Mass; Preco;  ");
                        sw.WriteLine("  ");
                        foreach (ListaCodigos cod in Mainn.codigosGuilho)
                        {
                            sw.WriteLine(
                            " "
                            + cod.Quant
                            + "; "
                            + cod.Codigo
                            + "; "
                            + cod.Nome
                            + "; "
                            + cod.Desc1
                             + "; "
                            + cod.Desc2
                            + "; "
                            + cod.Desc3
                            + "; "
                            + cod.Op1
                            + "; "
                            + cod.Op2
                            + "; "
                            + cod.Op3
                            + "; "
                            + cod.Op4
                            + "; "
                            + cod.Op5
                            + "; "
                            + cod.Projeto
                            + "; "
                            + cod.Path
                            + "; "
                            + cod.Volume.ToString()
                            + "; "
                            + cod.Area.ToString()
                            + "; "
                            + cod.Mass.ToString()
                            + "; "
                            + cod.Preco.ToString()
                            + " ");

                        }
                    }
                    if (lista == "codigosResto")
                    {
                        sw.WriteLine("Codigos que nao se sabe o setor");
                        sw.WriteLine("  ");
                        sw.WriteLine(" Quant; Codigo; Nome; Desc1; Desc2; Desc3; Op1; Op2; Op3; Op4; Op5; Projeto; Path; Volume; Area; Mass; Preco;  ");
                        sw.WriteLine("  ");
                        foreach (ListaCodigos cod in Mainn.codigosResto)
                        {
                            sw.WriteLine(
                            " "
                            + cod.Quant
                            + "; "
                            + cod.Codigo
                            + "; "
                            + cod.Nome
                            + "; "
                            + cod.Desc1
                             + "; "
                            + cod.Desc2
                            + "; "
                            + cod.Desc3
                            + "; "
                            + cod.Op1
                            + "; "
                            + cod.Op2
                            + "; "
                            + cod.Op3
                            + "; "
                            + cod.Op4
                            + "; "
                            + cod.Op5
                            + "; "
                            + cod.Projeto
                            + "; "
                            + cod.Path
                            + "; "
                            + cod.Volume.ToString()
                            + "; "
                            + cod.Area.ToString()
                            + "; "
                            + cod.Mass.ToString()
                            + "; "
                            + cod.Preco.ToString()
                            + " ");

                        }
                    }
                }

                foreach (ListaCodigos cod in Mainn.codigos)
                {
                    Console.WriteLine(String.Concat(Enumerable.Repeat(",       ", cod.Sub)) + cod.Codigo.Split('.')[0]);

                }
            }
        }

        public static void PrintListaCompleta()
        {
            string pathh = Mainn.pathh;

            double totalCompras = 0;
            

            pathh = pathh.Substring(0, pathh.Length - 4) + "-Completa.csv";

            using (StreamWriter sw = File.CreateText(pathh))
            {
                sw.WriteLine("Exportando todos os arquivos de uma Assembly");
                sw.WriteLine("Arquivo " + pathh + " ");
                sw.WriteLine(" ");
                sw.WriteLine("  ");
                sw.WriteLine("  ");

                sw.WriteLine("Lista Compras");
                sw.WriteLine("  ");
                sw.WriteLine(" Quant; Codigo; Nome; Desc1; Desc2; Desc3; Op1; Op2; Op3; Op4; Op5; Projeto; Path; Volume; Area; Mass; Preco; Tempo;  ");
                sw.WriteLine("  ");



                foreach (ListaCodigos cod in Mainn.codigosCompras)
                {
                    totalCompras += (cod.Preco * cod.Quant);

                    sw.WriteLine(
                    " "
                    + cod.Quant
                    + "; "
                    + cod.Codigo
                    + "; "
                    + cod.Nome
                    + "; "
                    + cod.Desc1
                     + "; "
                    + cod.Desc2
                    + "; "
                    + cod.Desc3
                    + "; "
                    + cod.Op1
                    + "; "
                    + cod.Op2
                    + "; "
                    + cod.Op3
                    + "; "
                    + cod.Op4
                    + "; "
                    + cod.Op5
                    + "; "
                    + cod.Projeto
                    + "; "
                    + cod.Path
                    + "; "
                    + cod.Volume.ToString()
                    + "; "
                    + cod.Area.ToString()
                    + "; "
                    + cod.Mass.ToString()
                    + "; "
                    + cod.Preco.ToString()
                    + "; "
                    + cod.Tempo.ToString()
                    + " ; "
                    + ( cod.Preco * cod.Quant ).ToString()
                    + " ");

                }

                sw.WriteLine("  ");
                sw.WriteLine("  ");
                sw.WriteLine("  ");
                sw.WriteLine("Lista Corte");
                sw.WriteLine("  ");
                sw.WriteLine(" Quant; Codigo; Nome; Desc1; Desc2; Desc3; Op1; Op2; Op3; Op4; Op5; Projeto; Path; Volume; Area; Mass;  Preco; Tempo;  ");
                sw.WriteLine("  ");

                foreach (ListaCodigos cod in Mainn.codigosCorte)
                {
                    sw.WriteLine(
                    " "
                    + cod.Quant
                    + "; "
                    + cod.Codigo
                    + "; "
                    + cod.Nome
                    + "; "
                    + cod.Desc1
                     + "; "
                    + cod.Desc2
                    + "; "
                    + cod.Desc3
                    + "; "
                    + cod.Op1
                    + "; "
                    + cod.Op2
                    + "; "
                    + cod.Op3
                    + "; "
                    + cod.Op4
                    + "; "
                    + cod.Op5
                    + "; "
                    + cod.Projeto
                    + "; "
                    + cod.Path
                    + "; "
                    + cod.Volume.ToString()
                    + "; "
                    + cod.Area.ToString()
                    + "; "
                    + cod.Mass.ToString()
                    + "; "
                    + cod.Preco.ToString()
                    + "; "
                    + cod.Tempo.ToString()
                    + " ");

                }
                sw.WriteLine("  ");
                sw.WriteLine("  ");
                sw.WriteLine("  ");
                sw.WriteLine("Lista Laser");
                sw.WriteLine("  ");
                sw.WriteLine(" Quant; Codigo; Nome; Desc1; Desc2; Desc3; Op1; Op2; Op3; Op4; Op5; Projeto; Path; Volume; Area; Mass;  Preco; Tempo;  ");
                sw.WriteLine("  ");

                foreach (ListaCodigos cod in Mainn.codigosLaser)
                {
                    sw.WriteLine(
                    " "
                    + cod.Quant
                    + "; "
                    + cod.Codigo
                    + "; "
                    + cod.Nome
                    + "; "
                    + cod.Desc1
                     + "; "
                    + cod.Desc2
                    + "; "
                    + cod.Desc3
                    + "; "
                    + cod.Op1
                    + "; "
                    + cod.Op2
                    + "; "
                    + cod.Op3
                    + "; "
                    + cod.Op4
                    + "; "
                    + cod.Op5
                    + "; "
                    + cod.Projeto
                    + "; "
                    + cod.Path
                    + "; "
                    + cod.Volume.ToString()
                    + "; "
                    + cod.Area.ToString()
                    + "; "
                    + cod.Mass.ToString()
                    + "; "
                    + cod.Preco.ToString()
                    + "; "
                    + cod.Tempo.ToString()
                    + " ");

                }
                sw.WriteLine("  ");
                sw.WriteLine("  ");
                sw.WriteLine("  ");
                sw.WriteLine("Lista Guilhotina");
                sw.WriteLine("  ");
                sw.WriteLine(" Quant; Codigo; Nome; Desc1; Desc2; Desc3; Op1; Op2; Op3; Op4; Op5; Projeto; Path; Volume; Area; Mass;  Preco; Tempo;  ");
                sw.WriteLine("  ");

                foreach (ListaCodigos cod in Mainn.codigosGuilho)
                {
                    sw.WriteLine(
                    " "
                    + cod.Quant
                    + "; "
                    + cod.Codigo
                    + "; "
                    + cod.Nome
                    + "; "
                    + cod.Desc1
                     + "; "
                    + cod.Desc2
                    + "; "
                    + cod.Desc3
                    + "; "
                    + cod.Op1
                    + "; "
                    + cod.Op2
                    + "; "
                    + cod.Op3
                    + "; "
                    + cod.Op4
                    + "; "
                    + cod.Op5
                    + "; "
                    + cod.Projeto
                    + "; "
                    + cod.Path
                    + "; "
                    + cod.Volume.ToString()
                    + "; "
                    + cod.Area.ToString()
                    + "; "
                    + cod.Mass.ToString()
                    + "; "
                    + cod.Preco.ToString()
                    + "; "
                    + cod.Tempo.ToString()
                    + " ");

                }

                sw.WriteLine("  ");
                sw.WriteLine("  ");
                sw.WriteLine("  ");
                sw.WriteLine("Lista Planas");
                sw.WriteLine("  ");
                sw.WriteLine(" Quant; Codigo; Nome; Desc1; Desc2; Desc3; Op1; Op2; Op3; Op4; Op5; Projeto; Path; Volume; Area; Mass;  Preco; Tempo;  ");
                sw.WriteLine("  ");

                foreach (ListaCodigos cod in Mainn.codigosPlanas)
                {
                    sw.WriteLine(
                    " "
                    + cod.Quant
                    + "; "
                    + cod.Codigo
                    + "; "
                    + cod.Nome
                    + "; "
                    + cod.Desc1
                     + "; "
                    + cod.Desc2
                    + "; "
                    + cod.Desc3
                    + "; "
                    + cod.Op1
                    + "; "
                    + cod.Op2
                    + "; "
                    + cod.Op3
                    + "; "
                    + cod.Op4
                    + "; "
                    + cod.Op5
                    + "; "
                    + cod.Projeto
                    + "; "
                    + cod.Path
                    + "; "
                    + cod.Volume.ToString()
                    + "; "
                    + cod.Area.ToString()
                    + "; "
                    + cod.Mass.ToString()
                    + "; "
                    + cod.Preco.ToString()
                    + "; "
                    + cod.Tempo.ToString()
                    + " ");

                }

                sw.WriteLine("  ");
                sw.WriteLine("  ");
                sw.WriteLine("  ");
                sw.WriteLine("Lista Exclusoes - Pecas de estoque ");
                sw.WriteLine("  ");
                sw.WriteLine(" Quant; Codigo; Nome; Desc1; Desc2; Desc3; Op1; Op2; Op3; Op4; Op5; Projeto; Path; Volume; Area; Mass;  Preco; Tempo;  ");
                sw.WriteLine("  ");

                foreach (ListaCodigos cod in Mainn.codigosExclusao)
                {
                    sw.WriteLine(
                    " "
                    + cod.Quant
                    + "; "
                    + cod.Codigo
                    + "; "
                    + cod.Nome
                    + "; "
                    + cod.Desc1
                     + "; "
                    + cod.Desc2
                    + "; "
                    + cod.Desc3
                    + "; "
                    + cod.Op1
                    + "; "
                    + cod.Op2
                    + "; "
                    + cod.Op3
                    + "; "
                    + cod.Op4
                    + "; "
                    + cod.Op5
                    + "; "
                    + cod.Projeto
                    + "; "
                    + cod.Path
                    + "; "
                    + cod.Volume.ToString()
                    + "; "
                    + cod.Area.ToString()
                    + "; "
                    + cod.Mass.ToString()
                    + "; "
                    + cod.Preco.ToString()
                    + "; "
                    + cod.Tempo.ToString()
                    + " ");

                }

                sw.WriteLine("  ");
                sw.WriteLine("  ");
                sw.WriteLine("  ");
                sw.WriteLine("Lista Montagens ");
                sw.WriteLine("  ");
                sw.WriteLine(" Quant; Codigo; Nome; Desc1; Desc2; Desc3; Op1; Op2; Op3; Op4; Op5; Projeto; Path; Volume; Area; Mass;  Preco; Tempo;  ");
                sw.WriteLine("  ");

                foreach (ListaCodigos cod in Mainn.codigosAss)
                {
                    sw.WriteLine(
                    " "
                    + cod.Quant
                    + "; "
                    + cod.Codigo
                    + "; "
                    + cod.Nome
                    + "; "
                    + cod.Desc1
                     + "; "
                    + cod.Desc2
                    + "; "
                    + cod.Desc3
                    + "; "
                    + cod.Op1
                    + "; "
                    + cod.Op2
                    + "; "
                    + cod.Op3
                    + "; "
                    + cod.Op4
                    + "; "
                    + cod.Op5
                    + "; "
                    + cod.Projeto
                    + "; "
                    + cod.Path
                    + "; "
                    + cod.Volume.ToString()
                    + "; "
                    + cod.Area.ToString()
                    + "; "
                    + cod.Mass.ToString()
                    + "; "
                    + cod.Preco.ToString()
                    + "; "
                    + cod.Tempo.ToString()
                    + " ");

                }



                sw.WriteLine("  ");
                sw.WriteLine("  ");
                sw.WriteLine("  ");
                sw.WriteLine("Lista Resto - Peças sem setor ");
                sw.WriteLine("  ");
                sw.WriteLine(" Quant; Codigo; Nome; Desc1; Desc2; Desc3; Op1; Op2; Op3; Op4; Op5; Projeto; Path; Volume; Area; Mass;  Preco; Tempo;  ");
                sw.WriteLine("  ");

                foreach (ListaCodigos cod in Mainn.codigosResto)
                {
                    sw.WriteLine(
                    " "
                    + cod.Quant
                    + "; "
                    + cod.Codigo
                    + "; "
                    + cod.Nome
                    + "; "
                    + cod.Desc1
                     + "; "
                    + cod.Desc2
                    + "; "
                    + cod.Desc3
                    + "; "
                    + cod.Op1
                    + "; "
                    + cod.Op2
                    + "; "
                    + cod.Op3
                    + "; "
                    + cod.Op4
                    + "; "
                    + cod.Op5
                    + "; "
                    + cod.Projeto
                    + "; "
                    + cod.Path
                    + "; "
                    + cod.Volume.ToString()
                    + "; "
                    + cod.Area.ToString()
                    + "; "
                    + cod.Mass.ToString()
                    + "; "
                    + cod.Preco.ToString()
                    + "; "
                    + cod.Tempo.ToString()
                    + " ");

                }


                sw.WriteLine("  ");
                sw.WriteLine("  ");
                sw.WriteLine("  ");
                sw.WriteLine("  ");
                sw.WriteLine(" Somas de Pesos: ");
                sw.WriteLine(ListaGeral.SomarPesosListaCompleta());
                sw.WriteLine("  ");
                sw.WriteLine(" Preco compras total: ; ; ; ;  " + totalCompras);

                


            }

            Console.WriteLine("Arquivo gravado em : " + pathh);

        }
    }
}
