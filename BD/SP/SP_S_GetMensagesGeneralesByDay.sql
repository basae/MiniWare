
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: 21-10-2014
-- Description:	Selecciona los mensages generales por dia
-- =============================================
CREATE PROCEDURE SP_S_GetMensagesGeneralesByDay
	@Date datetime
AS
BEGIN
	SELECT *FROM dbo.MensajeGeneral
	WHERE 
		DATEPART(YEAR,fechaCreacion)=DATEPART(YEAR,@Date) AND
		DATEPART(MONTH,fechaCreacion)=DATEPART(MONTH,@Date) AND
		DATEPART(DAY,fechaCreacion)=DATEPART(DAY,@Date)
END
GO
