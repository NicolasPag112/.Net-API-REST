using System;

namespace TarefasBackEnd.Model
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email  { get; set; }
        public string Senha  { get; set; }
    }
}