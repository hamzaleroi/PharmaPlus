USE [mydb]
GO

/****** Object:  Table [dbo].[Effet_therapeutique]    Script Date: 27/04/2018 02:06:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Effet_therapeutique](
	[ID] [int] NOT NULL,
	[Effet_th] [varchar](50) NULL,
 CONSTRAINT [PK_Effet_therapeutique] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

