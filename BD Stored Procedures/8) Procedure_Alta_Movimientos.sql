USE [CinemaRinku]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<JAVIER DE LA CRUZ>
-- Create date: <20-11-2022>
-- Description:	<SE GENERA EL PROCEDIMIENTO PARA CAPTURA DE MOVIMIENTOS>
-- =============================================
CREATE PROCEDURE [dbo].[Procedure_Alta_Movimientos]
@NumEmpleado	INT,
@IdRol			INT,
@IdMes			INT,
@CatidadEntrega INT,
@Respuesta		VARCHAR(50) OUTPUT
AS
DECLARE 
@HorasMes INT = 192, -- 8horas diarias X 6 dias de la semana y X 4 semanas a Mes
@PagoxEntrega DECIMAL(10,5) = 5.0,
@PagoTotalxEntrega DECIMAL(10,5),
@BonoChoferes DECIMAL(10,5) = 10.0,
@BonoCargadores DECIMAL(10,5) = 5.0,
@ISR DECIMAL(10,5) = 0.09, --El 9%
@ISRAdicional DECIMAL(10,5) = 0.03, --El 3% solo se aplica a los empleados con sueldo mayor a Diez mil
@ValeD		DECIMAL(10,5) = 0.04, -- Se aplica el 4% mensual al vale de despensa.
@PagoTotalxBonos DECIMAL(10,5)= 0.10,
@SueldoMesxHoras DECIMAL(10,5),
@Retencion DECIMAL(10,5),
@SueldoARetencion DECIMAL(10,5),
@SueldoDRetencion DECIMAL(10,5),
@SueldoMasVale DECIMAL(10,5),
@SueldoTotal DECIMAL(10,5)

BEGIN
	--SET NOCOUNT ON;
	SET @PagoTotalxEntrega = @PagoxEntrega * @CatidadEntrega;
	SET @SueldoMesxHoras = @HorasMes * (SELECT SueldoBase FROM dbo.EMPLEADOS WHERE NumEmpleado = @NumEmpleado) + @PagoTotalxEntrega;
	 
	IF (@IdRol = 1) -- LOS CHOFERES RECIBEN $10 POR HORA 
		BEGIN
			SET @PagoTotalxBonos = @HorasMes * @BonoChoferes;
		END;
	ELSE IF(@IdRol = 2)-- LOS CARGADORES RECIBEN $5 POR HORA 
	  BEGIN
	  SET @PagoTotalxBonos = @HorasMes * @BonoCargadores;
	  END

	  SET @SueldoARetencion = @SueldoMesxHoras + @PagoTotalxBonos;
	  SET @Retencion = @SueldoARetencion * @ISR;

	  SET @SueldoDRetencion = @SueldoARetencion - @Retencion;

	  IF (@SueldoDRetencion >= 10000)-- APLICAR EL 3%
		BEGIN
			SET @Retencion = @SueldoDRetencion * @ISRAdicional;
			SET @SueldoDRetencion = @SueldoDRetencion - @Retencion;
		END

		SET @SueldoMasVale = @SueldoDRetencion * @ValeD
		SET @SueldoTotal = @SueldoDRetencion + @SueldoMasVale

		INSERT INTO MOVIMIENTOS_MENSUAL(NumEmpleado,IdRol,IdMes,Entregas,Horas,PagoTotalxEntrega,PagoTotalXBonos,Retencion,Vale,SueldoTotal,FechaCaptura) 
		VALUES(@NumEmpleado,@IdRol,@IdMes,@CatidadEntrega,@HorasMes,@PagoTotalxEntrega,@PagoTotalxBonos,@Retencion,@SueldoMasVale,@SueldoTotal, GETDATE());
	
		SET @Respuesta = 'Datos del movimiento se han dado de alta correctamente.';

END
