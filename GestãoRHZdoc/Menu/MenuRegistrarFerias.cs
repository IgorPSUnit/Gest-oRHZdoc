using GestãoRHZdoc.Data;
using GestãoRHZdoc.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestãoRHZdoc.Menu
{
    internal class MenuRegistrarFerias : Menu
    {
        public override void Executar(FuncionarioDAL funcionarioDAL)
        {
            base.Executar(funcionarioDAL);
            ExibirTituloDaOpcao("Registro de Férias");
            Console.Write("Digite o nome do funcionário que deseja registrar férias: ");
            string nomeDoFuncionario = Console.ReadLine() ?? string.Empty;
            if (GlobalData.FuncionariosRegistrados.TryGetValue(nomeDoFuncionario, out Funcionario? funcionario) && funcionario != null)
            {
                Console.WriteLine($"Digite a data de início das férias de {nomeDoFuncionario} (formato: dd/MM/yyyy): ");
                string entradaDataInicio = Console.ReadLine() ?? string.Empty;
                DateTime dataInicioFerias = DateTime.ParseExact(entradaDataInicio, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                Console.WriteLine($"Digite a data de término das férias de {nomeDoFuncionario} (formato: dd/MM/yyyy): ");
                string entradaDataFim = Console.ReadLine() ?? string.Empty;
                DateTime dataFimFerias = DateTime.ParseExact(entradaDataFim, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                // Registrar as férias no funcionário


                Console.WriteLine($"Férias registradas com sucesso para {nomeDoFuncionario}!");
            }
            else
            {
                Console.WriteLine($"Funcionário {nomeDoFuncionario} não encontrado.");
            }
        }
    }
}
