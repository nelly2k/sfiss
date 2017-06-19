INSERT INTO Exercise
SELECT 'Leg Press','',0,'' UNION
SELECT 'Bench Press','',0,''

INSERT INTO Muscle
SELECT 'Quadriceps' UNION
SELECT 'Hamstring' UNION
SELECT 'Pectoralis'

INSERT INTO ExerciseMuscle
SELECT 1,1,1 UNION
SELECT 1,2,0 UNION
SELECT 2,3,1

INSERT INTO Equipment
SELECT 'Bench' 

INSERT INTO ExerciseEquipment
SELECT 2,1