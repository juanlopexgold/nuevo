create table MODELO(
idModelo int primary key identity(1,1),
Nombre varchar(50),
Descripcion varchar(200),
Estado bit,
FechaRegistro datetime default getdate()
)
SELECT * FROM MODELO


CREATE PROCEDURE insertar_modelo
    @Nombre VARCHAR(50),
    @Descripcion VARCHAR(200),
    @Estado BIT = 1
AS
BEGIN
    INSERT INTO MODELO (Nombre, Descripcion, Estado)
    VALUES (@Nombre, @Descripcion, @Estado);
END;
GO

EXEC insertar_modelo @Nombre = 'Modelo A', @Descripcion = 'Descripción del modelo A', @Estado = 1;
---------------------------------------------------------------------------------------------------------

---Actualizar

CREATE PROCEDURE modificar_modelo
    @IdModelo INT,
    @Nombre VARCHAR(50),
    @Descripcion VARCHAR(200),
    @Estado BIT = 1
AS
BEGIN
    UPDATE MODELO
    SET Nombre = @Nombre,
        Descripcion = @Descripcion,
        Estado = @Estado,
        FechaRegistro = GETDATE()
    WHERE idModelo = @IdModelo;
END;
GO

EXEC modificar_modelo 1, 'ModeloActualizado','sasa', 1;
-----------------------------------------------------------------------------------


-----buscar id

CREATE PROCEDURE buscar_modelo_Id
    @IdModelo INT
AS
BEGIN
    SELECT *
    FROM MODELO
    WHERE idModelo = @IdModelo;
END;
GO

EXEC buscar_modelo_Id @IdModelo = 1;

-----------------------------------------------------------------------
--listar

CREATE PROCEDURE listar_modelos
AS
BEGIN
    SELECT *
    FROM MODELO;
END;
GO


exec listar_modelos

------------------------------------------------------------------------------------

---eliminar

CREATE PROCEDURE eliminar_modelo
    @IdModelo INT
AS
BEGIN
    DELETE FROM MODELO
    WHERE idModelo = @IdModelo;
END;
GO

exec eliminar_modelo 1



