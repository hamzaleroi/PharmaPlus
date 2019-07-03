USE [mydb]
GO

/****** Object:  View [dbo].[view_tab_restitue_med]    Script Date: 17/04/2018 19:11:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE view [dbo].[view_tab_restitue_med] as 
select DateDeProduction,DateDePeremption,DateDeVente,Quantite,Prix,TabRestitue_STAT.Tab_medID,DCI,Marque,Dosage,Categorie ,Effet_Therapeutique,Oriente,Restitue,Rupture from TabRestitue_STAT 
join Tab_med on TabRestitue_STAT.Tab_medID = Tab_med.ID
GO

