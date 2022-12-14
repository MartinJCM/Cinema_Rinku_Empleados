USE [CinemaRinku]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<JAVIER DE LA CRUZ>
-- Create date: <19-11-2022>
-- Description:	<SE GENERA EL PROCEDIMIENTO PARA OBTENER EL EMPLEADO POR ID>
-- =============================================
CREATE PROCEDURE [dbo].[Procedure_OtieneEmpleado_Id]
@NumEmpleado INT
AS
BEGIN
	SET NOCOUNT ON;
		
SELECT E.NumEmpleado, R.IdRol, R.Rol, E.Nombre, E.ApellidoP, E.ApellidoM FROM dbo.EMPLEADOS E
		inner join dbo.ROLES R ON E.IdRol = R.IdRol
		WHERE NumEmpleado = @NumEmpleado
END