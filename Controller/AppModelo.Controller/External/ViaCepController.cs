using AppModelo.Model.Domain.Wrappers;
using AppModelo.Model.Infra.ViaCep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModelo.Controller.External
{
    public class ViaCepController
    {
        public ViaCepWrapper Obter(string cep)
        {
            
            
            var service = new ViaCepService();
            var viaCep = service.ObterDaApi(cep);

            return viaCep;
        }
    }
}
