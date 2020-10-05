USE PlaystationGamer;

CREATE TABLE users(
			userID				INT				PRIMARY KEY IDENTITY,
			userName			NVARCHAR(20)	NOT NULL,
			email				NVARCHAR(50)	NOT NULL,
			lastName			NVARCHAR(50)	NOT NULL,
			firstName			NVARCHAR(50)	NOT NULL,	
			photoPath			NVARCHAR(200)			,
)
GO

CREATE TABLE blog(
			blogID			INT					PRIMARY KEY IDENTITY,
			userID			INT					FOREIGN KEY REFERENCES users (userID),
			blogTitle		NVARCHAR(500)		NOT NULL,
			blogPost		TEXT				NOT NULL,
			blogDate		DATETIME			NOT NULL
)
GO

CREATE TABLE game(
			gameID			INT					PRIMARY KEY IDENTITY,
			titleName		NVARCHAR(100)		NOT NULL,
			genre			NVARCHAR(30)		NOT NULL,
			yearReleased	INT					NOT NULL,
)
GO

CREATE TABLE console(
			consoleID		INT					PRIMARY KEY IDENTITY,
			consoleName		NVARCHAR(50)		NOT NULL,
			yearReleased	INT					NOT NULL,
			unitsSold		NVARCHAR(50)		NOT NULL,
			price			NVARCHAR(50)		NOT NULL
)
GO

CREATE TABLE controller(
			controllerID	INT					PRIMARY KEY IDENTITY,
			consoleID		INT					FOREIGN KEY REFERENCES console (consoleID),
			controllerName	NVARCHAR(100)		NOT NULL,
			yearReleased	INT					NOT NULL,
			price			NVARCHAR(50)		NOT NULL
)
GO