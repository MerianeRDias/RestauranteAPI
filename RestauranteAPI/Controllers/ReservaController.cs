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
        public void AtualizarReservaMesa(Model.ReservaMesa reserva)
        {
            _sql.AtualizarReserva(reserva);
        }

        [HttpDelete("v1/DeletarReservaMesa/{cliente}")]
        public void DeletarReservaMesa(string cliente)
        {
            _sql.DeletarReserva(cliente);
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
        public List<Model.Mesa> ConsultarMesasDisponiveis(DateTime inicioReserva, DateTime fimReserva, int quantidadeCadeiras)
        {
            return _sql.ConsultarMesasDisponiveis(inicioReserva, fimReserva, quantidadeCadeiras);
        }

        [HttpGet("v1/ListarReservas")]
        public List<Model.ReservaMesa> ListarReservas()
        {
            return _sql.ListarReservasMesas();
        }

    }
}

