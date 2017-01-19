USE reisebuero;
GO

ALTER TABLE Buchung
ADD
CONSTRAINT FK_Buchung_Benutzer
FOREIGN KEY (benutzer_id)
REFERENCES Benutzer(id);
GO

ALTER TABLE Buchung_Zahlung
ADD
CONSTRAINT FK_Buchung_Zahlung_Zahlung
FOREIGN KEY (zahlung_id)
REFERENCES Zahlung(id);
GO

ALTER TABLE Buchung_Zahlung
ADD
CONSTRAINT FK_Buchung_Zahlung_Buchung
FOREIGN KEY (buchung_id)
REFERENCES Buchung(id);
GO

ALTER TABLE Buchung
ADD
CONSTRAINT FK_Buchung_Reisedatum
FOREIGN KEY (reisedatum_id)
REFERENCES Reisedatum(id);
GO

ALTER TABLE BuchungStorniert
ADD
CONSTRAINT FK_BuchungStorniert_Buchung
FOREIGN KEY (buchung_id)
REFERENCES Buchung(id)
GO

ALTER TABLE Adresse
ADD
CONSTRAINT FK_Adresse_Ort
FOREIGN KEY (ort_id)
REFERENCES Ort(id);
GO

ALTER TABLE Ort
ADD
CONSTRAINT FK_Ort_Land
FOREIGN KEY (land_id)
REFERENCES Land(id);
GO


ALTER TABLE Benutzer
ADD
CONSTRAINT FK_Benutzer_Land
FOREIGN KEY (land_id)
REFERENCES Land(id);
GO

ALTER TABLE Benutzer
ADD
CONSTRAINT FK_Benutzer_Adresse
FOREIGN KEY (adresse_id)
REFERENCES Adresse(id);
GO

ALTER TABLE Reise
ADD 
CONSTRAINT FK_Reise_Unterkunft
FOREIGN KEY (unterkunft_id)
REFERENCES Unterkunft(id);
GO

ALTER TABLE Reise
ADD 
CONSTRAINT FK_Reise_Ort
FOREIGN KEY (ort_id)
REFERENCES Ort(id);
GO

ALTER TABLE Reisedatum
ADD
CONSTRAINT FK_Reisedatum_Reise
FOREIGN KEY (reise_id)
REFERENCES Reise(id)
GO

ALTER TABLE Reisedurchfuehrung
ADD
CONSTRAINT FK_Reisedurchfuehrung_Reisedatum
FOREIGN KEY (reisedatum_id)
REFERENCES Reisedatum(id)
GO

ALTER TABLE Reise_Bild
ADD
CONSTRAINT FK_Reise_Bild_Reise
FOREIGN KEY (reise_id)
REFERENCES Reise(id);
GO

ALTER TABLE Reise_Bild
ADD
CONSTRAINT FK_Reise_Bild_Bild
FOREIGN KEY (bild_id)
REFERENCES Bild(id);
GO

ALTER TABLE Bewertung
ADD
CONSTRAINT FK_Bewertung_Reise
FOREIGN KEY (reise_id)
REFERENCES Reise(id);
GO

ALTER TABLE Unterkunft_Bild
ADD
CONSTRAINT FK_Unterkunft_Bild_Unterkunft
FOREIGN KEY (unterkunft_id)
REFERENCES Unterkunft(id);
GO

ALTER TABLE Unterkunft_Bild
ADD
CONSTRAINT FK_Unterkunft_Bild_Bild
FOREIGN KEY (bild_id)
REFERENCES Bild(id);
GO

ALTER TABLE Unterkunft
ADD
CONSTRAINT FK_Unterkunft_Verpflegung
FOREIGN KEY (verpflegung_id)
REFERENCES Verpflegung(id);
GO

ALTER TABLE Zahlung
ADD
CONSTRAINT FK_Zahlung_Zahlungsart
FOREIGN KEY (zahlungsart_id)
REFERENCES Zahlungsart(id);
GO


