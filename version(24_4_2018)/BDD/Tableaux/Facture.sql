USE [mydb]
GO

/****** Object:  Table [dbo].[Facture]    Script Date: 27/04/2018 02:07:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Facture](
	[FactureID] [int] IDENTITY(1,1) NOT NULL,
	[facture] [xml] NULL,
	[Client] [varchar](50) NOT NULL,
	[Date] [varchar](50) NOT NULL,
	[code] [int] NOT NULL,
 CONSTRAINT [PK_Facture] PRIMARY KEY CLUSTERED 
(
	[FactureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

