﻿CREATE TABLE [dbo].[AD_REFRESHTOKEN](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[USERID] [nvarchar](128) NOT NULL,
	[HASH] [varchar](50) NOT NULL,
	[PROTECTEDTICKET] [varchar](max) NOT NULL,
	[DTEMISSAO] [datetime] NOT NULL,
	[DTEMISSAOUTC] [datetime] NOT NULL,
	[DTEXPIRACAO] [datetime] NOT NULL,
	[DTEXPIRACAOUTC] [datetime] NOT NULL,
 CONSTRAINT [PK_AD_REFRESHTOKEN] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER RefreshTokenHistory 
   ON  dbo.AD_REFRESHTOKEN
   AFTER DELETE 
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    INSERT INTO [dbo].[AD_REFRESHTOKENHISTORY]
           ([IDREFRESHTOKEN]
           ,[USERID]
           ,[HASH]
           ,[PROTECTEDTICKET]
           ,[DTEMISSAO]
           ,[DTEMISSAOUTC]
           ,[DTEXPIRACAO]
           ,[DTEXPIRACAOUTC])
		SELECT [ID]
		  ,[USERID]
		  ,[HASH]
		  ,[PROTECTEDTICKET]
		  ,[DTEMISSAO]
		  ,[DTEMISSAOUTC]
		  ,[DTEXPIRACAO]
		  ,[DTEXPIRACAOUTC] FROM DELETED
END

GO
ALTER TABLE [dbo].[AD_REFRESHTOKEN] ADD  CONSTRAINT [DF_AD_REFRESHTOKEN_DTEMISSAO]  DEFAULT (getdate()) FOR [DTEMISSAO]
GO
ALTER TABLE [dbo].[AD_REFRESHTOKEN]  WITH CHECK ADD  CONSTRAINT [FK_AD_REFRESHTOKEN_AD_REFRESHTOKEN] FOREIGN KEY([USERID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO

ALTER TABLE [dbo].[AD_REFRESHTOKEN] CHECK CONSTRAINT [FK_AD_REFRESHTOKEN_AD_REFRESHTOKEN]