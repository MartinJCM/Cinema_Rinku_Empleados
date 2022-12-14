USE [CinemaRinku]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<JAVIER DE LA CRUZ>
-- Create date: <20-11-2022>
-- Description:	<SE GENERA EL PROCEDIMIENTO PARA OBTENER DETALLES DEL MOVIMIENTOS>
-- =============================================
CREATE PROCEDURE [dbo].[Procedure_Detalles_MovimientoEmp]
@NumEmpleado INT
AS
BEGIN
	SET NOCOUNT ON;
		SELECT E.NumEmpleado,R.Rol, CONCAT(E.Nombre,' ',E.ApellidoP, ' ', E.ApellidoM) Nombre, MS.Mes, M.Horas,M.Entregas, M.PagoTotalXEntrega,M.PagoTotalXBonos,M.Retencion,M.Vale, M.SueldoTotal
	FROM dbo.EMPLEADOS E
	inner join dbo.ROLES R ON E.IdRol = R.IdRol
	inner join dbo.MOVIMIENTOS_MENSUAL M ON M.NumEmpleado = E.NumEmpleado
	inner join dbo.MESES MS ON MS.IdMes = M.IdMes
	WHERE E.NumEmpleado = @NumEmpleado
END
