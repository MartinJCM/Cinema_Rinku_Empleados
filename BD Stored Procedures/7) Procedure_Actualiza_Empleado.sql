USE [CinemaRinku]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<JAVIER DE LA CRUZ>
-- Create date: <19-11-2022>
-- Description:	<SE GENERA EL PROCEDIMIENTO PARA ACTUALIZACION DEL EMPLEADO>
-- =============================================
CREATE PROCEDURE [dbo].[Procedure_Actualiza_Empleado]
@NumEmpleado INT,
@Nombre VARCHAR(50),
@ApellidoP VARCHAR(50),
@ApellidoM VARCHAR(50),
@IdRol INT,
@Respuesta VARCHAR(50) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE EMPLEADOS SET IdRol=@IdRol,
						 Nombre = @Nombre, 
						 ApellidoP= @ApellidoP, 
						 ApellidoM= @ApellidoM,
						 FechaModificacion= GETDATE()
						 WHERE NumEmpleado = @NumEmpleado;
	SET @Respuesta = 'Empleado se ha actualizado correctamente.'

END
