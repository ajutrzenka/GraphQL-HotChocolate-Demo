CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;
CREATE TABLE "Aircrafts" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Aircrafts" PRIMARY KEY AUTOINCREMENT,
    "RegistrationCode" TEXT NOT NULL,
    "Name" TEXT NULL,
    "Type" TEXT NULL,
    "Manufacturer" TEXT NULL,
    "ProductionYear" INTEGER NOT NULL,
    "SeatsNumber" INTEGER NOT NULL,
    "TopSpeed" INTEGER NOT NULL,
    "StallSpeed" INTEGER NOT NULL,
    "IsServiceRequired" INTEGER NOT NULL,
    "Discriminator" TEXT NOT NULL,
    "EnginePower" REAL NULL,
    "LiftToDragRatio" INTEGER NULL,
    "OptimalSpeed" INTEGER NULL
);

CREATE TABLE "Airports" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Airports" PRIMARY KEY AUTOINCREMENT,
    "Code" TEXT NOT NULL,
    "Name" TEXT NULL
);

CREATE TABLE "Persons" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Persons" PRIMARY KEY AUTOINCREMENT,
    "FirstName" TEXT NOT NULL,
    "LastName" TEXT NOT NULL
);

CREATE TABLE "Pilots" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Pilots" PRIMARY KEY AUTOINCREMENT,
    "PersonId" INTEGER NOT NULL,
    "HasValidLicense" INTEGER NOT NULL,
    "IsStudent" INTEGER NOT NULL,
    "IsInstructor" INTEGER NOT NULL,
    "HasValidMedicalExamination" INTEGER NOT NULL,
    "HasInsurance" INTEGER NOT NULL,
    CONSTRAINT "FK_Pilots_Persons_PersonId" FOREIGN KEY ("PersonId") REFERENCES "Persons" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Flights" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Flights" PRIMARY KEY AUTOINCREMENT,
    "AircraftId" INTEGER NOT NULL,
    "FirstPilotId" INTEGER NOT NULL,
    "SecondPilotId" INTEGER NULL,
    "FlightStatus" INTEGER NOT NULL,
    "TakeOffTime" TEXT NULL,
    "LandingTime" TEXT NULL,
    "HasInstructorGroundSupervision" INTEGER NOT NULL,
    "TaskType" TEXT NOT NULL,
    CONSTRAINT "FK_Flights_Aircrafts_AircraftId" FOREIGN KEY ("AircraftId") REFERENCES "Aircrafts" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Flights_Pilots_FirstPilotId" FOREIGN KEY ("FirstPilotId") REFERENCES "Pilots" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Flights_Pilots_SecondPilotId" FOREIGN KEY ("SecondPilotId") REFERENCES "Pilots" ("Id")
);

CREATE INDEX "IX_Flights_AircraftId" ON "Flights" ("AircraftId");

CREATE INDEX "IX_Flights_FirstPilotId" ON "Flights" ("FirstPilotId");

CREATE INDEX "IX_Flights_SecondPilotId" ON "Flights" ("SecondPilotId");

CREATE INDEX "IX_Pilots_PersonId" ON "Pilots" ("PersonId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20251019231126_IntialCreate', '9.0.10');

COMMIT;

