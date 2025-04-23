using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using KitchenBoss.AppData;
using KitchenBoss.AppModels;

namespace KitchenBoss.AppForms
{
    /// <summary>
    /// PKGH Форма для отображения данных в табличном виде.
    /// </summary>
    public partial class fmTableViewer : Form
    {
        private bool _isChanged = false;
        private readonly List<EmployeeViewModel> _deletedEmployees = new List<EmployeeViewModel>();
        private bool _isPositionsMode = false;
        private bool _isCustomersMode = false;
        private bool _isOrdersMode = false;
        private bool _isOrderItemsMode = false;
        private int? _customerIdForOrders = null;
        private int? _selectedOrderID = null;
        private bool _isUserControlMode = false;
        private bool _isUserControlOnlyManager = false;
        private bool _isDishesMode = false;
        private bool _isDishCategoriesMode = false;
        private bool _isIngredientsMode = false;
        private bool _isTablesMode = false;
        private int? _employeeId = null;
        private string _positionName = null;

        /// <summary>
        /// PKGH Конструктор для инициализации формы в различных режимах отображения данных.
        /// </summary>
        /// <param name="positionsMode">Нужно ли отображать данные о должностях.</param>
        /// <param name="customerMode">Нужно ли отображать данные о клиентах.</param>
        /// <param name="ordersMode">Нужно ли отображать данные о заказах.</param>
        /// <param name="customerId">Идентификатор клиента для фильтрации заказов.</param>
        /// <param name="orderId">Идентификатор заказа для отображения деталей заказа.</param>
        /// <param name="orderItemsMode">Нужно ли отображать детали заказа.</param>
        /// <param name="userControlMode">Нужно ли отображать данные для управления пользователями.</param>
        /// <param name="userControlOnlyManager">Нужно ли отображать только менеджеров при управлении пользователями.</param>
        /// <param name="dishesMode">Нужно ли отображать данные о блюдах.</param>
        /// <param name="dishCategoriesMode">Нужно ли отображать данные о категориях блюд.</param>
        /// <param name="ingredientsMode">Нужно ли отображать данные об ингредиентах.</param>
        /// <param name="tablesMode">Нужно ли отображать данные о столиках.</param>
        /// <param name="employeeId">Идентификатор сотрудника текущего пользователя.</param>
        public fmTableViewer(bool positionsMode = false, bool customerMode = false, bool ordersMode = false,
                            int? customerId = null, int? orderId = null, bool orderItemsMode = false,
                            bool userControlMode = false, bool userControlOnlyManager = false,
                            bool dishesMode = false, bool dishCategoriesMode = false, bool ingredientsMode = false,
                            bool tablesMode = false, int? employeeId = null)
        {
            InitializeComponent();

            _isPositionsMode = positionsMode;
            _isCustomersMode = customerMode;
            _isOrdersMode = ordersMode;
            _isOrderItemsMode = orderItemsMode;
            _customerIdForOrders = customerId;
            _selectedOrderID = orderId;
            _isUserControlMode = userControlMode;
            _isUserControlOnlyManager = userControlOnlyManager;
            _isDishesMode = dishesMode;
            _isDishCategoriesMode = dishCategoriesMode;
            _isIngredientsMode = ingredientsMode;
            _isTablesMode = tablesMode;

            _employeeId = employeeId;
            if (_employeeId != null)
                _positionName = GetEmployeePosition(_employeeId);

            ConfigureFormForMode();
        }

        /// <summary>
        /// PKGH Получение должности сотрудника.
        /// </summary>
        /// <param name="employeeId">Идентификатор сотрудника.</param>
        /// <returns>Строка с должностью сотрудника.</returns>
        private string GetEmployeePosition(int? employeeId)
        {
            try
            {
                using (var context = Program.context)
                {
                    var employee = context.Employees.FirstOrDefault(e => e.EmployeeID == employeeId);
                    if (employee == null)
                    {
                        return "Сотрудник не найден\nДоступ: Не определён";
                    }

                    var position = context.Positions.FirstOrDefault(p => p.PositionID == employee.PositionID);
                    string positionName = position?.PositionName ?? "Не определена";
                    return positionName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении данных сотрудника: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Ошибка";
            }
        }

        /// <summary>
        /// PKGH Настройка таблиц.
        /// </summary>

        private void SetupDataGridView()
        {
            tableViewerDgv.AutoGenerateColumns = false;
            tableViewerDgv.AllowUserToAddRows = true;

            tableViewerDgv.Columns.Clear();

            DataGridViewTextBoxColumn employeeIdColumn = new DataGridViewTextBoxColumn
            {
                Name = "EmployeeID",
                HeaderText = "ID",
                DataPropertyName = "EmployeeID",
                Visible = false
            };
            tableViewerDgv.Columns.Add(employeeIdColumn);

            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn
            {
                Name = "FullName",
                HeaderText = "ФИО",
                DataPropertyName = "FullName"
            };
            tableViewerDgv.Columns.Add(nameColumn);

            DataGridViewComboBoxColumn positionColumn = new DataGridViewComboBoxColumn
            {
                Name = "PositionID",
                HeaderText = "Должность",
                DataPropertyName = "PositionID"
            };
            tableViewerDgv.Columns.Add(positionColumn);

            DataGridViewTextBoxColumn hireDateColumn = new DataGridViewTextBoxColumn
            {
                Name = "HireDate",
                HeaderText = "Дата найма",
                DataPropertyName = "HireDate"
            };
            hireDateColumn.DefaultCellStyle.Format = "dd.MM.yyyy";
            tableViewerDgv.Columns.Add(hireDateColumn);

            DataGridViewTextBoxColumn salaryColumn = new DataGridViewTextBoxColumn
            {
                Name = "Salary",
                HeaderText = "Зарплата",
                DataPropertyName = "Salary"
            };
            salaryColumn.DefaultCellStyle.Format = "N2";
            salaryColumn.DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("ru-RU");
            tableViewerDgv.Columns.Add(salaryColumn);

            DataGridViewTextBoxColumn emailColumn = new DataGridViewTextBoxColumn
            {
                Name = "Email",
                HeaderText = "Email",
                DataPropertyName = "Email"
            };
            tableViewerDgv.Columns.Add(emailColumn);

            DataGridViewTextBoxColumn phoneColumn = new DataGridViewTextBoxColumn
            {
                Name = "PhoneNumber",
                HeaderText = "Телефон",
                DataPropertyName = "PhoneNumber"
            };
            tableViewerDgv.Columns.Add(phoneColumn);

            tableViewerDgv.AllowUserToDeleteRows = true;
        }

        private void SetupCustomersDataGridView()
        {
            tableViewerDgv.AutoGenerateColumns = false;
            tableViewerDgv.AllowUserToAddRows = true;
            tableViewerDgv.AllowUserToDeleteRows = true;
            tableViewerDgv.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            tableViewerDgv.Columns.Clear();

            DataGridViewTextBoxColumn customerIdColumn = new DataGridViewTextBoxColumn
            {
                Name = "CustomerID",
                HeaderText = "ID",
                DataPropertyName = "CustomerID",
                Visible = false,
                ReadOnly = true
            };
            tableViewerDgv.Columns.Add(customerIdColumn);

            DataGridViewTextBoxColumn firstNameColumn = new DataGridViewTextBoxColumn
            {
                Name = "FirstName",
                HeaderText = "Имя",
                DataPropertyName = "FirstName"
            };
            tableViewerDgv.Columns.Add(firstNameColumn);

            DataGridViewTextBoxColumn lastNameColumn = new DataGridViewTextBoxColumn
            {
                Name = "LastName",
                HeaderText = "Фамилия",
                DataPropertyName = "LastName"
            };
            tableViewerDgv.Columns.Add(lastNameColumn);

            DataGridViewTextBoxColumn phoneColumnCustomer = new DataGridViewTextBoxColumn
            {
                Name = "PhoneNumber",
                HeaderText = "Телефон",
                DataPropertyName = "PhoneNumber"
            };
            tableViewerDgv.Columns.Add(phoneColumnCustomer);

            DataGridViewTextBoxColumn emailColumnCustomer = new DataGridViewTextBoxColumn
            {
                Name = "Email",
                HeaderText = "Email",
                DataPropertyName = "Email"
            };
            tableViewerDgv.Columns.Add(emailColumnCustomer);

            tableViewerDgv.DefaultValuesNeeded += (sender, e) =>
            {
                e.Row.Cells["FirstName"].Value = "";
                e.Row.Cells["LastName"].Value = "";
            };
        }

        private void SetupPositionsDataGridView()
        {
            tableViewerDgv.AutoGenerateColumns = false;
            tableViewerDgv.AllowUserToAddRows = true;

            tableViewerDgv.Columns.Clear();

            DataGridViewTextBoxColumn positionIdColumn = new DataGridViewTextBoxColumn
            {
                Name = "PositionID",
                HeaderText = "ID",
                DataPropertyName = "PositionID",
                Visible = false
            };
            tableViewerDgv.Columns.Add(positionIdColumn);

            DataGridViewTextBoxColumn positionNameColumn = new DataGridViewTextBoxColumn
            {
                Name = "PositionName",
                HeaderText = "Название должности",
                DataPropertyName = "PositionName"
            };
            tableViewerDgv.Columns.Add(positionNameColumn);

            DataGridViewTextBoxColumn descriptionColumn = new DataGridViewTextBoxColumn
            {
                Name = "Description",
                HeaderText = "Описание",
                DataPropertyName = "Description"
            };
            tableViewerDgv.Columns.Add(descriptionColumn);
            tableViewerDgv.AllowUserToDeleteRows = true;
        }

        private void SetupOrdersDataGridView()
        {
            tableViewerDgv.AutoGenerateColumns = false;
            tableViewerDgv.AllowUserToAddRows = true;
            tableViewerDgv.AllowUserToDeleteRows = false;
            tableViewerDgv.Columns.Clear();

            DataGridViewComboBoxColumn customerNameColumn = new DataGridViewComboBoxColumn
            {
                Name = "CustomerID",
                HeaderText = "Клиент",
                DataPropertyName = "CustomerID",
                ValueMember = "CustomerID",
                DisplayMember = "FullName",
                DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
            };
            tableViewerDgv.Columns.Add(customerNameColumn);

            DataGridViewComboBoxColumn employeeNameColumn = new DataGridViewComboBoxColumn
            {
                Name = "EmployeeID",
                HeaderText = "Сотрудник",
                DataPropertyName = "EmployeeID",
                ValueMember = "EmployeeID",
                DisplayMember = "FullName",
                DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
            };
            tableViewerDgv.Columns.Add(employeeNameColumn);


            DataGridViewComboBoxColumn orderStatusColumn = new DataGridViewComboBoxColumn
            {
                Name = "OrderStatusID",
                HeaderText = "Статус заказа",
                DataPropertyName = "OrderStatusID",
                ValueMember = "OrderStatusID",
                DisplayMember = "StatusName"
            };
            tableViewerDgv.Columns.Add(orderStatusColumn);

            DataGridViewTextBoxColumn orderDateColumn = new DataGridViewTextBoxColumn
            {
                Name = "OrderDate",
                HeaderText = "Дата заказа",
                DataPropertyName = "OrderDate"
            };
            orderDateColumn.DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
            tableViewerDgv.Columns.Add(orderDateColumn);

            DataGridViewComboBoxColumn tableColumn = new DataGridViewComboBoxColumn
            {
                Name = "TableID",
                HeaderText = "Столик",
                DataPropertyName = "TableID",
                ValueMember = "TableID",
            };
            tableViewerDgv.Columns.Add(tableColumn);

            DataGridViewTextBoxColumn totalAmountColumn = new DataGridViewTextBoxColumn
            {
                Name = "TotalAmount",
                HeaderText = "Стоимость",
                DataPropertyName = "TotalAmount",
                ReadOnly = true,
                ToolTipText = "Рассчитывается\nавтоматически"
            };
            totalAmountColumn.DefaultCellStyle.Format = "N2";
            totalAmountColumn.DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("ru-RU");
            tableViewerDgv.Columns.Add(totalAmountColumn);

            tableViewerDgv.CellEndEdit += TableViewerDgv_CellEndEdit;

        }

        private void SetupOrderItemsDataGridView()
        {
            tableViewerDgv.AutoGenerateColumns = false;
            tableViewerDgv.AllowUserToAddRows = true;
            tableViewerDgv.AllowUserToDeleteRows = true;
            tableViewerDgv.Columns.Clear();

            DataGridViewTextBoxColumn orderItemIdColumn = new DataGridViewTextBoxColumn
            {
                Name = "OrderItemID",
                HeaderText = "OrderItem ID",
                DataPropertyName = "OrderItemID",
                Visible = false
            };
            tableViewerDgv.Columns.Add(orderItemIdColumn);

            DataGridViewTextBoxColumn orderIdColumn = new DataGridViewTextBoxColumn
            {
                Name = "OrderID",
                HeaderText = "OrderID",
                DataPropertyName = "OrderID",
                Visible = false
            };
            tableViewerDgv.Columns.Add(orderIdColumn);

            DataGridViewComboBoxColumn dishNameColumn = new DataGridViewComboBoxColumn
            {
                Name = "DishID",
                HeaderText = "Блюдо",
                DataPropertyName = "DishID",
                ValueMember = "DishID",
                DisplayMember = "DishName",
                DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
            };
            tableViewerDgv.Columns.Add(dishNameColumn);

            DataGridViewTextBoxColumn quantityColumn = new DataGridViewTextBoxColumn
            {
                Name = "Quantity",
                HeaderText = "Количество",
                DataPropertyName = "Quantity"
            };
            tableViewerDgv.Columns.Add(quantityColumn);

            DataGridViewTextBoxColumn priceColumn = new DataGridViewTextBoxColumn
            {
                Name = "Price",
                HeaderText = "Цена",
                DataPropertyName = "Price",
                ReadOnly = true,
                ToolTipText = "Рассчитывается\nавтоматически"
            };
            tableViewerDgv.Columns.Add(priceColumn);

            tableViewerDgv.CellValueChanged += TableViewerDgv_CellValueChanged_OrderItems;
            tableViewerDgv.CellEndEdit += TableViewerDgv_CellEndEdit_OrderItems;
        }

        private void SetupUserControlDataGridView(bool onlyManager)
        {
            tableViewerDgv.AutoGenerateColumns = false;
            tableViewerDgv.AllowUserToAddRows = true;
            tableViewerDgv.Columns.Clear();

            DataGridViewTextBoxColumn userIdColumn = new DataGridViewTextBoxColumn
            {
                Name = "UserID",
                HeaderText = "UserID",
                DataPropertyName = "UserID",
                Visible = false
            };
            tableViewerDgv.Columns.Add(userIdColumn);

            DataGridViewComboBoxColumn fullNameColumn = new DataGridViewComboBoxColumn
            {
                Name = "EmployeeID",
                HeaderText = "ФИО",
                DataPropertyName = "EmployeeID",
                DisplayMember = "FullName",
                ValueMember = "EmployeeID"
            };
            tableViewerDgv.Columns.Add(fullNameColumn);

            DataGridViewTextBoxColumn passwordColumn = new DataGridViewTextBoxColumn
            {
                Name = "Password",
                HeaderText = "Пароль",
                DataPropertyName = "Password"
            };
            tableViewerDgv.Columns.Add(passwordColumn);

            DataGridViewTextBoxColumn positionColumn = new DataGridViewTextBoxColumn
            {
                Name = "PositionName",
                HeaderText = "Должность",
                DataPropertyName = "PositionName",
                ReadOnly = true
            };
            tableViewerDgv.Columns.Add(positionColumn);

            using (var context = Program.context)
            {
                IQueryable<Employee> employeesQuery = context.Employees
                    .Include(e => e.Position);

                if (onlyManager)
                {
                    employeesQuery = employeesQuery.Where(e => e.Position.PositionName == "Менеджер");
                }

                var employees = employeesQuery.ToList()
                    .Select(e => new
                    {
                        EmployeeID = e.EmployeeID,
                        FullName = $"{e.FirstName} {e.LastName}",
                        PositionName = e.Position?.PositionName
                    })
                    .ToList();

                fullNameColumn.DataSource = employees;
            }

            tableViewerDgv.AllowUserToDeleteRows = true;
        }

        private void SetupDishesDataGridView()
        {
            tableViewerDgv.AutoGenerateColumns = false;
            tableViewerDgv.AllowUserToAddRows = true;
            tableViewerDgv.Columns.Clear();

            DataGridViewTextBoxColumn dishIdColumn = new DataGridViewTextBoxColumn
            {
                Name = "DishID",
                HeaderText = "ID",
                DataPropertyName = "DishID",
                Visible = false
            };
            tableViewerDgv.Columns.Add(dishIdColumn);

            DataGridViewTextBoxColumn dishNameColumn = new DataGridViewTextBoxColumn
            {
                Name = "DishName",
                HeaderText = "Название блюда",
                DataPropertyName = "DishName"
            };
            tableViewerDgv.Columns.Add(dishNameColumn);

            DataGridViewComboBoxColumn categoryColumn = new DataGridViewComboBoxColumn
            {
                Name = "CategoryID",
                HeaderText = "Категория",
                DataPropertyName = "CategoryID",
                ValueMember = "CategoryID",
                DisplayMember = "CategoryName",
                DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
                FlatStyle = FlatStyle.Flat
            };
            tableViewerDgv.Columns.Add(categoryColumn);

            DataGridViewTextBoxColumn priceColumnDish = new DataGridViewTextBoxColumn
            {
                Name = "Price",
                HeaderText = "Цена",
                DataPropertyName = "Price"
            };
            priceColumnDish.DefaultCellStyle.Format = "N2";
            priceColumnDish.DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("ru-RU");
            tableViewerDgv.Columns.Add(priceColumnDish);

            DataGridViewTextBoxColumn descriptionColumnDish = new DataGridViewTextBoxColumn
            {
                Name = "Description",
                HeaderText = "Описание",
                DataPropertyName = "Description"
            };
            tableViewerDgv.Columns.Add(descriptionColumnDish);

            tableViewerDgv.AllowUserToDeleteRows = true;
        }

        private void SetupDishCategoriesDataGridView()
        {
            tableViewerDgv.AutoGenerateColumns = false;
            tableViewerDgv.AllowUserToAddRows = true;
            tableViewerDgv.Columns.Clear();

            DataGridViewTextBoxColumn categoryIdColumn = new DataGridViewTextBoxColumn
            {
                Name = "CategoryID",
                HeaderText = "ID",
                DataPropertyName = "CategoryID",
                Visible = false
            };
            tableViewerDgv.Columns.Add(categoryIdColumn);

            DataGridViewTextBoxColumn categoryNameColumn = new DataGridViewTextBoxColumn
            {
                Name = "CategoryName",
                HeaderText = "Название категории",
                DataPropertyName = "CategoryName"
            };
            tableViewerDgv.Columns.Add(categoryNameColumn);

            tableViewerDgv.AllowUserToDeleteRows = true;
        }

        private void SetupIngredientsDataGridView()
        {
            tableViewerDgv.AutoGenerateColumns = false;
            tableViewerDgv.AllowUserToAddRows = true;
            tableViewerDgv.Columns.Clear();

            DataGridViewTextBoxColumn ingredientIdColumn = new DataGridViewTextBoxColumn
            {
                Name = "IngredientID",
                HeaderText = "ID",
                DataPropertyName = "IngredientID",
                Visible = false
            };
            tableViewerDgv.Columns.Add(ingredientIdColumn);

            DataGridViewTextBoxColumn ingredientNameColumn = new DataGridViewTextBoxColumn
            {
                Name = "IngredientName",
                HeaderText = "Название ингредиента",
                DataPropertyName = "IngredientName"
            };
            tableViewerDgv.Columns.Add(ingredientNameColumn);

            DataGridViewTextBoxColumn unitColumn = new DataGridViewTextBoxColumn
            {
                Name = "Unit",
                HeaderText = "Единица измерения",
                DataPropertyName = "Unit"
            };
            tableViewerDgv.Columns.Add(unitColumn);

            tableViewerDgv.AllowUserToDeleteRows = true;
        }

        private void SetupTablesDataGridView()
        {
            tableViewerDgv.AutoGenerateColumns = false;
            tableViewerDgv.AllowUserToAddRows = true;
            tableViewerDgv.Columns.Clear();

            DataGridViewTextBoxColumn tableIdColumn = new DataGridViewTextBoxColumn
            {
                Name = "TableID",
                HeaderText = "ID",
                DataPropertyName = "TableID",
                Visible = false
            };
            tableViewerDgv.Columns.Add(tableIdColumn);

            DataGridViewTextBoxColumn tableNumberColumn = new DataGridViewTextBoxColumn
            {
                Name = "TableNumber",
                HeaderText = "Номер столика",
                DataPropertyName = "TableNumber"
            };
            tableViewerDgv.Columns.Add(tableNumberColumn);

            DataGridViewTextBoxColumn capacityColumn = new DataGridViewTextBoxColumn
            {
                Name = "Capacity",
                HeaderText = "Вместимость",
                DataPropertyName = "Capacity"
            };
            tableViewerDgv.Columns.Add(capacityColumn);

            tableViewerDgv.AllowUserToDeleteRows = true;
        }

        /// <summary>
        /// PKGH Загрузка данных.
        /// </summary>

        private void LoadData()
        {
            using (var context = Program.context)
            {
                List<Position> positions = context.Positions.ToList();
                DataGridViewComboBoxColumn positionColumn = (DataGridViewComboBoxColumn)tableViewerDgv.Columns["PositionID"];
                if (positionColumn != null)
                {
                    positionColumn.DataSource = positions;
                    positionColumn.DisplayMember = "PositionName";
                    positionColumn.ValueMember = "PositionID";
                }

                List<EmployeeViewModel> employees = context.Employees
                    .Include(e => e.Position)
                    .ToList()
                    .Select(e => new EmployeeViewModel
                    {
                        EmployeeID = e.EmployeeID,
                        FullName = $"{e.FirstName} {e.LastName}",
                        PositionID = e.PositionID,
                        HireDate = e.HireDate,
                        Salary = e.Salary,
                        Email = e.Email,
                        PhoneNumber = e.PhoneNumber
                    }).ToList();

                tableViewerDgv.DataSource = new BindingList<EmployeeViewModel>(employees);
            }
        }

        private void LoadCustomersData()
        {
            using (var context = Program.context)
            {
                List<CustomerViewModel> customers = context.Customers
                    .ToList()
                    .Select(c => new CustomerViewModel
                    {
                        CustomerID = c.CustomerID,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        PhoneNumber = c.PhoneNumber,
                        Email = c.Email
                    }).ToList();

                tableViewerDgv.DataSource = new BindingList<CustomerViewModel>(customers);
            }
        }

        private void LoadPositionsData()
        {
            using (var context = Program.context)
            {
                List<Position> positions = context.Positions.ToList();
                tableViewerDgv.DataSource = new BindingList<Position>(positions);
            }
        }

        private void LoadOrdersData()
        {
            using (var context = Program.context)
            {
                IQueryable<Order> ordersQuery = context.Orders
                    .Include(o => o.Customer)
                    .Include(o => o.Employee)
                    .Include(o => o.OrderStatu);

                if (_customerIdForOrders.HasValue)
                {
                    ordersQuery = ordersQuery.Where(o => o.CustomerID == _customerIdForOrders.Value);
                }

                List<Order> orders = ordersQuery.ToList();

                DataGridViewComboBoxColumn customerColumn = (DataGridViewComboBoxColumn)tableViewerDgv.Columns["CustomerID"];
                if (customerColumn != null)
                {
                    var customers = context.Customers
                        .ToList()
                        .Select(c => new
                        {
                            CustomerID = c.CustomerID,
                            FullName = $"{c.FirstName} {c.LastName}"
                        }).ToList();
                    customerColumn.DataSource = customers;
                }

                DataGridViewComboBoxColumn employeeColumn = (DataGridViewComboBoxColumn)tableViewerDgv.Columns["EmployeeID"];
                if (employeeColumn != null)
                {
                    var employees = context.Employees
                        .ToList()
                        .Select(e => new
                        {
                            EmployeeID = e.EmployeeID,
                            FullName = $"{e.FirstName} {e.LastName}"
                        }).ToList();

                    employeeColumn.DataSource = employees;
                }

                DataGridViewComboBoxColumn tableColumn = (DataGridViewComboBoxColumn)tableViewerDgv.Columns["TableID"];
                if (tableColumn != null)
                {
                    var tableDisplayList = context.Tables.ToList().Select(t => new
                    {
                        TableID = t.TableID,
                        DisplayString = $"{t.TableNumber} (Мест: {t.Capacity})"
                    }).ToList();

                    tableColumn.DataSource = tableDisplayList;
                    tableColumn.DisplayMember = "DisplayString";
                    tableColumn.ValueMember = "TableID";
                }

                List<OrderViewModel> orderViewModels = orders.Select(o => new OrderViewModel
                {
                    OrderID = o.OrderID,
                    CustomerID = (int)o.CustomerID,
                    CustomerName = o.Customer != null ? $"{o.Customer.FirstName} {o.Customer.LastName}" : "N/A",
                    EmployeeID = o.EmployeeID,
                    EmployeeName = o.Employee != null ? $"{o.Employee.FirstName} {o.Employee.LastName}" : null,
                    OrderStatusID = o.OrderStatusID,
                    OrderDate = o.OrderDate,
                    TableID = (int)o.TableID,
                    TableNumber = context.Tables.Where(t => t.TableID == o.TableID).Select(t => t.TableNumber).FirstOrDefault(),
                    TotalAmount = o.TotalAmount
                }).ToList();

                tableViewerDgv.DataSource = new BindingList<OrderViewModel>(orderViewModels);

                var orderStatuses = context.OrderStatus.ToList();
                DataGridViewComboBoxColumn orderStatusColumn = (DataGridViewComboBoxColumn)tableViewerDgv.Columns["OrderStatusID"];
                if (orderStatusColumn != null)
                {
                    orderStatusColumn.DataSource = orderStatuses;
                    orderStatusColumn.DisplayMember = "StatusName";
                    orderStatusColumn.ValueMember = "OrderStatusID";
                }
            }
        }

        private void LoadOrderItemsData(int orderID)
        {
            using (var context = Program.context)
            {
                Order order = context.Orders
                                 .Include(o => o.OrderStatu)
                                 .FirstOrDefault(o => o.OrderID == orderID);

                bool isReadOnly = order?.OrderStatu?.StatusName == "Отменен" ||
                                 order?.OrderStatu?.StatusName == "Закрыт";

                List<OrderItem> orderItems = context.OrderItems
                                      .Include(oi => oi.Dish)
                                      .Where(oi => oi.OrderID == orderID)
                                      .ToList();

                List<Dish> dishList = context.Dishes.ToList();
                DataGridViewComboBoxColumn dishColumn = (DataGridViewComboBoxColumn)tableViewerDgv.Columns["DishID"];
                if (dishColumn != null)
                {
                    dishColumn.DataSource = dishList;
                }

                tableViewerDgv.DataSource = new BindingList<OrderItem>(orderItems);

                tableViewerDgv.ReadOnly = isReadOnly;
                tableViewerDgv.AllowUserToAddRows = !isReadOnly;
                tableViewerDgv.AllowUserToDeleteRows = !isReadOnly;

                foreach (DataGridViewRow row in tableViewerDgv.Rows)
                {
                    UpdatePrice(row);

                    if (isReadOnly)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            cell.ReadOnly = true;
                        }
                    }
                }

                if (isReadOnly)
                {
                    MessageBox.Show("Этот чек нельзя редактировать, так как заказ имеет статус 'Отменен' или 'Закрыт'",
                                   "Информация",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
                }
            }
        }

        private void LoadUserData(bool onlyManager)
        {
            using (var context = Program.context)
            {
                IQueryable<Employee> allEmployeesQuery = context.Employees.Include(e => e.Position);
                if (onlyManager)
                    allEmployeesQuery = allEmployeesQuery.Where(e => e.Position.PositionName == "Менеджер");

                List<Employee> allEmployees = allEmployeesQuery.ToList();

                List<User> users = context.Users.Include(u => u.Employee.Position).ToList();

                HashSet<int> usedEmployeeIDs = users.Select(u => u.EmployeeID).ToHashSet();

                var availableEmployees = allEmployees
                    .Where(e => !usedEmployeeIDs.Contains(e.EmployeeID))
                    .Select(e => new
                    {
                        e.EmployeeID,
                        FullName = $"{e.FirstName} {e.LastName}"
                    })
                    .ToList();

                var allEmployeeDisplayList = allEmployees
                    .Select(e => new
                    {
                        e.EmployeeID,
                        FullName = $"{e.FirstName} {e.LastName}"
                    })
                    .ToList();

                List<UserViewModel> userViewModels = users.Select(u => new UserViewModel
                {
                    UserID = u.UserID,
                    EmployeeID = u.EmployeeID,
                    FullName = $"{u.Employee.FirstName} {u.Employee.LastName}",
                    PositionName = u.Employee.Position?.PositionName,
                    Password = "******"
                }).ToList();

                DataGridViewComboBoxColumn employeeColumn = tableViewerDgv.Columns["EmployeeID"] as DataGridViewComboBoxColumn;
                if (employeeColumn != null)
                {
                    employeeColumn.DataSource = allEmployees
                        .Select(e => new
                        {
                            e.EmployeeID,
                            FullName = $"{e.FirstName} {e.LastName}"
                        })
                        .ToList();
                    employeeColumn.DisplayMember = "FullName";
                    employeeColumn.ValueMember = "EmployeeID";
                }

                tableViewerDgv.DataSource = new BindingList<UserViewModel>(userViewModels);
                tableViewerDgv.Refresh();
            }
        }

        private void LoadDishesData()
        {
            using (var context = Program.context)
            {
                List<DishCategory> categories = context.DishCategories.ToList();

                DataGridViewComboBoxColumn categoryColumn = (DataGridViewComboBoxColumn)tableViewerDgv.Columns["CategoryID"];

                if (categoryColumn != null)
                {
                    categoryColumn.DataSource = categories;
                    categoryColumn.DisplayMember = "CategoryName";
                    categoryColumn.ValueMember = "CategoryID";
                }

                List<DishViewModel> dishes = context.Dishes
                    .Include(d => d.DishCategory)
                    .ToList()
                    .Select(d => new DishViewModel
                    {
                        DishID = d.DishID,
                        DishName = d.DishName,
                        CategoryID = d.CategoryID,
                        Price = d.Price,
                        Description = d.Description,
                        CategoryName = d.DishCategory?.CategoryName
                    }).ToList();

                tableViewerDgv.DataSource = new BindingList<DishViewModel>(dishes);
            }
        }

        private void LoadDishCategoriesData()
        {
            using (var context = Program.context)
            {
                List<DishCategory> categories = context.DishCategories.ToList();
                tableViewerDgv.DataSource = new BindingList<DishCategory>(categories);
            }
        }

        private void LoadIngredientsData()
        {
            using (var context = Program.context)
            {
                List<Ingredient> ingredients = context.Ingredients.ToList();
                tableViewerDgv.DataSource = new BindingList<Ingredient>(ingredients);
            }
        }

        private void LoadTablesData()
        {
            using (var context = Program.context)
            {
                List<Table> tables = context.Tables.ToList();
                tableViewerDgv.DataSource = new BindingList<Table>(tables);
            }
        }

        /// <summary>
        /// PKGH Сохранение данных.
        /// </summary>

        private void SaveEmployeesData()
        {
            if (!ValidateData())
                return;

            using (var context = Program.context)
            {
                try
                {
                    foreach (DataGridViewRow row in tableViewerDgv.Rows)
                    {
                        if (row.IsNewRow) continue;

                        int employeeId = Convert.ToInt32(row.Cells["EmployeeID"].Value);
                        Employee employee = context.Employees.Find(employeeId);

                        if (employee != null)
                        {
                            string[] fullName = row.Cells["FullName"].Value.ToString().Split(' ');
                            employee.FirstName = fullName[0];
                            employee.LastName = fullName.Length > 1 ? fullName[1] : "";

                            employee.PositionID = (int)row.Cells["PositionID"].Value;


                            employee.HireDate = Convert.ToDateTime(row.Cells["HireDate"].Value);
                            employee.Salary = decimal.Parse(row.Cells["Salary"].Value?.ToString()?.Replace(" ", "") ?? "0");
                            employee.Email = row.Cells["Email"].Value?.ToString();
                            employee.PhoneNumber = row.Cells["PhoneNumber"].Value?.ToString();
                        }
                        else
                        {
                            string[] fullName = row.Cells["FullName"].Value.ToString().Split(' ');
                            object positionValue = row.Cells["PositionID"].Value;
                            int positionId = (int)positionValue;


                            Employee newEmployee = new Employee
                            {
                                FirstName = fullName[0],
                                LastName = fullName.Length > 1 ? fullName[1] : "",
                                PositionID = positionId,
                                HireDate = Convert.ToDateTime(row.Cells["HireDate"].Value),
                                Salary = decimal.Parse(row.Cells["Salary"].Value?.ToString()?.Replace(" ", "") ?? "0"),
                                Email = row.Cells["Email"].Value?.ToString(),
                                PhoneNumber = row.Cells["PhoneNumber"].Value?.ToString()
                            };

                            context.Employees.Add(newEmployee);
                        }
                    }

                    context.SaveChanges();
                    _isChanged = false;
                    saveButton.Enabled = false;

                    MessageBox.Show("Данные успешно сохранены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveCustomersData()
        {
            using (var context = Program.context)
            {
                try
                {
                    foreach (DataGridViewRow row in tableViewerDgv.Rows)
                    {
                        if (row.IsNewRow) continue;

                        int customerId = Convert.ToInt32(row.Cells["CustomerID"].Value ?? 0);
                        Customer customer = context.Customers.Find(customerId);

                        string firstName = row.Cells["FirstName"].Value?.ToString();
                        string lastName = row.Cells["LastName"].Value?.ToString();

                        if (string.IsNullOrWhiteSpace(firstName))
                        {
                            MessageBox.Show("Имя клиента не может быть пустым", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (customer != null)
                        {
                            customer.FirstName = firstName;
                            customer.LastName = lastName ?? "";
                            customer.PhoneNumber = row.Cells["PhoneNumber"].Value?.ToString();
                            customer.Email = row.Cells["Email"].Value?.ToString();
                        }
                        else
                        {
                            Customer newCustomer = new Customer
                            {
                                FirstName = firstName,
                                LastName = lastName ?? "",
                                PhoneNumber = row.Cells["PhoneNumber"].Value?.ToString(),
                                Email = row.Cells["Email"].Value?.ToString()
                            };
                            context.Customers.Add(newCustomer);
                        }
                    }

                    context.SaveChanges();
                    _isChanged = false;
                    saveButton.Enabled = false;
                    MessageBox.Show("Данные клиентов успешно сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCustomersData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении клиентов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SavePositionsData()
        {
            using (var context = Program.context)
            {
                try
                {
                    foreach (DataGridViewRow row in tableViewerDgv.Rows)
                    {
                        if (row.IsNewRow) continue;

                        int positionId = Convert.ToInt32(row.Cells["PositionID"].Value ?? 0);
                        Position position = context.Positions.Find(positionId);

                        if (position != null)
                        {
                            position.PositionName = row.Cells["PositionName"].Value?.ToString();
                            position.Description = row.Cells["Description"].Value?.ToString();
                        }
                        else
                        {
                            Position newPosition = new Position
                            {
                                PositionName = row.Cells["PositionName"].Value?.ToString(),
                                Description = row.Cells["Description"].Value?.ToString()
                            };
                            context.Positions.Add(newPosition);
                        }
                    }


                    context.SaveChanges();
                    _isChanged = false;
                    saveButton.Enabled = false;

                    MessageBox.Show("Данные о должностях успешно сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении должностей: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveOrdersData()
        {
            using (var context = Program.context)
            {
                try
                {
                    foreach (DataGridViewRow row in tableViewerDgv.Rows)
                    {
                        if (row.IsNewRow) continue;

                        OrderViewModel orderViewModel = row.DataBoundItem as OrderViewModel;

                        int? customerId = row.Cells["CustomerID"].Value as int?;
                        int? employeeId = row.Cells["EmployeeID"].Value as int?;
                        int? orderStatusId = row.Cells["OrderStatusID"].Value as int?;
                        DateTime? orderDate = row.Cells["OrderDate"].Value as DateTime?;
                        int? tableId = row.Cells["TableID"].Value as int?;
                        decimal? totalAmount = row.Cells["TotalAmount"].Value as decimal?;

                        if (orderViewModel == null)
                        {
                            Order order = new Order();
                            order.CustomerID = (int)customerId;
                            order.EmployeeID = (int)employeeId;
                            order.OrderStatusID = (int)orderStatusId;
                            order.OrderDate = (DateTime)orderDate;
                            order.TableID = (int)tableId;
                            order.TotalAmount = 0;

                            context.Orders.Add(order);
                        }
                        else
                        {

                            int orderId = orderViewModel.OrderID;
                            Order order = context.Orders.Find(orderId);

                            if (order != null)
                            {
                                if (row.Cells["OrderStatusID"].Value != null)
                                {
                                    order.OrderStatusID = (int)row.Cells["OrderStatusID"].Value;
                                }

                                if (row.Cells["TableID"].Value != null)
                                {
                                    order.TableID = (int)row.Cells["TableID"].Value;
                                }

                                order.EmployeeID = (int)row.Cells["EmployeeID"].Value;

                            }
                        }

                    }

                    context.SaveChanges();
                    _isChanged = false;
                    saveButton.Enabled = false;

                    MessageBox.Show("Данные о заказах успешно сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadOrdersData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении заказов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveOrderItemsData()
        {
            using (var context = Program.context)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        _isChanged = false;
                        saveButton.Enabled = false;

                        var order = context.Orders
                                         .Include(o => o.OrderStatu)
                                         .FirstOrDefault(o => o.OrderID == _selectedOrderID);

                        if (order?.OrderStatu?.StatusName == "Отменен" ||
                            order?.OrderStatu?.StatusName == "Закрыт")
                        {
                            MessageBox.Show("Нельзя редактировать чек для заказа со статусом 'Отменен' или 'Закрыт'",
                                          "Ошибка",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Warning);
                            return;
                        }

                        var existingItems = context.OrderItems
                                                  .Where(oi => oi.OrderID == _selectedOrderID)
                                                  .ToList();

                        var deletedItems = existingItems
                            .Where(ei => !tableViewerDgv.Rows
                                .Cast<DataGridViewRow>()
                                .Any(row => !row.IsNewRow &&
                                           Convert.ToInt32(row.Cells["OrderItemID"].Value ?? 0) == ei.OrderItemID))
                            .ToList();

                        foreach (var item in deletedItems)
                        {
                            context.OrderItems.Remove(item);
                        }

                        decimal totalAmount = 0;

                        foreach (DataGridViewRow row in tableViewerDgv.Rows)
                        {
                            if (row.IsNewRow) continue;

                            int orderItemId = Convert.ToInt32(row.Cells["OrderItemID"].Value ?? 0);
                            OrderItem orderItem;

                            if (orderItemId > 0)
                            {
                                orderItem = context.OrderItems.Find(orderItemId);
                                if (orderItem == null) continue;
                            }
                            else
                            {
                                orderItem = new OrderItem
                                {
                                    OrderID = _selectedOrderID.Value
                                };
                                context.OrderItems.Add(orderItem);
                            }

                            orderItem.DishID = (int)row.Cells["DishID"].Value;
                            orderItem.Quantity = Convert.ToInt32(row.Cells["Quantity"].Value);

                            var dish = context.Dishes.Find(orderItem.DishID);
                            if (dish != null)
                            {
                                totalAmount += dish.Price * orderItem.Quantity;
                            }
                        }

                        if (order != null)
                        {
                            order.TotalAmount = totalAmount;
                            context.Entry(order).State = EntityState.Modified;
                        }

                        context.SaveChanges();
                        transaction.Commit();

                        _isChanged = false;
                        saveButton.Enabled = false;

                        if (_isOrdersMode)
                        {
                            LoadOrdersData();
                        }
                        else
                        {
                            var ordersForm = Application.OpenForms.OfType<fmTableViewer>()
                                .FirstOrDefault(f => f._isOrdersMode);
                            ordersForm?.LoadOrdersData();
                        }

                        MessageBox.Show("Данные чека клиента успешно сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadOrderItemsData(_selectedOrderID ?? 0);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Ошибка при сохранении чека клиента: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void SaveUserData()
        {
            using (var context = Program.context)
            {
                try
                {
                    foreach (DataGridViewRow row in tableViewerDgv.Rows)
                    {
                        if (row.IsNewRow) continue;

                        int userId = row.Cells["UserID"].Value == null ? 0 : Convert.ToInt32(row.Cells["UserID"].Value);
                        int employeeId = Convert.ToInt32(row.Cells["EmployeeID"].Value);
                        string password = row.Cells["Password"].Value?.ToString();

                        User user = context.Users.FirstOrDefault(u => u.UserID == userId);

                        if (user != null)
                        {
                            if (!string.IsNullOrEmpty(password) && password != "******")
                            {
                                Guid newSalt = Guid.NewGuid();
                                string hashedPassword = HashPassword(password, newSalt.ToString());

                                user.PasswordHash = Convert.FromBase64String(hashedPassword);
                                user.PasswordSalt = newSalt;
                            }
                            user.EmployeeID = employeeId;
                        }
                        else
                        {
                            Guid newSalt = Guid.NewGuid();
                            string hashedPassword = HashPassword(password ?? "defaultpassword", newSalt.ToString());

                            User newUser = new User
                            {
                                EmployeeID = employeeId,
                                PasswordHash = Convert.FromBase64String(hashedPassword),
                                PasswordSalt = newSalt
                            };
                            context.Users.Add(newUser);
                        }
                    }

                    context.SaveChanges();
                    _isChanged = false;
                    saveButton.Enabled = false;
                    MessageBox.Show("Данные успешно сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveDishesData()
        {
            using (var context = Program.context)
            {
                try
                {
                    foreach (DataGridViewRow row in tableViewerDgv.Rows)
                    {
                        if (row.IsNewRow) continue;

                        int dishId = Convert.ToInt32(row.Cells["DishID"].Value ?? 0);
                        Dish dish = context.Dishes.Find(dishId);

                        if (dish != null)
                        {
                            dish.DishName = row.Cells["DishName"].Value?.ToString();
                            dish.CategoryID = (int)row.Cells["CategoryID"].Value;
                            dish.Price = Convert.ToDecimal(row.Cells["Price"].Value);
                            dish.Description = row.Cells["Description"].Value?.ToString();
                        }
                        else
                        {
                            Dish newDish = new Dish
                            {
                                DishName = row.Cells["DishName"].Value?.ToString(),
                                CategoryID = (int)row.Cells["CategoryID"].Value,
                                Price = Convert.ToDecimal(row.Cells["Price"].Value),
                                Description = row.Cells["Description"].Value?.ToString()
                            };
                            context.Dishes.Add(newDish);
                        }
                    }

                    context.SaveChanges();
                    _isChanged = false;
                    saveButton.Enabled = false;
                    MessageBox.Show("Данные о блюдах успешно сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении блюд: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveDishCategoriesData()
        {
            using (var context = Program.context)
            {
                try
                {
                    foreach (DataGridViewRow row in tableViewerDgv.Rows)
                    {
                        if (row.IsNewRow) continue;

                        int categoryId = Convert.ToInt32(row.Cells["CategoryID"].Value ?? 0);
                        DishCategory category = context.DishCategories.Find(categoryId);

                        if (category != null)
                        {
                            category.CategoryName = row.Cells["CategoryName"].Value?.ToString();
                        }
                        else
                        {
                            DishCategory newCategory = new DishCategory
                            {
                                CategoryName = row.Cells["CategoryName"].Value?.ToString()
                            };
                            context.DishCategories.Add(newCategory);
                        }
                    }

                    context.SaveChanges();
                    _isChanged = false;
                    saveButton.Enabled = false;
                    MessageBox.Show("Данные о категориях блюд успешно сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении категорий блюд: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveIngredientsData()
        {
            using (var context = Program.context)
            {
                try
                {
                    foreach (DataGridViewRow row in tableViewerDgv.Rows)
                    {
                        if (row.IsNewRow) continue;

                        int ingredientId = Convert.ToInt32(row.Cells["IngredientID"].Value ?? 0);
                        Ingredient ingredient = context.Ingredients.Find(ingredientId);

                        if (ingredient != null)
                        {
                            ingredient.IngredientName = row.Cells["IngredientName"].Value?.ToString();
                            ingredient.Unit = row.Cells["Unit"].Value?.ToString();
                        }
                        else
                        {
                            Ingredient newIngredient = new Ingredient
                            {
                                IngredientName = row.Cells["IngredientName"].Value?.ToString(),
                                Unit = row.Cells["Unit"].Value?.ToString()
                            };
                            context.Ingredients.Add(newIngredient);
                        }
                    }

                    context.SaveChanges();
                    _isChanged = false;
                    saveButton.Enabled = false;
                    MessageBox.Show("Данные об ингредиентах успешно сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении ингредиентов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveTablesData()
        {
            using (var context = Program.context)
            {
                try
                {
                    foreach (DataGridViewRow row in tableViewerDgv.Rows)
                    {
                        if (row.IsNewRow) continue;

                        int tableId = Convert.ToInt32(row.Cells["TableID"].Value ?? 0);
                        Table table = context.Tables.Find(tableId);

                        if (table != null)
                        {
                            table.TableNumber = Convert.ToInt32(row.Cells["TableNumber"].Value);
                            table.Capacity = Convert.ToInt32(row.Cells["Capacity"].Value);
                        }
                        else
                        {
                            Table newTable = new Table
                            {
                                TableNumber = Convert.ToInt32(row.Cells["TableNumber"].Value),
                                Capacity = Convert.ToInt32(row.Cells["Capacity"].Value)
                            };
                            context.Tables.Add(newTable);
                        }
                    }

                    context.SaveChanges();
                    _isChanged = false;
                    saveButton.Enabled = false;
                    MessageBox.Show("Данные о столиках успешно сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении столиков: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        /// <summary>
        /// PKGH Хэширует пароль с использованием SHA512 и соли.
        /// </summary>
        /// <param name="password">Пароль для хеширования.</param>
        /// <param name="salt">Соль для хеширования.</param>
        /// <returns>Хэшированный пароль в виде строки Base64.</returns>
        private string HashPassword(string password, string salt)
        {
            string passwordWithSalt = salt + password;
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(passwordWithSalt);
                byte[] hashBytes = sha512.ComputeHash(bytes);

                return Convert.ToBase64String(hashBytes);
            }
        }

        /// <summary>
        /// PKGH Проверяет данные, введенные пользователем в DataGridView.
        /// </summary>
        /// <returns>True, если данные валидны, иначе False.</returns>
        private bool ValidateData()
        {
            if (!_isUserControlMode)
            {
                foreach (DataGridViewRow row in tableViewerDgv.Rows)
                {
                    if (row.IsNewRow) continue;

                    string fullName = row.Cells["FullName"].Value?.ToString();
                    if (string.IsNullOrWhiteSpace(fullName) || fullName.Split(' ').Length != 2)
                    {
                        MessageBox.Show("В поле ФИО должно быть ровно 2 слова (Имя и Фамилия)", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    if (string.IsNullOrWhiteSpace(row.Cells["PositionID"].Value?.ToString()) ||
                        string.IsNullOrWhiteSpace(row.Cells["HireDate"].Value?.ToString()) ||
                        string.IsNullOrWhiteSpace(row.Cells["Salary"].Value?.ToString()))
                    {
                        MessageBox.Show("Первые 4 столбца не могут быть пустыми", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    if (string.IsNullOrWhiteSpace(row.Cells["Email"].Value?.ToString()) &&
                        string.IsNullOrWhiteSpace(row.Cells["PhoneNumber"].Value?.ToString()))
                    {
                        MessageBox.Show("Должен быть заполнен хотя бы один контакт (Email или Телефон)", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// PKGH Проверяет данные пользователей перед сохранением.
        /// </summary>
        /// <returns>True, если данные валидны, иначе False.</returns>
        private bool ValidateUserData()
        {
            HashSet<int> usedEmployees = new HashSet<int>();

            foreach (DataGridViewRow row in tableViewerDgv.Rows)
            {
                if (row.IsNewRow) continue;

                int employeeId = Convert.ToInt32(row.Cells["EmployeeID"].Value);

                if (usedEmployees.Contains(employeeId))
                {
                    MessageBox.Show("Сотрудник уже добавлен.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                usedEmployees.Add(employeeId);

                if (string.IsNullOrWhiteSpace(row.Cells["Password"].Value?.ToString()))
                {
                    MessageBox.Show("Пароль не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        private void tableViewerDgv_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            if (tableViewerDgv.Columns["PositionID"] is DataGridViewComboBoxColumn positionColumn && positionColumn.Items.Count > 0)
            {
                e.Row.Cells["PositionID"].Value = ((Position)positionColumn.Items[0]).PositionID;
            }
        }

        private void tableViewerDgv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (_isOrdersMode)
            {
                e.Cancel = true;
                MessageBox.Show("Удаление заказов запрещено.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_isOrderItemsMode)
            {
                _isChanged = true;
                saveButton.Enabled = true;
            }

            if (!e.Row.IsNewRow)
            {
                EmployeeViewModel employee = e.Row.DataBoundItem as EmployeeViewModel;
                if (employee != null)
                {
                    if (employee.EmployeeID > 0)
                    {
                        _deletedEmployees.Add(employee);
                        _isChanged = true;
                        saveButton.Enabled = true;
                    }
                    ((BindingList<EmployeeViewModel>)tableViewerDgv.DataSource).Remove(employee);
                }
            }
        }

        /// <summary>
        /// PKGH Обновляет цену в строке DataGridView на основе выбранного блюда и количества.
        /// </summary>
        /// <param name="row">Строка DataGridView, которую необходимо обновить.</param>
        private void UpdatePrice(DataGridViewRow row)
        {
            if (row.IsNewRow) return;

            DataGridViewCell dishIdCell = row.Cells["DishID"];
            if (dishIdCell.Value == null || !(dishIdCell.Value is int))
            {
                row.Cells["Price"].Value = 0;
                return;
            }
            int dishID = (int)dishIdCell.Value;

            DataGridViewCell quantityCell = row.Cells["Quantity"];
            if (quantityCell.Value == null || !int.TryParse(quantityCell.Value.ToString(), out int quantity))
            {
                row.Cells["Price"].Value = 0;
                return;
            }

            using (var context = Program.context)
            {
                Dish dish = context.Dishes.Find(dishID);
                if (dish != null)
                {
                    decimal price = dish.Price * quantity;
                    row.Cells["Price"].Value = price;
                }
                else
                    row.Cells["Price"].Value = 0;
            }
        }

        private void TableViewerDgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            tableViewerDgv.EndEdit();
        }

        private void tableViewerDgv_CellEndEdit_UserControl(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = tableViewerDgv.Rows[e.RowIndex];
            if (row.IsNewRow) return;

            if (tableViewerDgv.Columns[e.ColumnIndex].Name == "EmployeeID")
            {
                object selectedEmployeeId = row.Cells["EmployeeID"].Value;
                if (selectedEmployeeId != null)
                {
                    int empId = (int)selectedEmployeeId;

                    foreach (DataGridViewRow otherRow in tableViewerDgv.Rows)
                    {
                        if (otherRow == row || otherRow.IsNewRow) continue;

                        if ((int)otherRow.Cells["EmployeeID"].Value == empId)
                        {
                            MessageBox.Show("Пользователь для этого сотрудника уже существует!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            row.Cells["EmployeeID"].Value = null;
                            row.Cells["PositionName"].Value = null;

                            return;
                        }
                    }

                    using (var context = Program.context)
                    {
                        Employee employee = context.Employees
                            .Include(emp => emp.Position)
                            .FirstOrDefault(emp => emp.EmployeeID == empId);

                        if (employee != null)
                        {
                            row.Cells["PositionName"].Value = employee.Position?.PositionName;
                        }
                    }
                }
            }
        }

        private void TableViewerDgv_CellValueChanged_OrderItems(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                UpdatePrice(tableViewerDgv.Rows[e.RowIndex]);
                _isChanged = true;
                saveButton.Enabled = true;
            }
        }

        private void TableViewerDgv_CellEndEdit_OrderItems(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                UpdatePrice(tableViewerDgv.Rows[e.RowIndex]);
                _isChanged = true;
                saveButton.Enabled = true;
            }
        }

        private void tableViewerDgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception is FormatException || e.Exception is ArgumentException)
                e.Cancel = true;
        }

        private void tableViewerDgv_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tableViewerDgv.IsCurrentCellDirty && tableViewerDgv.CurrentCell is DataGridViewComboBoxCell)
            {
                tableViewerDgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
                _isChanged = true;
                saveButton.Enabled = true;
            }
        }

        private void tableViewerDgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            _isChanged = true;
            saveButton.Enabled = true;
        }

        private void tableViewerDgv_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            _isChanged = true;
            saveButton.Enabled = true;
        }

        private void positionsButton_Click(object sender, EventArgs e)
        {
            fmTableViewer positionsForm = new fmTableViewer(positionsMode: true, employeeId: _employeeId);
            positionsForm.Show();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (_isPositionsMode)
                SavePositionsData();
            else if (_isCustomersMode)
                SaveCustomersData();
            else if (_isOrdersMode)
                SaveOrdersData();
            else if (_isOrderItemsMode)
                SaveOrderItemsData();
            else if (_isUserControlMode)
            {
                if (!ValidateUserData())
                    return;
                SaveUserData();
            }
            else if (_isDishesMode)
                SaveDishesData();
            else if (_isDishCategoriesMode)
                SaveDishCategoriesData();
            else if (_isIngredientsMode)
                SaveIngredientsData();
            else if (_isTablesMode)
                SaveTablesData();
            else
                SaveEmployeesData();
        }

        private void fmTableViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isChanged)
            {
                DialogResult result = MessageBox.Show("Сохранить изменения внесённые изменения?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                    saveButton_Click(sender, e);
            }
        }

        private void clientOrderDishesButton_Click(object sender, EventArgs e)
        {
            if (_isOrdersMode)
            {
                if (tableViewerDgv.SelectedCells.Count > 0)
                {
                    int rowIndex = tableViewerDgv.SelectedCells[0].RowIndex;
                    if (rowIndex >= 0 && rowIndex < tableViewerDgv.Rows.Count)
                    {
                        DataGridViewRow selectedRow = tableViewerDgv.Rows[rowIndex];
                        if (selectedRow.DataBoundItem != null)
                        {
                            OrderViewModel order = selectedRow.DataBoundItem as OrderViewModel;
                            if (order != null)
                            {
                                fmTableViewer orderItemsForm = new fmTableViewer(customerId: order.CustomerID, orderId: order.OrderID, orderItemsMode: true, employeeId: _employeeId);
                                orderItemsForm.Show();
                            }
                            else
                                MessageBox.Show("Выбранная строка не содержит данных о заказе.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                            MessageBox.Show("Выбранная строка не содержит данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                        MessageBox.Show("Не удалось получить данные.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dishesCategoriesButton_Click(object sender, EventArgs e)
        {
            fmTableViewer dishCategoriesForm = new fmTableViewer(dishCategoriesMode: true, employeeId: _employeeId);
            dishCategoriesForm.Show();
        }

        private void dishesIngredientsButton_Click(object sender, EventArgs e)
        {
            fmTableViewer ingredientsForm = new fmTableViewer(ingredientsMode: true, employeeId: _employeeId);
            ingredientsForm.Show();
        }

        private void ConfigureFormForMode()
        {
            if (_isPositionsMode)
            {
                Text = "KitchenBoss - Должности";
                headerSubtitleLabel.Text = "Должности";
                positionsButton.Visible = false;
                clientOrderDishesButton.Visible = false;
                SetupPositionsDataGridView();
                LoadPositionsData();
                Size = new Size(497, 431);
                tableViewerDgv.Size = new Size(457, 280);
                saveButton.Location = new Point(380, 5);
                tableViewerDgv.ReadOnly = _positionName != "Менеджер";
                saveButton.Visible = _positionName == "Менеджер";
            }

            else if (_isCustomersMode)
            {
                Text = "KitchenBoss - Клиенты";
                headerSubtitleLabel.Text = "Клиенты";
                positionsButton.Visible = false;
                clientOrderDishesButton.Visible = false;
                SetupCustomersDataGridView();
                LoadCustomersData();
                tableViewerDgv.ReadOnly = _positionName == "Повар" || _positionName == "Повар-стажер";
                saveButton.Visible = _positionName != "Повар" || _positionName != "Повар-стажер";
            }
            else if (_isOrdersMode)
            {
                Text = "KitchenBoss - Заказы";
                headerSubtitleLabel.Text = "Заказы";
                positionsButton.Visible = false;
                SetupOrdersDataGridView();
                LoadOrdersData();
                Size = new Size(682, 431);
                tableViewerDgv.Size = new Size(642, 280);
                saveButton.Location = new Point(556, 5);
                clientOrderDishesButton.Location = new Point(420, 5);
                clientOrderDishesButton.Visible = true;
                tableViewerDgv.ReadOnly = _positionName == "Повар-стажер";
                saveButton.Visible = _positionName != "Повар-стажер";
            }
            else if (_isOrderItemsMode)
            {
                Text = "KitchenBoss - Позиции заказа";
                headerSubtitleLabel.Text = "Позиции заказа";
                positionsButton.Visible = false;
                clientOrderDishesButton.Visible = false;
                SetupOrderItemsDataGridView();
                if (_selectedOrderID.HasValue)
                {
                    LoadOrderItemsData(_selectedOrderID.Value);
                }
                saveButton.Enabled = true;
                Size = new Size(497, 431);
                tableViewerDgv.Size = new Size(457, 280);
                saveButton.Location = new Point(380, 5);
            }
            else if (_isUserControlOnlyManager)
            {
                Text = "KitchenBoss - Добавление менеджера";
                headerSubtitleLabel.Text = "Добавление менеджера";
                positionsButton.Visible = false;
                clientOrderDishesButton.Visible = false;
                SetupUserControlDataGridView(true);
                LoadUserData(true);
                tableViewerDgv.CellEndEdit += tableViewerDgv_CellEndEdit_UserControl;
            }
            else if (_isUserControlMode)
            {
                Text = "KitchenBoss - Управление пользователями";
                headerSubtitleLabel.Text = "Управление пользователями";
                positionsButton.Visible = false;
                clientOrderDishesButton.Visible = false;
                SetupUserControlDataGridView(false);
                LoadUserData(false);
                tableViewerDgv.CellEndEdit += tableViewerDgv_CellEndEdit_UserControl;
                tableViewerDgv.ReadOnly = _positionName != "Менеджер";
                saveButton.Visible = _positionName == "Менеджер";
            }
            else if (_isDishesMode)
            {
                Text = "KitchenBoss - Блюда";
                headerSubtitleLabel.Text = "Блюда";
                positionsButton.Visible = false;
                clientOrderDishesButton.Visible = false;
                SetupDishesDataGridView();
                LoadDishesData();
                dishesCategoriesButton.Visible = true;
                dishesCategoriesButton.Location = new Point(10, 5);
                dishesIngredientsButton.Visible = true;
                dishesIngredientsButton.Location = new Point(145, 5);
                tableViewerDgv.ReadOnly = _positionName != "Менеджер" || _positionName != "Шеф-повар";
                saveButton.Visible = _positionName == "Менеджер" || _positionName != "Шеф-повар";
            }
            else if (_isDishCategoriesMode)
            {
                Text = "KitchenBoss - Категории блюд";
                headerSubtitleLabel.Text = "Категории блюд";
                positionsButton.Visible = false;
                clientOrderDishesButton.Visible = false;
                SetupDishCategoriesDataGridView();
                LoadDishCategoriesData();
                tableViewerDgv.ReadOnly = _positionName != "Менеджер" || _positionName != "Шеф-повар";
                saveButton.Visible = _positionName == "Менеджер" || _positionName != "Шеф-повар";
            }
            else if (_isIngredientsMode)
            {
                Text = "KitchenBoss - Ингредиенты";
                headerSubtitleLabel.Text = "Ингредиенты";
                positionsButton.Visible = false;
                clientOrderDishesButton.Visible = false;
                SetupIngredientsDataGridView();
                LoadIngredientsData();
                tableViewerDgv.ReadOnly = _positionName != "Менеджер" || _positionName != "Шеф-повар";
                saveButton.Visible = _positionName == "Менеджер" || _positionName == "Шеф-повар";
            }
            else if (_isTablesMode)
            {
                Text = "KitchenBoss - Столики";
                headerSubtitleLabel.Text = "Столики";
                positionsButton.Visible = false;
                clientOrderDishesButton.Visible = false;
                dishesCategoriesButton.Visible = false;
                dishesIngredientsButton.Visible = false;
                SetupTablesDataGridView();
                LoadTablesData();
                tableViewerDgv.ReadOnly = _positionName == "Повар" || _positionName == "Повар-стажер";
                saveButton.Visible = _positionName != "Повар" || _positionName != "Повар-стажер";
            }
            else
            {
                SetupDataGridView();
                LoadData();
                Size = new Size(682, 431);
                tableViewerDgv.Size = new Size(642, 280);
                saveButton.Location = new Point(556, 5);
                tableViewerDgv.ReadOnly = _positionName != "Менеджер" || _positionName != "Шеф-повар";
                saveButton.Visible = _positionName == "Менеджер" || _positionName == "Шеф-повар";
            }
        }
    }
}