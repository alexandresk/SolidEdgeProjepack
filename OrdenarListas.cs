using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjeMacro
{
    class OrdenarListas
    {

        public static string[] arrayCompras;
        public static string[] arrayComprasPreco;
        public static string[] arrayComprasDesc;

        public static string[] arrayCompras2;
        public static string[] arrayComprasPreco2;
        public static string[] arrayComprasDesc2;

        public static string[] saidaSplit;

        public static void AbrirListaCompras() 
        {
            arrayCompras = System.IO.File.ReadAllLines(@"\\fs\e\Projetos\ProjeMacroListas\listaComprasEditavel.csv");
            arrayComprasPreco = new string[arrayCompras.Length];
            arrayComprasDesc = new string[arrayCompras.Length];

            arrayCompras2 = new string[arrayCompras.Length];
            arrayComprasPreco2 = new string[arrayCompras.Length];
            arrayComprasDesc2 = new string[arrayCompras.Length];

            bool igual = false;

            int cont = 0;

            

            for (int i = 0; i < arrayCompras.Length; i++)
            {

                saidaSplit = arrayCompras[i].Split(';');

                arrayComprasPreco[i] = saidaSplit[0].Replace('.', ','); // replace pra limpar enganos de . por ,
                arrayCompras[i] = saidaSplit[1];
                arrayComprasDesc[i] = saidaSplit[2];
                Console.WriteLine("lista compras:  " + arrayCompras[i] + " Preco: " + arrayComprasPreco[i]);
                igual = false;

                for (int x = 0; x < arrayCompras.Length; x++)
                {
                    
                    if( arrayCompras[i] == arrayCompras2[x] )
                    {
                        igual = true;
                    }
                }

                if(igual == false)
                {
                    Console.WriteLine(arrayCompras[i]);
                    arrayCompras2[cont] = arrayCompras[i];
                    arrayComprasDesc2[cont] = arrayComprasDesc[i];
                    arrayComprasPreco2[cont] = arrayComprasPreco[i];
                    cont++;
                }
                else
                {
                    Console.WriteLine(arrayCompras[i] + " repetido");
                }
            }

            using (StreamWriter sw = File.CreateText(@"\\fs\e\Projetos\ProjeMacroListas\listaComprasEditavelSaida.csv"))
            {
                for (int i = 0; i < arrayCompras2.Length; i++)
                {
                    if(arrayCompras2[i] != null) // pra evitar a printar linhas vazias so com ;;
                    {
                        sw.WriteLine(arrayComprasPreco2[i] + "; " + arrayCompras2[i] + "; " + arrayComprasDesc2[i]);
                    }
                    
                }
                    
            }
        }

        
    }
}
