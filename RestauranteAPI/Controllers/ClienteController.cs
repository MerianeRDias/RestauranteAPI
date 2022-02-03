using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestauranteAPI.Conexoes;
using System;
using System.Collections.Generic;

namespace RestauranteAPI.Controllers
{
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly Conexoes.Sql _sql;

        public ClienteController()
        {
            _sql = new Conexoes.Sql();
        }

        [HttpPost ("v1/Cliente")] 
        public IActionResult CadastrarCliente(Model.Cliente cliente)
        {
            try 
            {
                if (Model.Validacao.IsCpf(cliente.Cpf) == false)
                {
                   throw new InvalidOperationException("Cpf inválido!");
                }

                if (string.IsNullOrWhiteSpace(cliente.Nome) || cliente.Nome.Length < 1 || cliente.Nome.Length > 80)      
                {
                    throw new InvalidOperationException("O nome deve conter entre 1 a 80 caracteres.");
                }

                _sql.CadastrarCliente(cliente);

                return StatusCode(200);
            }
            catch(InvalidOperationException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
           
        }


        [HttpPut("v1/Cliente")]
        public IActionResult AtualizarCliente(Model.Cliente cliente)
        {
            try
            {
                _sql.AtualizarCliente(cliente); 

                return StatusCode(200);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        [HttpDelete("v1/Cliente")]
        public IActionResult DeletarCliente(Model.Cliente cliente)
        {
            try
            {
                _sql.DeletarCliente(cliente);

                return StatusCode(200);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        [HttpGet("v1/Cliente/{cpf}")]
        public IActionResult SelecionarCliente(string cpf)
        {
            try
            {
                var cliente = _sql.SelecionarCliente(cpf); 

                return StatusCode(200, cliente);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        [HttpGet("v1/Cliente")]
        public IActionResult ListarClientes()
        {
            try
            {
                var clientes = _sql.ListarClientes();

                return StatusCode(200, clientes);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }


    }
}
