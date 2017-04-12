USE  ITIN20LAP
GO

CREATE TABLE furnishings(
id INT IDENTITY (1,1) NOT NULL,
description VARCHAR(50) NULL
)

CREATE TABLE roomfurnishings(
id INT IDENTITY (1,1) NOT NULL,
room_id INT NOT NULL,
furnishing_id INT NOT NULL
)

CREATE TABLE rooms(
id INT IDENTITY (1,1) NOT NULL,
facility_id INT NOT NULL,
description VARCHAR(50) NOT NULL,
price DECIMAL(6,2) NOT NULL
)

CREATE TABLE facilities(
id INT IDENTITY (1,1) NOT NULL,
facilityname VARCHAR(50) NOT NULL,
zip VARCHAR(50) NOT NULL,
city VARCHAR(50) NOT NULL,
street VARCHAR(50) NOT NULL,
number VARCHAR(50) NOT NULL
)

CREATE TABLE bookings(
id INT IDENTITY(1,1) NOT NULL,
room_id INT NOT NULL,
company_id INT NOT NULL,
startdate DATETIME NOT NULL,
enddate DATETIME NOT NULL,
price decimal NOT NULL
)

CREATE TABLE bookingdetails(
id INT IDENTITY(1,1) NOT NULL,
booking_id INT NOT NULL,
date DATETIME NOT NULL,
bill_id INT NULL,
price decimal NOT NULL,
ispaid BIT NOT NULL
)

CREATE TABLE bills(
id INT IDENTITY(1,1) NOT NULL,
date DATETIME NOT NULL,
portaluser_id INT NOT NULL
)

CREATE TABLE portalusers(
id INT IDENTITY(1,1) NOT NULL,
role_id INT NOT NULL,
company_id INT NOT NULL,
email VARCHAR(255) NOT NULL,
password VARBINARY(1000) NOT NULL,
firstname VARCHAR(50) NOT NULL,
lastname VARCHAR(50) NOT NULL,
active BIT NOT NULL
)

CREATE TABLE portalroles(
id INT IDENTITY (1,1) NOT NULL,
description	 VARCHAR(50) NOT NULL,
active BIT NOT NULL
)

CREATE TABLE contacts(
id INT IDENTITY(1,1) NOT NULL,
portaluser_id INT NOT NULL,
company_id INT NOT NULL
)

CREATE TABLE companies(
id INT IDENTITY(1,1) NOT NULL,
companyname VARCHAR(50) NOT NULL,
zip VARCHAR(50) NOT NULL,
city VARCHAR(50) NOT NULL,
street VARCHAR(50) NOT NULL,
number VARCHAR(50) NOT NULL
)

CREATE TABLE bookingreversals(
id INT IDENTITY(1,1) NOT NULL,
booking_id INT NOT NULL,
portaluser_id INT NOT NULL,
reason VARCHAR(50) NOT NULL
);


CREATE TABLE [dbo].[Log] (
    [Id] [int] IDENTITY (1, 1) NOT NULL,
    [Date] [datetime] NOT NULL,
    [Thread] [varchar] (255) NOT NULL,
    [Level] [varchar] (50) NOT NULL,
    [Logger] [varchar] (255) NOT NULL,
    [Message] [varchar] (4000) NOT NULL,
    [Exception] [varchar] (2000) NULL
)

GO