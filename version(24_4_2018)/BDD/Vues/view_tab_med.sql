USE [mydb]
GO

/****** Object:  View [dbo].[view_tab_med]    Script Date: 17/04/2018 19:11:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create view [dbo].[view_tab_med] as 
select DateDeProduction,DateDePeremption,DateDeVente,Quantite,Prix,Tab_NEW_STAT.Tab_medID,DCI,Marque,Dosage,Categorie ,Effet_Therapeutique,Oriente,Restitue,Rupture from Tab_NEW_STAT 
join Tab_med on Tab_NEW_STAT.Tab_medID = Tab_med.ID
GO

