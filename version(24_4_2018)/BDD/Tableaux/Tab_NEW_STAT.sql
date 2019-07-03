USE [mydb]
GO

/****** Object:  Table [dbo].[Tab_NEW_STAT]    Script Date: 27/04/2018 02:08:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tab_NEW_STAT](
	[ID] [int] IDENTITY(1000,1) NOT NULL,
	[DateDeProduction] [date] NOT NULL,
	[DateDePeremption] [date] NOT NULL,
	[DateDeVente] [date] NOT NULL,
	[Quantite] [int] NOT NULL,
	[Prix] [real] NOT NULL,
	[Tab_medID] [int] NOT NULL,
 CONSTRAINT [PK_Tab_NEW_STAT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Tab_NEW_STAT]  WITH CHECK ADD  CONSTRAINT [FK_Tab_NEW_STAT_Tab_med] FOREIGN KEY([Tab_medID])
REFERENCES [dbo].[Tab_med] ([ID])
GO

ALTER TABLE [dbo].[Tab_NEW_STAT] CHECK CONSTRAINT [FK_Tab_NEW_STAT_Tab_med]
GO

