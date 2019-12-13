using System.Collections.Generic;
using RoleTopMvc.Models;
using RoleTopMvc.Repositories;

namespace RoleTopMvc.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        public List<Orcamento> Orcamento {get;set;}
        public uint PedidosAprovados {get;set;}
        public uint PedidosReprovados {get;set;}
        public uint PedidosPendentes {get;set;}

        public DashboardViewModel()
        {
            this.Orcamento = new List<Orcamento>();
        }
    }        
}
