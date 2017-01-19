ALTER TABLE Unterkunft
ADD
CONSTRAINT ck_kategorie
CHECK ( kategorie >= 0 AND kategorie <= 5 );

ALTER TABLE Bewertung
ADD
CONSTRAINT ck_wertung
CHECK ( wertung >=0 AND wertung <= 5 );