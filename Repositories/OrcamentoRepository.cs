using System;
using System.Collections.Generic;
using System.IO;
using RoleTopMvc.Models;
using RoleTopMvc.Repositories;  

namespace RoleTopMvc.Repositories {
    public class OrcamentoRepository {
        private const string PATH = "Database/Orcamento.csv";
        public OrcamentoRepository () {
            if (!File.Exists (PATH)) {
                File.Create (PATH).Close ();
            }
        }
        public bool Inserir (Orcamento orcamento) {
            var linha = new string[] { PrepararOrcamentoCSV (orcamento) };
            File.AppendAllLines (PATH, linha);

            return true;
        }

        private string PrepararOrcamentoCSV (Orcamento orcamento) {
            return $"nome={orcamento.Nome};email={orcamento.Email};telefone={orcamento.Telefone};data_evento={orcamento.DataEvento};tipo_evento={orcamento.Evento};observacoes={orcamento.Observacoes}";
        }

        public List<Orcamento> ObterTodos () {
            var linhas = File.ReadAllLines (PATH);
            List<Orcamento> pedidos = new List<Orcamento>();

            foreach (var linha in linhas) {
                Orcamento orcamento = new Orcamento ();

                orcamento.Nome = ExtrairValorDoCampo("nome", linha);
                orcamento.Email = ExtrairValorDoCampo("email", linha);
                orcamento.Telefone = ExtrairValorDoCampo("telefone", linha);
                orcamento.DataEvento = DateTime.Parse(ExtrairValorDoCampo("data_evento", linha));
                orcamento.Evento = ExtrairValorDoCampo("evento", linha);
                orcamento.Observacoes = ExtrairValorDoCampo("cliente_observacoes", linha);
                orcamento.Status = uint.Parse(ExtrairValorDoCampo("status_orcamento", linha));

                pedidos.Add(orcamento);
            }
            return null;
        }

        protected string ExtrairValorDoCampo (string nomeCampo, string linha) {
            var chave = nomeCampo;

            var indiceChave = linha.IndexOf (chave);
            var indiceTerminal = linha.IndexOf (";", indiceChave);

            var valor = "";

            if (indiceTerminal != -1) {
                valor = linha.Substring (indiceChave, indiceTerminal - indiceChave);
            } else {
                valor = linha.Substring (indiceChave);
            }
            System.Console.WriteLine ($"Campo {nomeCampo} e valor {valor}");
            return valor.Replace (nomeCampo + "=", "");
        }
    }
}