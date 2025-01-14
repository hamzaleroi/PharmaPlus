USE [mydb]
GO
/****** Object:  Trigger [dbo].[delete_notif_2]    Script Date: 23/04/2018 01:15:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[delete_notif_2]
   ON  [dbo].[Tab_NEW]
   AFTER DELETE
AS 
BEGIN

    declare @med_id int
	select @med_id = [Tab_medID] from deleted

	declare @date datetime
	select @date = SYSDATETIME()	

	IF ( not exists(SELECT * FROM [dbo].[Tab_NEW] WHERE @med_id=[Tab_medID])) 
		DELETE FROM Tab_notification WHERE [med_id]=@med_id and ([Type_notif]=1 or [Type_notif]=-1)
	ELSE
	BEGIN 
		declare @quantite int
		select @quantite = (SELECT SUM(Quantite) FROM [dbo].[Tab_NEW] WHERE @med_id=[Tab_medID])
		IF (@quantite <= 0 ) 
			DELETE FROM Tab_notification WHERE [med_id]=@med_id and ([Type_notif]=1 or [Type_notif]=-1)
	END

	IF ( not exists(SELECT * FROM Tab_NEW where Tab_medID=@med_id))
		DELETE FROM Tab_notification WHERE [med_id]=@med_id and ([Type_notif]=2 or [Type_notif]=-2)

	ELSE
	BEGIN
		declare @date_per datetime
		SELECT TOP 1 @date_per=DateDePeremption FROM Tab_NEW where Tab_medID=@med_id order by  DateDePeremption
		IF ( @date_per-@date >= 30 )
			DELETE FROM Tab_notification WHERE [med_id]=@med_id and ([Type_notif]=2 or [Type_notif]=-2)
	END
END
