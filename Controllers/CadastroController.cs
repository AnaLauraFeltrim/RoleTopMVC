using System;
using RoleTopMvc.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTopMvc.Models;

namespace RoleTopMvc.Controllers
{
    public class CadastroController : Controller
    {
        ClienteRepository clienteRepository = new ClienteRepository();
        public IActionResult Cadastro () {
            return View (); 
        }

        public IActionResult CadastrarCliente (IFormCollection form) 
        {
            ViewData["Action"] = "Cadastro";
            try {
                Cliente cliente = new Cliente (
                    form["nome"],
                    form["email"],
                    form["senha"],
                    form["telefone"],
                    DateTime.Parse (form["data_Nascimento"]));

                    clienteRepository.Inserir(cliente);
                    
                return View ("Sucesso");
            } 
            catch (Exception e) 
            {
                System.Console.WriteLine (e.StackTrace);
                return View ("Erro");
            }
        }
    }
}