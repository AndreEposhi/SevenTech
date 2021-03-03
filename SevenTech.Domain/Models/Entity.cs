using System;

namespace SevenTech.Domain.Models
{
    /// <summary>
    /// Entidade base para outras entidades
    /// </summary>
    public abstract class Entity
    {
        public DateTime DataCadastro { get; private set; }
        public int Id { get; private set; }

        protected Entity() { }
        public Entity(int id)
        {
            Id = id;
            DataCadastro = DateTime.Now.Date;
        }
    }
}