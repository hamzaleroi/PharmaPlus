USE [mydb]
GO
/****** Object:  Trigger [dbo].[add_notif_res]    Script Date: 23/04/2018 01:13:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[add_notif_res]
   ON [dbo].[TabRestitue]
   AFTER UPDATE,INSERT
AS 
BEGIN

	declare @med_id int
	select @med_id = Tab_medID from inserted

	declare @date_per datetime
	select @date_per = DateDePeremption from inserted

	declare @date datetime
	select @date = SYSDATETIME()
	/*
	declare @quantite int
	select @quantite = (SELECT SUM(Quantite) FROM [dbo].[TabRestitue] WHERE @med_id=[Tab_medID])
	
	IF ( @quantite < 50 )
	BEGIN
		IF NOT EXISTS(SELECT * FROM Tab_notification WHERE [med_id]=@med_id and (Type_notif=3 or Type_notif=-3)) insert into Tab_notification([med_id],[Date],[Type_notif]) values (@med_id,@date,3)
		ELSE UPDATE Tab_notification SET Date=@date WHERE [med_id]=@med_id and (Type_notif=3 or Type_notif=-3)
	END

	ELSE DELETE FROM Tab_notification WHERE [med_id]=@med_id and (Type_notif=3 or Type_notif=-3)
	*/

	IF ( @date_per-@date < 30 )
	BEGIN
		IF NOT EXISTS(SELECT * FROM Tab_notification WHERE [med_id]=@med_id and (Type_notif=4 or Type_notif=-4)) insert into Tab_notification([med_id],[Date],[Type_notif]) values (@med_id,@date,4)
		ELSE UPDATE Tab_notification SET Date=@date WHERE [med_id]=@med_id and (Type_notif=4 or Type_notif=-4)
	END

END