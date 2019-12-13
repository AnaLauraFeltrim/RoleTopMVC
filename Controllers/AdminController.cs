using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTopMvc.Models;
using RoleTopMvc.Repositories;
using RoleTopMvc.ViewModels;

namespace RoleTopMvc.Controllers
{
    public class AdministradorController : AbstractController
    {
        OrcamentoRepository orcamentorepository = new OrcamentoRepository();
        
            OrcamentoRepository pedidoRepository = new OrcamentoRepository();
        public IActionResult Dashboard()
        {
            
            DashboardViewModel dashboardViewModel = new DashboardViewModel();
            
            
            dashboardViewModel.NomeView = "Dashboard";
            dashboardViewModel.UsuarioEmail = ObterUsuarioSession();

            return View(dashboardViewModel);
        
        } 


    }
}