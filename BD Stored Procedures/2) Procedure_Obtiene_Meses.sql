USE [CinemaRinku]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<JAVIER DE LA CRUZ>
-- Create date: <20-11-2022>
-- Description:	<SE GENERA EL PROCEDIMIENTO PARA OBTENER LISTAS DE MESES>
-- =============================================
CREATE PROCEDURE [dbo].[Procedure_Obtiene_Meses]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT IdMes, Mes FROM MESES;
END
