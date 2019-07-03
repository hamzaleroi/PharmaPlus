USE [mydb]
GO

/****** Object:  Table [dbo].[autre_pharms]    Script Date: 27/04/2018 02:05:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[autre_pharms](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](100) NOT NULL,
	[lat] [float] NOT NULL,
	[longi] [float] NOT NULL,
	[adress] [nchar](100) NULL,
	[degre_echange] [float] NULL
) ON [PRIMARY]

GO

