CREATE DATABASE Futurama
GO

USE Futurama
GO

CREATE TABLE [Characters](
	[Id] int IDENTITY(1,1) NOT NULL,
	[Name] nvarchar(50) NOT NULL,
	[Planet] nvarchar(50) NULL,
	[Species] nvarchar(50) NULL,
	CONSTRAINT [PK_Characters] PRIMARY KEY CLUSTERED ([Id] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO [Characters] VALUES 
	('Philip J. Fry', 'Earth', 'Human'),
	('Leela Turanga', 'Earth', 'Mutant-Human'),
	('Bender Bending Rodríguez', 'Earth', 'Robot'),
	('Hubert J. Farnsworth', 'Earth', 'Human'),
	('John A. Zoidberg', 'Decapod 10', 'Decapodian'),
	('Amy Wong', 'Mars', 'Human'),
	('Hermes Conrad', 'Earth', 'Human')
