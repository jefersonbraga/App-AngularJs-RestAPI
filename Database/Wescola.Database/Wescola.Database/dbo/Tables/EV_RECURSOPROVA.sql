﻿CREATE TABLE [dbo].[EV_RECURSOPROVA](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EVENTOID] [int] NOT NULL,
	[TITULO] [varchar](100) NOT NULL,
	[INSTRUCOES] [varchar](max) NULL,
	[DTINICIO] [datetime] NOT NULL,
	[HRINICIO] [time](7) NULL,
	[DTTERMINO] [datetime] NOT NULL,
	[HRTERMINO] [time](7) NULL,
	[DTCADASTRO] [datetime] NOT NULL,
	[DTATUALIZACAO] [datetime] NOT NULL,
	[DTEXCLUSAO] [datetime] NULL,
 CONSTRAINT [PK_EV_RECURSOPROVA] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


GO
ALTER TABLE [dbo].[EV_RECURSOPROVA]  WITH CHECK ADD  CONSTRAINT [FK_EV_RECURSOPROVA_EV_RECURSOPROVA] FOREIGN KEY([EVENTOID])
REFERENCES [dbo].[EV_EVENTO] ([ID])
GO

ALTER TABLE [dbo].[EV_RECURSOPROVA] CHECK CONSTRAINT [FK_EV_RECURSOPROVA_EV_RECURSOPROVA]