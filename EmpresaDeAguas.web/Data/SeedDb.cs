using EmpresaDeAguas.web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaDeAguas.web.Data
{
    public class SeedDb
    {
        private readonly DataContext context;

        private Random random;

        public SeedDb(DataContext context)
        {
            this.context = context;

            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            if(!this.context.Contadores.Any())
            {
                this.AddContador("Lisboa");
                this.AddContador("Porto");
                this.AddContador("Aveiro");
                await this.context.SaveChangesAsync();
            }
        }

        private void AddContador(string morada)
        {
            this.context.Contadores.Add(new Contador
            {
                Morada = morada,
                Codigo_postal = this.random.Next(9999)
            });
        }
    }
}
