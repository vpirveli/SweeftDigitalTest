SELECT distinct T.Id, T.Name, T.LastName
FROM Teacher T
INNER JOIN TeacherPupil TP on T.Id = TP.TeacherId
INNER JOIN Pupil P on TP.PupilID = P.Id
WHERE P.Name = 'Giorgi'