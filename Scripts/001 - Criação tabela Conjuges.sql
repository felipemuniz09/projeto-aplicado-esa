CREATE TABLE Conjuges
(
    Codigo UNIQUEIDENTIFIER,
    Nome NVARCHAR(100) CONSTRAINT NN_Conjuges_Nome NOT NULL,
    Percentual DECIMAL CONSTRAINT NN_Conjuges_Percentual NOT NULL,
    CONSTRAINT PK_Conjuges PRIMARY KEY (Codigo)
)