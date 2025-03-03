USE [mydb]
GO
/****** Object:  Trigger [dbo].[delete_notif_b1]    Script Date: 23/04/2018 01:07:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[delete_notif_b1]
   ON [dbo].[Bien_etre]
   AFTER DELETE
AS 
BEGIN
	declare @marque varchar(50)
	select @marque = Marque from deleted

	declare @type varchar(50)
	select @type = Type from deleted

	declare @date datetime
	select @date = SYSDATETIME()

	IF ( not exists(SELECT * FROM [dbo].[Bien_etre] WHERE [Marque]=@marque and [Type]=@type))
		DELETE FROM Tab_notification WHERE [Marque]=@marque and [Type]=@type and ([Type_notif]=5 or [Type_notif]=-5)
	ELSE
	BEGIN 
		declare @quantite int
		select @quantite = (SELECT SUM(Quantite) FROM [dbo].[Bien_etre] WHERE [Marque]=@marque and [Type]=@type)
		IF (@quantite <= 0 )
			DELETE FROM Tab_notification WHERE [Marque]=@marque and [Type]=@type and ([Type_notif]=5 or [Type_notif]=-5)
	END

	IF ( not exists(SELECT * FROM [dbo].[Bien_etre] where [Marque]=@marque and [Type]=@type))
		DELETE FROM Tab_notification WHERE [Marque]=@marque and [Type]=@type and ([Type_notif]=6 or [Type_notif]=-6)
	ELSE
	BEGIN
		declare @date_per datetime
		SELECT TOP 1 @date_per=DateDePeremption FROM [dbo].[Bien_etre] where [Marque]=@marque and [Type]=@type order by  DateDePeremption
		IF ( @date_per-@date >= 30 )
			DELETE FROM Tab_notification WHERE [Marque]=@marque and [Type]=@type and ([Type_notif]=6 or [Type_notif]=-6)
	END
END
