use master
go

create database SuperheroManagement_ANTONELLI
GO

use SuperheroManagement
go

create table Superheroes (
    Id int identity primary key,
    SecretName nvarchar(max),
    HeroName nvarchar(max),
    Strength int,
    AssetsValue int,
    CanFly bit,
    Powers nvarchar(max)
)

create table Villains (
    Id int identity primary key,
    SecretName nvarchar(max),
    VillainName nvarchar(max),
    KilledPeople int,
    Strength int,
    Characteristics nvarchar(max),
    NemesisId int references Superheroes (Id)
)

MODIFICHE PER TEST:

1)
use master 
go

use SuperheroManagement_ANTONELLI
go

alter table Villains 
add KidnappedPeople int


2)
use master
go

use SuperheroManagement_ANTONELLI
go

create table Supporters (
    Id int identity primary key,
    [Name] nvarchar(max),
    Surname nvarchar(max),
    Birth int,
    HeroSupported int references Superheroes (Id)
)


3)
use master
go

use SuperheroManagement_ANTONELLI
go

ALTER TABLE Superheroes
ADD SupportersId int references Supporters (Id)
