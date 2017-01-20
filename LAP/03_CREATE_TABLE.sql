USE  ITIN20LAP
GO

CREATE TABLE furnishings(
id INT idENTITY (1,1),
description VARCHAR(50)
)

CREATE TABLE roomfurnishings(
id INT idENTITY (1,1),
room_id INT,
furnishing_id INT
)

CREATE TABLE rooms(
id INT idENTITY (1,1),
floor_id INT,
description VARCHAR(50)
)

CREATE TABLE floors(
id INT idENTITY (1,1),
facility_id INT,
description VARCHAR(50)
)

CREATE TABLE facilities(
id INT idENTITY (1,1),
facilityname VARCHAR(50),
zip VARCHAR(50),
city VARCHAR(50),
street VARCHAR(50),
number VARCHAR(50)
)

CREATE TABLE bookings(
id INT idENTITY(1,1),
room_id INT,
portaluser_id INT,
date DATETIME
)

CREATE TABLE billdetails(
id INT idENTITY(1,1),
bill_id INT,
booking_id INT
)

CREATE TABLE bills(
id INT idENTITY(1,1),
date DATETIME,
portaluser_id INT
)

CREATE TABLE portalusers(
id INT idENTITY(1,1),
role_id INT,
email VARCHAR(255),
password VARCHAR(255),
firstname VARCHAR(50),
lastname VARCHAR(50)
)

CREATE TABLE portalroles(
id INT idENTITY (1,1),
description	 VARCHAR(50)
)

CREATE TABLE contacts(
id INT idENTITY(1,1),
portaluser_id INT,
company_id INT
)

CREATE TABLE companies(
id INT idENTITY(1,1),
companyname VARCHAR(50),
zip VARCHAR(50),
city VARCHAR(50),
street VARCHAR(50),
number VARCHAR(50)
)

CREATE TABLE bookingreversals(
id INT IDENTITY(1,1),
booking_id INT,
portaluser_id INT,
reason VARCHAR(50)
);

GO