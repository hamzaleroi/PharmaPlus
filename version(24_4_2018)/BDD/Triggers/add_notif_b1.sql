USE [mydb]
GO
/****** Object:  Trigger [dbo].[add_notif_b1]    Script Date: 23/04/2018 00:58:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[add_notif_b1]
   ON  [dbo].[Bien_etre]
   AFTER UPDATE,INSERT
AS 
BEGIN

	declare @marque varchar(50)
	select @marque = Marque from inserted

	declare @type varchar(50)
	select @type = Type from inserted

	declare @date_per datetime
	select @date_per = DateDePeremption from inserted

	declare @date datetime
	select @date = SYSDATETIME()

	declare @quantite int
	select @quantite = (SELECT SUM(Quantite) FROM [dbo].[Bien_etre] WHERE [Marque]=@marque and [Type]=@type)
	
	IF ( @quantite < 50 )
	BEGIN
		IF NOT EXISTS(SELECT * FROM Tab_notification WHERE [Marque]=@marque and [Type]=@type and (Type_notif=5 or Type_notif=-5)) insert into Tab_notification([Date],[Type_notif],[Marque],[Type]) values (@date,5,@marque,@type)
		ELSE UPDATE Tab_notification SET Date=@date WHERE [Marque]=@marque and [Type]=@type and (Type_notif=5 or Type_notif=-5)
	END

	ELSE DELETE FROM Tab_notification WHERE [Marque]=@marque and [Type]=@type and (Type_notif=5 or Type_notif=-5)


	IF ( @date_per-@date < 30 )
	BEGIN
		IF NOT EXISTS(SELECT * FROM Tab_notification WHERE [Marque]=@marque and [Type]=@type and (Type_notif=6 or Type_notif=-6)) insert into Tab_notification([Date],[Type_notif],[Marque],[Type]) values (@date,6,@marque,@type)
		ELSE UPDATE Tab_notification SET Date=@date WHERE [Marque]=@marque and [Type]=@type and (Type_notif=6 or Type_notif=-6)
	END

END