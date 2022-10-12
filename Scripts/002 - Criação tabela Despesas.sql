CREATE TABLE Despesas
(
    Codigo UNIQUEIDENTIFIER,
    Descricao NVARCHAR(200) CONSTRAINT NN_Despesas_Descricao NOT NULL,
    Valor DECIMAL(18,2) CONSTRAINT NN_Despesas_Valor NOT NULL,
    CONSTRAINT PK_Despesas PRIMARY KEY (Codigo)
)