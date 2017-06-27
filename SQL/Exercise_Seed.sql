INSERT INTO Exercise
SELECT 'Leg Press','',0,'', 0,null,0 UNION
SELECT 'Bench Press','',1,'',1,null,0

INSERT INTO Muscle
SELECT 'Quadriceps',1 UNION
SELECT 'Hamstring',1 UNION
SELECT 'Pectoralis',2

INSERT INTO ExerciseMuscle
SELECT 1,1,1 UNION
SELECT 1,2,0 UNION
SELECT 2,3,1

INSERT INTO Equipment
SELECT 'Bench' 

INSERT INTO ExerciseEquipment
SELECT 2,1