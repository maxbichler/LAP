USE ITIN20LAP;
GO

INSERT INTO furnishings(description) VALUES('Stuhl');
INSERT INTO furnishings(description) VALUES('Tisch');
INSERT INTO furnishings(description) VALUES('Monitor');
INSERT INTO furnishings(description) VALUES('Computer');
INSERT INTO furnishings(description) VALUES('Kasten');
GO

--INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(1,1);
--INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(2,2);
--INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(3,3);
--INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(4,4);
--INSERT INTO roomfurnishings(room_id,furnishing_id) VALUES(5,5);
--GO

--INSERT INTO rooms(floor_id,description) VALUES(1,'EntwicklerBüro');
--INSERT INTO rooms(floor_id,description) VALUES(2,'ServerRaum');
--INSERT INTO rooms(floor_id,description) VALUES(3,'TechnikerBüro');
--INSERT INTO rooms(floor_id,description) VALUES(4,'LagerRaum');
--INSERT INTO rooms(floor_id,description) VALUES(5,'Büro');
--GO

INSERT INTO rooms(description) VALUES('EntwicklerBüro');
INSERT INTO rooms(description) VALUES('ServerRaum');
INSERT INTO rooms(description) VALUES('TechnikerBüro');
INSERT INTO rooms(description) VALUES('LagerRaum');
INSERT INTO rooms(description) VALUES('Büro');
GO

--INSERT INTO floors(facility_id,description) VALUES(1,'Erdgeschoss');
--INSERT INTO floors(facility_id,description) VALUES(2,'1.Stock');
--INSERT INTO floors(facility_id,description) VALUES(3,'2.Stock');
--INSERT INTO floors(facility_id,description) VALUES(4,'3.Stock');
--INSERT INTO floors(facility_id,description) VALUES(5,'4.Stock');
--GO

INSERT INTO floors(description) VALUES('Erdgeschoss');
INSERT INTO floors(description) VALUES('1.Stock');
INSERT INTO floors(description) VALUES('2.Stock');
INSERT INTO floors(description) VALUES('3.Stock');
INSERT INTO floors(description) VALUES('4.Stock');
GO

INSERT INTO facilities(facilityname,zip,city,street,number) VALUES('crowd-o-moto','1110','Wien','Volkstheater','17');
INSERT INTO facilities(facilityname,zip,city,street,number) VALUES('pc-web','4020','Linz','Wienerstrasse','22');
INSERT INTO facilities(facilityname,zip,city,street,number) VALUES('bundesrechenzentrum','5020','Salzburg','Hinterholz','8');
INSERT INTO facilities(facilityname,zip,city,street,number) VALUES('bbrz-Vorarlberg','6700','Bregenz','Mariahilfsstrasse','2');
INSERT INTO facilities(facilityname,zip,city,street,number) VALUES('bbrz-Schärding','4975','Schärding','Linzerstrasse','1');
Go

--INSERT INTO bookingreversals(booking_id,portaluser_id,reason) VALUES(1,1,'Langweilig');
--INSERT INTO bookingreversals(booking_id,portaluser_id,reason) VALUES(2,2,'Nicht Gut');
--INSERT INTO bookingreversals(booking_id,portaluser_id,reason) VALUES(3,3,'Dum');
--INSERT INTO bookingreversals(booking_id,portaluser_id,reason) VALUES(4,4,'zu wenige Seiten');
--INSERT INTO bookingreversals(booking_id,portaluser_id,reason) VALUES(5,5,'Zu viele seiten');
--GO

INSERT INTO bookingreversals(reason) VALUES('Langweilig');
INSERT INTO bookingreversals(reason) VALUES('Nicht Gut');
INSERT INTO bookingreversals(reason) VALUES('Dum');
INSERT INTO bookingreversals(reason) VALUES('zu wenige Seiten');
INSERT INTO bookingreversals(reason) VALUES('Zu viele seiten');
GO

--INSERT INTO bookings(room_id,portaluser_id,date) VALUES(1,1,'2016-01-09');
--INSERT INTO bookings(room_id,portaluser_id,date) VALUES(2,2,'2016-13-06');
--INSERT INTO bookings(room_id,portaluser_id,date) VALUES(3,3,'2016-20-06');
--INSERT INTO bookings(room_id,portaluser_id,date) VALUES(4,4,'2017-01-01');
--INSERT INTO bookings(room_id,portaluser_id,date) VALUES(5,5,'2017-13-01');
--GO

INSERT INTO bookings(date) VALUES('2016-01-09');
INSERT INTO bookings(date) VALUES('2016-13-06');
INSERT INTO bookings(date) VALUES('2016-20-06');
INSERT INTO bookings(date) VALUES('2017-01-01');
INSERT INTO bookings(date) VALUES('2017-13-01');
GO

--INSERT INTO billdetails(bill_id,booking_id) VALUES(1,1);
--INSERT INTO billdetails(bill_id,booking_id) VALUES(2,2);
--INSERT INTO billdetails(bill_id,booking_id) VALUES(3,3);
--INSERT INTO billdetails(bill_id,booking_id) VALUES(4,4);
--INSERT INTO billdetails(bill_id,booking_id) VALUES(5,5);
--GO

--INSERT INTO bills(date,portaluser_id) VALUES('2016-08-09',1);
--INSERT INTO bills(date,portaluser_id) VALUES('2016-20-06',1);
--INSERT INTO bills(date,portaluser_id) VALUES('2016-27-06',1);
--INSERT INTO bills(date,portaluser_id) VALUES('2017-08-01',1);
--INSERT INTO bills(date,portaluser_id) VALUES('2017-20-01',1);
--Go

INSERT INTO bills(date) VALUES('2016-08-09');
INSERT INTO bills(date) VALUES('2016-20-06');
INSERT INTO bills(date) VALUES('2016-27-06');
INSERT INTO bills(date) VALUES('2017-08-01');
INSERT INTO bills(date) VALUES('2017-20-01');
Go

--INSERT INTO portalusers(role_id,email,password,firstname,lastname) VALUES(1,'dzallinger@gmx.at',HASHBYTES('SHA2_512', '123user!'),'Daniel','Zallinger');
--INSERT INTO portalusers(role_id,email,password,firstname,lastname) VALUES(1,'mbichler@gmx.at',HASHBYTES('SHA2_512', '123user!'),'Max','Bichler');
--INSERT INTO portalusers(role_id,email,password,firstname,lastname) VALUES(1,'edruckner@gmx.at',HASHBYTES('SHA2_512', '123user!'),'Erwin','Druckner');
--INSERT INTO portalusers(role_id,email,password,firstname,lastname) VALUES(1,'wwagi@gmx.at',HASHBYTES('SHA2_512', '123user!'),'Wagner','Wagi');
--INSERT INTO portalusers(role_id,email,password,firstname,lastname) VALUES(1,'bbückowich@gmx.at',HASHBYTES('SHA2_512', '123user!'),'Bojan','Bückowich');
--GO

INSERT INTO portalusers(email,password,firstname,lastname) VALUES('dzallinger@gmx.at',HASHBYTES('SHA2_512', '123user!'),'Daniel','Zallinger');
INSERT INTO portalusers(email,password,firstname,lastname) VALUES('mbichler@gmx.at',HASHBYTES('SHA2_512', '123user!'),'Max','Bichler');
INSERT INTO portalusers(email,password,firstname,lastname) VALUES('edruckner@gmx.at',HASHBYTES('SHA2_512', '123user!'),'Erwin','Druckner');
INSERT INTO portalusers(email,password,firstname,lastname) VALUES('wwagi@gmx.at',HASHBYTES('SHA2_512', '123user!'),'Wagner','Wagi');
INSERT INTO portalusers(email,password,firstname,lastname) VALUES('bbückowich@gmx.at',HASHBYTES('SHA2_512', '123user!'),'Bojan','Bückowich');
GO

INSERT INTO portalroles(description) VALUES('Admin');
INSERT INTO portalroles(description) VALUES('User');
INSERT INTO portalroles(description) VALUES('Mitarbeiter');
GO

--INSERT INTO contacts(portaluser_id,company_id) VALUES(1,1);
--INSERT INTO contacts(portaluser_id,company_id) VALUES(2,2);
--INSERT INTO contacts(portaluser_id,company_id) VALUES(3,3);
--INSERT INTO contacts(portaluser_id,company_id) VALUES(4,4);
--INSERT INTO contacts(portaluser_id,company_id) VALUES(5,5);
--GO

INSERT INTO companies(companyname,zip,city,street,number) VALUES('Microsoft','1120','Wien','Am Europl.','3');
INSERT INTO companies(companyname,zip,city,street,number) VALUES('Apple','1110','Wien','Westbahnhof','22');
INSERT INTO companies(companyname,zip,city,street,number) VALUES('Blizzard','1311','Wien','Stephansplatz','11');
INSERT INTO companies(companyname,zip,city,street,number) VALUES('Westwood','1140','Wien','Rennbahnweg','2');
INSERT INTO companies(companyname,zip,city,street,number) VALUES('Notch','1340','Wien','Rennbahnweg','13');
GO
