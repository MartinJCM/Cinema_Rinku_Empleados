USE [CinemaRinku]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<JAVIER DE LA CRUZ>
-- Create date: <19-11-2022>
-- Description:	<SE GENERA EL PROCEDIMIENTO PARA OBTENER ROLES>
-- =============================================
CREATE PROCEDURE [dbo].[Procedure_Obtiene_Roles]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT IdRol, Rol FROM dbo.ROLES;
END
