USE [MiniWareBD]
GO
/****** Object:  StoredProcedure [dbo].[SP_I_MENSAJEGENERAL]    Script Date: 24/10/2014 11:48:41 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: 27-10-2014
-- Description:	Trae los mensajes de cada alumno que no esten vistos
-- =============================================

CREATE PROCEDURE [dbo].[SP_S_MensajesGeneralById]
	@IdMensaje int
AS
BEGIN
	SELECT *FROM MENSAJEGENERAL WHERE ID=@IdMensaje
	
END
