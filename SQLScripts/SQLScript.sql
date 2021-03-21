
-- TABLES
IF EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[Categories]') AND type in (N'U'))
BEGIN
	ALTER TABLE [Products] DROP CONSTRAINT FK_PROD_CATEGORY_ID
	DROP TABLE [dbo].[Categories]
	PRINT '[dbo].[Categories] successfully dropped.'
END

GO
	BEGIN
		Create table [dbo].[Categories](
			Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
			[Name] VARCHAR(100),
			IsDeleted BIT
		);
	
		BEGIN
			INSERT INTO [dbo].[Categories] VALUES('5F2E8B2C-EB8E-419D-AA0B-D5F3DD03D672', 'Home', 0);
			INSERT INTO [dbo].[Categories] VALUES('C6DE31FF-36FE-4CFC-8802-376BD99E454E', 'Garden', 0);
			INSERT INTO [dbo].[Categories] VALUES('8779775C-9BCF-4B47-B5D6-6A5FCDC021CC', 'Electronics', 0);
			INSERT INTO [dbo].[Categories] VALUES('B5DED159-84AA-4373-B1F6-460F531FD793', 'Fitness', 0);
			INSERT INTO [dbo].[Categories] VALUES('78FC7BA7-C1C5-46E9-8D8E-E86BE2BB04AE', 'Toys', 0);
		END
	END
GO
PRINT '[dbo].[Categories] successfully created.'

------------

IF EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[Products]') AND type in (N'U'))
BEGIN
	DROP TABLE [dbo].[Products]
	PRINT '[dbo].[Products] successfully dropped.'
END

GO
	BEGIN
		Create table [dbo].[Products](
			Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
			CategoryId UNIQUEIDENTIFIER NOT NULL,
			[Name] VARCHAR(100),
			[Description] VARCHAR(200),
			SKU INT,
			Price DECIMAL(19,2),
			IsDeleted BIT
			CONSTRAINT FK_PROD_CATEGORY_ID
				FOREIGN KEY (CategoryId)
				REFERENCES [dbo].[Categories] (Id)
				ON DELETE CASCADE
		);
	
		BEGIN
			INSERT INTO [dbo].[Products] VALUES('42432058-14CB-4824-BF4D-8E766D274F50', '5F2E8B2C-EB8E-419D-AA0B-D5F3DD03D672', 'Sofa', 'Sit Comfortably', 10293, '65.99', 0);
			INSERT INTO [dbo].[Products] VALUES('ACD2FEED-0874-4FBF-B457-24103B35C066', 'C6DE31FF-36FE-4CFC-8802-376BD99E454E', 'Flower', 'Bloom', 28194, '15.99', 0);
			INSERT INTO [dbo].[Products] VALUES('33A88080-C7FE-4D70-8549-482EABB229D9', '8779775C-9BCF-4B47-B5D6-6A5FCDC021CC', 'FlatScreen TV', 'Watch in HD', 10293, '120.99', 0);
		END
	END
GO
PRINT '[dbo].[Products] successfully created.'
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

-- STORED PROCEDURES
IF EXISTS 
(
	SELECT *
	FROM sys.objects
	WHERE object_id = OBJECT_ID(N'[dbo].[spGetAllProducts]')
)
	BEGIN
		DROP PROCEDURE [dbo].[spGetAllProducts];
		PRINT '[dbo].[spGetAllProducts] successfully dropped.'
	END
GO
	CREATE PROCEDURE [dbo].[spGetAllProducts] 
	AS
	BEGIN
		SET NOCOUNT ON;

		SELECT * 
		FROM [dbo].[Products]
		Where IsDeleted = 0
	END
GO
	PRINT '[dbo].[spGetAllProducts] successfully created.'

------------

	IF EXISTS 
(
	SELECT *
	FROM sys.objects
	WHERE object_id = OBJECT_ID(N'[dbo].[spGetAllCategories]')
)
	BEGIN
		DROP PROCEDURE [dbo].[spGetAllCategories];
		PRINT '[dbo].[spGetAllCategories] successfully dropped.'
	END
GO
	CREATE PROCEDURE [dbo].[spGetAllCategories] 
	AS
	BEGIN
		SET NOCOUNT ON;

		SELECT * 
		FROM [dbo].[Categories]
		WHERE IsDeleted = 0
	END
GO
	PRINT '[dbo].[spGetAllCategories] successfully created.'

------------

	IF EXISTS 
(
	SELECT *
	FROM sys.objects
	WHERE object_id = OBJECT_ID(N'[dbo].[spGetProductsByCategoryId]')
)
	BEGIN
		DROP PROCEDURE [dbo].[spGetProductsByCategoryId];
		PRINT '[dbo].[spGetProductsByCategoryId] successfully dropped.'
	END
GO
	CREATE PROCEDURE [dbo].[spGetProductsByCategoryId] 
		@CategoryId UNIQUEIDENTIFIER
	AS
	BEGIN
		SET NOCOUNT ON;

		SELECT * 
		FROM [dbo].[Products]
		WHERE IsDeleted = 0
			AND CategoryId = @CategoryId
	END
GO
	PRINT '[dbo].[spGetProductsByCategoryId] successfully created.'