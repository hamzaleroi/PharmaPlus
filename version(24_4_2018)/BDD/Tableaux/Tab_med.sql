USE [mydb]
GO

/****** Object:  Table [dbo].[Tab_med]    Script Date: 27/04/2018 02:07:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Tab_med](
	[ID] [int] IDENTITY(1000,1) NOT NULL,
	[DCI] [varchar](50) NOT NULL,
	[Marque] [varchar](50) NOT NULL,
	[Forme] [int] NULL,
	[Dosage] [real] NULL,
	[Categorie] [bit] NULL,
	[Effet_Therapeutique] [int] NULL,
	[Remboursement] [bit] NULL,
	[Oriente] [bit] NULL,
	[Restitue] [bit] NULL,
	[Rupture] [bit] NULL,
 CONSTRAINT [PK_Tab_med] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

