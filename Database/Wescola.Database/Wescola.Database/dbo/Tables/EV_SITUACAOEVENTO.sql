﻿CREATE TABLE [dbo].[EV_SITUACAOEVENTO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DESCRICAO] [varchar](50) NOT NULL,
	[DTCADASTRO] [datetime] NOT NULL,
	[DTATUALIZACAO] [datetime] NOT NULL,
	[DTEXCLUSAO] [datetime] NULL,
 CONSTRAINT [PK_EV_SITUACAOEVENTO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


GO
ALTER TABLE [dbo].[EV_SITUACAOEVENTO] ADD  CONSTRAINT [DF_EV_SITUACAOEVENTO_DTATUALIZACAO]  DEFAULT (getdate()) FOR [DTATUALIZACAO]
GO
ALTER TABLE [dbo].[EV_SITUACAOEVENTO] ADD  CONSTRAINT [DF_EV_SITUACAOEVENTO_DTCADASTRO]  DEFAULT (getdate()) FOR [DTCADASTRO]