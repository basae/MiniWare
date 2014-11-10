
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: 21-10-2014
-- Description:	Inserta un Mensaje General
-- =============================================
CREATE PROCEDURE SP_I_MENSAJEGENERAL
	@Id int output,
	@Descripcion text,
	@De varchar(100),
	@FechaCierre datetime,
	@Grado int,
	@Grupo varchar(2)
AS
BEGIN
	INSERT INTO dbo.MensajeGeneral
	(
		Descripcion,
		De,
		FechaCreacion,
		FechaCierre,
		Grado,
		Grupo
	)
	VALUES
	(
		@Descripcion,
		@De,
		getdate(),
		@FechaCierre,
		@Grado,
		@Grupo
	)

	set @Id=scope_identity();
END
GO
