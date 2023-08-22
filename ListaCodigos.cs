using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeMacro
{

    public class ListaCodigos
    {
        public ListaCodigos() { }

        public string Codigo { get; set; }
        public string Path { get; set; }
        public int Quant { get; set; }
        public int Sub { get; set; }
        public string Nome { get; set; }
        public string Projeto { get; set; }
        public string Desc1 { get; set; }
        public string Desc2 { get; set; }
        public string Desc3 { get; set; }
        public string Op1 { get; set; }
        public string Op2 { get; set; }
        public string Op3 { get; set; }
        public string Op4 { get; set; }
        public string Op5 { get; set; }
        public double Volume { get; set; }
        public double Area { get; set; }
        public double Mass { get; set; }
        public double Preco { get; set; }
        public string Tempo { get; set; }
        public string Pcp { get; set; }

        public ListaCodigos(
            string codigo,
            string path, 
            int quant, 
            int sub, 
            string nome, 
            string projeto,
            string desc1, 
            string desc2, 
            string desc3,
            string op1,
            string op2,
            string op3,
            string op4,
            string op5,
            double volume,
            double area,
            double mass,
            double preco,
            string tempo,
            string pcp // Corte, Lares, Guilhotina, Direto, Estoque
            )
        {
            this.Codigo = codigo;
            this.Path = path;
            this.Quant = quant;
            this.Sub = sub;
            this.Nome = nome;
            this.Projeto = projeto;
            this.Desc1 = desc1;
            this.Desc2 = desc2;
            this.Desc3 = desc3;
            this.Op1 = op1;
            this.Op2 = op2;
            this.Op3 = op3;
            this.Op4 = op4;
            this.Op5 = op5;
            this.Volume = volume;
            this.Area = area;
            this.Mass = mass;
            this.Preco = preco;
            this.Tempo = tempo;
            this.Pcp = pcp;
        }
    }
}
