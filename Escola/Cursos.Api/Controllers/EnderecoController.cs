using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Cursos.Business;

namespace Cursos.Api.Controllers
{
    [RoutePrefix("services/endereco")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EnderecoController : ApiController
    {
        [Route("getendereco/{cep}")]
        public HttpResponseMessage GetEndereco(string cep)
        {
            try
            {
                var ws = new WsCorreios.AtendeClienteClient();
                var resposta = ws.consultaCEP(cep.Replace(".", ""));
                var retorno = new EnderecoViewModel();
                if (resposta != null)
                {
                    retorno = new EnderecoViewModel
                    {
                        Endereco = resposta.end,
                        Bairro = resposta.bairro,
                        Cidade = resposta.cidade,
                        Complemento = resposta.complemento,
                        Uf = resposta.uf
                    };
                }
                return Request.CreateResponse(HttpStatusCode.OK, retorno);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, string.Empty);
            }
        }
    }
}
