USE  ITIN20LAP
GO

ALTER TABLE furnishings
ADD
CONSTRAINT pk_furnishings
PRIMARY KEY (id)
GO
 

ALTER TABLE roomfurnishings 
ADD
CONSTRAINT pk_roomfurnishings
PRIMARY KEY (id)
GO
 

ALTER TABLE rooms 
ADD
CONSTRAINT pk_rooms
PRIMARY KEY (id)
GO
 

--ALTER TABLE floors 
--ADD
--CONSTRAINT pk_floors
--PRIMARY KEY (id)
--GO
 

ALTER TABLE facilities 
ADD
CONSTRAINT pk_facilities
PRIMARY KEY (id)
GO
 

ALTER TABLE bookings 
ADD
CONSTRAINT pk_bookings
PRIMARY KEY (id)
GO
 

ALTER TABLE bookingdetails 
ADD
CONSTRAINT pk_bookingdetails
PRIMARY KEY (id)
GO
 

ALTER TABLE bills 
ADD
CONSTRAINT pk_bills
PRIMARY KEY (id)
GO

ALTER TABLE portalusers 
ADD
CONSTRAINT pk_portalusers
PRIMARY KEY (id)
GO
 

ALTER TABLE portalroles 
ADD
CONSTRAINT pk_portalroles
PRIMARY KEY (id)
GO
 

ALTER TABLE companies 
ADD
CONSTRAINT pk_companies
PRIMARY KEY (id)
GO

ALTER TABLE bookingreversals 
ADD
CONSTRAINT pk_bookingreversals
PRIMARY KEY (id)
GO