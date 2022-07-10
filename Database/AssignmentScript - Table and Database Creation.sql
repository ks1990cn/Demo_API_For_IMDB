DROP DATABASE AssignmentDeltaX
/*
Scripts for DeltaX Backend .Net Engineer by Tanmay Seth
*/
CREATE DATABASE AssignmentDeltaX
USE AssignmentDeltaX
/*
----------------------------------
Creating Producer table which contains producer data
----------------------------------
*/

CREATE TABLE Producer(
ProducerID INT IDENTITY(1,1) PRIMARY KEY,
ProducerName VARCHAR(max),
Bio VARCHAR(max),
DOB DATE,
Company VARCHAR(max),
Gender VARCHAR(10)
)

/*
------------------------------------
Creating Actor Table which contains Actors data
------------------------------------
*/

CREATE TABLE Actor(
ActorID INT IDENTITY(1,1) PRIMARY KEY,
ActorName VARCHAR(max),
Bio VARCHAR(max),
DOB DATE,
Company VARCHAR(max),
Gender VARCHAR(10)
)

/*
------------------------------------
Creating Movie Table which contains Movies data
------------------------------------
*/
CREATE TABLE Movies(
MovieID INT IDENTITY(1,1) PRIMARY KEY,
MovieName VARCHAR(max),
Plot VARCHAR(max),
DOR DATE,
Poster VARCHAR(max),
)

