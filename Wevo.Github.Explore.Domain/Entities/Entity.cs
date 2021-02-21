using System;
using System.ComponentModel;

namespace Wevo.Github.Explore.Domain.Entities
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.Now;
            Ativo = true;
        }
        public Guid Id { get; set; }

        [DisplayName("Data de criação")]
        public DateTime DataCriacao { get; set; }
        [DisplayName("Data de alteração")]
        public DateTime DataAlteracao { get; set; }
        public string UserGithub { get; set; }
        public bool Ativo { get; set; }
    }
}
