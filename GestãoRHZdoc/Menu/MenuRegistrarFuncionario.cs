using GestãoRHZdoc.Data;
using GestãoRHZdoc.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GestãoRHZdoc.Menu
{
    internal class MenuRegistrarFuncionario : Menu
    {
        public override void Executar(FuncionarioDAL funcionarioDAL)
        {
            base.Executar(funcionarioDAL);
            ExibirTituloDaOpcao("Registro de Funcionarios");
            Console.Write("Digite o nome do funcionario que deseja registrar: ");
            string nomeDoFuncionario = Console.ReadLine() ?? string.Empty;
            Console.WriteLine($"Digite o cargo de {nomeDoFuncionario}");
            string cargoDoFuncionario = Console.ReadLine() ?? string.Empty;
            Console.WriteLine($"Qual o salario de {nomeDoFuncionario}");
            string entradaSalario = Console.ReadLine() ?? string.Empty;

            // Substituir vírgula por ponto se necessário (ou vice-versa, dependendo da cultura)
            entradaSalario = entradaSalario.Replace(",", ".");

            decimal salarioFuncionario = decimal.Parse(entradaSalario, System.Globalization.CultureInfo.InvariantCulture);
            Console.WriteLine($"Você digitou: {salarioFuncionario}");
            Console.WriteLine($"Digite a data que {nomeDoFuncionario} foi admitido na empresa: ");
            string entradaDataAdmissao = Console.ReadLine() ?? string.Empty;
            DateTime dataAdmissaoFuncionario = DateTime.Parse(entradaDataAdmissao, System.Globalization.CultureInfo.InvariantCulture);
            Console.WriteLine($"Você digitou: {dataAdmissaoFuncionario.ToShortDateString()}");
            //Gerar um ID numero único para o funcionário
            int idFuncionario = GlobalData.FuncionariosRegistrados.Count + 1;
            // Criar o objeto Funcionario
            Funcionario funcionario = new Funcionario(idFuncionario, nomeDoFuncionario, cargoDoFuncionario, dataAdmissaoFuncionario, salarioFuncionario);
            GlobalData.FuncionariosRegistrados.Add(nomeDoFuncionario, funcionario);
        }
    }
}
