-- TABELLER FÖR PROJEKT, HÄMTA INGENTING FRÅN NÅGON AV TABELLERNA!! HÄMTA FRÅN VYN: CompleteMentorProfile. Finns längre ner i denna Query.
-- Hämta inget ifrån dessa.
create table Programs(
Programname varchar(100) primary key
)
create table Courses(
Coursecode varchar(8),
Coursename varchar(100),
primary key(Coursename)
)
create table FakeLadok(
StudentID varchar(8) primary key,
Firstname varchar(50),
Lastname varchar(50),
Gender varchar(10),
City varchar(50),
Program varchar(100) foreign key references Programs(Programname),
)
-- Lägg till saker i denna tabell vid skapning av profil--
create table MentorProfile(
StudentID varchar(8) foreign key references FakeLadok(StudentID),
ImageUrl varchar(200),
Info varchar(200),
primary key (StudentID)
)
-- Lägg till saker i denna tabell vid skapning av profil--
create table CompletedCourses(
StudentID varchar(8) foreign key references FakeLadok(StudentID),
Coursename varchar(100) foreign key references Courses(Coursename),
primary key(StudentID, Coursename)
)
-- Lägg till saker i denna tabell vid skapning av profil--
create table MentorMerits(
StudentID varchar(8) foreign key references FakeLadok(StudentID),
Merit varchar(20), 
primary key(StudentID, Merit))
-- Lägg till saker i denna tabell vid skapning av profil--
create table MentorAvailability(
StudentID varchar(8) foreign key references FakeLadok(StudentID),
Availabledays varchar(20), 
primary key(StudentID, Availabledays))
-- Lägg till saker i denna tabell vid skapning av profil--
create table ProfileStatus(
StudentID varchar(8) foreign key references FakeLadok(StudentID),
Student bit,
Mentor bit
primary key (StudentID)
)

-- Vy att använda när vi vill visa profilen -- 
create view CompleteMentorProfile
as
Select fl.StudentID, fl.Firstname, fl.Lastname, fl.Gender, fl.City, fl.Program, mp.ImageUrl, mp.Info, cc.Coursename, mm.Merit, ma.Availabledays, ps.Student, ps.Mentor
from FakeLadok fl
FULL JOIN MentorProfile mp on fl.StudentID = mp.StudentID
FULL JOIN CompletedCourses cc on mp.StudentID = cc.StudentID
FULL JOIN MentorMerits mm on cc.StudentID = mm.StudentID 
FULL JOIN MentorAvailability ma on mm.StudentID = ma.StudentID
FULL JOIN ProfileStatus ps ON ma.StudentID = ps.StudentID

drop view CompleteMentorProfile
SELECT * FROM CompleteMentorProfile

-- Lite info jag stoppat in--
INSERT INTO Programs(Programname)
VALUES ('Computer Science')
INSERT INTO Programs(Programname)
VALUES ('Innovation and Design')
INSERT INTO Programs(Programname)
VALUES ('International Marketing')
INSERT INTO Programs(Programname)
VALUES ('Software Engineering')

INSERT INTO Courses(Coursecode,Coursename)
VALUES ('DVA231','Web application development') 
INSERT INTO Courses(Coursecode,Coursename)
VALUES ('DVA338','Computer graphics basics') 
INSERT INTO Courses(Coursecode,Coursename)
VALUES ('MMA122','Discreet mathematics') 
INSERT INTO Courses(Coursecode,Coursename)
VALUES ('DVA234','Databases') 

INSERT INTO FakeLadok(StudentID, Firstname, Lastname, Gender, City, Program)
VALUES ('lis16001', 'Linus', 'Sens Ingels', 'Man', 'Västerås', 'Computer Science');
INSERT INTO FakeLadok(StudentID, Firstname, Lastname, Gender, City, Program)
VALUES ('fdn16001', 'Fanny', 'Danielsson', 'Female', 'Västerås', 'Computer Science');
INSERT INTO FakeLadok(StudentID, Firstname, Lastname, Gender, City, Program)
VALUES ('jmr16009', 'Jonathan', 'Major', 'Man', 'Västerås', 'Computer Science');
INSERT INTO FakeLadok(StudentID, Firstname, Lastname, Gender, City, Program)
VALUES ('ewr15001', 'Erika', 'Weilander', 'Female', 'Västerås', 'Computer Science');
INSERT INTO FakeLadok(StudentID, Firstname, Lastname, Gender, City, Program)
VALUES ('adn16001', 'Lisa', 'Fredriksson', 'Female', 'Västerås', 'International Marketing');
INSERT INTO FakeLadok(StudentID, Firstname, Lastname, Gender, City, Program)
VALUES ('vbn16001', 'Viktor', 'Bergman', 'Man', 'Västerås', 'Computer Science');

INSERT INTO CompletedCourses(StudentID, Coursename)
VALUES('fdn16001', 'Web application development')
INSERT INTO CompletedCourses(StudentID, Coursename)
VALUES('fdn16001', 'Computer graphics basics')
INSERT INTO CompletedCourses(StudentID, Coursename)
VALUES('jmr16009', 'Web application development')
INSERT INTO CompletedCourses(StudentID, Coursename)
VALUES('vbn16001', 'Computer graphics basics')
INSERT INTO CompletedCourses(StudentID, Coursename)
VALUES('lis16001', 'Web application development')
INSERT INTO CompletedCourses(StudentID, Coursename)
VALUES('lis16001', 'Computer graphics basics')
INSERT INTO CompletedCourses(StudentID, Coursename)
VALUES('jmr16009', 'Discreet mathematics')
INSERT INTO CompletedCourses(StudentID, Coursename)
VALUES('vbn16001', 'Databases')

INSERT INTO MentorMerits(StudentID, Merit)
VALUES ('fdn16001','SQL')
INSERT INTO MentorMerits(StudentID, Merit)
VALUES ('jmr16009','SQL')
INSERT INTO MentorMerits(StudentID, Merit)
VALUES ('vbn16001','Long hair')
INSERT INTO MentorMerits(StudentID, Merit)
VALUES ('ewr15001','Cute smile')

INSERT INTO MentorAvailability(StudentID, Availabledays)
VALUES ('fdn16001','Friday')
INSERT INTO MentorAvailability(StudentID, Availabledays)
VALUES ('jmr16009','Sunday')
INSERT INTO MentorAvailability(StudentID, Availabledays)
VALUES ('vbn16001','Monday')
INSERT INTO MentorAvailability(StudentID, Availabledays)
VALUES ('ewr15001','Sunday')

INSERT INTO MentorProfile(StudentID, ImageUrl, Info)
VALUES ('fdn16001', 'img/AboutUs.jpg', 'Best WoW-player EU.')
INSERT INTO MentorProfile(StudentID, ImageUrl, Info)
VALUES ('ewr15001', 'img/AboutUs.jpg', 'Sassygirl;)')
INSERT INTO MentorProfile(StudentID, ImageUrl, Info)
VALUES ('vbn16001', 'img/AboutUs.jpg', 'Long hair dont care.')
INSERT INTO MentorProfile(StudentID, ImageUrl, Info)
VALUES ('lis16001', 'img/AboutUs.jpg', 'Fika.')
INSERT INTO MentorProfile(StudentID, ImageUrl, Info)
VALUES ('jmr16009', 'img/AboutUs.jpg', 'I learn everthing over a night.')

INSERT INTO ProfileStatus(StudentID, Student, Mentor)
VALUES('ewr15001', 0, 1)
INSERT INTO ProfileStatus(StudentID, Student, Mentor)
VALUES('jmr16009', 0, 1)
INSERT INTO ProfileStatus(StudentID, Student, Mentor)
VALUES('lis16001', 0, 1)
INSERT INTO ProfileStatus(StudentID, Student, Mentor)
VALUES('vbn16001', 0, 1)
INSERT INTO ProfileStatus(StudentID, Student, Mentor)
VALUES('fdn16001', 0, 1)
INSERT INTO ProfileStatus(StudentID, Student, Mentor)
VALUES('adn16001', 1, 0)

SELECT * FROM Programs
SELECT * FROM Courses
SELECT * FROM FakeLadok
SELECT * FROM MentorProfile
SELECT * FROM CompletedCourses
SELECT * FROM CompleteMentorProfile

