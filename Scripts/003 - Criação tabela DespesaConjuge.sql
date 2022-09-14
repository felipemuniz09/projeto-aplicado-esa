CREATE TABLE DespesaConjuge
(
    Codigo UNIQUEIDENTIFIER,
    CodigoDespesa UNIQUEIDENTIFIER CONSTRAINT NN_DespesaConjuge_CodigoDespesa NOT NULL,
    CodigoConjuge UNIQUEIDENTIFIER CONSTRAINT NN_DespesaConjuge_Conjuge NOT NULL,
    Valor DECIMAL CONSTRAINT NN_DespesaConjuge_Valor NOT NULL,
    CONSTRAINT PK_DespesaConjuge PRIMARY KEY (Codigo),
    CONSTRAINT FK_DespesaConjuge_Despesas FOREIGN KEY (CodigoDespesa) REFERENCES dbo.Despesas (Codigo),
    CONSTRAINT FK_DespesaConjuge_Conjuges FOREIGN KEY (CodigoConjuge) REFERENCES dbo.Conjuges (Codigo)
)