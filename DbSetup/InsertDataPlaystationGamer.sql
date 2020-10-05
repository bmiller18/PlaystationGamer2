USE PlaystationGamer;
GO

SELECT *
FROM game;
GO

BEGIN TRAN
INSERT INTO game
VALUES ('Last of Us Part 2', 'Action-Adventure', 2020)
COMMIT TRAN
GO
