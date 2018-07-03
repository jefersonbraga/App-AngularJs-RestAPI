﻿CREATE TABLE [dbo].[EV_EVENTO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOME] [varchar](250) NOT NULL,
	[LOCALID] [int] NULL,
	[TP_EVENTO] [varchar](50) NULL,
	[SITUACAO] [varchar](50) NULL,
	[DISPONIVEL] [varchar](50) NULL,
	[EXIBIRLOCAL] [varchar](50) NULL,
	[INSCRICAO] [varchar](50) NULL,
	[TEMAID] [int] NULL,
	[VALOREVENTO] [money] NOT NULL,
	[QTDVAGAS] [int] NULL,
	[FREQUENCIA] [decimal](18, 0) NULL,
	[DTINICIO] [datetime] NULL,
	[DTTERMINO] [datetime] NULL,
	[HORAINICIO] [time](7) NULL,
	[HORATERMINO] [time](7) NULL,
	[ENDERECO] [varchar](max) NULL,
	[VECIMENTOBOLETO] [datetime] NULL,
	[DESCRICAO] [varchar](max) NULL,
	[MENSAGEMBOLETO] [varchar](max) NULL,
	[MENSAGEMCOMPROVANTE] [varchar](max) NULL,
	[IDANTIGO] [int] NULL,
	[DTCADASTRO] [datetime] NOT NULL,
	[DTATUALIZACAO] [datetime] NOT NULL,
	[DTEXCLUSAO] [datetime] NULL,
 CONSTRAINT [PK_EV_EVENTO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


GO
/****** Object:  Index [NonClusteredIndex-20171012-191351]    Script Date: 11/30/2017 5:47:33 PM ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20171012-191351] ON [dbo].[EV_EVENTO]
(
	[IDANTIGO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]


GO
ALTER TABLE [dbo].[EV_EVENTO]  WITH CHECK ADD  CONSTRAINT [FK_EV_EVENTO_EV_TEMA] FOREIGN KEY([TEMAID])
REFERENCES [dbo].[EV_TEMA] ([ID])
GO

ALTER TABLE [dbo].[EV_EVENTO] CHECK CONSTRAINT [FK_EV_EVENTO_EV_TEMA]
GO
ALTER TABLE [dbo].[EV_EVENTO]  WITH CHECK ADD  CONSTRAINT [FK_EV_EVENTO_EV_LOCALEVENTO] FOREIGN KEY([LOCALID])
REFERENCES [dbo].[EV_LOCALEVENTO] ([ID])
GO

ALTER TABLE [dbo].[EV_EVENTO] CHECK CONSTRAINT [FK_EV_EVENTO_EV_LOCALEVENTO]