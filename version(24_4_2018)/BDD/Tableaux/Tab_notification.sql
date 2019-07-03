USE [mydb]
GO

/****** Object:  Table [dbo].[Tab_notification]    Script Date: 27/04/2018 02:08:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Tab_notification](
	[med_id] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Type_notif] [int] NOT NULL,
	[Marque] [varchar](50) NULL,
	[Type] [varchar](50) NULL,
 CONSTRAINT [PK_Tab_notification] PRIMARY KEY CLUSTERED 
(
	[med_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

