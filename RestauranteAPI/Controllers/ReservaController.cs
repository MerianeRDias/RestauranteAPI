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

        [HttpPost("v1/ReservaMesa")]
        public void CadastrarReserva(Model.ReservaMesa reserva)
        {
            _sql.CadastrarReserva(reserva);
        }

        [HttpPut("v1/ReservaMesa")]
        public void AtualizarReservaMesa(Model.ReservaMesa reserva)
        {
            _sql.AtualizarReserva(reserva);
        }

        [HttpDelete("v1/ReservaMesa/{cliente}")]
        public void DeletarReservaMesa(string cliente)
        {
            _sql.DeletarReserva(cliente);
        }

        [HttpGet("v1/ReservaMesa/{inicioReserva}/{fimReserva}/{quantidadeCadeiras}")]
        public List<Model.Mesa> ConsultarMesasDisponiveis(DateTime inicioReserva, DateTime fimReserva, int quantidadeCadeiras)
        {
            return _sql.ConsultarMesasDisponiveis(inicioReserva, fimReserva, quantidadeCadeiras);
        }

        [HttpGet("v1/ReservaMesa")]
        public List<Model.ReservaMesa> ListarReservas()
        {
            return _sql.ListarReservasMesas();
        }

    }
}

