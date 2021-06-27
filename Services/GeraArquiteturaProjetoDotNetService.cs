using GeradorCodigo.WebApi.Enums;
using GeradorCodigo.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeradorCodigo.WebApi.Services
{
    public class GeraArquiteturaProjetoDotNetService
    {
        private string pastaDownload { get; set; }
        private string pastaProjeto { get; set; }
        private string dirWebApi { get; set; }
        private string dirDomain { get; set; }
        private string dirRepository { get; set; }
        private string dirArqSolucao { get; set; }
        private string dirArqWebApi { get; set; }
        private string dirArqDomain { get; set; }
        private string dirArqRepository { get; set; }

        public GeraArquiteturaProjetoDotNetService(ParamGeracao parametro)
        {
            pastaDownload = "Download";
            pastaProjeto = pastaDownload + @"\" + parametro.NomeProjeto;
            dirWebApi = pastaProjeto + @"\" + $"{parametro.NomeProjeto}.WebApi";
            dirDomain = pastaProjeto + @"\" + $"{parametro.NomeProjeto}.Domain";
            dirRepository = pastaProjeto + @"\" + $"{parametro.NomeProjeto}.Repository";
            dirArqSolucao = pastaProjeto + @"\" + parametro.NomeProjeto + ".sln";
            dirArqWebApi = dirWebApi + @"\" + $"{parametro.NomeProjeto}.WebApi.csproj";
            dirArqDomain = dirDomain + @"\" + $"{parametro.NomeProjeto}.Domain.csproj";
            dirArqRepository = dirRepository + @"\" + $"{parametro.NomeProjeto}.Repository.csproj";
        }


        public bool Processar()
        {
            try
            {
                Console.WriteLine("## INICIANDO CRIACAO PROJETO .NET CORE ##");
                Console.WriteLine("## CRIANDO PROJETOS ##");
                CriaProjetos();
                Console.WriteLine("## LIMPANDO ARQUIVOS DESNECESSARIOS ##");
                DeletaArquivos();
                Console.WriteLine("## ADD REFERENCIA DE PROJETOS NA SOLUCAO ##");
                AddProjetosCriadoNaSolucao();
                Console.WriteLine("## ADD REFERENCIA ENTRE PROJETOS ##");
                AddReferenciaEntreProjetos();
                Console.WriteLine("## ADD PACKAGES ##");
                AddPackages();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void CriaProjetos()
        {
            ComandoService.Executar(Configuracao.ComandosDotNet.SOLUTION.GetDescription().Replace("[DIRETORIO]", pastaProjeto));
            ComandoService.Executar(Configuracao.ComandosDotNet.WEBAPI.GetDescription().Replace("[DIRETORIO]", dirWebApi));
            ComandoService.Executar(Configuracao.ComandosDotNet.CLASSLIBRARY.GetDescription().Replace("[DIRETORIO]", dirDomain));
            ComandoService.Executar(Configuracao.ComandosDotNet.CLASSLIBRARY.GetDescription().Replace("[DIRETORIO]", dirRepository));
        }

        private void DeletaArquivos()
        {
            ComandoService.Executar(Configuracao.ComandosBasicos.DELETAR.GetDescription().Replace("[DIRETORIO]", dirDomain + @"\Class1.cs"));
            ComandoService.Executar(Configuracao.ComandosBasicos.DELETAR.GetDescription().Replace("[DIRETORIO]", dirRepository + @"\Class1.cs"));
            ComandoService.Executar(Configuracao.ComandosBasicos.DELETAR.GetDescription().Replace("[DIRETORIO]", dirWebApi + @"\WeatherForecast.cs"));
            ComandoService.Executar(Configuracao.ComandosBasicos.DELETAR.GetDescription().Replace("[DIRETORIO]", dirWebApi + @"\Controllers\WeatherForecastController.cs"));
        }

        private void AddProjetosCriadoNaSolucao()
        {
            ComandoService.Executar(Configuracao.ComandosDotNet.REFERENCIASOLUCAO.GetDescription().Replace("[DIRETORIOSOLUCAO]", dirArqSolucao).Replace("[DIRETORIOPROJETO]", dirArqWebApi));
            ComandoService.Executar(Configuracao.ComandosDotNet.REFERENCIASOLUCAO.GetDescription().Replace("[DIRETORIOSOLUCAO]", dirArqSolucao).Replace("[DIRETORIOPROJETO]", dirArqDomain));
            ComandoService.Executar(Configuracao.ComandosDotNet.REFERENCIASOLUCAO.GetDescription().Replace("[DIRETORIOSOLUCAO]", dirArqSolucao).Replace("[DIRETORIOPROJETO]", dirArqRepository));
        }

        private void AddReferenciaEntreProjetos()
        {
            ComandoService.Executar(Configuracao.ComandosDotNet.REFERENCIAPROJETO.GetDescription().Replace("[DIRETORIOPROJETO]", dirArqWebApi).Replace("[DIRETORIOPROJETOREF]", dirArqDomain));
            ComandoService.Executar(Configuracao.ComandosDotNet.REFERENCIAPROJETO.GetDescription().Replace("[DIRETORIOPROJETO]", dirArqWebApi).Replace("[DIRETORIOPROJETOREF]", dirArqRepository));
            ComandoService.Executar(Configuracao.ComandosDotNet.REFERENCIAPROJETO.GetDescription().Replace("[DIRETORIOPROJETO]", dirArqRepository).Replace("[DIRETORIOPROJETOREF]", dirArqDomain));
        }

        private void AddPackages()
        {
            ComandoService.Executar(Configuracao.ComandosPackage.SWAGGER.GetDescription().Replace("[DIRETORIOPROJETO]", dirArqWebApi));
            ComandoService.Executar(Configuracao.ComandosPackage.AUTOMAPPER.GetDescription().Replace("[DIRETORIOPROJETO]", dirArqWebApi));


            ComandoService.Executar(Configuracao.ComandosPackage.ENTITYDESIGN.GetDescription().Replace("[DIRETORIOPROJETO]", dirArqRepository));
            ComandoService.Executar(Configuracao.ComandosPackage.ENTITYTOOLS.GetDescription().Replace("[DIRETORIOPROJETO]", dirArqRepository));
            ComandoService.Executar(Configuracao.ComandosPackage.POMELO.GetDescription().Replace("[DIRETORIOPROJETO]", dirArqRepository));
            ComandoService.Executar(Configuracao.ComandosPackage.POMELODESIGN.GetDescription().Replace("[DIRETORIOPROJETO]", dirArqRepository));
        }


    }
}
