USE [CinemaRinku]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<JAVIER DE LA CRUZ>
-- Create date: <19-11-2022>
-- Description:	<SE GENERA EL RPOCEDIMIENTO PARA OBTENER TODOS LOS EMPLEADOS>
-- =============================================
CREATE PROCEDURE [dbo].[Procedure_Obtiene_TodosEmpleados]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT E.NumEmpleado,R.Rol, E.Nombre, E.ApellidoP, E.ApellidoM 
	FROM dbo.EMPLEADOS E
	inner join dbo.ROLES R ON E.IdRol = R.IdRol
END
