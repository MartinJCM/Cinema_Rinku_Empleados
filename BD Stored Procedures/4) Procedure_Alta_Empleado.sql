USE [CinemaRinku]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<JAVIER DE LA CRUZ>
-- Create date: <19-11-2022>
-- Description:	<SE GENERA EL PROCEDIMIENTO PARA LA CREACION DEL EMPLEADO>
-- =============================================
CREATE PROCEDURE [dbo].[Procedure_Alta_Empleado]
@NumEmpleado INT,
@Nombre VARCHAR(50),
@ApellidoP VARCHAR(50),
@ApellidoM VARCHAR(50),
@IdRol INT,
@Respuesta VARCHAR(50) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO EMPLEADOS (NumEmpleado, IdRol, Nombre, ApellidoP, ApellidoM, SueldoBase, FechaAlta) 
	VALUES(@NumEmpleado,@IdRol, @Nombre, @ApellidoP, @ApellidoM,30, GETDATE());	
	SET @Respuesta = 'Empleado se ha capturado correctamente.'

END
