USE [master]
GO

ALTER DATABASE [SuperheroManagement]
SET SINGLE_USER WITH
ROLLBACK AFTER 1

DROP DATABASE [SuperheroManagement]
go

CREATE DATABASE [SuperheroManagement]
GO

USE [SuperheroManagement]
GO

CREATE TABLE [dbo].[Superheroes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HeroName] [nvarchar](max) NOT NULL,
	[SecretName] [nvarchar](max) NOT NULL,
	[Strength] [int] NOT NULL,
	[CanFly] [bit] NOT NULL,
	[AssetsValue] [float] NOT NULL,
	[Powers] [nvarchar](max) NULL,
 CONSTRAINT [PK_Superheroes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[Villains](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VillainName] [nvarchar](max) NOT NULL,
	[SecretName] [nvarchar](max) NULL,
	[KilledPeople] [int] NOT NULL,
	[KidnappedPeople] [int] NOT NULL,
	[FirstDate] [date] NOT NULL,
	[Strength] [int] NOT NULL,
	[Characteristics] [nvarchar](max) NULL,
	[NemesisId] [int] NULL,
 CONSTRAINT [PK_Villains] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Villains]  WITH CHECK ADD  CONSTRAINT [FK_Villains_Superheroes] FOREIGN KEY([NemesisId])
REFERENCES [dbo].[Superheroes] ([Id])
ON UPDATE CASCADE
ON DELETE SET NULL
GO

ALTER TABLE [dbo].[Villains] CHECK CONSTRAINT [FK_Villains_Superheroes]
GO

delete from Villains
delete from Superheroes

insert into Superheroes
(HeroName, SecretName, AssetsValue, CanFly, Powers, Strength)
values
('Superman', 'Clark Kent', 5000, 1, 'Laser sight', 100),
('Batman', 'Bruce Wayne', 1000000000, 0, '- none -', 8)

insert into Villains
(VillainName, SecretName, Characteristics, FirstDate, KidnappedPeople, KilledPeople, Strength, NemesisId)
values
('The Penguin', 'Osvald Cobble', 'Always with an umbrella', '1960-1-5', 30, 12, 4, 2),
('Lex Luthor', 'Lex Luthor', 'bald', '1950-4-12', 2, 5, 6, 1),
('Joker', 'Jack Napier', 'constant creepy smile, dressed like a clown', '1955-8-25', 50, 37, 6, 2)

select * from Superheroes
select * from Villains
