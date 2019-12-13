using System.IO;
using System;
using RoleTopMvc.Models;


namespace RoleTopMvc.Repositories
{
    public class ClienteRepository : RepositoryBase
    {
        private const string PATH = "Database/Cliente.csv";
        public ClienteRepository()
        {
            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }
        public bool Inserir (Cliente cliente)
        {
            var linha = new string[] { PrepararRegistroCSV(cliente) };
            File.AppendAllLines(PATH, linha);

            return true;
        }

        
        private string PrepararRegistroCSV(Cliente cliente)
        {
            return $"nome={cliente.Nome};email={cliente.Email};senha={cliente.Senha};telefone={cliente.Telefone};data_nascimento={cliente.DataNascimento};tipo_usuario={cliente.TipoUsuario}";
        }

        public Cliente ObterPor (string email)
        {
            var linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                if(ExtrairValorDoCampo("email", item).Equals(email))
                {
                    Cliente c = new Cliente();
                    c.Nome = ExtrairValorDoCampo("nome", item);
                    c.TipoUsuario = uint.Parse(ExtrairValorDoCampo("tipo_usuario", item));
                    c.Email = ExtrairValorDoCampo("email", item);
                    c.DataNascimento = 
                    DateTime.Parse(ExtrairValorDoCampo("data_nascimento", item));
                    c.Telefone = ExtrairValorDoCampo("telefone", item);
                    c.Senha = ExtrairValorDoCampo("senha", item);

                    return c;
                }
            }
            return null;
        }
    }
}

