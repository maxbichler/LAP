USE reisebuero;
GO

INSERT INTO Land(bezeichnung) VALUES('ôsterreich');
INSERT INTO Land(bezeichnung) VALUES('Deutschland');
INSERT INTO Land(bezeichnung) VALUES('Italien');
INSERT INTO Land(bezeichnung) VALUES('Schweiz');
INSERT INTO Land(bezeichnung) VALUES('Frankreich');
INSERT INTO Land(bezeichnung) VALUES('Spanien');
INSERT INTO Land(bezeichnung) VALUES('Portugal');
INSERT INTO Land(bezeichnung) VALUES('Grossbritannien');
INSERT INTO Land(bezeichnung) VALUES('Belgien');
INSERT INTO Land(bezeichnung) VALUES('Schweden');
GO


INSERT INTO Ort(land_id,bezeichnung) VALUES(1,'Wien');
INSERT INTO Ort(land_id,bezeichnung) VALUES(2,'Berlin');
INSERT INTO Ort(land_id,bezeichnung) VALUES(3,'Genua');
INSERT INTO Ort(land_id,bezeichnung) VALUES(4,'Bern');
INSERT INTO Ort(land_id,bezeichnung) VALUES(5,'Nizza');
INSERT INTO Ort(land_id,bezeichnung) VALUES(6,'Barcelona');
GO


INSERT INTO Adresse(ort_id, adressdaten)
VALUES(1, '1010 Stephansplatz 1');
INSERT INTO Adresse(ort_id, adressdaten)
VALUES(2, '23456 Domplatz 22');
INSERT INTO Adresse(ort_id, adressdaten)
VALUES(3, '31312 Via Roma 3');
INSERT INTO Adresse(ort_id, adressdaten)
VALUES(4, '1452 Schweizergarten 4');
INSERT INTO Adresse(ort_id, adressdaten)
VALUES(5, '52541 Boulevard du Paris');
GO

INSERT INTO Benutzer(email, passwort, vorname, nachname, geschlecht, adresse_id, telefon, land_id, geburtsdatum, titel, ist_Mitarbeiter)
VALUES('muster@itfox.at', HASHBYTES('SHA2_512', '123user!'), 'Max', 'Muster', 0, 1, '0043676123456', 2, '1990/1/1','Mag.',0);
INSERT INTO Benutzer(email, passwort, vorname, nachname, geschlecht, adresse_id, telefon,land_id, geburtsdatum, titel, ist_Mitarbeiter)
VALUES('marco@itfox.at', HASHBYTES('SHA2_512', '123user!'), 'Marco', 'Wurz', 0, 2, '0049743212121', 1, '1998/5/3', 'Dipl. Ing.',1);
INSERT INTO Benutzer(email, passwort, vorname, nachname, geschlecht, adresse_id, telefon, land_id, geburtsdatum, titel,ist_Mitarbeiter)
VALUES('claudia@itfox.at', HASHBYTES('SHA2_512', '123user!'), 'Claudia', 'Stiegl', 1, 3, '003256124565', 3, '1987/10/3', 'Prof.',1);
INSERT INTO Benutzer(email, passwort, vorname, nachname, geschlecht, adresse_id, telefon, land_id, geburtsdatum, titel,ist_Mitarbeiter)
VALUES('daniel@itfox.at', HASHBYTES('SHA2_512', '123user!'), 'Daniel', 'Zalli', 0, 4, '00396123456', 4, '1999/7/7', 'Mag.',0);
INSERT INTO Benutzer(email, passwort, vorname, nachname, geschlecht, adresse_id, telefon, land_id, geburtsdatum, titel,ist_Mitarbeiter)
VALUES('stefan@itfox.at', HASHBYTES('SHA2_512', '123user!'), 'Stefan', 'Groig', 0, 5, '0055236458', 3,'1960/1/5', 'Mag.',1);
GO

INSERT INTO Verpflegung(bezeichnung) VALUES('Ohne Verpflegung');
INSERT INTO Verpflegung(bezeichnung) VALUES('FrÅhstÅck');
INSERT INTO Verpflegung(bezeichnung) VALUES('Halbpension');
INSERT INTO Verpflegung(bezeichnung) VALUES('Vollpension');
INSERT INTO Verpflegung(bezeichnung) VALUES('All Inclusive');
GO

INSERT INTO Unterkunft(bezeichnung, beschreibung, kategorie, verpflegung_id)
VALUES('Hotel Arosa', 'Dieses Hotel bietet au·ergewîhnlichen Komfort', 4, 4);
INSERT INTO Unterkunft(bezeichnung, beschreibung, kategorie, verpflegung_id)
VALUES('Hotel de Croissant', 'Dieses Hotel schmeckt nach Croissants', 3, 2);
INSERT INTO Unterkunft(bezeichnung, beschreibung, kategorie, verpflegung_id)
VALUES('Pension Pomp', 'Luxus in seiner schînsten Form', 5, 5);
INSERT INTO Unterkunft(bezeichnung, beschreibung, kategorie, verpflegung_id)
VALUES('AlmhÅtte zum Sepp', 'Gute urige KÅche und Jausen', 2, 1);
INSERT INTO Unterkunft(bezeichnung, beschreibung, kategorie, verpflegung_id)
VALUES('Hotel Allin', 'Dieses Hotel bietet alles au·er Vollpension', 4, 3);
GO

INSERT INTO Reise(titel, beschreibung, unterkunft_id, preis_erwachsener, preis_kind,ort_id)
VALUES('Wandern in den Bergen', 'Erleben Sie die schîne Bergwelt in ôsterreich', 4, 65.99, 32.99,1);
INSERT INTO Reise(titel, beschreibung, unterkunft_id, preis_erwachsener, preis_kind, ort_id)
VALUES('Wellnes pur', 'Genie·en Sie italienische Luft und Wellnes vom Feinsten', 1, 150.00, 75.00,2);
INSERT INTO Reise(titel, beschreibung, unterkunft_id, preis_erwachsener, preis_kind, ort_id)
VALUES('Fu·ball pur', 'Fahren Sie zum EM-Finale nach Paris!', 2, 199.99, 99.99,3);
INSERT INTO Reise(titel, beschreibung, unterkunft_id, preis_erwachsener, preis_kind,ort_id)
VALUES('Urlaub der Creme de la Creme', 'Verbleiben Sie in einem unserer 4000 Zimmer', 3, 259.90, 129.90,4);
INSERT INTO Reise(titel, beschreibung, unterkunft_id, preis_erwachsener, preis_kind,ort_id)
VALUES('Pokern wie die Pros', 'Fahren Sie zur World Pokers Tour nach Las Vegas!', 5, 1200.00, 600.00,5);
GO

INSERT INTO Reisedatum(reise_id, startdatum, enddatum, anmeldefrist)
VALUES(1, '2016-31-07', '2016-06-08', '2016-30-06');
INSERT INTO Reisedatum(reise_id, startdatum, enddatum, anmeldefrist)
VALUES(1, '2017-20-01', '2017-30-01', '2017-01-01');
INSERT INTO Reisedatum(reise_id, startdatum, enddatum, anmeldefrist)
VALUES(2, '2016-01-12', '2016-06-12', '2016-10-11');
INSERT INTO Reisedatum(reise_id, startdatum, enddatum, anmeldefrist)
VALUES(2, '2016-04-12', '2016-05-12', '2016-04-01');
INSERT INTO Reisedatum(reise_id, startdatum, enddatum, anmeldefrist)
VALUES(3, '2016-25-07', '2016-30-07', '2016-15-06');
INSERT INTO Reisedatum(reise_id, startdatum, enddatum, anmeldefrist)
VALUES(3, '2017-25-07', '2017-30-07', '2017-15-06');
INSERT INTO Reisedatum(reise_id, startdatum, enddatum, anmeldefrist)
VALUES(4, '2017-07-01', '2017-21-01', '2016-23-12');
INSERT INTO Reisedatum(reise_id,startdatum, enddatum,anmeldefrist) 
VALUES(4,'2017-10-10','2017-11-09','2017-09-09');
INSERT INTO Reisedatum(reise_id, startdatum, enddatum, anmeldefrist)
VALUES(5, '2017-01-03', '2017-15-03', '2017-02-02');
INSERT INTO Reisedatum(reise_id,startdatum, enddatum,anmeldefrist) 
VALUES(5,'2017-10-10','2017-11-09','2017-09-09');
GO

INSERT INTO Bild (bilddaten)
SELECT BulkColumn
FROM Openrowset( 
Bulk 'C:\ITIN20AKT\Datenbank\Skripte\testimages\1_hotel_test.jpg', Single_Blob) AS import;
GO

INSERT INTO Bild(bilddaten)
SELECT BulkColumn
FROM Openrowset( 
Bulk 'C:\ITIN20AKT\Datenbank\Skripte\testimages\2_hotel_test.jpg', Single_Blob) AS import;
GO

INSERT INTO Bild (bilddaten)
SELECT BulkColumn
FROM Openrowset( 
Bulk 'C:\ITIN20AKT\Datenbank\Skripte\testimages\3_hotel_test.jpg', Single_Blob) AS import;
GO

INSERT INTO Bild (bilddaten)
SELECT BulkColumn
FROM Openrowset( 
Bulk 'C:\ITIN20AKT\Datenbank\Skripte\testimages\4_hotel_test.jpg', Single_Blob) AS import;
GO

INSERT INTO Bild (bilddaten)
SELECT BulkColumn
FROM Openrowset( 
Bulk 'C:\ITIN20AKT\Datenbank\Skripte\testimages\5_hotel_test.jpg', Single_Blob) AS import;
GO

INSERT INTO Bild (bilddaten)
SELECT BulkColumn
FROM Openrowset( 
Bulk 'C:\ITIN20AKT\Datenbank\Skripte\testimages\1_reise_test.jpg', Single_Blob) AS import;	
GO

INSERT INTO Bild (bilddaten)
SELECT BulkColumn
FROM Openrowset( 
Bulk 'C:\ITIN20AKT\Datenbank\Skripte\testimages\2_reise_test.jpg', Single_Blob) AS import;
GO

INSERT INTO Bild (bilddaten)
SELECT BulkColumn
FROM Openrowset( 
Bulk 'C:\ITIN20AKT\Datenbank\Skripte\testimages\3_reise_test.jpg', Single_Blob) AS import;
GO

INSERT INTO Bild (bilddaten)
SELECT BulkColumn
FROM Openrowset( 
Bulk 'C:\ITIN20AKT\Datenbank\Skripte\testimages\4_reise_test.jpg', Single_Blob) AS import;
GO

INSERT INTO Bild (bilddaten)
SELECT BulkColumn
FROM Openrowset( 
Bulk 'C:\ITIN20AKT\Datenbank\Skripte\testimages\5_reise_test.jpg', Single_Blob) AS import;
GO

INSERT INTO Reise_Bild (bild_id, reise_id) VALUES(1, 1);
INSERT INTO Reise_Bild (bild_id, reise_id) VALUES(2, 2);
INSERT INTO Reise_Bild (bild_id, reise_id) VALUES(3, 3);
INSERT INTO Reise_Bild (bild_id, reise_id) VALUES(4, 4);
INSERT INTO Reise_Bild (bild_id, reise_id) VALUES(5, 5);
GO

INSERT INTO Unterkunft_Bild (bild_id, unterkunft_id) VALUES(6,1);
INSERT INTO Unterkunft_Bild (bild_id, unterkunft_id) VALUES(7,2);
INSERT INTO Unterkunft_Bild (bild_id, unterkunft_id) VALUES(8,3);
INSERT INTO Unterkunft_Bild (bild_id, unterkunft_id) VALUES(9,4);
INSERT INTO Unterkunft_Bild (bild_id, unterkunft_id) VALUES(10,5);
GO

INSERT INTO Zahlungsart(bezeichnung) VALUES('Visa');
INSERT INTO Zahlungsart(bezeichnung) VALUES('öberweisung');
INSERT INTO Zahlungsart(bezeichnung) VALUES('MasterCard');
GO

INSERT INTO Zahlung(vorname, nachname, nummer, zahlungsart_id) VALUES('Max', 'Bichi','1568744958',1);
INSERT INTO Zahlung(vorname, nachname, nummer, zahlungsart_id) VALUES('Michi', 'Lehnchen','1567774958',2);
INSERT INTO Zahlung(vorname, nachname, nummer, zahlungsart_id) VALUES('Steffi', 'Gindl','177744555445',3);
GO

INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(1);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(1);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(1);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(1);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(1);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(2);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(2);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(2);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(2);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(2);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(3);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(3);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(3);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(3);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(3);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(4);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(4);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(4);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(4);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(4);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(5);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(5);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(5);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(5);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(5);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(6);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(6);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(6);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(6);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(6);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(7);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(7);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(7);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(7);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(7);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(8);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(8);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(8);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(8);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(8);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(9);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(9);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(9);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(9);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(9);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(10);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(10);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(10);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(10);
INSERT INTO Reisedurchfuehrung(reisedatum_id) VALUES(10);
GO

INSERT INTO Buchung(vorname, nachname, geburtsdatum, reisedatum_id,benutzer_id,passnummer) 
VALUES('Hubert', 'Meier', '1960-12-12',1, 1,'AB12345670');
INSERT INTO Buchung(vorname, nachname, geburtsdatum,reisedatum_id,benutzer_id,passnummer)
VALUES('Karl', 'Huber', '1980-10-4',2, 2,'56484651GHD');
INSERT INTO Buchung(vorname, nachname, geburtsdatum,reisedatum_id,benutzer_id,passnummer) 
VALUES('Maria', 'Huber','1950-04-12',3, 3,'KHGKFKU265456');
GO

INSERT INTO Buchung_Zahlung(buchung_id, zahlung_id) VALUES(1,3);
INSERT INTO Buchung_Zahlung(buchung_id, zahlung_id) VALUES(2,2);
INSERT INTO Buchung_Zahlung(buchung_id, zahlung_id) VALUES(3,1);
GO

INSERT INTO Bewertung(wertung, reise_id) VALUES(5,1);
INSERT INTO Bewertung(wertung, reise_id) VALUES(3,2);
INSERT INTO Bewertung(wertung, reise_id) VALUES(4,3);
GO

INSERT INTO BuchungStorniert(buchung_id) VALUES(1);
GO

