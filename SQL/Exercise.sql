CREATE TABLE Exercise(
	Id INT NOT NULL IDENTITY,
	Title NVARCHAR(150) NOT NULL,
	OtherTitle NVARCHAR(MAX) NULL,
	Complexity INT NULL,
	Notes NVARCHAR(MAX) NULL,
	ExerciseType INT NULL,
	CONSTRAINT pk_exercise PRIMARY KEY (Id),
	CONSTRAINT un_title UNIQUE (Title)
)
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
	OtherTitle NVARCHAR(MAX) NULL,
	Complexity INT NULL,
	Notes NVARCHAR(MAX) NULL,
	CreatedBy UNIQUEIDENTIFIER NOT NULL,
	ExerciseId INT NULL,
	CONSTRAINT pk_request PRIMARY KEY (Id),
	CONSTRAINT fk_request_exercise FOREIGN KEY (ExerciseId) REFERENCES Exercise (Id),
)


