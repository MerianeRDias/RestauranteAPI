using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestauranteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasReservaController : ControllerBase
    {
        private readonly Conexoes.Sql _sql;

        public PessoasReservaController()
        {
            _sql = new Conexoes.Sql();
        }

        [HttpPost("v1/PessoasReserva")]
        public void CadastrarReserva(Model.ReservaMesa reserva)
        {
            _sql.CadastrarReserva(reserva);
        }
    }
}
