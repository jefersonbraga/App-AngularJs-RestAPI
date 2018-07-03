﻿CREATE TABLE [dbo].[AD_ORGAOS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ORGAO] [varchar](250) NOT NULL,
	[IDORGAOANTIGO] [int] NULL,
 CONSTRAINT [PK_AD_ORGAOS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
