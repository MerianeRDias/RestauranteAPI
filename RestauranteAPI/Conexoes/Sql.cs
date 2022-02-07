using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RestauranteAPI.Conexoes
{
    public class Sql
    {
        private readonly SqlConnection _conexao;

        public Sql()
        {
            string conexao = System.IO.File.ReadAllText(@"C:\Users\Meriane\Documents\RumoAcademy\VisualStudio\conexao\stringConexaoES03.txt");
            this._conexao = new SqlConnection(conexao);

        }

        public void CadastrarCliente(Model.Cliente cliente)
        {
            try
            {
                _conexao.Open();

                string sql = @"INSERT INTO Cliente
                                (Cpf,Nome)
                               VALUES
                                (@cpf, @nome);";

                using (SqlCommand cmd = new SqlCommand(sql, _conexao))
                {
                    cmd.Parameters.AddWithValue("cpf", cliente.Cpf);
                    cmd.Parameters.AddWithValue("nome", cliente.Nome);
                    cmd.ExecuteNonQuery();
                }
            }

            finally
            {
                _conexao.Close();
            }

        }

        public void AtualizarCliente(Model.Cliente cliente)
        {
            try
            {
                _conexao.Open();

                string sql = @"UPDATE Cliente
                                   SET Nome = @Nome
                                 WHERE Cpf = @Cpf";

                using (SqlCommand cmd = new SqlCommand(sql, _conexao))
                {
                    cmd.Parameters.AddWithValue("Cpf", cliente.Cpf);
                    cmd.Parameters.AddWithValue("Nome", cliente.Nome);

                    cmd.ExecuteNonQuery();


                    if (cmd.ExecuteNonQuery() == 0)
                    {
                        throw new InvalidOperationException("O cliente não foi atualizado!");
                    }
                }
            }
            finally
            {
                _conexao.Close();
            }

        }

        public void DeletarCliente(Model.Cliente cliente)
        {
            try
            {
                _conexao.Open();

                string sql = @"DELETE FROM Cliente
                                 WHERE Cpf = @Cpf";

                using (var cmd = new SqlCommand(sql, _conexao))
                {
                    cmd.Parameters.AddWithValue("@Cpf", cliente.Cpf);
                    cmd.ExecuteNonQuery();


                    if (cmd.ExecuteNonQuery() == 0)
                    {
                        throw new InvalidOperationException("O cliente não foi deletado!");
                    }

                }
            }
            finally
            {
                _conexao.Close();
            }
        }

        public Model.Cliente SelecionarCliente(string cpf)
        {
            try
            {
                _conexao.Open();

                string sql = @"Select * FROM Cliente
                                 WHERE Cpf = @Cpf";

                using (var cmd = new SqlCommand(sql, _conexao))
                {
                    cmd.Parameters.AddWithValue("@Cpf", cpf);
                    var rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        var cliente = new Model.Cliente();
                        cliente.Cpf = cpf;
                        cliente.Nome = rdr["Nome"].ToString();

                        return cliente;
                    }
                    else
                    {
                        throw new InvalidOperationException("Cpf " + cpf + " não encontrado!");
                    }
                }
            }
            finally
            {
                _conexao.Close();
            }
        }

        public List<Model.Cliente> ListarClientes()
        {
            var clientes = new List<Model.Cliente>();
            try
            {
                _conexao.Open();

                string sql = @"Select * FROM Cliente";

                using (var cmd = new SqlCommand(sql, _conexao))
                {
                    var rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        var cliente = new Model.Cliente();
                        cliente.Cpf = rdr["Cpf"].ToString();
                        cliente.Nome = rdr["Nome"].ToString();

                        clientes.Add(cliente);
                    }

                    throw new InvalidOperationException("Lista não encontrada!");
                }
            }
            finally
            {
                _conexao.Close();
            }

            return clientes;
        }

        public void CadastrarMesa(Model.Mesa mesa)
        {
            try
            {
                _conexao.Open();

                string sql = @"INSERT INTO Mesa
                                (QuantidadeCadeiras)
                               VALUES
                                (@quantidadeCadeiras);";

                using (SqlCommand cmd = new SqlCommand(sql, _conexao))
                {
                    cmd.Parameters.AddWithValue("quantidadeCadeiras", mesa.QuantidadeCadeiras);
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                _conexao.Close();
            }

        }

        public void AtualizarMesa(Model.Mesa mesa)
        {
            try
            {
                _conexao.Open();

                string sql = @"UPDATE Mesa
                                   SET QuantidadeCadeiras =  @quantidadeCadeiras
                                 WHERE Identificador = @identificador";

                using (SqlCommand cmd = new SqlCommand(sql, _conexao))
                {
                    cmd.Parameters.AddWithValue("identificador", mesa.Identificador);
                    cmd.Parameters.AddWithValue("quantidadeCadeiras", mesa.QuantidadeCadeiras);

                    cmd.ExecuteNonQuery();

                    if (cmd.ExecuteNonQuery() == 0)
                    {
                        throw new InvalidOperationException("A mesa não foi atualizada!");
                    }
                }
            }
            finally
            {
                _conexao.Close();
            }

        }

        public void DeletarMesa(Model.Mesa mesa)
        {
            try
            {
                _conexao.Open();

                string sql = @"DELETE FROM Mesa
                                 WHERE Identificador = @identificador";

                using (var cmd = new SqlCommand(sql, _conexao))
                {
                    cmd.Parameters.AddWithValue("@identificador", mesa.Identificador);
                    cmd.ExecuteNonQuery();

                    if (cmd.ExecuteNonQuery() == 0)
                    {
                        throw new InvalidOperationException("A mesa não foi deletada!");
                    }

                }
            }
            finally
            {
                _conexao.Close();
            }
        }

        public Model.Mesa SelecionarMesa(int identificador)
        {
            try
            {
                _conexao.Open();

                string sql = @"Select * FROM Mesa
                               WHERE Identificador = @identificador";

                using (var cmd = new SqlCommand(sql, _conexao))
                {
                    cmd.Parameters.AddWithValue("@identificador", identificador);
                    var rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        var mesa = new Model.Mesa();
                        mesa.Identificador = Convert.ToInt16(rdr["Identificador"]);
                        mesa.QuantidadeCadeiras = Convert.ToInt16(rdr["QuantidadeCadeiras"]);

                        return mesa;
                    }
                    else
                    {
                        throw new InvalidOperationException("Mesa " + identificador + " não encontrada!");
                    }
                }
            }
            finally
            {
                _conexao.Close();
            }
        }

        public List<Model.Mesa> ListarMesas()
        {
            var mesas = new List<Model.Mesa>();
            try
            {
                _conexao.Open();

                string sql = @"Select * FROM Mesa";

                using (var cmd = new SqlCommand(sql, _conexao))
                {
                    var rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        var mesa = new Model.Mesa();
                        mesa.Identificador = Convert.ToInt16(rdr["Identificador"]);
                        mesa.QuantidadeCadeiras = Convert.ToInt16(rdr["QuantidadeCadeiras"]);

                        mesas.Add(mesa);
                    }

                    throw new InvalidOperationException("Lista não encontrada!");
                }
            }
            finally
            {
                _conexao.Close();
            }

            return mesas;
        }

        public void CadastrarReserva(Model.ReservaMesa reserva)
        {
            try
            {
                _conexao.Open();

                string sql = @"INSERT INTO ReservaMesa
                                (InicioReserva, FimReserva, Cliente, Mesa)
                               VALUES
                                (@inicioReserva, @fimReserva, @cliente, @mesa );";

                using (SqlCommand cmd = new SqlCommand(sql, _conexao))
                {
                    cmd.Parameters.AddWithValue("inicioReserva", reserva.InicioReserva);
                    cmd.Parameters.AddWithValue("fimReserva", reserva.FimReserva);
                    cmd.Parameters.AddWithValue("cliente", reserva.Cliente);
                    cmd.Parameters.AddWithValue("mesa", reserva.Mesa);
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                _conexao.Close();
            }

        }
        public void AtualizarReserva(Model.ReservaMesa reserva)
        {
            try
            {
                _conexao.Open();

                string sql = @"UPDATE ReservaMesa
                                   SET InicioReserva = @inicioReserva,
                                       FimReserva = @fimReserva,
                                       Cliente = @cliente,
                                       Mesa = @mesa         
                                 WHERE Identificador = @identificador";

                using (SqlCommand cmd = new SqlCommand(sql, _conexao))
                {
                    cmd.Parameters.AddWithValue("identificador", reserva.Identificador);
                    cmd.Parameters.AddWithValue("inicioReserva", reserva.InicioReserva);
                    cmd.Parameters.AddWithValue("fimReserva", reserva.FimReserva);
                    cmd.Parameters.AddWithValue("cliente", reserva.Cliente);
                    cmd.Parameters.AddWithValue("mesa", reserva.Mesa);

                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                _conexao.Close();
            }

        }

        public void DeletarReserva(string cliente)
        {
            try
            {
                _conexao.Open();

                string sql = @"DELETE FROM ReservaMesa
                                 WHERE Cliente = @cliente";

                using (var cmd = new SqlCommand(sql, _conexao))
                {
                    cmd.Parameters.AddWithValue("cliente", cliente);
                    cmd.ExecuteNonQuery();

                }
            }
            finally
            {
                _conexao.Close();
            }
        }


        public Model.ReservaMesa SelecionarReserva(int identificador)
        {
            
            try
            {
                _conexao.Open();

                string sql = @"Select * FROM Reserva
                               WHERE Identificador = @identificador";

                using (var cmd = new SqlCommand(sql, _conexao))
                {
                    cmd.Parameters.AddWithValue("@identificador", identificador);
                    var rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        var reserva = new Model.ReservaMesa();
                        reserva.Identificador = identificador;
                        reserva.InicioReserva = Convert.ToDateTime(rdr["InicioReserva"]);
                        reserva.FimReserva = Convert.ToDateTime(rdr["FimReserva"]);
                        reserva.Mesa = new Model.Mesa()
                        {
                            Identificador = Convert.ToInt32(rdr["Mesa"])
                        };

                        return reserva ;
                    }
                    else
                    {
                        throw new InvalidOperationException("Reserva " + identificador + " não encontrada!");
                    }
                }
            }
            finally
            {
                _conexao.Close();
            }
        }


        public List<Model.ReservaMesa> ListarReservasMesas()
        {
            var reservas = new List<Model.ReservaMesa>();
            try
            {
                _conexao.Open();

                string sql = @"Select  
                                    Identificador,
	                                InicioReserva,
	                                FimReserva,
	                                Mesa
                            FROM ReservaMesa";

                using (var cmd = new SqlCommand(sql, _conexao))
                {
                    var rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        var reserva = new Model.ReservaMesa();
                        reserva.Identificador = Convert.ToInt32(rdr["Identificador"]);
                        reserva.InicioReserva = Convert.ToDateTime(rdr["InicioReserva"]);
                        reserva.FimReserva = Convert.ToDateTime(rdr["FimReserva"]);
                        reserva.Mesa = new Model.Mesa()
                        {
                            Identificador = Convert.ToInt32(rdr["Mesa"])
                        };

                        reservas.Add(reserva);
                    }
                }
            }
            finally
            {
                _conexao.Close();
            }

            return reservas;
        }


        public List<Model.Mesa> ConsultarMesasDisponiveis(DateTime inicioReserva, DateTime fimReserva, int quantidadeCadeiras)
        {
            var mesas = new List<Model.Mesa>();

            try
            {
                _conexao.Open();

                string sql = @"SELECT m.Identificador FROM Mesa m 
                                WHERE m.Identificador NOT IN
                                (SELECT m.Identificador AS IdentificadorMesa FROM Mesa m
                                JOIN ReservaMesa rm ON m.Identificador = rm.Mesa
                                WHERE rm.InicioReserva
                                BETWEEN @dataInicio AND @dataFim
                                AND rm.FimReserva 
                                BETWEEN @dataInicio AND @dataFim)  
                                AND m.QuantidadeCadeiras = @quantidadeCadeiras";


                using (var cmd = new SqlCommand(sql, _conexao))
                {
                   
                    cmd.Parameters.AddWithValue("dataInicio", inicioReserva);
                    cmd.Parameters.AddWithValue("dataFim", fimReserva);
                    cmd.Parameters.AddWithValue("quantidadeCadeiras", quantidadeCadeiras);
                    var rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        var mesa = new Model.Mesa();
                        mesa.Identificador = Convert.ToInt32(rdr["Identificador"]);
                        mesas.Add(mesa);
                    }
                    
                }
            }
            finally
            {
                _conexao.Close();
            }

            return mesas;
        }
        

    }
}
