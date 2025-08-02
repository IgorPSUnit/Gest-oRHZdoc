using GestãoRHZdoc.Data;
using GestãoRHZdoc.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestãoRHZdoc.Menu
{
    internal class MenuMostrarFerias : Menu
    {
        public override void Executar(FuncionarioDAL funcionarioDAL)
        {
            base.Executar(funcionarioDAL);
            ExibirTituloDaOpcao("Exibindo todas as férias registradas na nossa aplicação");

            foreach (var funcionario in GlobalData.FuncionariosRegistrados.Values)
            {
                if (funcionario.Ferias != null && funcionario.Ferias.Any())
                {
                    Console.WriteLine($"\nFuncionário: {funcionario.Nome}");

                    foreach (var ferias in funcionario.Ferias)
                    {
                        Console.WriteLine($"- Período: {ferias.DataInicio?.ToString("dd/MM/yyyy")} a {ferias.DataTermino?.ToString("dd/MM/yyyy")} - Status: {ferias.StatusFerias}");
                    }

                    Console.WriteLine();
                }
            }

            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }

    }
}
