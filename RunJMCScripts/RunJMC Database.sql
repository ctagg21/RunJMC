USE master
GO

IF EXISTS(SELECT * FROM sys.databases WHERE name='RunJMC')
DROP DATABASE RunJMC
GO

CREATE DATABASE RunJMC
GO


