USE  ITIN20LAP
GO

ALTER TABLE furnishings 
ADD
CONSTRAINT fk_furnishings_rooms
FOREIGN KEY (room_id)
REFERENCES rooms(id)
GO
 

--ALTER TABLE rooms 
--ADD
--CONSTRAINT fk_rooms_floors
--FOREIGN KEY (floor_id)
--REFERENCES floors(id)
--GO
 

--ALTER TABLE floors 
--ADD
--CONSTRAINT fk_floors_facilities
--FOREIGN KEY (facility_id)
--REFERENCES facilities(id)
--GO
 

ALTER TABLE bookings 
ADD
CONSTRAINT fk_bookings_rooms
FOREIGN KEY (room_id)
REFERENCES rooms(id)
GO
 

ALTER TABLE bookings 
ADD
CONSTRAINT fk_bookings_portalusers
FOREIGN KEY (portaluser_id)
REFERENCES portalusers(id)
GO
 

ALTER TABLE bookingreversals 
ADD
CONSTRAINT fk_bookingreversals_bookings
FOREIGN KEY (booking_id)
REFERENCES bookings(id)
GO

ALTER TABLE bookingreversals 
ADD
CONSTRAINT fk_bookingreversals_portalusers
FOREIGN KEY (portaluser_id)
REFERENCES portalusers(id)
GO
 

ALTER TABLE portalusers 
ADD
CONSTRAINT fk_portalusers_portalroles
FOREIGN KEY (role_id)
REFERENCES portalroles(id)
GO

ALTER TABLE portalusers 
ADD
CONSTRAINT fk_portalusers_comüpanies
FOREIGN KEY (company_id)
REFERENCES companies(id)
GO
 

ALTER TABLE contacts 
ADD
CONSTRAINT fk_contacts_portalusers
FOREIGN KEY (portaluser_id)
REFERENCES portalusers(id)
GO

ALTER TABLE contacts 
ADD
CONSTRAINT fk_contacts_companies
FOREIGN KEY (company_id)
REFERENCES companies(id)
GO

ALTER TABLE billdetails 
ADD
CONSTRAINT fk_billdetails_bills
FOREIGN KEY (bill_id)
REFERENCES bills(id)
GO

ALTER TABLE billdetails 
ADD
CONSTRAINT fk_billdetails_bookings
FOREIGN KEY (booking_id)
REFERENCES bookings(id)
GO

ALTER TABLE bills 
ADD
CONSTRAINT fk_bills_portalusers
FOREIGN KEY (portaluser_id)
REFERENCES portalusers(id)