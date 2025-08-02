using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace GestãoRHZdoc.Modelos
{
    public class Ferias
    {
        public int IdFerias { get; set; }
        public int IdFuncionario { get; set; }
        public virtual Funcionario Funcionario { get; set; } = null!;
        public DateTime? DataInicio { get; private set; }
        public DateTime? DataTermino { get; private set; }

        public string StatusFerias
        {
            get
            {
                if (!DataInicio.HasValue || !DataTermino.HasValue)
                    return "Não definido";

                DateTime hoje = DateTime.Today;
                DateTime inicio = DataInicio.Value;
                DateTime fim = DataTermino.Value;

                if (hoje < inicio)
                    return "Pendente";
                else if (hoje >= inicio && hoje <= fim)
                    return "Em andamento";
                else
                    return "Concluídas";
            }
        }

        //public Ferias(Funcionario funcionario, string dataInicio, string dataTermino)
        //{
        //    if (funcionario == null)
        //        throw new ArgumentNullException(nameof(funcionario), "Funcionário não pode ser nulo.");

        //    Funcionario = funcionario;
        //    IdFuncionario = funcionario.Id;

        //    DefinirPeriodo(dataInicio, dataTermino);
        //}

        //private void DefinirPeriodo(string dataInicio, string dataTermino)
        //{
        //    if (!DateTime.TryParse(dataInicio, out DateTime inicio))
        //        throw new ArgumentException("Data de início inválida.", nameof(dataInicio));

        //    if (!DateTime.TryParse(dataTermino, out DateTime termino))
        //        throw new ArgumentException("Data de término inválida.", nameof(dataTermino));

        //    if (termino < inicio)
        //        throw new ArgumentException("A data de término não pode ser anterior à data de início.");

        //    if ((termino - inicio).TotalDays > 30)
        //        throw new ArgumentException("O período de férias não pode exceder 30 dias.");

        //    DataInicio = inicio;
        //    DataTermino = termino;
        //}

        //public override string ToString()
        //{
        //    return $"Funcionário: {Funcionario.Nome} | Início: {DataInicio:dd/MM/yyyy} | Fim: {DataTermino:dd/MM/yyyy} | Status: {StatusFerias}";
        //}

        //public void EditarFerias(string novaDataInicio, string novaDataTermino)
        //{
        //    DefinirPeriodo(novaDataInicio, novaDataTermino);
        //    Console.WriteLine("Férias editadas com sucesso!");
        //}

        //public void ExibirCadastroComFerias(Funcionario funcionario)
        //{
        //    Console.WriteLine("Cadastro de Férias");
        //    Console.WriteLine("-------------------");
        //    Console.WriteLine($"Funcionário: {funcionario.Nome}");
        //    Console.WriteLine($"Cargo: {funcionario.Cargo}");
        //    Console.WriteLine($"Data de Admissão: {funcionario.DataDeAdmissão}");
        //    Console.WriteLine($"Salário: {funcionario.Salario:C}");
        //    Console.WriteLine($"Data de Início: {funcionario.FeriasDataInicio:dd/MM/yyyy}");
        //    Console.WriteLine($"Data de Término: {DataTermino:dd/MM/yyyy}");
        //    Console.WriteLine($"Status: {StatusFerias}");
        //}

        //public static void ConsultarFerias(List<Ferias> listaDeFerias)
        //{
        //    Console.WriteLine("Consulta de Férias");
        //    Console.WriteLine("-------------------");
        //    Console.Write("Digite o nome do funcionário para consultar as férias: ");
        //    string nomeFuncionario = Console.ReadLine();

        //    var resultados = listaDeFerias
        //        .Where(f => f.Funcionario.Nome.Equals(nomeFuncionario, StringComparison.OrdinalIgnoreCase))
        //        .ToList();

        //    if (resultados.Any())
        //    {
        //        foreach (var ferias in resultados)
        //        {
        //            Console.WriteLine(ferias);
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Nenhuma férias encontrada para este funcionário.");
        //    }
        //}

        //public void ExcluirFerias()
        //{
        //    Funcionario = null;
        //    IdFuncionario = 0;
        //    DataInicio = null;
        //    DataTermino = null;
        //    Console.WriteLine("Férias excluídas com sucesso!");
        //}
    }
}
