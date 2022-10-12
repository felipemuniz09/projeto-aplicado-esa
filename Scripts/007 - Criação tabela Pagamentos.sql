CREATE TABLE Pagamentos
(
    Codigo UNIQUEIDENTIFIER CONSTRAINT DF_Pagamentos_Codigo DEFAULT NEWID(),
    CodigoConjugePagou UNIQUEIDENTIFIER CONSTRAINT NN_Pagamentos_CodigoConjugePagou NOT NULL,
    CodigoConjugeRecebeu UNIQUEIDENTIFIER CONSTRAINT NN_Pagamentos_CodigoConjugeRecebeu NOT NULL,
    Valor DECIMAL(18,2) CONSTRAINT NN_Pagamentos_Valor NOT NULL,
    DataHoraCriacao DATETIME CONSTRAINT NN_Pagamentos_DataHoraCriacao NOT NULL CONSTRAINT DF_Pagamentos_DataHoraCriacao DEFAULT GETDATE(), 
    CONSTRAINT PK_Pagamentos PRIMARY KEY (Codigo),
    CONSTRAINT FK_Pagamentos_Conjuge_Pagou FOREIGN KEY (CodigoConjugePagou) REFERENCES dbo.Conjuges (Codigo),
    CONSTRAINT FK_Pagamentos_Conjuge_Recebeu FOREIGN KEY (CodigoConjugeRecebeu) REFERENCES dbo.Conjuges (Codigo)
)