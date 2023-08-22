using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ProjeMacro
{
    class IntelbrasBuffer
    {


        // com o buffer ligado deu 30% de troca de bobina
        // com buffer desligado fica em 50%, ou seja pra cada 2 volumes 1 

        // com segundo processo de selecao. Fica em 27%

        //com segundo buffer (B) e com os processos de selecao, consegue baixar pra 25%


        public static int buffer = 1;
        public static int esteira = 0;
        public static int pos1 = 0;
        public static int pre1 = 0;
        public static int pre2 = 0;
        public static int pre3 = 0;


        public static int bufferB = 1;
        public static int esteiraB = 0;
        public static int pos1B = 0;
        public static int pre1B = 0;
        public static int pre2B = 0;
        public static int pre3B = 0;

        public static int contadorBuffer = 0;
        public static int contadorBufferB = 0;
        public static int contadorTrocas = 0;
        public static int contadorProdutos = 0;


        public static Random rnd = new Random();

        public static int[] produtos = new int[5000];

        public static string[] prod = new string[3] { "       " , " 00000 ", " XXXXX " };

        public static void GerarProdutos()
        {
            for (int i = 0; i < produtos.Length; i++)
            {
                produtos[i] = rnd.Next(1, 3);
                //Console.WriteLine(produtos[i]);
               
            }



        }

        public static void Gerador(int passo)
        {
            string temp;
            string linha = "      ";
            string outLinha;
            string outBuffer;

            Ciclo(passo);

            for (int i = passo; i < produtos.Length; i++)
            {
                temp = prod[produtos[i]];
                if( i == passo + 3) { temp = "*" + temp;}
                linha = linha + temp;
                
                
            }

            

            outLinha = linha.Substring(0, 200);
            //outBuffer = "      " + prod[0] + prod[0] + prod[0] + prod[buffer];
            outBuffer = "      " + prod[0] + prod[0] + prod[0] + prod[buffer] +  prod[0] + prod[0] + prod[bufferB];

            Console.SetCursorPosition(0, 15);
            Console.WriteLine(outLinha);
            Console.WriteLine(outLinha);
            Console.WriteLine(outBuffer);
            Console.WriteLine(outBuffer);



            Console.ReadKey(); // manual
            //if(passo > 4900) { Console.ReadKey(); } // auto até o fim
            Gerador(passo + 1);
        }
        


        public static void Ciclo( int posicao)
        {
            double fracao;
            bool diee = false;

            esteira = produtos[posicao + 3];
            pos1 = produtos[posicao + 2];
            pre1 = produtos[posicao + 4];
            pre2 = produtos[posicao + 5];


            bool dieeB = false;

            esteiraB = produtos[posicao + 6];
            pos1B = produtos[posicao + 5];
            pre1B = produtos[posicao + 7];
            pre2B = produtos[posicao + 8];

            Console.SetCursorPosition(0, 24);
            Console.WriteLine("                                                                               ");
            
            
            if (buffer == 2 && esteira == 1)
            {
                if (pos1 == 2 && pre1 == 2 && diee == false)
                {
                    // mover buffer pra esteira
                    Console.WriteLine("Trocou buffer " + prod[buffer] + " por " + prod[produtos[posicao + 3]] + " Contador Buffer: " + contadorBuffer);
                    produtos[posicao + 3] = buffer;
                    buffer = 1;
                    diee = true;
                }

                //if (pre1 == 2 && pre2 == 2 && pos1 == 1 && diee == false) aumentou de 30 % para 33 %
                if (pre1 == 1 && pre2 == 1 && pos1 == 2 && diee == false) // caiu pra 27% :o
                {
                    // mover buffer pra esteira
                    Console.WriteLine("Trocou buffer v2 " + prod[buffer] + " por " + prod[produtos[posicao + 3]] + " Contador Buffer: " + contadorBuffer);
                    produtos[posicao + 3] = buffer;
                    buffer = 1;
                    diee = true;
                }

            }
            if (buffer == 1 && esteira == 2 && diee == false)
            {
                if (pos1 == 1 && pre1 == 1 && diee == false)
                {
                    // mover buffer para esteira
                    Console.WriteLine("Trocou buffer " + prod[buffer] + " por " + prod[produtos[posicao + 3]] + " Contador Buffer: " + contadorBuffer);
                    produtos[posicao + 3] = buffer;
                    buffer = 2;
                    diee = true;
                }

                //if (pre1 == 1 && pre2 == 1 && pos1 == 2 && diee == false) aumentou de 30% para 33%
                if (pre1 == 2 && pre2 == 2 && pos1 == 1 && diee == false) // caiu pra 27%
                {
                    // mover buffer pra esteira
                    Console.WriteLine("Trocou buffer v2 " + prod[buffer] + " por " + prod[produtos[posicao + 3]] + " Contador Buffer: " + contadorBuffer);
                    produtos[posicao + 3] = buffer;
                    buffer = 2;
                    diee = true;
                }
            }

            if(diee == true) { contadorBuffer++;  }


            if (bufferB == 2 && esteiraB == 1)
            {
                /*if (pos1B == 2 && pre1B == 2 && dieeB == false)
                {
                    // mover buffer pra esteira
                    Console.WriteLine("Trocou buffer " + prod[bufferB] + " por " + prod[produtos[posicao + 6]] + " Contador Buffer: " + contadorBufferB);
                    produtos[posicao + 6] = bufferB;
                    bufferB = 1;
                    dieeB = true;
                }*/

                //if (pre1 == 2 && pre2 == 2 && pos1 == 1 && diee == false) aumentou de 30 % para 33 %
                /*if (pre1B == 1 && pre2B == 1 && pos1B == 2 && dieeB == false) // caiu pra 27% :o
                {
                    // mover buffer pra esteira
                    Console.WriteLine("Trocou buffer v2 " + prod[bufferB] + " por " + prod[produtos[posicao + 6]] + " Contador Buffer: " + contadorBufferB);
                    produtos[posicao + 6] = bufferB;
                    bufferB = 1;
                    dieeB = true;
                }*/

            }
            if (bufferB == 1 && esteiraB == 2 && dieeB == false)
            {
                /*if (pos1B == 1 && pre1B == 1 && dieeB == false)
                {
                    // mover buffer para esteira
                    Console.WriteLine("Trocou buffer " + prod[bufferB] + " por " + prod[produtos[posicao + 6]] + " Contador Buffer: " + contadorBufferB);
                    produtos[posicao + 6] = bufferB;
                    bufferB = 2;
                    dieeB = true;
                }*/

                //if (pre1 == 1 && pre2 == 1 && pos1 == 2 && diee == false) aumentou de 30% para 33%
                /*if (pre1B == 2 && pre2B == 2 && pos1B == 1 && dieeB == false) // caiu pra 27%
                {
                    // mover buffer pra esteira
                    Console.WriteLine("Trocou buffer v2 " + prod[bufferB] + " por " + prod[produtos[posicao + 6]] + " Contador Buffer: " + contadorBufferB);
                    produtos[posicao + 6] = bufferB;
                    bufferB = 2;
                    dieeB = true;
                }*/
            }

            if (dieeB == true) { contadorBufferB++; }


            /*if (buffer == 0 && esteira > 0)
            {
                if (pos1 == 1 && pre1 == 1 && esteira == 2)
                {
                    // mover esteira pra buffer
                }
                if (pos1 == 2 && pre1 == 2 && esteira == 1)
                {
                    // mover esteira pra buffer
                }
            }*/



            contadorProdutos++;

            // contando trocas
            if(produtos[posicao -1 ] != produtos[posicao])
            {
                contadorTrocas++;
                Console.SetCursorPosition(0, 28);
                Console.WriteLine("Total de Trocas:  " + contadorTrocas + "                                                    ");
            }

            fracao = ( (double)contadorTrocas / ((double)contadorProdutos + 1) ) * 100;

            Console.SetCursorPosition(0, 30);
            Console.WriteLine("Produtos: " + contadorProdutos + " T/P =  " +  fracao.ToString() + "%                        " );

        }


    }
}
