USE [mydb]
GO

/****** Object:  Table [dbo].[Commande]    Script Date: 27/04/2018 02:06:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Commande](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[commande] [xml] NULL,
	[fournisseur] [nchar](50) NOT NULL,
	[Date] [date] NOT NULL,
	[code] [int] NOT NULL,
 CONSTRAINT [PK_Commande] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

