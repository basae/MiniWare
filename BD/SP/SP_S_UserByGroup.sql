SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: 21-10-2014
-- Description:	Obtener usuarios por Grado y Grupo
-- =============================================
CREATE PROCEDURE SP_S_UserByGroup
	-- Add the parameters for the stored procedure here
	@Grado int,
	@Grupo varchar(1)
AS
BEGIN
	SELECT *FROM dbo.Usuario
	WHERE Grado=@Grado AND Grupo=@Grupo
END
GO
