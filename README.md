# ExemploDapperCore
Exemplo de Dapper 1.6 em .NetCore 2.1

#Instalação do Docker para Banco de Dados:
Rode o comando para SQL Server em Ubuntu
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=@123mudar' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-CU8-ubuntu

#Instalação do Ambiente:
Ao rodar o banco de dados, rode o seguinte SCRIPT:

<code>
  CREATE DATABASE DbTest;
GO
USE DbTest;
GO

CREATE TABLE Estado(
	Id UNIQUEIDENTIFIER NOT NULL,
	Name VARCHAR(50) NOT NULL,
	Short VARCHAR(20) NOT NULL
);
GO
CREATE TABLE Cidade(
	Id UNIQUEIDENTIFIER NOT NULL,
	Name VARCHAR(50) NOT NULL,
	EstadoId UNIQUEIDENTIFIER NOT NULL
);
GO
</code>

#Ao rodar, execute os comandos dentro da pasta COMMANDS
