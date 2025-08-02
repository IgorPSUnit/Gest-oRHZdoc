using GestãoRHZdoc.Modelos;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestãoRHZdoc.Data
{
    internal class FuncionarioDAL
    {
        private readonly GestaoRHContext context;
        public FuncionarioDAL(GestaoRHContext context)
        {
            this.context = context;
        }

        public IEnumerable<Funcionario> Listar()
        {
            return context.Funcionario.ToList();
        }

        public void Adicionar(Funcionario funcionario)
        {
            context.Funcionario.Add(funcionario);
            context.SaveChanges();
        }

        public void Atualizar(Funcionario funcionario)
        {
            context.Funcionario.Update(funcionario);
            context.SaveChanges();
        }

        public void Deletar(Funcionario funcionario)
        {
            context.Funcionario.Remove(funcionario);
            context.SaveChanges();
        }

        public IEnumerable<Funcionario> BuscarPorCargo(string cargo)
        {
            return context.Funcionario.Where(f => f.Cargo == cargo).ToList();
        }
    }


}
