﻿CREATE TABLE [dbo].[EV_CONTROLENECESSIDADE](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[INCRICAOID] [int] NULL,
	[CLIENTEID] [int] NULL,
	[NECESSIDADEID] [int] NULL,
 CONSTRAINT [PK_EV_CONTROLENECESSIDADE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


GO
ALTER TABLE [dbo].[EV_CONTROLENECESSIDADE]  WITH CHECK ADD  CONSTRAINT [FK_EV_CONTROLENECESSIDADE_EV_NECESSIDADE] FOREIGN KEY([NECESSIDADEID])
REFERENCES [dbo].[EV_NECESSIDADE] ([ID])
GO

ALTER TABLE [dbo].[EV_CONTROLENECESSIDADE] CHECK CONSTRAINT [FK_EV_CONTROLENECESSIDADE_EV_NECESSIDADE]
GO
ALTER TABLE [dbo].[EV_CONTROLENECESSIDADE]  WITH CHECK ADD  CONSTRAINT [FK_EV_CONTROLENECESSIDADE_EV_INSCRICAO] FOREIGN KEY([INCRICAOID])
REFERENCES [dbo].[EV_INSCRICAO] ([ID])
GO

ALTER TABLE [dbo].[EV_CONTROLENECESSIDADE] CHECK CONSTRAINT [FK_EV_CONTROLENECESSIDADE_EV_INSCRICAO]
GO
ALTER TABLE [dbo].[EV_CONTROLENECESSIDADE]  WITH CHECK ADD  CONSTRAINT [FK_EV_CONTROLENECESSIDADE_EV_CLIENTE] FOREIGN KEY([CLIENTEID])
REFERENCES [dbo].[EV_CLIENTE] ([ID])
GO

ALTER TABLE [dbo].[EV_CONTROLENECESSIDADE] CHECK CONSTRAINT [FK_EV_CONTROLENECESSIDADE_EV_CLIENTE]