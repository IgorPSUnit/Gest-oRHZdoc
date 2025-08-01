using GestãoRHZdoc.Modelos; // ✅ Importa as entidades do RH
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestãoRHZdoc.Data
{
    
    internal class DAL<T> where T : class
    {
        //Usa o contexto da sua aplicação RH
        protected readonly GestaoRHContext context;

        //Construtor recebendo o contexto do RH
        public DAL(GestaoRHContext context)
        {
            this.context = context;
        }

        //Lista todos os registros da entidade T
        public IEnumerable<T> Listar()
        {
            return context.Set<T>().ToList();
        }

        //Adiciona um novo objeto do tipo T ao banco
        public void Adicionar(T objeto)
        {
            context.Set<T>().Add(objeto);
            context.SaveChanges();
        }

        //Atualiza um objeto existente
        public void Atualizar(T objeto)
        {
            context.Set<T>().Update(objeto);
            context.SaveChanges();
        }

        //Remove um objeto do banco
        public void Deletar(T objeto)
        {
            context.Set<T>().Remove(objeto);
            context.SaveChanges();
        }

        //Recupera um objeto baseado em uma condição (ex: x => x.Id == 1)
        public T? RecuperarPor(Func<T, bool> condicao)
        {
            return context.Set<T>().FirstOrDefault(condicao);
        }

        //Lista todos os objetos que satisfazem a condição
        public IEnumerable<T> ListarPor(Func<T, bool> condicao)
        {
            return context.Set<T>().Where(condicao);
        }
    }
}
