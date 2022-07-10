USE AssignmentDeltaX

/*
------------------------------
Creating MoviesActor Table for Many To Many Relation
------------------------------
*/

CREATE TABLE MOVIESACTORS(
MOVIESID INT NOT NULL FOREIGN KEY REFERENCES MOVIES(MOVIEID), 
ACTORSID INT NOT NULL FOREIGN KEY REFERENCES ACTOR(ACTORID),
PRIMARY KEY (MOVIESID,ACTORSID)
)
/*
------------------------------
Creating MoviesProducers Table for Many To One Relation
------------------------------
*/
ALTER TABLE MOVIES
ADD PRODUCERID INT NOT NULL FOREIGN KEY REFERENCES PRODUCER(PRODUCERID)

