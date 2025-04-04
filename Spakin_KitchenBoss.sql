--CREATE DATABASE Shapkin_KitchenBoss;
--GO

USE Shapkin_KitchenBoss;
GO

CREATE TABLE Position (
    PositionID INT PRIMARY KEY IDENTITY(1,1),
    PositionName NVARCHAR(50) NOT NULL UNIQUE,
    Description NVARCHAR(255) NULL
);

CREATE TABLE Employee (
    EmployeeID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    PositionID INT NOT NULL,
    HireDate DATE NOT NULL,
    Salary DECIMAL(10, 2) NOT NULL,
    Email NVARCHAR(100),
    PhoneNumber NVARCHAR(20),
    CONSTRAINT FK_Employee_Position FOREIGN KEY (PositionID) REFERENCES Position(PositionID)
);

CREATE TABLE DishCategory (
    CategoryID INT PRIMARY KEY IDENTITY(1,1),
    CategoryName NVARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE Dish (
    DishID INT PRIMARY KEY IDENTITY(1,1),
    DishName NVARCHAR(100) NOT NULL,
    CategoryID INT NOT NULL,
    Description NVARCHAR(255),
    Price DECIMAL(10, 2) NOT NULL,
    CONSTRAINT FK_Dish_Category FOREIGN KEY (CategoryID) REFERENCES DishCategory(CategoryID)
);

CREATE TABLE Ingredient (
    IngredientID INT PRIMARY KEY IDENTITY(1,1),
    IngredientName NVARCHAR(100) NOT NULL UNIQUE,
    Unit NVARCHAR(20) NOT NULL
);

CREATE TABLE DishIngredient (
    DishID INT NOT NULL,
    IngredientID INT NOT NULL,
    Quantity DECIMAL(10, 2) NOT NULL,
    PRIMARY KEY (DishID, IngredientID),
    CONSTRAINT FK_DishIngredient_Dish FOREIGN KEY (DishID) REFERENCES Dish(DishID),
    CONSTRAINT FK_DishIngredient_Ingredient FOREIGN KEY (IngredientID) REFERENCES Ingredient(IngredientID)
);

CREATE TABLE Customer (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    PhoneNumber NVARCHAR(20),
    Email NVARCHAR(100)
);

CREATE TABLE [Table] (
    TableID INT PRIMARY KEY IDENTITY(1,1),
    TableNumber INT NOT NULL UNIQUE,
    Capacity INT NOT NULL
);

CREATE TABLE OrderStatus (
    OrderStatusID INT PRIMARY KEY IDENTITY(1,1),
    StatusName NVARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE [Order] (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT,
    TableID INT,
    EmployeeID INT NOT NULL, -- кто принял заказ
    OrderDate DATETIME NOT NULL DEFAULT GETDATE(),
    OrderStatusID INT NOT NULL,
    TotalAmount DECIMAL(10, 2) NOT NULL DEFAULT 0,
    CONSTRAINT FK_Order_Customer FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID),
    CONSTRAINT FK_Order_Table FOREIGN KEY (TableID) REFERENCES [Table](TableID),
    CONSTRAINT FK_Order_Employee FOREIGN KEY (EmployeeID) REFERENCES Employee(EmployeeID),
    CONSTRAINT FK_Order_OrderStatus FOREIGN KEY (OrderStatusID) REFERENCES OrderStatus(OrderStatusID)
);

CREATE TABLE OrderItem (
    OrderItemID INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT NOT NULL,
    DishID INT NOT NULL,
    Quantity INT NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    CONSTRAINT FK_OrderItem_Order FOREIGN KEY (OrderID) REFERENCES [Order](OrderID),
    CONSTRAINT FK_OrderItem_Dish FOREIGN KEY (DishID) REFERENCES Dish(DishID)	
);
GO


-- Автоматическое обновление TotalAmount в Order при добавлении OrderItem
CREATE TRIGGER TR_OrderItem_Insert ON OrderItem AFTER INSERT
AS
BEGIN
    UPDATE [Order]
    SET TotalAmount = (SELECT ISNULL(SUM(oi.Quantity * oi.Price), 0) FROM OrderItem oi WHERE oi.OrderID = i.OrderID)
    FROM inserted i
    WHERE [Order].OrderID = i.OrderID;
END;
GO

-- Автоматическое обновление TotalAmount в Order при удалении OrderItem
CREATE TRIGGER TR_OrderItem_Delete ON OrderItem AFTER DELETE
AS
BEGIN
    UPDATE [Order]
    SET TotalAmount = (SELECT ISNULL(SUM(oi.Quantity * oi.Price), 0) FROM OrderItem oi WHERE oi.OrderID = d.OrderID)
    FROM deleted d
    WHERE [Order].OrderID = d.OrderID;
END;
GO

-- Автоматическое обновление TotalAmount в Order при изменении OrderItem
CREATE TRIGGER TR_OrderItem_Update ON OrderItem AFTER UPDATE
AS
BEGIN
    UPDATE [Order]
    SET TotalAmount = (SELECT ISNULL(SUM(oi.Quantity * oi.Price), 0) FROM OrderItem oi WHERE oi.OrderID = i.OrderID)
    FROM inserted i
    WHERE [Order].OrderID = i.OrderID;
END;
GO


INSERT INTO Position (PositionName, Description) VALUES
(N'Повар', N'Готовит блюда'),
(N'Официант', N'Принимает и обслуживает заказы'),
(N'Менеджер', N'Управляет рестораном'),
(N'Шеф-повар', N'Руководит кухней и разрабатывает меню');

INSERT INTO OrderStatus (StatusName) VALUES
(N'Принят'),
(N'Готовится'),
(N'Готов'),
(N'Подан'),
(N'Закрыт'),
(N'Отменен');

INSERT INTO DishCategory (CategoryName) VALUES
(N'Салаты'),
(N'Супы'),
(N'Горячие блюда'),
(N'Напитки'),
(N'Закуски'),
(N'Десерты'),
(N'Блюда на гриле');

INSERT INTO Ingredient (IngredientName, Unit) VALUES
(N'Помидоры', N'кг'),
(N'Огурцы', N'кг'),
(N'Куриное филе', N'кг'),
(N'Рис', N'кг'),
(N'Говядина', N'кг'),
(N'Картофель', N'кг'),
(N'Лук', N'кг'),
(N'Морковь', N'кг'),
(N'Сыр Моцарелла', N'кг'),
(N'Салат Айсберг', N'кг'),
(N'Майонез', N'л'),
(N'Оливковое масло', N'л'),
(N'Лимонный сок', N'л'),
(N'Базилик', N'кг'),
(N'Специи для гриля', N'кг');

INSERT INTO Dish (DishName, CategoryID, Description, Price) VALUES
(N'Салат "Цезарь"', 1, N'Классический салат с курицей', 450.00),
(N'Греческий салат', 1, N'Салат из свежих овощей с фетой', 400.00),
(N'Борщ', 2, N'Традиционный украинский суп', 300.00),
(N'Куриный суп с лапшой', 2, N'Легкий и питательный суп', 250.00),
(N'Курица с рисом', 3, N'Жареное куриное филе с рисом', 550.00),
(N'Стейк из говядины', 3, N'Сочный стейк на гриле', 800.00),
(N'Картофель фри', 5, N'Классическая закуска', 200.00),
(N'Луковые кольца', 5, N'Хрустящие луковые кольца', 250.00),
(N'Шоколадный торт', 6, N'Нежный шоколадный торт', 350.00),
(N'Тирамису', 6, N'Итальянский десерт', 400.00),
(N'Чай черный', 4, N'Черный чай', 100.00),
(N'Кофе', 4, N'Ароматный кофе', 150.00),
(N'Шашлык из свинины', 7, N'Сочный шашлык на гриле', 600.00),
(N'Овощи гриль', 7, N'Ассорти из овощей, приготовленных на гриле', 450.00),
(N'Пицца Маргарита', 3, N'Простая и вкусная пицца', 500.00);

INSERT INTO DishIngredient (DishID, IngredientID, Quantity) VALUES
(1, 10, 0.2),
(1, 3, 0.3),
(1, 11, 0.1),
(2, 1, 0.2),
(2, 2, 0.2),
(2, 9, 0.1),
(3, 1, 0.1),
(3, 3, 0.2),
(3, 7, 0.1),
(3, 8, 0.1),
(4, 3, 0.3),
(4, 4, 0.2),
(5, 5, 0.2),
(5, 15, 0.05),
(6, 6, 0.3);

INSERT INTO Employee (FirstName, LastName, PositionID, HireDate, Salary, Email, PhoneNumber) VALUES
(N'Иван', N'Иванов', 1, '2022-01-15', 60000.00, 'ivan@gmail.com', '892695498321'),
(N'Петр', N'Петров', 2, '2022-03-01', 40000.00, NULL, '82166543254'),
(N'Анна', N'Сидорова', 3, '2021-11-10', 80000.00, 'anna@mail.ru', NULL),
(N'Мария', N'Кузнецова', 4, '2023-05-20', 90000.00, 'maria@yandex.ru', '89546583254'),
(N'Сергей', N'Смирнов', 2, '2023-07-01', 42000.00, 'sergey@gmail.com', '89653215874'),
(N'Ольга', N'Попова', 1, '2023-09-15', 62000.00, 'olga@mail.ru', NULL),
(N'Дмитрий', N'Васильев', 2, '2023-10-01', 45000.00, 'dmitry@gmail.com', '83219876554');

INSERT INTO Customer (FirstName, LastName, PhoneNumber, Email) VALUES
(N'Елена', N'Смирнова', '89123456789', 'elena@mail.ru'),
(N'Дмитрий', N'Козлов', '89234567890', 'dmitry@yandex.ru'),
(N'Анастасия', N'Иванова', '89345678901', 'anastasia@mail.ru'),
(N'Алексей', N'Петров', '89456789012', 'alexey@pkgh.ru'),
(N'Светлана', N'Сидорова', '89567890123', 'svetlana@pkgh.ru'),
(N'Михаил', N'Кузнецов', '89678901234', 'mikhail@gmail.com'),
(N'Наталья', N'Васильева', '89789012345', 'natalia@mail.ru');

INSERT INTO [Table] (TableNumber, Capacity) VALUES
(1, 4),
(2, 2),
(3, 6),
(4, 4),
(5, 2),
(6, 8),
(7, 4),
(8, 2),
(9, 6),
(10, 10);

INSERT INTO [Order] (CustomerID, TableID, EmployeeID, OrderStatusID) VALUES
(1, 1, 2, 1),
(2, 2, 2, 2),
(3, 3, 5, 1),
(4, 4, 5, 3),
(5, 5, 7, 1),
(6, 6, 7, 4),
(7, 7, 2, 1),
(1, 8, 5, 2),
(2, 9, 7, 5),
(3, 10, 2, 1);

INSERT INTO OrderItem (OrderID, DishID, Quantity, Price) VALUES
(1, 1, 1, 450.00),
(1, 3, 1, 300.00),
(2, 2, 2, 400.00),
(3, 5, 1, 550.00),
(3, 7, 2, 200.00),
(4, 6, 1, 800.00),
(5, 11, 2, 100.00),
(6, 10, 1, 400.00),
(7, 1, 1, 450.00),
(7, 4, 1, 250.00),
(8, 12, 2, 150.00),
(9, 9, 1, 350.00),
(10, 13, 1, 600.00),
(10, 14, 1, 450.00);
GO


CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash VARBINARY(64) NOT NULL, -- Хэш пароля
    PasswordSalt UNIQUEIDENTIFIER NOT NULL, -- Соль для пароля
    PositionID INT NOT NULL, -- ID должности (уровень доступа)
    EmployeeID INT NULL, --ID сотрудника (для связи)
    CONSTRAINT FK_Users_Position FOREIGN KEY (PositionID) REFERENCES Position(PositionID),
    CONSTRAINT FK_Users_Employee FOREIGN KEY (EmployeeID) REFERENCES Employee(EmployeeID)
);
GO

-- Функция для хэширования пароля с солью
CREATE FUNCTION HashPassword(@Password NVARCHAR(MAX), @Salt UNIQUEIDENTIFIER)
RETURNS VARBINARY(64)
AS
BEGIN
    DECLARE @PasswordWithSalt NVARCHAR(MAX) = CAST(@Salt AS NVARCHAR(36)) + @Password;
    DECLARE @HashedPassword VARBINARY(64) = HASHBYTES('SHA2_512', @PasswordWithSalt);
    RETURN @HashedPassword;
END;
GO

-- Пример использования функции HashPassword и добавления пользователя
-- 1. Создаем новую соль (генерируется один раз для каждого пользователя)
--DECLARE @NewSalt UNIQUEIDENTIFIER = NEWID();

-- 2. Хэшируем пароль с новой солью
--DECLARE @PasswordToHash NVARCHAR(MAX) = N'P@$$wOrd';
--DECLARE @HashedPassword VARBINARY(64) = dbo.HashPassword(@PasswordToHash, @NewSalt);

-- 3. Вставляем данные пользователя в таблицу Users (пример)
--INSERT INTO Users (Username, PasswordHash, PasswordSalt, PositionID)
--VALUES (N'TestUser', @HashedPassword, @NewSalt, 1);



SELECT * FROM Customer;
--SELECT * FROM Dish;
SELECT
    d.DishName,
    dc.CategoryName,
    d.Description,
    d.Price
FROM Dish d
JOIN DishCategory dc ON d.CategoryID = dc.CategoryID;
SELECT * FROM DishCategory;
--SELECT * FROM DishIngredient;
SELECT
    d.DishName,
    di.IngredientID,
    di.Quantity
FROM DishIngredient di
JOIN Dish d ON di.DishID = d.DishID;
--SELECT * FROM Employee;
SELECT
    e.FirstName,
    e.LastName,
    p.PositionName,
    e.HireDate,
    e.Salary,
    e.Email,
    e.PhoneNumber
FROM Employee e
JOIN Position p ON e.PositionID = p.PositionID;
SELECT * FROM Ingredient;
--SELECT * FROM [Order];
SELECT
    c.FirstName + ' ' + c.LastName AS CustomerName,
    e.FirstName + ' ' + e.LastName AS EmployeeName,
    os.StatusName,
    o.OrderDate,
    o.TotalAmount
FROM [Order] o
LEFT JOIN Customer c ON o.CustomerID = c.CustomerID
JOIN Employee e ON o.EmployeeID = e.EmployeeID
JOIN OrderStatus os ON o.OrderStatusID = os.OrderStatusID;
--SELECT * FROM OrderItem;
SELECT
    o.OrderID,
    d.DishName,
    oi.Quantity,
    oi.Price
FROM OrderItem oi
JOIN [Order] o ON oi.OrderID = o.OrderID
JOIN Dish d ON oi.DishID = d.DishID;
SELECT * FROM OrderStatus;
SELECT * FROM Position;
SELECT * FROM [Table];
