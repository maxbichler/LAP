
USE ITIN20LAP;
GO

INSERT INTO furnishings(description) VALUES('Beamer');
INSERT INTO furnishings(description) VALUES('Computer');
INSERT INTO furnishings(description) VALUES('Overhead Projektor');
INSERT INTO furnishings(description) VALUES('Schreibutensilien');
INSERT INTO furnishings(description) VALUES('Flipchart');
INSERT INTO furnishings(description) VALUES('Drucker');
GO

INSERT INTO facilities(facilityname,zip,city,street,number) VALUES('Milleniumtower','1110','Wien','Simmeringer Hauptstrasse','123');
INSERT INTO facilities(facilityname,zip,city,street,number) VALUES('BBRZ','1110','Wien','Simmeringer Hauptstrasse','123');
INSERT INTO facilities(facilityname,zip,city,street,number) VALUES('Simmering','1110','Wien','Simmeringer Hauptstrasse','123');
INSERT INTO facilities(facilityname,zip,city,street,number) VALUES('Ottakring','1110','Wien','Simmeringer Hauptstrasse','123');
INSERT INTO facilities(facilityname,zip,city,street,number) VALUES('Penzing','1110','Wien','Simmeringer Hauptstrasse','123');
Go

INSERT INTO rooms(facility_id,description, price, booked) VALUES(1,'Seminar', 100, 'false');
INSERT INTO rooms(facility_id,description, price, booked) VALUES(2,'Seminar', 100, 'false');
INSERT INTO rooms(facility_id,description, price, booked) VALUES(3,'Seminar', 100, 'false');
INSERT INTO rooms(facility_id,description, price, booked) VALUES(4,'Seminar', 100, 'false');
INSERT INTO rooms(facility_id,description, price, booked) VALUES(5,'Seminar', 100, 'false');
INSERT INTO rooms(facility_id,description, price, booked) VALUES(1,'Schulung', 200, 'false');
INSERT INTO rooms(facility_id,description, price, booked) VALUES(2,'Schulung', 200, 'false');
INSERT INTO rooms(facility_id,description, price, booked) VALUES(3,'Schulung', 200, 'false');
INSERT INTO rooms(facility_id,description, price, booked) VALUES(4,'Schulung', 200, 'false');
INSERT INTO rooms(facility_id,description, price, booked) VALUES(5,'Schulung', 200, 'false');
INSERT INTO rooms(facility_id,description, price, booked) VALUES(1,'Seminar Premium', 300, 'false');
INSERT INTO rooms(facility_id,description, price, booked) VALUES(2,'Seminar Premium', 300, 'false');
INSERT INTO rooms(facility_id,description, price, booked) VALUES(3,'Seminar Premium', 300, 'false');
INSERT INTO rooms(facility_id,description, price, booked) VALUES(4,'Seminar Premium', 300, 'false');
INSERT INTO rooms(facility_id,description, price, booked) VALUES(5,'Seminar Premium', 300, 'false');
INSERT INTO rooms(facility_id,description, price, booked) VALUES(1,'Schulung Premium', 400, 'false');
INSERT INTO rooms(facility_id,description, price, booked) VALUES(2,'Schulung Premium', 400, 'false');
INSERT INTO rooms(facility_id,description, price, booked) VALUES(3,'Schulung Premium', 400, 'false');
INSERT INTO rooms(facility_id,description, price, booked) VALUES(4,'Schulung Premium', 400, 'false');
INSERT INTO rooms(facility_id,description, price, booked) VALUES(5,'Schulung Premium', 400, 'false');
INSERT INTO rooms(facility_id,description, price, booked) VALUES(1,'Besprechungsraum', 500, 'false');
INSERT INTO rooms(facility_id,description, price, booked) VALUES(2,'Besprechungsraum', 500, 'false');
INSERT INTO rooms(facility_id,description, price, booked) VALUES(3,'Besprechungsraum', 500, 'false');
INSERT INTO rooms(facility_id,description, price, booked) VALUES(4,'Besprechungsraum', 500, 'false');
INSERT INTO rooms(facility_id,description, price, booked) VALUES(5,'Besprechungsraum', 500, 'false');
INSERT INTO rooms(facility_id,description, price, booked) VALUES(1,'Besprechungsraum Deluxe', 800, 'false');
INSERT INTO rooms(facility_id,description, price, booked) VALUES(2,'Besprechungsraum Deluxe', 800, 'false');
INSERT INTO rooms(facility_id,description, price, booked) VALUES(3,'Besprechungsraum Deluxe', 800, 'false');
INSERT INTO rooms(facility_id,description, price, booked) VALUES(4,'Besprechungsraum Deluxe', 800, 'false');
INSERT INTO rooms(facility_id,description, price, booked) VALUES(5,'Besprechungsraum Deluxe', 800, 'false');


--Seminar 1 - 5
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(1,4);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(1,5);

INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(2,4);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(2,5);

INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(3,4);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(3,5);

INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(4,4);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(4,5);

INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(5,4);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(5,5);

--Schulung 6 - 10
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(6,2);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(6,3);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(6,4);

INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(7,2);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(7,3);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(7,4);

INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(8,2);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(8,3);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(8,4);

INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(9,2);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(9,3);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(9,4);

INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(10,2);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(10,3);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(10,4);


--Seminar Premium 11 - 15
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(11,1);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(11,4);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(11,5);

INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(12,1);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(12,4);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(12,5);

INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(13,1);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(13,4);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(13,5);

INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(14,1);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(14,4);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(14,5);

INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(15,1);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(15,4);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(15,5);

--Schulung Premium 16 - 20
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(16,1);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(16,2);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(16,3);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(16,4);

INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(17,1);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(17,2);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(17,3);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(17,4);

INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(18,1);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(18,2);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(18,3);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(18,4);

INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(19,1);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(19,2);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(19,3);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(19,4);

INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(20,1);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(20,2);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(20,3);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(20,4);


--Besprechung 21 - 25
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(21,1);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(21,2);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(21,4);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(21,5);

INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(22,1);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(22,2);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(22,4);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(22,5);

INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(23,1);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(23,2);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(23,4);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(23,5);

INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(24,1);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(24,2);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(24,4);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(24,5);

INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(25,1);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(25,2);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(25,4);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(25,5);


--Besprechung Deluxe 26 - 30
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(26,1);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(26,2);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(26,3);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(26,4);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(26,5);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(26,6);

INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(27,1);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(27,2);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(27,3);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(27,4);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(27,5);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(27,6);

INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(28,1);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(28,2);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(28,3);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(28,4);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(28,5);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(28,6);

INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(29,1);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(29,2);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(29,3);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(29,4);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(29,5);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(29,6);

INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(30,1);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(30,2);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(30,3);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(30,4);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(30,5);
INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(30,6);

GO



INSERT INTO portalroles(description,active) VALUES('Admin', 'true');
INSERT INTO portalroles(description,active) VALUES('User', 'true');
INSERT INTO portalroles(description,active) VALUES('Mitarbeiter', 'false');
GO

INSERT INTO companies(companyname,zip,city,street,number) VALUES('Microsoft','1110','Wien','Simmeringer Hauptstrasse','3');
INSERT INTO companies(companyname,zip,city,street,number) VALUES('Apple','1160','Wien','Westbahnhof','22');
INSERT INTO companies(companyname,zip,city,street,number) VALUES('Blizzard','1010','Wien','Stephansplatz','11');
INSERT INTO companies(companyname,zip,city,street,number) VALUES('Ea','1030','Wien','Rennbahnweg','2');
INSERT INTO companies(companyname,zip,city,street,number) VALUES('Steam','1030','Wien','Rennbahnweg','13');
GO

INSERT INTO portalusers(role_id,company_id,email,password,firstname,lastname, active) VALUES(2,1,'dzallinger@gmx.at',HASHBYTES('SHA2_512', '123user!'),'Daniel','Zallinger', 'true');
INSERT INTO portalusers(role_id,company_id,email,password,firstname,lastname, active) VALUES(1,2,'mbichler@gmx.at',HASHBYTES('SHA2_512', '123user!'),'Max','Bichler', 'true');
INSERT INTO portalusers(role_id,company_id,email,password,firstname,lastname, active) VALUES(2,3,'edruckner@gmx.at',HASHBYTES('SHA2_512', '123user!'),'Erwin','Druckner', 'false');
INSERT INTO portalusers(role_id,company_id,email,password,firstname,lastname, active) VALUES(3,4,'pwagner@gmx.at',HASHBYTES('SHA2_512', '123user!'),'Phillip','Wagner', 'false');
INSERT INTO portalusers(role_id,company_id,email,password,firstname,lastname, active) VALUES(3,5,'bmarkovic@gmx.at',HASHBYTES('SHA2_512', '123user!'),'Bojan','Markovic', 'false');
GO

INSERT INTO bookings(room_id,portaluser_id,startdate, enddate) VALUES(1,1,'2016-01-09', '2016-30-09');
INSERT INTO bookings(room_id,portaluser_id,startdate, enddate) VALUES(2,2,'2016-13-06', '2016-01-7');
INSERT INTO bookings(room_id,portaluser_id,startdate, enddate) VALUES(3,3,'2016-20-06', '2016-01-09');
INSERT INTO bookings(room_id,portaluser_id,startdate, enddate) VALUES(4,4,'2017-01-01', '2017-01-06');
INSERT INTO bookings(room_id,portaluser_id,startdate, enddate) VALUES(5,5,'2017-13-01', '2017-16-01');
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