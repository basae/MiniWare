USE [MiniWareBD]
GO
/****** Object:  StoredProcedure [dbo].[SP_S_UserByGroup]    Script Date: 10/22/2014 09:53:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: 21-10-2014
-- Description:	Obtener usuarios por Grado y Grupo
-- =============================================
CREATE PROCEDURE [dbo].[SP_S_User]
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	SELECT *FROM dbo.Usuario
	WHERE Id=@Id
END
