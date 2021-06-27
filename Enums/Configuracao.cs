using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace GeradorCodigo.WebApi.Enums
{
    public static class Configuracao
    {

        public enum ComandosDotNet
        {
            [Description("dotnet new webapi -o [DIRETORIO]")]
            WEBAPI = 1,
            [Description("dotnet new classlib -o [DIRETORIO]")]
            CLASSLIBRARY = 2,
            [Description("dotnet new sln -o [DIRETORIO]")]
            SOLUTION = 3,
            [Description(@"dotnet sln [DIRETORIOSOLUCAO] add [DIRETORIOPROJETO]")]
            REFERENCIASOLUCAO = 4,
            [Description(@"dotnet add [DIRETORIOPROJETO] reference [DIRETORIOPROJETOREF]")]
            REFERENCIAPROJETO = 5
        }

        public enum ComandosPackage
        {
            [Description(@"dotnet add [DIRETORIOPROJETO] package Swashbuckle.AspNetCore.Swagger --version 6.1.4")]
            SWAGGER = 1,
            [Description(@"dotnet add [DIRETORIOPROJETO] package AutoMapper --version 10.1.1")]
            AUTOMAPPER = 2,
            [Description(@"dotnet add [DIRETORIOPROJETO] package Pomelo.EntityFrameworkCore.MySql --version 3.2.4")]
            POMELO = 3,
            [Description(@"dotnet add [DIRETORIOPROJETO] package Pomelo.EntityFrameworkCore.MySql.Design --version 1.1.2")]
            POMELODESIGN = 4,
            [Description(@"dotnet add [DIRETORIOPROJETO] package Microsoft.EntityFrameworkCore.Design --version 3.1.6")]
            ENTITYDESIGN = 5,
            [Description(@"dotnet add [DIRETORIOPROJETO] package Microsoft.EntityFrameworkCore.Tools --version 3.1.6")]
            ENTITYTOOLS = 6
        }


        public enum ComandosBasicos
        {
            [Description("del [DIRETORIO]")]
            DELETAR = 1
        }

    }
}
