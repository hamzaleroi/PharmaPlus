USE [mydb]
GO

/****** Object:  Table [dbo].[Tab_NEW]    Script Date: 27/04/2018 02:07:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tab_NEW](
	[ID] [int] IDENTITY(1000,1) NOT NULL,
	[DateDeProduction] [date] NOT NULL,
	[DateDePeremption] [date] NOT NULL,
	[Quantite] [int] NOT NULL,
	[Prix] [real] NOT NULL,
	[Tab_medID] [int] NOT NULL,
	[lot] [int] NULL,
 CONSTRAINT [PK_Tab_NEW] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Tab_NEW]  WITH CHECK ADD  CONSTRAINT [FK_Tab_NEW_Tab_med] FOREIGN KEY([Tab_medID])
REFERENCES [dbo].[Tab_med] ([ID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Tab_NEW] CHECK CONSTRAINT [FK_Tab_NEW_Tab_med]
GO

