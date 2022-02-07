using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace RestauranteAPI.Controllers
{
    [ApiController]
    public class MesaController : ControllerBase
    {
        private readonly Conexoes.Sql _sql;

        public MesaController()
        {
            _sql = new Conexoes.Sql();
        }

        [HttpPost ("v1/CadastrarMesa")]
        public IActionResult CadastrarMesa(Model.Mesa mesa)
        {
            try
            {
                if (mesa.QuantidadeCadeiras <= 2)
                {
                    throw new InvalidOperationException("A mesa deve conter pelo menos 2 cadeiras!");
                }

                _sql.CadastrarMesa(mesa);


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

        [HttpPut("v1/AtualizarMesa")]
        public IActionResult AtualizarMesa(Model.Mesa mesa)
        {
            try
            {
                _sql.AtualizarMesa(mesa);

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

        [HttpDelete("v1/DeletarMesa")]
        public IActionResult DeletarMesa(Model.Mesa mesa)
        {
            try
            {
                _sql.DeletarMesa(mesa);

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


        [HttpGet("v1/SelecionarMesa/{identificador}")]
        public IActionResult SelecionarMesa(int identificador)
        {
            try
            {
                var mesa = _sql.SelecionarMesa(identificador);

                return StatusCode(200, mesa);
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

        [HttpGet("v1/ListarMesas")]
        public IActionResult ListarMesas()
        {
            try
            {
                var mesas = _sql.ListarMesas();

                return StatusCode(200, mesas);
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
