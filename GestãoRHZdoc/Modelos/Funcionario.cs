using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestãoRHZdoc.Modelos
{
    public class Funcionario
    {
        private List<Ferias> ferias = new List<Ferias>();

        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cargo { get; set; } = string.Empty;
        public DateTime DataDeAdmissao { get; set; }
        public decimal Salario { get; set; }
        public Boolean Status { get; set; }
        public Funcionario() { }

        public virtual List<Ferias> Ferias { get => ferias; set => ferias = value; }

        public Funcionario(int id, string nome, string cargo, DateTime dataAdmissao, decimal salario)
        {
            Id = id;
            Nome = nome;
            Cargo = cargo;
            DataDeAdmissao = dataAdmissao;
            Status = true;
            Salario = salario;
        }

        public override string ToString()
        {
            string statusTexto = Status ? "Ativo" : "Inativo";
            int totalFerias = Ferias?.Count ?? 0;

            return $"Nome: {Nome}\n" +
                   $"Cargo: {Cargo}\n" +
                   $"Salário: {Salario:C}\n" +
                   $"Admissão: {DataDeAdmissao:dd/MM/yyyy}\n" +
                   $"Status: {statusTexto}\n" +
                   $"Férias registradas: {totalFerias}\n";
        }


        //public List<Ferias> ferias { get; set; } = new List<Ferias>();
        //public List<HistoricoAlteracao> historico { get; set; } = new List<HistoricoAlteracao>();

        //public IEnumerable<Ferias> Ferias => ferias;

        //public void AdicionarFerias(Ferias feria)
        //{
        //   ferias.Add(feria);
        //}

        //public void ExibirFerias()
        //{
        //    Console.WriteLine($"As ferias de {Nome} começam {Ferias.}");
        //}
    }
}
