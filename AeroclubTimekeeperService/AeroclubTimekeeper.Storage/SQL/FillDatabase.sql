INSERT INTO "Aircrafts" 
(RegistrationCode, Name, Type, Manufacturer, ProductionYear, SeatsNumber, TopSpeed, StallSpeed, IsServiceRequired, Discriminator, EnginePower, LiftToDragRatio, OptimalSpeed) 
VALUES
('SP-KBK', 'Cessna 172', 'Awionetka', 'Cessna', 2000, 4, 302, 87, 0, 'Aeroplane', 160.0, NULL, NULL),
('SP-3550', 'PZL KR-03 Puchatek', 'Szybowiec dwumiejscowy', 'WSK Krosno', 1985, 2, 200, 65, 0, 'Glider', NULL, 27, 85),
('SP-4143', 'SZD-51 Junior', 'Szybowiec jednomiejscowy', 'Allstar PZL Glider', 1980, 1, 220, 55, 0, 'Glider', NULL, 35, 80),
('SP-2342', 'Grob G103 Twin Astir', 'Szybowiec dwumiejscowy', 'Grob Aircraft', 1995, 2, 250, 70, 1, 'Glider', NULL, 38, 90);

INSERT INTO "Airports" (Code, Name) VALUES
('EPPR', 'Pruszcz Gdanski Airport'),
('EPGD', 'Gdansk Lech Walesa Airport');

INSERT INTO "Pilots" (FirstName, LastName, BirthDate, Email, HasValidLicense, IsStudent, IsInstructor, HasValidMedicalExamination, HasInsurance) VALUES
('Artur', 'Jutrzenka-Trzebiatowski', '1986-06-19', 'artur.jutrzenka@example.com', 0, 1, 0, 1, 1),
('Sophia', 'Anderson', '1991-09-30', 'sophia.anderson@example.com', 1, 0, 1, 1, 1),
('Olivia', 'Wilson', '1992-04-18', 'olivia.wilson@example.com', 0, 1, 0, 0, 0),
('James', 'Thomas', '1970-09-30', 'james.thomas@example.com', 1, 0, 0, 1, 0),
('Ava', 'Jackson', '1989-12-05', 'ava.jackson@example.com', 1, 0, 0, 1, 1);

INSERT INTO "CurrentWeathers" (AirportId, TemperatureC, WindDirection, WindSpeedKnots)
SELECT Id, 20, 15, 2
FROM "Airports"
WHERE Code = 'EPPR';

INSERT INTO "CurrentWeathers" (AirportId, TemperatureC, WindDirection, WindSpeedKnots)
SELECT Id, 15, 0, 4
FROM "Airports"
WHERE Code = 'EPGD';

INSERT INTO "Flights" (
    StartAirportId,
    EndAirportId,
    FlightStatus,
    TakeOffTime,
    LandingTime,
    AircraftId,
    FirstPilotId,
    SecondPilotId,
    HasInstructorGroundSupervision,
    TaskType)
VALUES
(1, 2, 2, '2025-09-20 08:00:00', '2025-09-20 15:00:00', 1, 2, 3, 0, 'PPL-I/3'),
(1, 1, 2, '2025-09-21 09:30:00', '2025-09-21 10:30:00', 2, 1, 2, 0, 'SPL-I/VI'),
(1, 1, 2, '2025-09-22 09:30:00', '2025-09-22 10:00:00', 3, 1, 2, 0, 'SPL-IV/1'),
(1, 1, 2, '2025-09-23 10:45:00', '2025-09-23 11:15:00', 2, 5, 2, 0, 'SPL-V/1'),
(1, 1, 1, '2025-10-20 09:30:00', NULL, 3, 4, 2, 0, 'SPL-VI/1'),
(2, 1, 0, NULL, NULL, 3, 1, NULL, 1, 'SPL-IV/1'),
(1, 1, 0, NULL, NULL, 2, 2, 1, 0, 'SPL-I/3');
