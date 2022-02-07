using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace RestauranteAPI.Controllers
{
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly Conexoes.Sql _sql;

        public ReservaController()
        {
            _sql = new Conexoes.Sql();
        }

        [HttpPost("v1/CadastrarReservaMesa")]
        public void CadastrarReserva(Model.ReservaMesa reserva)
        {
            _sql.CadastrarReserva(reserva);
        }

        [HttpPut("v1/AtualizarReservaMesa")]
        public IActionResult AtualizarReservaMesa(Model.ReservaMesa reserva)
        {
            try
            {
                _sql.AtualizarReserva(reserva);

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

        [HttpDelete("v1/DeletarReservaMesa/{cliente}")]
        public IActionResult DeletarReservaMesa(string cliente)
        {
            try
            {

                _sql.DeletarReserva(cliente);

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

        [HttpGet("v1/SelecionarReservaMesa/{identificador}")]
        public IActionResult SelecionarReserva(int identificador)
        {
            try
            {
                var reserva = _sql.SelecionarReserva(identificador);

                return StatusCode(200, reserva);
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

        [HttpGet("v1/ConsultarMesasDisponiveis/{inicioReserva}/{fimReserva}/{quantidadeCadeiras}")]
        public IActionResult ConsultarMesasDisponiveis(DateTime inicioReserva, DateTime fimReserva, int quantidadeCadeiras)
        {

            try
            {
                var mesasDisponiveis = _sql.ConsultarMesasDisponiveis(inicioReserva, fimReserva, quantidadeCadeiras);

                return StatusCode(200, mesasDisponiveis);
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

        [HttpGet("v1/ListarReservas")]
        public IActionResult ListarReservas()
        {
            try
            {
                var reservas =  _sql.ListarReservasMesas();

                return StatusCode(200, reservas);
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

