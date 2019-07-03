USE [mydb]
GO

/****** Object:  Table [dbo].[Formes_galenique]    Script Date: 27/04/2018 02:07:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Formes_galenique](
	[ID] [int] NOT NULL,
	[forme] [varchar](50) NULL,
 CONSTRAINT [PK_Formes_galenique] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

