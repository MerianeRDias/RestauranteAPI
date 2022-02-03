using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

//[EX SALA 03]
//Somos um restaurante de luxo, que precisamos garantir a reserva correta das mesas.

//J� tivemos problemas com grandes clientes, de funcion�rios que n�o se comunicaram direito e geraram conflitos nas reservas.

//Precisamos de um sistema que:

//Cadastre os nossos clientes
//Verifique a disponibilidade de mesas dispon�veis para o hor�rio e quantidade de pessoas.
//Reserve essa mesa para um hor�rio e registre os nomes das pessoas que v�o estar presentes nelas.

//Busque pelo cpf a mesa reservada pelo cliente, assim como os dados do individuo.
//Precisamos buscar pelo cpf uma lista de reservas atuais, passadas e futuras.
