﻿CREATE TABLE [dbo].[EV_INSCRICAO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CLIENTEID] [int] NOT NULL,
	[EVENTOID] [int] NOT NULL,
	[NEESPECIALID] [int] NULL,
	[DTINSCRICAO] [datetime] NOT NULL,
	[VALOR] [money] NOT NULL,
	[FORMAPAGAMENTO] [varchar](50) NULL,
	[PAGO] [varchar](50) NULL,
	[DTBOLETOEMITIDO] [datetime] NULL,
	[BOLETOEMITIDO] [varchar](50) NULL,
	[DATAPAGAMENTO] [datetime] NULL,
	[VALORRECEBIDO] [money] NULL,
	[TURNO] [varchar](50) NULL,
	[CARGO] [varchar](250) NULL,
	[SALA] [varchar](50) NULL,
	[FASE01] [varchar](50) NULL,
	[FASE02] [varchar](50) NULL,
	[FASE03] [varchar](50) NULL,
	[FASE04] [varchar](50) NULL,
	[LOCALPROVAID] [int] NULL,
	[SALAID] [int] NULL,
	[BAIXA] [varchar](50) NULL,
	[CRIADO] [datetime] NULL,
	[DTCADASTRO] [datetime] NOT NULL,
	[DTALTERACAO] [datetime] NOT NULL,
	[DTEXCLUSAO] [datetime] NULL,
 CONSTRAINT [PK_EV_INSCRICAO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


GO
/****** Object:  Index [NonClusteredIndex-20171016-020530]    Script Date: 11/30/2017 5:47:33 PM ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20171016-020530] ON [dbo].[EV_INSCRICAO]
(
	[CRIADO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]


GO
ALTER TABLE [dbo].[EV_INSCRICAO]  WITH CHECK ADD  CONSTRAINT [FK_EV_INSCRICAO_EV_EVENTO] FOREIGN KEY([EVENTOID])
REFERENCES [dbo].[EV_EVENTO] ([ID])
GO

ALTER TABLE [dbo].[EV_INSCRICAO] CHECK CONSTRAINT [FK_EV_INSCRICAO_EV_EVENTO]
GO
ALTER TABLE [dbo].[EV_INSCRICAO]  WITH CHECK ADD  CONSTRAINT [FK_EV_INSCRICAO_EV_CLIENTE] FOREIGN KEY([CLIENTEID])
REFERENCES [dbo].[EV_CLIENTE] ([ID])
GO

ALTER TABLE [dbo].[EV_INSCRICAO] CHECK CONSTRAINT [FK_EV_INSCRICAO_EV_CLIENTE]