using RoleTopMvc.Enums;
using RoleTopMvc.Repositories;
using System;

namespace RoleTopMvc.Models
{
    public class Orcamento
    {
        public string Nome {get;set;}
        public string Telefone {get;set;}
        public string Email {get;set;}
        public DateTime DataEvento {get;set;}
        public string Evento {get;set;}  
        public string Observacoes {get;set;}
        public uint Status {get;set;}

        public Orcamento ()
        {
            
        }

        public Orcamento (string nome, string email, string telefone, DateTime dataEvento, string evento, string observacoes)
        {
            this.Nome = nome;
            this.Email = email;
            this.Telefone = telefone;
            this.DataEvento = dataEvento;
            this.Evento = evento;
            this.Observacoes = observacoes;
            this.Status = (uint)StatusOrcamento.PENDENTE;
        }
    }
}