Create Database MoviesList;

Use MoviesList;

CREATE TABLE [dbo].[Actors] (
    [ActorID]        	INT             IDENTITY (1, 1)  NOT NULL,
    [Name]      	NVARCHAR (100)	NOT NULL,
    [Sex]		VARCHAR(50)	NOT NULL,
    [DOB]		DATETIME	NOT NULL,
    [Bio]		NVARCHAR(MAX)	NOT NULL,
    PRIMARY KEY CLUSTERED ([ActorID] ASC)
);

CREATE TABLE [dbo].[Movies] (
    [MovieID]       	INT            IDENTITY (1, 1) NOT NULL,
    [Name]		NVARCHAR (100)	NOT NULL,
    [YearOfRelease] 	DATETIME	NOT NULL,
    [Plot]		NVARCHAR(MAX)	NOT NULL,
    [Poster]		nvarchar(MAX)	NULL,
    [ActorID]		INT		NULL,
    [ProducerID]	INT	NULL,
    PRIMARY KEY CLUSTERED ([MovieID] ASC)
);

CREATE TABLE [dbo].[Producer] (
    [ProducerID]        INT            IDENTITY (1, 1) NOT NULL,
    [Name]      	NVARCHAR (100)  NOT NULL,
    [Sex]		VARCHAR(50)	NOT NULL,
    [DOB]		DATETIME	NOT NULL,
    [Bio]		NVARCHAR(Max)	NOT NULL,
    PRIMARY KEY CLUSTERED ([ProducerID] ASC)
);

CREATE TABLE [dbo].[Image] (
    [ImageID]        	INT            IDENTITY (1, 1) NOT NULL,
    [Title]		VARCHAR (250)	NULL,
    [ImagePath]		VARCHAR(MAX)	NULL,
    PRIMARY KEY CLUSTERED ([ImageID] ASC)
);

--Inserting Vlaues for Testing the scenario
INSERT INTO [dbo].[Actors](Name, Sex, DOB, Bio) VALUES ('Leonardo DeCaprio', 'M', '11-11-1974', 'Leonardo Wilhelm DiCaprio is an American actor, producer, and environmentalist. He has often played unconventional parts, particularly in biopics and period films. As of 2019, his films have earned US$7.2 billion worldwide, and he has placed eight times in annual rankings of the world highest-paid actors');
INSERT INTO [dbo].[Actors](Name, Sex, DOB, Bio) VALUES ('Robert Downey Jr', 'M', '04-04-1965', 'Robert John Downey Jr. is an American actor, producer, and singer. His career has been characterized by critical and popular success in his youth, followed by a period of substance abuse and legal troubles, before a resurgence of commercial success in middle age.');

INSERT INTO [dbo].[Producer](Name, Sex, DOB, Bio) VALUES ('Kevin Feige', 'M', '11-11-1973','Kevin Feige is an American film producer who has been the president of Marvel Studios since 2007. The films he has produced have a combined worldwide box office gross of over $26.8 billion. Feige is a member of the Producers Guild of America.');

--Adding Referential Integrity Constraint
ALTER TABLE [dbo].[Movies]
  ADD CONSTRAINT FK_MovieActor FOREIGN KEY (ActorID) REFERENCES Actors (ActorID);
ALTER TABLE [dbo].[Movies]
ADD CONSTRAINT FK_MovieProducer FOREIGN KEY (ProducerID) REFERENCES Producer (ProducerID);



--END


--BELOW STATEMENTS ARE EXTRA AND NOT USED IN THIS PROJECT

--Below are the other workarounds for Image Upload
INSERT INTO Movies(MovieID, Name, YearOfRelease, Plot, Poster, ActorID, ProducerID) 
SELECT  1, 'Iron Man 3','2013-04-26 00:00:00.000','Tony-Stark encounters a formidable foe called the Mandarin. After failing to defeat his enemy, Tony embarks on a journey of self-discovery as he fights against the powerful Mandarin.','image',2 , 1 BulkColumn 
FROM Openrowset( Bulk 'C:\Users\duppa\Desktop\Images\Pic1.jpg', Single_Blob) as Image

INSERT INTO [dbo].[Movies]([Poster])
SELECT 1  Bulkcolumn
FROM   OPENROWSET(BULK 'C:\Users\duppa\Desktop\Images\Pic1.jpg', SINGLE_BLOB) AS IMG_DATA;

--Alternate method for Image upload

CREATE TABLE [dbo].[Posters] (
    [PosterID]		INT            IDENTITY (1, 1) NOT NULL, 
    [Poster]		image NULL,
    PRIMARY KEY CLUSTERED ([PosterID] ASC)
   )
--Stored Procedure for Image Upload
Use MoviesList
Go
CREATE PROCEDURE dbo.usp_ImportImage (
    @PicName NVARCHAR (100)
   )
AS
BEGIN
   DECLARE @Path2OutFile NVARCHAR (2000);
   DECLARE @tsql NVARCHAR (2000);
   SET NOCOUNT ON
   SET @Path2OutFile = CONCAT (
         @ImageFolderPath
         ,'\'
         , @Filename
         );
   SET @tsql = 'insert into Posters (PosterName, PosterFileName, PosterData) ' +
               ' SELECT ' + '''' + @PicName + '''' + ',' + '''' + @Filename + '''' + ', * ' + 
               'FROM Openrowset( Bulk ' + '''' + @Path2OutFile + '''' + ', Single_Blob) as img'
   EXEC (@tsql)
   SET NOCOUNT OFF
END
GO

exec dbo.usp_ImportImage 'Pic1.jpg','C:\Users\duppa\Desktop\Images','Pic1.jpg'


