CREATE TABLE EXAMPLE(
	ID VARCHAR(20)
);

CREATE TABLE Users(
	Id INT NOT NULL PRIMARY KEY,
	Title VARCHAR(60),
	FirstName VARCHAR(60),
	MiddleName VARCHAR(60),
	LastName VARCHAR(60),
	Suffix VARCHAR(60),
	AddressLine1 VARCHAR(60),
	AddressLine2 VARCHAR(60),
	City VARCHAR(60),
	StateProvinceName VARCHAR(60),
	CountryRegionName VARCHAR(60),
	PostalCode VARCHAR(60),
	PhoneNumber VARCHAR(60),
	BirthDate DATE,
	Education VARCHAR(60),
	Occupation VARCHAR(60),
	Gender VARCHAR(5),
	MaritalStatus VARCHAR(5),
	HomeOwnerFlag INT,
	NumberCarsOwned INT,
	NumberChildrenAtHome INT,
	TotalChildren INT,
	YearlyIncome INT
);

Delete from Users Where 1=1;

select count(*) from Users;