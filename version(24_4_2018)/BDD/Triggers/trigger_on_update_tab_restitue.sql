USE [mydb]
GO
/****** Object:  Trigger [dbo].[trigger_on_update_tab_restitue]    Script Date: 17/04/2018 19:09:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE trigger [dbo].[trigger_on_update_tab_restitue]
on [dbo].[TabRestitue] 
for UPDATE
AS
UPDATE
    Table_A
SET
    Table_A.Quantite = Table_A.Quantite + deleted.Quantite - inserted.Quantite
   
FROM
    TabRestitue_STAT AS Table_A
    INNER JOIN deleted 
        ON Table_A.Tab_medID = deleted.Tab_medID and Table_A.Prix = deleted.Prix
		INNER JOIN inserted  ON Table_A.Tab_medID = inserted.Tab_medID and Table_A.Prix = inserted.Prix and deleted.Quantite > inserted.Quantite
WHERE
    Table_A.DateDeVente = Convert(Date,getDate()) ;
IF NOT EXISTS 
    (SELECT * from TabRestitue_STAT AS Table_A
    INNER JOIN deleted 
        ON Table_A.Tab_medID = deleted.Tab_medID and Table_A.Prix = deleted.Prix
		INNER JOIN inserted  ON Table_A.Tab_medID = inserted.Tab_medID and Table_A.Prix = inserted.Prix)
    BEGIN
insert into TabRestitue_STAT  select deleted.DateDeProduction,deleted.DateDePeremption,getdate() , deleted.Quantite - inserted.Quantite ,inserted.Prix,inserted.Tab_medID  from deleted 
INNER JOIN inserted ON deleted.Tab_medID = inserted.Tab_medID and
deleted.Prix = inserted.Prix 
	END