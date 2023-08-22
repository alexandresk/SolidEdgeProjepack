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
using System.Diagnostics;

namespace ProjeMacro
{
    class Welcome
    {

        public static void Abrir()
        {
            // limpando variaveis
            Mainn.codigos.Clear();
            Mainn.codigosUnicos.Clear();
            Mainn.codigosImpressao.Clear();
            Mainn.codigosCompras.Clear();
            Mainn.codigosCorte.Clear();
            Mainn.codigosPlanas.Clear();
            Mainn.codigosExclusao.Clear();
            Mainn.codigosAss.Clear();

            //Mainn.pathh = "";

            Console.Clear();



            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("  -----------------------------------------------------------------------------------------");
            Console.WriteLine("  -----------------------------------------------------------------------------------------");
            Console.WriteLine("  ---------------                                                       -------------------");
            Console.WriteLine("  ---------------                                                       -------------------");
            Console.WriteLine("  ---------------               MACRO SOLID EDGE PROJEPACK              -------------------");
            Console.WriteLine("  ---------------                                                       -------------------");
            Console.WriteLine("  ---------------                                                       -------------------");
            Console.WriteLine("  -----------------------------------------------------------------------------------------");
            Console.WriteLine("  " + new string('-', 89));
            Console.WriteLine("  ");
            Console.WriteLine("  ");




            //Console.WriteLine("  1) Processo Completo");
            Console.WriteLine("  11) AddCampoAsm");
            Console.WriteLine("  12) Mudar Campo arquivos Abertos");
            //Console.WriteLine("  13) Exportar txt lista");
            //Console.WriteLine("  14) Exportar txt unica ");
            //Console.WriteLine("  15) Exportar txt unica e limpa ");
            //Console.WriteLine("  16) Abrir Todos Drafts (antigo)");
            Console.WriteLine("  17) Nome Projeto com Quantidade");
            Console.WriteLine("  18) Mudar Campo Pasta ");
            Console.WriteLine("  19) Fechar e Salvar docs abertos");
            Console.WriteLine("  20) Abrir Drafts Impressao 70 por vez");
            Console.WriteLine("  21) Lista Geral Completa");
            //Console.WriteLine("  22) Inserir Banco de Dados");

            string comando = Console.ReadLine();

            if (comando == "1")
            {
                FuncoesGeral.AddCampoAsm(false);

                System.Threading.Thread.Sleep(500);

                ListaGeral.AssemblyOccurence();
                ListaGeral.CriarListaUnica();
                ListaGeral.CriarListaUnicaLimpa();

                System.Threading.Thread.Sleep(500);

                Arquivo.PrintLista(true, "codigos");
                Arquivo.PrintLista(true, "codigosUnicos");
                Arquivo.PrintLista(true, "codigosUnicosImpressao");

                System.Threading.Thread.Sleep(500);

                //EscreverQuantProperty.AddNoProjeto();

                System.Threading.Thread.Sleep(500);

                //AbrirAllDrafts.AbrirListaExclusoesDftPadrao();
                //AbrirAllDrafts.AbrirDaAssembly();
            }

            // timer para controle do tempo do processo
            Stopwatch relogio = new Stopwatch();
            relogio.Start();


            if (comando == "11")
            {
                FuncoesGeral.AddCampoAsm(false);
            }
            if (comando == "12")
            {
                FuncoesGeral.AddCampoArquivosAbertos();
            }
            if (comando == "13")
            {
                ListaGeral.AssemblyOccurence();
                ListaGeral.CriarListaUnica();
                ListaGeral.PassarQuantParaCodigos();
                Arquivo.PrintLista(true, "codigos");
            }
            if (comando == "14")
            {
                ListaGeral.AssemblyOccurence();
                ListaGeral.CriarListaUnica();
                ListaGeral.PassarQuantParaCodigos();
                Arquivo.PrintLista(true, "codigosUnicos");
            }
            if (comando == "15")
            {
                ListaGeral.AssemblyOccurence();
                ListaGeral.CriarListaUnica();
                ListaGeral.PassarQuantParaCodigos();
                ListaGeral.CriarListaUnicaLimpa();
                ListaGeral.OrdenarListaUnicaLimpaPorNome();
                Arquivo.PrintLista(true, "codigosUnicosImpressao");
            }
            if (comando == "16")
            {
                AbrirAllDrafts.AbrirDaAssembly();
            }
            if (comando == "17")
            {
                ListaGeral.AssemblyOccurence();
                ListaGeral.CriarListaUnica();
                FuncoesGeral.AddCampoAsm(true);
                Arquivo.PrintLista(true, "codigosUnicos");

            }
            if (comando == "18")
            {
                FuncoesGeral.AbrirArquivosPasta();
                FuncoesGeral.AddCampoArquivosAbertos();
            }
            if (comando == "19")
            {
                FuncoesGeral.SalvarFecharTodosArquivosAbertos(true);
            }
            if (comando == "20") //Abrir Drafts Impressao 50 por vez
            {
                Mainn.leituraRapidaSemCampos = true; // true é nao ler os campos, pra impressao nao precisa
                ListaGeral.AssemblyOccurence();
                ListaGeral.CriarListaUnica();
                ListaGeral.CriarListaUnicaLimpa();
                AbrirAllDrafts.AbrirListaCodigosLimpa();
            }
            if (comando == "21") // Lista Geral Completa
            {
                Mainn.leituraRapidaSemCampos = false; // ler tudo
                ListaGeral.AssemblyOccurence();
                ListaGeral.CriarListaUnica();
                //ListaGeral.CriarListaUnicaLimpa();
                ListaGeral.CriarListaComprasCorteLaserEtc(true); // false para custos
                Arquivo.PrintListaCompleta();
            }
            if (comando == "22") // Integrador
            {
                ListaGeral.AssemblyOccurence();
                ListaGeral.CriarListaUnica();
                ListaGeral.CriarListaComprasCorteLaserEtc(true);
                Integrador.InserirPedidoProducao("Projeto Teste", Mainn.codigo, Mainn.pathh);
            }
            if (comando == "23") // Lista Geral Completa para Custos 
            {
                Mainn.leituraRapidaSemCampos = false; // ler tudo
                ListaGeral.AssemblyOccurence();
                ListaGeral.CriarListaUnica();
                //ListaGeral.CriarListaUnicaLimpa();
                ListaGeral.CriarListaComprasCorteLaserEtc(false); // false para custos
                Arquivo.PrintListaCompleta();
            }

            if (comando == "99") // pega lista editavel e limpa deixando só um resultado, agora usar compras2.csv
            {
                OrdenarListas.AbrirListaCompras();
            }

            if (comando == "454")
            {
                PrivataGame.Inicio();
            }

            if (comando == "666")
            {
                Console.Clear();
                IntelbrasBuffer.GerarProdutos();
                IntelbrasBuffer.Gerador(1);
            }


            relogio.Stop();
            Console.WriteLine("Tempo execucao processo foi de " + relogio.Elapsed.TotalSeconds.ToString() + " segundos.");
            


            Console.WriteLine("Digite S para Sair ou qualquer tecla para Reiniciar o Programa");

            string check = Console.ReadLine();

            if (check == "S")
            {
                if (System.Windows.Forms.Application.MessageLoop)
                {
                    // WinForms app
                    System.Windows.Forms.Application.Exit();
                }
                else
                {
                    // Console app
                    System.Environment.Exit(1);
                }
            }
            else
            {
                Abrir();
            }


        }
    }
}
