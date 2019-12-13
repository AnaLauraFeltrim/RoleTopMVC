using System;


namespace RoleTopMvc.Models
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string Email {get;set;}
        public string Telefone {get;set;}
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public uint TipoUsuario {get;set;}

        public Cliente () {

        }

        public Cliente (string nome, string email, string senha,  string telefone, DateTime dataNascimento) {
            this.Nome = nome;
            this.Email = email;
            this.Telefone = telefone;
            this.Senha = senha;
            this.DataNascimento = dataNascimento;
            

        }
    }
}