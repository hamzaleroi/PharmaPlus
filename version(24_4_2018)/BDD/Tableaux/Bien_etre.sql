USE [mydb]
GO

/****** Object:  Table [dbo].[Bien_etre]    Script Date: 27/04/2018 02:06:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Bien_etre](
	[ID] [int] IDENTITY(1,1000) NOT NULL,
	[Marque] [varchar](50) NOT NULL,
	[Type] [varchar](50) NOT NULL,
	[DateDeProduction] [date] NULL,
	[DateDePeremption] [date] NULL,
	[Quantite] [int] NULL,
	[Prix] [real] NULL,
	[Gout] [varchar](50) NULL,
 CONSTRAINT [PK_Bien_etre] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

