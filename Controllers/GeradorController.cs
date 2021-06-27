using GeradorCodigo.WebApi.Enums;
using GeradorCodigo.WebApi.Models;
using GeradorCodigo.WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GeradorCodigo.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeradorController : Controller
    {

        private MySqlDatabase MySqlDatabase { get; set; }

        public GeradorController(MySqlDatabase mySqlDatabase)
        {
            this.MySqlDatabase = mySqlDatabase; ;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ParamGeracao parametro)
        {


            // ## 1ª FAZE - ARQUITETURA

            //Criar Solucao


            //Criar Class WebApi


            //Criar Class Libary - Domain, Repository


            //Deletar arquivos que nao ser utlizado


            //Referenciar projetos entre si


            //Referenciar uma solucao


            // ## 2ª FAZE - CRIAR 


            var criaProjeto = new GeraArquiteturaProjetoDotNetService(parametro).Processar();

            if (!criaProjeto)
                return BadRequest();



            return Ok();
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var cmd = this.MySqlDatabase.Connection.CreateCommand() as MySqlCommand;
                cmd.CommandText = @"show tables";

                var listaBanco = new List<Table>();

                using (var reader = await cmd.ExecuteReaderAsync())
                {

                    while (await reader.ReadAsync())
                    {
                        listaBanco.Add(new Table { Tabela = reader.GetString(0) });
                    }
                }

                foreach (var tabelas in listaBanco)
                {

                    cmd.CommandText = $"SHOW COLUMNS FROM {tabelas.Tabela}";

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            tabelas.Colunas.Add(new ColumnsTable
                            {
                                Field = reader["Field"].ToString(),
                                Type = reader["Type"].ToString(),
                                Null = reader["Null"].ToString(),
                                Key = reader["Key"].ToString(),
                                Extra = reader["Extra"].ToString(),
                            }); ;
                        }

                    }
                }

                return Ok(listaBanco);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}
