
CREATE TABLE Gestores (
    GestorID INT PRIMARY KEY,
    Nombre NVARCHAR(100)
); 

Alter PROCEDURE AsignarSaldos
AS
BEGIN
    -- Variables
    DECLARE @saldos TABLE (Saldo DECIMAL(10, 2));
    DECLARE @gestores TABLE (GestorID INT);
    DECLARE @saldo DECIMAL(10, 2);
    DECLARE @gestorID INT;
    DECLARE @numGestores INT;
    DECLARE @numSaldos INT;
    DECLARE @sumaOriginal DECIMAL(18, 2);
    DECLARE @sumaAsignada DECIMAL(18, 2);
    
    -- Limpiar la tabla SaldosAsignados
    DELETE FROM SaldosAsignados;
    
    -- Insertar los saldos
    INSERT INTO @saldos (Saldo) VALUES 
        (2277), (3953), (4726), (1414), (627), (1784), (1634), (3958),
        (2156), (1347), (2166), (820), (2325), (3613), (2389), (4130),
        (2007), (3027), (2591), (3940), (3888), (2975), (4470), (2291),
        (3393), (3588), (3286), (2293), (4353), (3315), (4900), (794),
        (4424), (4505), (2643), (2217), (4193), (2893), (4120), (3352),
        (2355), (3219), (3064), (4893), (272), (1299), (4725), (1900),
        (4927), (4011);
    
   
    
    -- Insertar gestores
    INSERT INTO @gestores (GestorID)
    SELECT GestorID FROM Gestores;

    -- Contar el número de gestores y saldos
    SET @numGestores = (SELECT COUNT(*) FROM @gestores);
    SET @numSaldos = (SELECT COUNT(*) FROM @saldos);

    -- Evitar división por cero
    IF @numGestores = 0 OR @numSaldos = 0
    BEGIN
        RAISERROR('No hay gestores o saldos disponibles.', 16, 1);
        RETURN;
    END

    -- Cursor para saldos ordenados de forma descendente
    DECLARE saldo_cursor CURSOR FOR
    SELECT Saldo FROM @saldos ORDER BY Saldo DESC;

    -- Cursor para los gestores
    DECLARE gestor_cursor CURSOR FOR
    SELECT GestorID FROM @gestores;

    -- Abrir los cursores
    OPEN saldo_cursor;
    OPEN gestor_cursor;

    -- Obtener el primer saldo
    FETCH NEXT FROM saldo_cursor INTO @saldo;

    -- Variable para saber si el bucle de gestores ha terminado
    DECLARE @terminado INT = 0;

    -- Ciclo sobre los saldos
    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Reiniciar el cursor de gestores cuando terminen los gestores
        IF @terminado = 1
        BEGIN
            CLOSE gestor_cursor;
            OPEN gestor_cursor;
            SET @terminado = 0;
        END

        -- Obtener el siguiente gestor
        FETCH NEXT FROM gestor_cursor INTO @gestorID;

        -- Verificar si el bucle de gestores ha llegado al final
        IF @@FETCH_STATUS <> 0
        BEGIN
            SET @terminado = 1;
            CONTINUE;
        END

        -- Asignar el saldo al gestor
        INSERT INTO SaldosAsignados (GestorID, Saldo)
        VALUES (@gestorID, @saldo);

        -- Obtener el siguiente saldo
        FETCH NEXT FROM saldo_cursor INTO @saldo;
    END

    -- Cerrar y liberar los cursores
    CLOSE saldo_cursor;
    DEALLOCATE saldo_cursor;
    CLOSE gestor_cursor;
    DEALLOCATE gestor_cursor;
	-- Seleccionar los saldos asignados
    SELECT * FROM SaldosAsignados;
   
END
EXEC AsignarSaldos;