using Microsoft.EntityFrameworkCore;
using api_tarefas.Modelo;

namespace api_tarefas.Contexto
{
    public class TarefaContexto : DbContext
    {
        public TarefaContexto(DbContextOptions<TarefaContexto> options) : base(options)


        {

        }


        public DbSet<TarefaItem> Tarefas { get; set; } = null;
}

}
