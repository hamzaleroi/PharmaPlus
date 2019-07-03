USE [mydb]
GO

/****** Object:  Table [dbo].[echange]    Script Date: 27/04/2018 02:06:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[echange](
	[N_telephone] [int] NOT NULL,
	[nom_pharm] [varchar](50) NOT NULL,
	[adress] [text] NOT NULL,
	[FAX] [int] NOT NULL,
	[degre] [int] NOT NULL,
 CONSTRAINT [PK_echange] PRIMARY KEY CLUSTERED 
(
	[N_telephone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

