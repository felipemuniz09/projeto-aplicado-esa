ALTER TABLE Conjuges ADD CONSTRAINT DF_Conjuges_Codigo DEFAULT newid() FOR Codigo;
ALTER TABLE Despesas ADD CONSTRAINT DF_Despesas_Codigo DEFAULT newid() FOR Codigo;
ALTER TABLE DespesaConjuge ADD CONSTRAINT DF_DespesaConjuge_Codigo DEFAULT newid() FOR Codigo;