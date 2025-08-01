using GestãoRHZdoc.Data;
using GestãoRHZdoc.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestãoRHZdoc.Menu
{
    internal class MenuMostrarFuncionarios : Menu
    {
        public override void Executar(FuncionarioDAL funcionarioDAL)
        {
            base.Executar(funcionarioDAL);
            ExibirTituloDaOpcao("Exibindo todos os funcionários registrados na nossa aplicação");

              foreach (var funcionario in funcionarioDAL.Listar())
                {
                    Console.WriteLine(funcionario.ToString());
                }
  
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }

    }
}
