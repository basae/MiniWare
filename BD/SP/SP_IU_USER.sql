SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: 21-10-2014
-- Description:	Inserta un Usuario
-- =============================================
CREATE PROCEDURE SP_IU_USER
	-- Add the parameters for the stored procedure here
	@Id int,
	@Nombre varchar(30),
	@ApPaterno varchar(30),
	@ApMaterno varchar(30),
	@Username varchar(30),
	@Password varchar(50),
	@Celular bigint,
	@Correo varchar(100),
	@Grado int,
	@Grupo varchar(1)
	
AS
BEGIN
	IF(@Id =0 or @Id=null)
	BEGIN
		INSERT INTO dbo.Usuario
		(
			Nombre,
			ApPaterno,
			ApMaterno,
			Username,
			Password,
			Celular,
			Correo,
			Grado,
			Grupo
		)
		VALUES
		(
			@Nombre,
			@ApPaterno,
			@ApMaterno,
			@Username,
			@Password,
			@Celular,
			@Correo,
			@Grado,
			@Grupo
		)
	END
	ELSE
	BEGIN
		UPDATE dbo.Usuario SET
		Nombre=@Nombre,
		ApPaterno=@ApPaterno,
		ApMaterno=@ApMaterno,
		Username=@Username,
		Password=@Password,
		Celular=@Celular,
		Correo=@Correo,
		Grado=@Grado,
		Grupo=@Grupo
		where Id=@Id		
	END
END
GO
