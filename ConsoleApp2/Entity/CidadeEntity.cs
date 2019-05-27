using System;

namespace ConsoleApp2.Entity
{
    public class CidadeEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid EstadoId { get; set; }
        public EstadoEntity Estado { get; set; }

        public CidadeEntity()
        {
            this.Estado = new EstadoEntity();
        }
    }
}
