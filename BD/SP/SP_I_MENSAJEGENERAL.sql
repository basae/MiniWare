
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
	@Id int,
	@Descripcion text,
	@De varchar(100),
	@FechaCierre datetime
AS
BEGIN
	INSERT INTO dbo.MensajeGeneral
	(
		Descripcion,
		De,
		FechaCreacion,
		FechaCierre
	)
	VALUES
	(
		@Descripcion,
		@De,
		getdate(),
		@FechaCierre
	)
END
GO
