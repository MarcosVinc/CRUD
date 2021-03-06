﻿using BacanasBurgues.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacanaBurgues.Repositorio
{
     public class RepositorioDeCliente
    {
        Conexao conexao = new Conexao();
        SqlCommand cmd = new SqlCommand();
        public string mensagem = "";

        public void Salvar(Cliente cliente)
        {
            //comando Sql --SqlComand
            cmd.CommandText = "insert into Cliente values(@identificador, @nome, @endereco,@telefone,@cep)";
            // parametros
            cmd.Parameters.AddWithValue("@identificador", cliente.Identificador);
            cmd.Parameters.AddWithValue("@nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@endereco", cliente.Endereco);
            cmd.Parameters.AddWithValue("@telefone", cliente.Telefone);
            cmd.Parameters.AddWithValue("@cep", cliente.Cep);
            //conectar com banco -- Conexao
            try
            {
                cmd.Connection = conexao.conectar();
                //executar comando
                cmd.ExecuteNonQuery();
                //desconectar
                conexao.desconectar();
                // mostrar mensagem de erro ou sucesso
                this.mensagem = "Cadastrado com sucesso";
            }
            catch (SqlException e ) 
            {
                this.mensagem = e.Message;
            }
      
        }
        public List<Cliente> Consulta()
        {
            var clientes  = new List<Cliente>();

            cmd.CommandText = "select * from Cliente";

            try
            {
                cmd.Connection = conexao.conectar();
                SqlDataReader read = cmd.ExecuteReader();
                //executar comando
                while (read.Read())
                {
                    Cliente x = new Cliente();
                    x.Identificador = (string)read["Identificador"];
                    x.Nome = (string)read["Nome"];
                    x.Endereco = (string)read["Endereco"];
                    x.Telefone = (string)read["Telefone"];
                    x.Cep = int.Parse(read["Cep"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                    
                    clientes.Add(x);
                }

                read.Close();
                //desconectar
                conexao.desconectar();
                // mostrar mensagem de erro ou sucesso
                this.mensagem = "Cadastrado com sucesso";

            }
            catch (SqlException e)
            {
                this.mensagem = e.Message;
            }

            return clientes;

        }

        public void Alterar(Cliente alterarCliente)
        {
            //comando Sql --SqlComand
            cmd.CommandText = "update Cliente set Nome = @nome, Endereco = @endereco, Telefone = @telefone , Cep = @cep where Identificador = @identificador";
            //parametros
            cmd.Parameters.AddWithValue("@identificador", alterarCliente.Identificador);
            cmd.Parameters.AddWithValue("@nome", alterarCliente.Nome);
            cmd.Parameters.AddWithValue("@endereco", alterarCliente.Endereco);
            cmd.Parameters.AddWithValue("@telefone", alterarCliente.Telefone);
            cmd.Parameters.AddWithValue("@cep", alterarCliente.Cep);

            //conectar com banco -- Conexao
            try
            {
                cmd.Connection = conexao.conectar();
                //executar comando
                cmd.ExecuteNonQuery();
                //desconectar
                conexao.desconectar();
                // mostrar mensagem de erro ou sucesso
                this.mensagem = "alterada com sucasso";

            }
            catch (SqlException e)
            {
                this.mensagem = e.Message;
            }

        }

        public void Deletar(Cliente deletarCliente)
        {
            //comando Sql --SqlComand
            cmd.CommandText = "DELETE FROM Cliente WHERE Identificador = @identificador;"; ;
            //parametros
            cmd.Parameters.AddWithValue("@identificador", deletarCliente.Identificador);

            //conectar com banco -- Conexao
            try
            {
                cmd.Connection = conexao.conectar();
                //executar comando
                cmd.ExecuteNonQuery();
                //desconectar
                conexao.desconectar();
                // mostrar mensagem de erro ou sucesso
                this.mensagem = "Excluida com sucesso";

            }
            catch (SqlException e)
            {
                this.mensagem = e.Message;
            }

        }
    }
}
