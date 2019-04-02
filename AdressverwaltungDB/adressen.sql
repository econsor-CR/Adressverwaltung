CREATE TABLE [dbo].[adressen]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [name] NVARCHAR(MAX) NOT NULL, 
    [vorname] NVARCHAR(MAX) NOT NULL, 
    [email] NVARCHAR(MAX) NOT NULL, 
    [telefonnummer] INT NOT NULL, 
    [strasse] NVARCHAR(MAX) NOT NULL, 
    [hausnummer] NVARCHAR(MAX) NOT NULL, 
    [postleitzahl] INT NOT NULL, 
    [ort] NVARCHAR(MAX) NOT NULL
)
