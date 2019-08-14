CREATE DATABASE PRUEBA

CREATE TABLE PERSONA 
(
  ID_P INT IDENTITY (1,1),
  NOMBRE VARCHAR(50) NOT NULL,
  APELLIDO VARCHAR (50) NOT NULL,
  CONSTRAINT PK1 PRIMARY KEY(ID_P)
)

CREATE TABLE TAREA 
(
   ID_T INT IDENTITY (1,1),
   DESCRIPCION VARCHAR(60) NOT NULL,
   ID_P INT NOT NULL,
   CONSTRAINT PK2 PRIMARY KEY(ID_T),
   CONSTRAINT FK1 FOREIGN KEY(ID_P)
   REFERENCES PERSONA (ID_P)

)

GO
CREATE PROCEDURE SPA_INSERTPERSONA
@NOMBRE VARCHAR(50),
@APELLIDO VARCHAR(50)
AS
BEGIN 
INSERT INTO PERSONA (NOMBRE,APELLIDO)
VALUES(@NOMBRE,@APELLIDO)
END 
GO

CREATE PROC SPA_UPDATEPERSONA
@ID_P INT,
@NOMBRE VARCHAR(50),
@APELLIDO VARCHAR(50)
  
AS 
BEGIN 
 
UPDATE PERSONA
SET  NOMBRE = @NOMBRE,
     APELLIDO = @APELLIDO 
     
WHERE  ID_P = @ID_P
END
GO

CREATE PROCEDURE SPA_DELETEPERSONA
@ID_P INT
AS 
BEGIN 
DELETE
FROM   PERSONA
WHERE  ID_P = @ID_P
END
GO

CREATE PROCEDURE SPA_INSERTTAREA
@DESCRIPCION VARCHAR(50),
@ID_P INT
AS
BEGIN 
INSERT INTO TAREA (DESCRIPCION,ID_P)
VALUES(@DESCRIPCION,@ID_P)
END 
GO

CREATE PROC SPA_UPDATETARE
@ID_T INT,
@DESCRIPCION VARCHAR(50)
AS 
BEGIN 
 
UPDATE TAREA
SET  DESCRIPCION = @DESCRIPCION
     
WHERE  ID_T = @ID_T
END
GO

CREATE PROCEDURE SPA_DELETETAREA
@ID_T INT
AS 
BEGIN 
DELETE
FROM   TAREA
WHERE  ID_T = @ID_T
END
GO

SELECT * FROM PERSONA

SELECT * FROM TAREA