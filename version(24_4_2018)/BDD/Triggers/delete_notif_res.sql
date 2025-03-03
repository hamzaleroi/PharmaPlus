USE [mydb]
GO
/****** Object:  Trigger [dbo].[delete_notif_res]    Script Date: 23/04/2018 01:14:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[delete_notif_res]
   ON  [dbo].[TabRestitue]
   AFTER DELETE
AS 
BEGIN

    declare @med_id int
	select @med_id = [Tab_medID] from deleted

	declare @date datetime
	select @date = SYSDATETIME()

	/*
	IF ( not exists(SELECT * FROM [dbo].[TabRestitue] WHERE @med_id=[Tab_medID])) 
		DELETE FROM Tab_notification WHERE [med_id]=@med_id and ([Type_notif]=3 or [Type_notif]=-3)
	ELSE
	BEGIN 
		declare @quantite int
		select @quantite = (SELECT SUM(Quantite) FROM [dbo].[TabRestitue] WHERE @med_id=[Tab_medID])
		IF (@quantite <= 0 ) 
			DELETE FROM Tab_notification WHERE [med_id]=@med_id and ([Type_notif]=3 or [Type_notif]=-3)
	END
	*/

	IF ( not exists(SELECT * FROM [dbo].[TabRestitue] where Tab_medID=@med_id))
		DELETE FROM Tab_notification WHERE [med_id]=@med_id and ([Type_notif]=4 or [Type_notif]=-4)

	ELSE
	BEGIN
		declare @date_per datetime
		SELECT TOP 1 @date_per=DateDePeremption FROM [dbo].[TabRestitue] where Tab_medID=@med_id order by  DateDePeremption
		IF ( @date_per-@date >= 30 )
			DELETE FROM Tab_notification WHERE [med_id]=@med_id and ([Type_notif]=4 or [Type_notif]=-4)
	END
END
