if exists (select * from sys.objects where name = 'Clientes' and type = 'U')
   drop table Clientes
go

CREATE TABLE [dbo].[Clientes](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Endereco] [varchar](80) NOT NULL,
	[Cidade] [varchar](80) NOT NULL,
	[Telefone] [varchar](20) NULL,
	[Email] [varchar](50) NULL,
	[Ativo] [bit] NOT NULL,
	 CONSTRAINT [PK_IdCliente] PRIMARY KEY CLUSTERED 
	(
		[IdCliente] ASC
	)
) ON [PRIMARY]
GO

