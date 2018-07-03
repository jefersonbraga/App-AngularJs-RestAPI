﻿CREATE TABLE [dbo].[EV_AVALIACAOOBSERVACAO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AVALIACAOID] [int] NOT NULL,
	[CLIENTEID] [int] NOT NULL,
	[OBSERVACAO] [varchar](max) NOT NULL,
	[DTATUALIZACAO] [datetime] NOT NULL,
	[DTCADASTRO] [datetime] NOT NULL,
	[DTEXCLUSAO] [datetime] NULL,
 CONSTRAINT [PK_EV_AVALIACAOOBSERVACAO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


GO
ALTER TABLE [dbo].[EV_AVALIACAOOBSERVACAO]  WITH CHECK ADD  CONSTRAINT [FK_EV_AVALIACAOOBSERVACAO_EV_CLIENTE] FOREIGN KEY([CLIENTEID])
REFERENCES [dbo].[EV_CLIENTE] ([ID])
GO

ALTER TABLE [dbo].[EV_AVALIACAOOBSERVACAO] CHECK CONSTRAINT [FK_EV_AVALIACAOOBSERVACAO_EV_CLIENTE]
GO
ALTER TABLE [dbo].[EV_AVALIACAOOBSERVACAO]  WITH CHECK ADD  CONSTRAINT [FK_EV_AVALIACAOOBSERVACAO_EV_AVALIACAO] FOREIGN KEY([AVALIACAOID])
REFERENCES [dbo].[EV_AVALIACAO] ([ID])
GO

ALTER TABLE [dbo].[EV_AVALIACAOOBSERVACAO] CHECK CONSTRAINT [FK_EV_AVALIACAOOBSERVACAO_EV_AVALIACAO]