CREATE TABLE Exercise(
	Id INT NOT NULL IDENTITY,
	Title NVARCHAR(150) NOT NULL,
	OtherTitles NVARCHAR(MAX) NULL,
	Complexity INT NULL,
	Notes NVARCHAR(MAX) NULL,
	ExerciseType INT NULL,
	CONSTRAINT pk_exercise PRIMARY KEY (Id),
	CONSTRAINT un_title UNIQUE (Title)
)
GO
CREATE NONCLUSTERED INDEX [ind_exercise_title] 
  ON [Exercise]
  ([Title] ASC)
GO
CREATE TABLE Muscle (
	Id INT NOT NULL IDENTITY,
	Title NVARCHAR(150) NOT NULL,
	Area INT NULL
	CONSTRAINT pk_muscle PRIMARY KEY (Id),
)
GO
CREATE TABLE ExerciseMuscle(
	ExerciseId INT NOT NULL,
	MuscleId INT NOT NULL,
	IsMajor BIT NOT NULL DEFAULT (1)
	CONSTRAINT pk_exercisemuscle PRIMARY KEY (ExerciseId, MuscleId),
	CONSTRAINT fk_exercisemuscle_exercise FOREIGN KEY (ExerciseId) REFERENCES Exercise (Id),
	CONSTRAINT fk_exercisemuscle_muscle FOREIGN KEY (MuscleId) REFERENCES Muscle (Id)
)
CREATE TABLE Equipment (
	Id INT NOT NULL IDENTITY,
	Title NVARCHAR(150) NOT NULL
	CONSTRAINT pk_equipment PRIMARY KEY (Id)
)
GO 
CREATE TABLE ExerciseEquipment(
	ExerciseId INT NOT NULL,
	EquipmentId INT NOT NULL,
	CONSTRAINT pk_exerciseequipment PRIMARY KEY (ExerciseId, EquipmentId),
	CONSTRAINT fk_exerciseequipment_exercise FOREIGN KEY (ExerciseId) REFERENCES Exercise (Id),
	CONSTRAINT fk_exerciseequipment_equipment FOREIGN KEY (EquipmentId) REFERENCES Equipment (Id)
)
GO
CREATE TABLE Request(
	Id INT NOT NULL IDENTITY,
	Title NVARCHAR(150) NOT NULL,
	OtherTitles NVARCHAR(MAX) NULL,
	Complexity INT NULL,
	Notes NVARCHAR(MAX) NULL,
	CreatedBy UNIQUEIDENTIFIER NOT NULL,
	ExerciseId INT NULL,
	IsProcessed BIT NOT NULL Default 0,
	CONSTRAINT pk_request PRIMARY KEY (Id),
	CONSTRAINT fk_request_exercise FOREIGN KEY (ExerciseId) REFERENCES Exercise (Id),
)
GO
CREATE TABLE ExerciseAnalytics(
	ExerciseId INT NOT NULL,
	WeekStartDate DATE NOT NULL,
	Total INT NOT NULL DEFAULT 0,
	Female INT NOT NULL DEFAULT 0,
	Male INT NOT NULL DEFAULT 0,
	LevelBeginner INT NOT NULL DEFAULT 0,
	LevelIntermediate INT NOT NULL DEFAULT 0,
	LevelAdvanced INT NOT NULL DEFAULT 0,
	Age25 INT NOT NULL DEFAULT 0,
	Age25_34 INT NOT NULL DEFAULT 0,
	Age35_44 INT NOT NULL DEFAULT 0,
	Age45_54 INT NOT NULL DEFAULT 0,
	Age55_65 INT NOT NULL DEFAULT 0,
	Age65 INT NOT NULL DEFAULT 0,
	BMIBelow INT NOT NULL DEFAULT 0,
	BMINormal INT NOT NULL DEFAULT 0,
	BMIOverweight INT NOT NULL DEFAULT 0,
	CONSTRAINT pk_exerciseAnalytics PRIMARY KEY ( ExerciseId,WeekStartDate),
	CONSTRAINT fk_exerciseAnalytics_exercise FOREIGN KEY (ExerciseId) REFERENCES Exercise(Id),
)
GO
