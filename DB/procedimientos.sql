--insertar categoria
CREATE PROCEDURE insertar_categoria
    @Categoria VARCHAR(60),
    @Descripcion VARCHAR(250),
    @Estado BIT = 1
AS
BEGIN
    INSERT INTO CATEDORIA (Categoria, Descripcion, Estado)
    VALUES (@Categoria, @Descripcion, @Estado);
END;
--EXEC insertar_categoria @Categoria = 'Entretenimiento', @Descripcion = 'Dispositivos electrónicos', @Estado = 1;
go

--editar categoria
CREATE PROCEDURE modificar_categoria
    @IdCategoria INT,
    @Categoria VARCHAR(60),
    @Descripcion VARCHAR(250),
    @Estado BIT = 1
AS
BEGIN
    UPDATE CATEDORIA
    SET Categoria = @Categoria,
        Descripcion = @Descripcion,
        Estado = @Estado,
        FechaRegistro = GETDATE()
    WHERE IdCategoria = @IdCategoria;
END;
go
EXEC modificar_categoria @IdCategoria = 1, @Categoria = 'Otro', @Descripcion = 'Dispositivos electrónicos actualizados', @Estado = 1;
go

--buscar por ID
CREATE PROCEDURE buscar_categoria_Id
@IdCategoria INT
AS
BEGIN
    SELECT TOP 50 *
    FROM CATEDORIA
    WHERE IdCategoria = @IdCategoria;
END;

--EXEC buscar_categoria_Id @IdCategoria = 3;
go

--listar registros
CREATE PROCEDURE listar_categoria
AS
BEGIN
    SELECT * FROM CATEDORIA;
END;

EXEC listar_categoria;
go

--desactivar regitros
CREATE PROCEDURE eliminar_categoria
    @IdCategoria INT
AS
BEGIN
    DELETE FROM CATEDORIA
    WHERE IdCategoria = @IdCategoria;
END;

--EXEC DeactivateCategoria @IdCategoria = 1;



--PROCEDIMEITOS ALMACENADOS DE MOELO
--insertar modelo
CREATE PROCEDURE insertar_modelo
    @Nombre VARCHAR(50),
    @Estado BIT
AS
BEGIN
    INSERT INTO MODELO (Nombre, Estado)
    VALUES (@Nombre, @Estado);
END;
--EXEC insertar_modelo @Nombre = 'Modelo1', @Estado = 1;
go

--editar modelo
CREATE PROCEDURE editar_modelo
    @IdModelo INT,
    @Nombre VARCHAR(50),
    @Estado BIT
AS
BEGIN
    UPDATE MODELO
    SET Nombre = @Nombre,
        Estado = @Estado,
        FechaRegistro = GETDATE()
    WHERE idModelo = @IdModelo;
END;
--EXEC editar_modelo @IdModelo = 1, @Nombre = 'NuevoNombre', @Estado = 1;
go

--buscar por ID
CREATE PROCEDURE buscar_modelo_por_id
    @IdModelo INT
AS
BEGIN
    SELECT * FROM MODELO
    WHERE idModelo = @IdModelo;
END;
EXEC buscar_modelo_por_id @IdModelo = 3;
go

--listar registros
CREATE PROCEDURE mostrar_modelos
AS
BEGIN
    SELECT * FROM MODELO;
END;

EXEC mostrar_modelos;
go

--eliminar regitros
CREATE PROCEDURE eliminar_modelo
    @IdModelo INT
AS
BEGIN
    DELETE FROM MODELO
    WHERE idModelo = @IdModelo;
END;

--EXEC DeactivateCategoria @IdCategoria = 1;