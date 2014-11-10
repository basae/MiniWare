USE [MiniWareBD]
GO
/****** Object:  StoredProcedure [dbo].[SP_I_MENSAJEGENERAL]    Script Date: 24/10/2014 11:48:41 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: 21-10-2014
-- Description:	Inserta un Mensaje Personal
-- =============================================

CREATE PROCEDURE [dbo].[SP_I_MENSAJEPERSONAL]
	@IdMensajeGeneral int,
	@IdUsuario int
AS
BEGIN
	INSERT INTO [dbo].[MensajePersonal]
	(
		IdMensajeGeneral,
		IdUsuario,
		Visto
	)
	VALUES
	(
		@IdMensajeGeneral,
		@IdUsuario,
		0
	)
END
