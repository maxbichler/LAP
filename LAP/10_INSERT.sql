
USE ITIN20LAP;
GO

INSERT INTO furnishings(description) VALUES('Stuhl');
INSERT INTO furnishings(description) VALUES('Tisch');
INSERT INTO furnishings(description) VALUES('Monitor');
INSERT INTO furnishings(description) VALUES('Computer');
INSERT INTO furnishings(description) VALUES('Kasten');
GO

INSERT INTO facilities(facilityname,zip,city,street,number) VALUES('Milleniumtower','1110','Wien','Simmeringer Hauptstrasse','123');
INSERT INTO facilities(facilityname,zip,city,street,number) VALUES('BBRZ','1110','Wien','Simmeringer Hauptstrasse','123');
INSERT INTO facilities(facilityname,zip,city,street,number) VALUES('Simmering','1110','Wien','Simmeringer Hauptstrasse','123');
INSERT INTO facilities(facilityname,zip,city,street,number) VALUES('Ottakring','1110','Wien','Simmeringer Hauptstrasse','123');
INSERT INTO facilities(facilityname,zip,city,street,number) VALUES('Penzing','1110','Wien','Simmeringer Hauptstrasse','123');
Go

INSERT INTO rooms(facility_id,description, price) VALUES(1,'Seminar', 100.99);
INSERT INTO rooms(facility_id,description, price) VALUES(2,'Schulung', 200.99);
INSERT INTO rooms(facility_id,description, price) VALUES(3,'Seminar Premium', 300.99);
INSERT INTO rooms(facility_id,description, price) VALUES(4,'Schulung Premium', 400.99);
INSERT INTO rooms(facility_id,description, price) VALUES(5,'Besprechungsraum', 500.99);
GO

--1 Roomfurnishings id 1-5 per 5 rooms
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(1,1);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(1,2);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(1,3);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(1,4);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(1,5);
--2
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(2,1);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(2,2);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(2,3);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(2,4);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(2,5);
--3
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(3,1);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(3,2);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(3,3);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(3,4);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(3,5);
--4
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(4,1);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(4,2);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(4,3);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(4,4);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(4,5);
--5
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(5,1);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(5,2);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(5,3);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(5,4);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(5,5);
GO

INSERT INTO portalroles(description,active) VALUES('Admin', 'true');
INSERT INTO portalroles(description,active) VALUES('User', 'true');
INSERT INTO portalroles(description,active) VALUES('Mitarbeiter', 'false');
GO

INSERT INTO companies(companyname,zip,city,street,number) VALUES('Microsoft','1120','Wien','Am Europl.','3');
INSERT INTO companies(companyname,zip,city,street,number) VALUES('Apple','1110','Wien','Westbahnhof','22');
INSERT INTO companies(companyname,zip,city,street,number) VALUES('Blizzard','1311','Wien','Stephansplatz','11');
INSERT INTO companies(companyname,zip,city,street,number) VALUES('Westwood','1140','Wien','Rennbahnweg','2');
INSERT INTO companies(companyname,zip,city,street,number) VALUES('Notch','1340','Wien','Rennbahnweg','13');
GO

INSERT INTO portalusers(role_id,company_id,email,password,firstname,lastname, active) VALUES(2,1,'dzallinger@gmx.at',HASHBYTES('SHA2_512', '123user!'),'Daniel','Zallinger', 'true');
INSERT INTO portalusers(role_id,company_id,email,password,firstname,lastname, active) VALUES(1,2,'mbichler@gmx.at',HASHBYTES('SHA2_512', '123user!'),'Max','Bichler', 'true');
INSERT INTO portalusers(role_id,company_id,email,password,firstname,lastname, active) VALUES(2,3,'edruckner@gmx.at',HASHBYTES('SHA2_512', '123user!'),'Erwin','Druckner', 'false');
INSERT INTO portalusers(role_id,company_id,email,password,firstname,lastname, active) VALUES(3,4,'pwagner@gmx.at',HASHBYTES('SHA2_512', '123user!'),'Phillip','Wagner', 'false');
INSERT INTO portalusers(role_id,company_id,email,password,firstname,lastname, active) VALUES(3,5,'bmarkovic@gmx.at',HASHBYTES('SHA2_512', '123user!'),'Bojan','Markovic', 'false');
GO

INSERT INTO bookings(room_id,portaluser_id,date) VALUES(1,1,'2016-01-09');
INSERT INTO bookings(room_id,portaluser_id,date) VALUES(2,2,'2016-13-06');
INSERT INTO bookings(room_id,portaluser_id,date) VALUES(3,3,'2016-20-06');
INSERT INTO bookings(room_id,portaluser_id,date) VALUES(4,4,'2017-01-01');
INSERT INTO bookings(room_id,portaluser_id,date) VALUES(5,5,'2017-13-01');
GO

INSERT INTO bills(date,portaluser_id) VALUES('2016-08-09',1);
INSERT INTO bills(date,portaluser_id) VALUES('2016-20-06',1);
INSERT INTO bills(date,portaluser_id) VALUES('2016-27-06',1);
INSERT INTO bills(date,portaluser_id) VALUES('2017-08-01',1);
INSERT INTO bills(date,portaluser_id) VALUES('2017-20-01',1);
Go

INSERT INTO billdetails(bill_id,date,booking_id) VALUES(1,'2016-08-01',1);
INSERT INTO billdetails(bill_id,date,booking_id) VALUES(2,'2016-20-06',2);
INSERT INTO billdetails(bill_id,date,booking_id) VALUES(3,'2016-27-06',3);
INSERT INTO billdetails(bill_id,date,booking_id) VALUES(4,'2017-08-01',4);
INSERT INTO billdetails(bill_id,date,booking_id) VALUES(5,'2017-20-01',5);
GO

INSERT INTO contacts(portaluser_id,company_id) VALUES(1,1);
INSERT INTO contacts(portaluser_id,company_id) VALUES(2,2);
INSERT INTO contacts(portaluser_id,company_id) VALUES(3,3);
INSERT INTO contacts(portaluser_id,company_id) VALUES(4,4);
INSERT INTO contacts(portaluser_id,company_id) VALUES(5,5);
GO

INSERT INTO bookingreversals(booking_id,portaluser_id,reason) VALUES(1,1,'Fehlbuchung');
INSERT INTO bookingreversals(booking_id,portaluser_id,reason) VALUES(2,2,'Systemfehler');
INSERT INTO bookingreversals(booking_id,portaluser_id,reason) VALUES(3,3,'User verschulden Fehlbuchung');
INSERT INTO bookingreversals(booking_id,portaluser_id,reason) VALUES(4,4,'Mitarbeiter verschulden Fehlbuchung');
INSERT INTO bookingreversals(booking_id,portaluser_id,reason) VALUES(5,5,'Insert Reason');
GO