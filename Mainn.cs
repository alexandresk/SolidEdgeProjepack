using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidEdgeFramework;
using SolidEdgeAssembly;
using SolidEdgeCommunity;
using System.Threading;
using System.Net;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Diagnostics;






namespace ProjeMacro
{
    class Mainn
    {

       

        public static List<ListaCodigos> codigos;
        public static List<ListaCodigos> codigosUnicos;
        public static List<ListaCodigos> codigosImpressao;

        public static List<ListaCodigos> codigosCompras;
        public static List<ListaCodigos> codigosCorte;
        public static List<ListaCodigos> codigosLaser;
        public static List<ListaCodigos> codigosGuilho;
        public static List<ListaCodigos> codigosPlanas;
        public static List<ListaCodigos> codigosResto;
        public static List<ListaCodigos> codigosExclusao;
        public static List<ListaCodigos> codigosAss;

        public static string[] arrayExclusao;
        public static string[] arrayCompras;
        public static string[] arrayComprasPreco;
        public static string[] arrayCorte;
        public static string[] arrayLaser;
        public static string[] arrayGuilho;
        public static string[] arrayPlanas;

        //public static string[] arrayReguas; // para excluir da lista;

        public static string pathh;
        public static string codigo;
        public static string nome;

        public static bool leituraRapidaSemCampos = false;
        public static string Usuario;

        public static float precoCorte;
        public static float precoGuilhotina;
        public static float precoLaser;
        public static float precoPlanas;

        static void Main(string[] args)
        {
            codigo = "";
            pathh = "";
            nome = "";

            codigos = new List<ListaCodigos>();
            codigosUnicos = new List<ListaCodigos>();
            codigosImpressao = new List<ListaCodigos>();
            codigosCompras = new List<ListaCodigos>();
            codigosCorte = new List<ListaCodigos>();
            codigosLaser = new List<ListaCodigos>();
            codigosGuilho = new List<ListaCodigos>();
            codigosPlanas = new List<ListaCodigos>();
            codigosResto = new List<ListaCodigos>();
            codigosExclusao = new List<ListaCodigos>();
            codigosAss = new List<ListaCodigos>();

            ListaGeral.AbrirListaExclusoes();
            ListaGeral.AbrirListaCompras();
            ListaGeral.AbrirListaLaser();
            ListaGeral.AbrirListaGuilho();
            ListaGeral.AbrirListaCorte();
            ListaGeral.AbrirListaPlanas();
            ListaGeral.AbrirListaPrecos();
            FuncoesGeral.LerNomeDoUsuario();


            /* // Abrindo um programa externo e esperando finalizar para continuar 
            Process ExternalProcess = new Process();
            ExternalProcess.StartInfo.FileName = "Notepad.exe";
            ExternalProcess.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            ExternalProcess.Start();
            ExternalProcess.WaitForExit();*/

            if (password.Pass()) 
            {
                Welcome.Abrir(); 
                
            }
            else
            {
                Console.WriteLine("Teste Versao failed ");
            }
            

        }

        
    }
}