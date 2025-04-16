using KitchenBoss.AppModels;
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

namespace KitchenBoss.AppForms
{
    /// <summary>
    /// TODO: Подогнать под требования
    /// TODO: Написать summary-комментарии
    /// TODO: Сделать таблицу Клиентов редактируемой
    /// </summary>
    public partial class fmTableViewer : Form
    {
        private bool isChanged = false;
        private readonly List<EmployeeViewModel> deletedEmployees = new List<EmployeeViewModel>();
        private bool isPositionsMode = false;
        private bool isCustomersMode = false;
        private bool isOrdersMode = false;
        private bool isOrderItemsMode = false;
        private int? customerIdForOrders = null;
        private int? selectedOrderID = null;
        private bool isUserControlMode = false;

        public fmTableViewer()
        {
            InitializeComponent();
            SetupDataGridView();
            LoadData();
        }

        public fmTableViewer(bool positionsMode = false, bool customerMode = false, bool ordersMode = false, int? customerId = null, int? orderId = null, bool orderItemsMode = false, bool userControlMode = false, bool userControlOnlyManager = false)
        {
            InitializeComponent();

            isPositionsMode = positionsMode;
            isCustomersMode = customerMode;
            isOrdersMode = ordersMode;
            isOrderItemsMode = orderItemsMode;
            customerIdForOrders = customerId;
            selectedOrderID = orderId;
            isUserControlMode = userControlMode;

            if (isPositionsMode)
            {
                Text = "KitchenBoss - Должности";
                headerSubtitleLabel.Text = "Должности";
                positionsButton.Visible = false;
                clientOrderDishesButton.Visible = false;
                SetupPositionsDataGridView();
                LoadPositionsData();
            }
            else if (isCustomersMode)
            {
                Text = "KitchenBoss - Клиенты";
                headerSubtitleLabel.Text = "Клиенты";
                positionsButton.Visible = false;
                clientOrderDishesButton.Visible = false;
                SetupCustomersDataGridView();
                LoadCustomersData();
            }
            else if (isOrdersMode)
            {
                Text = "KitchenBoss - Заказы клиентов";
                headerSubtitleLabel.Text = "Заказы клиентов";
                Size = new Size(682, 431);
                tableViewerDgv.Size = new Size(642, 280);
                saveButton.Location = new Point(516, 5);
                clientOrderDishesButton.Location = new Point(400, 5);
                positionsButton.Visible = false;
                clientOrderDishesButton.Visible = true;
                SetupOrdersDataGridView();
                LoadOrdersData();
                AllowUserToAddNewRowInOrderDataGridView();
            }
            else if (isOrderItemsMode)
            {
                Text = "KitchenBoss - Чек клиента";
                headerSubtitleLabel.Text = "Чек клиента";
                Size = new Size(497, 431);
                tableViewerDgv.Size = new Size(457, 280);
                saveButton.Location = new Point(380, 5);
                positionsButton.Visible = false;
                clientOrderDishesButton.Visible = false;
                SetupOrderItemsDataGridView();
                LoadOrderItemsData(selectedOrderID ?? 0);
            }
            else if (userControlMode && userControlOnlyManager)
            {
                Text = "KitchenBoss - Добавление менеджера";
                headerSubtitleLabel.Text = "Добавление менеджера";
                positionsButton.Visible = false;
                clientOrderDishesButton.Visible = false;
                SetupUserControlDataGridView(true);
                LoadUserData(true);
                tableViewerDgv.CellEndEdit += tableViewerDgv_CellEndEdit_UserControl;
            }
            else if (userControlMode)
            {
                Text = "KitchenBoss - Управление пользователями";
                headerSubtitleLabel.Text = "Управление пользователями";
                positionsButton.Visible = false;
                clientOrderDishesButton.Visible = false;
                SetupUserControlDataGridView(false);
                LoadUserData(false);
                tableViewerDgv.CellEndEdit += tableViewerDgv_CellEndEdit_UserControl;
            }
            else
            {
                SetupDataGridView();
                LoadData();
            }
        }

        private void SetupDataGridView()
        {
            tableViewerDgv.AutoGenerateColumns = false;
            tableViewerDgv.AllowUserToAddRows = true;

            tableViewerDgv.Columns.Clear();

            var employeeIdColumn = new DataGridViewTextBoxColumn
            {
                Name = "EmployeeID",
                HeaderText = "ID",
                DataPropertyName = "EmployeeID",
                Visible = false
            };
            tableViewerDgv.Columns.Add(employeeIdColumn);

            var nameColumn = new DataGridViewTextBoxColumn
            {
                Name = "FullName",
                HeaderText = "ФИО",
                DataPropertyName = "FullName"
            };
            tableViewerDgv.Columns.Add(nameColumn);

            var positionColumn = new DataGridViewComboBoxColumn
            {
                Name = "PositionID",
                HeaderText = "Должность",
                DataPropertyName = "PositionID"
            };
            tableViewerDgv.Columns.Add(positionColumn);

            var hireDateColumn = new DataGridViewTextBoxColumn
            {
                Name = "HireDate",
                HeaderText = "Дата найма",
                DataPropertyName = "HireDate"
            };
            hireDateColumn.DefaultCellStyle.Format = "dd.MM.yyyy";
            tableViewerDgv.Columns.Add(hireDateColumn);

            var salaryColumn = new DataGridViewTextBoxColumn
            {
                Name = "Salary",
                HeaderText = "Зарплата",
                DataPropertyName = "Salary"
            };
            salaryColumn.DefaultCellStyle.Format = "N2";
            salaryColumn.DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("ru-RU");
            tableViewerDgv.Columns.Add(salaryColumn);

            var emailColumn = new DataGridViewTextBoxColumn
            {
                Name = "Email",
                HeaderText = "Email",
                DataPropertyName = "Email"
            };
            tableViewerDgv.Columns.Add(emailColumn);

            var phoneColumn = new DataGridViewTextBoxColumn
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
            tableViewerDgv.Columns.Clear();

            var customerIdColumn = new DataGridViewTextBoxColumn
            {
                Name = "CustomerID",
                HeaderText = "ID",
                DataPropertyName = "CustomerID",
                Visible = false
            };
            tableViewerDgv.Columns.Add(customerIdColumn);

            var fullNameColumn = new DataGridViewTextBoxColumn
            {
                Name = "FullName",
                HeaderText = "ФИО",
                DataPropertyName = "FullName"
            };
            tableViewerDgv.Columns.Add(fullNameColumn);

            var phoneColumn = new DataGridViewTextBoxColumn
            {
                Name = "PhoneNumber",
                HeaderText = "Телефон",
                DataPropertyName = "PhoneNumber"
            };
            tableViewerDgv.Columns.Add(phoneColumn);

            var emailColumn = new DataGridViewTextBoxColumn
            {
                Name = "Email",
                HeaderText = "Email",
                DataPropertyName = "Email"
            };
            tableViewerDgv.Columns.Add(emailColumn);

            tableViewerDgv.AllowUserToDeleteRows = true;
        }

        private void SetupPositionsDataGridView()
        {
            tableViewerDgv.AutoGenerateColumns = false;
            tableViewerDgv.AllowUserToAddRows = true;

            tableViewerDgv.Columns.Clear();

            var positionIdColumn = new DataGridViewTextBoxColumn
            {
                Name = "PositionID",
                HeaderText = "ID",
                DataPropertyName = "PositionID",
                Visible = false
            };
            tableViewerDgv.Columns.Add(positionIdColumn);

            var positionNameColumn = new DataGridViewTextBoxColumn
            {
                Name = "PositionName",
                HeaderText = "Название должности",
                DataPropertyName = "PositionName"
            };
            tableViewerDgv.Columns.Add(positionNameColumn);

            var descriptionColumn = new DataGridViewTextBoxColumn
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

            var customerNameColumn = new DataGridViewComboBoxColumn
            {
                Name = "CustomerID",
                HeaderText = "Клиент",
                DataPropertyName = "CustomerID",
                ValueMember = "CustomerID",
                DisplayMember = "FullName",
                DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
            };
            tableViewerDgv.Columns.Add(customerNameColumn);

            var employeeNameColumn = new DataGridViewComboBoxColumn
            {
                Name = "EmployeeID",
                HeaderText = "Сотрудник",
                DataPropertyName = "EmployeeID",
                ValueMember = "EmployeeID",
                DisplayMember = "FullName",
                DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
            };
            tableViewerDgv.Columns.Add(employeeNameColumn);


            var orderStatusColumn = new DataGridViewComboBoxColumn
            {
                Name = "OrderStatusID",
                HeaderText = "Статус заказа",
                DataPropertyName = "OrderStatusID",
                ValueMember = "OrderStatusID",
                DisplayMember = "StatusName"
            };
            tableViewerDgv.Columns.Add(orderStatusColumn);

            var orderDateColumn = new DataGridViewTextBoxColumn
            {
                Name = "OrderDate",
                HeaderText = "Дата заказа",
                DataPropertyName = "OrderDate"
            };
            orderDateColumn.DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
            tableViewerDgv.Columns.Add(orderDateColumn);

            var tableColumn = new DataGridViewComboBoxColumn
            {
                Name = "TableID",
                HeaderText = "Столик",
                DataPropertyName = "TableID",
                ValueMember = "TableID",
            };
            tableViewerDgv.Columns.Add(tableColumn);

            var totalAmountColumn = new DataGridViewTextBoxColumn
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

            tableViewerDgv.CellEndEdit += tableViewerDgv_CellEndEdit;

        }

        private void SetupOrderItemsDataGridView()
        {
            tableViewerDgv.AutoGenerateColumns = false;
            tableViewerDgv.AllowUserToAddRows = true;
            tableViewerDgv.AllowUserToDeleteRows = true;
            tableViewerDgv.Columns.Clear();

            var orderItemIdColumn = new DataGridViewTextBoxColumn
            {
                Name = "OrderItemID",
                HeaderText = "OrderItem ID",
                DataPropertyName = "OrderItemID",
                Visible = false
            };
            tableViewerDgv.Columns.Add(orderItemIdColumn);

            var orderIdColumn = new DataGridViewTextBoxColumn
            {
                Name = "OrderID",
                HeaderText = "OrderID",
                DataPropertyName = "OrderID",
                Visible = false
            };
            tableViewerDgv.Columns.Add(orderIdColumn);

            var dishNameColumn = new DataGridViewComboBoxColumn
            {
                Name = "DishID",
                HeaderText = "Блюдо",
                DataPropertyName = "DishID",
                ValueMember = "DishID",
                DisplayMember = "DishName",
                DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
            };
            tableViewerDgv.Columns.Add(dishNameColumn);

            var quantityColumn = new DataGridViewTextBoxColumn
            {
                Name = "Quantity",
                HeaderText = "Количество",
                DataPropertyName = "Quantity"
            };
            tableViewerDgv.Columns.Add(quantityColumn);

            var priceColumn = new DataGridViewTextBoxColumn
            {
                Name = "Price",
                HeaderText = "Цена",
                DataPropertyName = "Price",
                ReadOnly = true,
                ToolTipText = "Рассчитывается\nавтоматически"
            };
            tableViewerDgv.Columns.Add(priceColumn);

            tableViewerDgv.CellValueChanged += tableViewerDgv_CellValueChanged_OrderItems;
            tableViewerDgv.CellEndEdit += tableViewerDgv_CellEndEdit_OrderItems;
        }

        private void SetupUserControlDataGridView(bool onlyManager)
        {
            tableViewerDgv.AutoGenerateColumns = false;
            tableViewerDgv.AllowUserToAddRows = true;
            tableViewerDgv.Columns.Clear();

            var userIdColumn = new DataGridViewTextBoxColumn
            {
                Name = "UserID",
                HeaderText = "UserID",
                DataPropertyName = "UserID",
                Visible = false
            };
            tableViewerDgv.Columns.Add(userIdColumn);

            var fullNameColumn = new DataGridViewComboBoxColumn
            {
                Name = "EmployeeID",
                HeaderText = "ФИО",
                DataPropertyName = "EmployeeID",
                DisplayMember = "FullName",
                ValueMember = "EmployeeID"
            };
            tableViewerDgv.Columns.Add(fullNameColumn);

            var passwordColumn = new DataGridViewTextBoxColumn
            {
                Name = "Password",
                HeaderText = "Пароль",
                DataPropertyName = "Password"
            };
            tableViewerDgv.Columns.Add(passwordColumn);

            var positionColumn = new DataGridViewTextBoxColumn
            {
                Name = "PositionName",
                HeaderText = "Должность",
                DataPropertyName = "PositionName",
                ReadOnly = true
            };
            tableViewerDgv.Columns.Add(positionColumn);

            using (var context = Program.context)
            {
                var employeesQuery = context.Employees
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

        private void tableViewerDgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            tableViewerDgv.EndEdit();
        }

        private void tableViewerDgv_CellEndEdit_UserControl(object sender, DataGridViewCellEventArgs e)
        {
            var row = tableViewerDgv.Rows[e.RowIndex];
            if (row.IsNewRow) return;

            if (tableViewerDgv.Columns[e.ColumnIndex].Name == "EmployeeID")
            {
                var selectedEmployeeId = row.Cells["EmployeeID"].Value;
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
                        var employee = context.Employees
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

        private void LoadData()
        {
            using (var context = Program.context)
            {
                var positions = context.Positions.ToList();
                var positionColumn = (DataGridViewComboBoxColumn)tableViewerDgv.Columns["PositionID"];
                if (positionColumn != null)
                {
                    positionColumn.DataSource = positions;
                    positionColumn.DisplayMember = "PositionName";
                    positionColumn.ValueMember = "PositionID";
                }

                var employees = context.Employees
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
                var customers = context.Customers
                    .ToList()
                    .Select(c => new
                    {
                        CustomerID = c.CustomerID,
                        FullName = $"{c.FirstName} {c.LastName}",
                        PhoneNumber = c.PhoneNumber,
                        Email = c.Email
                    })
                    .ToList();

                tableViewerDgv.DataSource = new BindingList<dynamic>(customers.Cast<dynamic>().ToList());
            }
        }

        private void LoadPositionsData()
        {
            using (var context = Program.context)
            {
                var positions = context.Positions.ToList();
                tableViewerDgv.DataSource = new BindingList<Position>(positions);
            }
        }

        private void LoadOrdersData()
        {
            using (var context = Program.context)
            {
                var ordersQuery = context.Orders
                    .Include(o => o.Customer)
                    .Include(o => o.Employee)
                    .Include(o => o.OrderStatu);

                if (customerIdForOrders.HasValue)
                {
                    ordersQuery = ordersQuery.Where(o => o.CustomerID == customerIdForOrders.Value);
                }

                var orders = ordersQuery.ToList();

                var customerColumn = (DataGridViewComboBoxColumn)tableViewerDgv.Columns["CustomerID"];
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

                var employeeColumn = (DataGridViewComboBoxColumn)tableViewerDgv.Columns["EmployeeID"];
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

                var tableColumn = (DataGridViewComboBoxColumn)tableViewerDgv.Columns["TableID"];
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

                var orderViewModels = orders.Select(o => new OrderViewModel
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
                var orderStatusColumn = (DataGridViewComboBoxColumn)tableViewerDgv.Columns["OrderStatusID"];
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
                var order = context.Orders
                                 .Include(o => o.OrderStatu)
                                 .FirstOrDefault(o => o.OrderID == orderID);

                bool isReadOnly = order?.OrderStatu?.StatusName == "Отменен" ||
                                 order?.OrderStatu?.StatusName == "Закрыт";

                var orderItems = context.OrderItems
                                      .Include(oi => oi.Dish)
                                      .Where(oi => oi.OrderID == orderID)
                                      .ToList();

                var dishList = context.Dishes.ToList();
                var dishColumn = (DataGridViewComboBoxColumn)tableViewerDgv.Columns["DishID"];
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
                var allEmployeesQuery = context.Employees.Include(e => e.Position);
                if (onlyManager)
                    allEmployeesQuery = allEmployeesQuery.Where(e => e.Position.PositionName == "Менеджер");

                var allEmployees = allEmployeesQuery.ToList();

                var users = context.Users.Include(u => u.Employee.Position).ToList();

                var usedEmployeeIDs = users.Select(u => u.EmployeeID).ToHashSet();

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

                var userViewModels = users.Select(u => new UserViewModel
                {
                    UserID = u.UserID,
                    EmployeeID = u.EmployeeID,
                    FullName = $"{u.Employee.FirstName} {u.Employee.LastName}",
                    PositionName = u.Employee.Position?.PositionName,
                    Password = "******"
                }).ToList();

                var employeeColumn = tableViewerDgv.Columns["EmployeeID"] as DataGridViewComboBoxColumn;
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

        private void tableViewerDgv_CellValueChanged_OrderItems(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                UpdatePrice(tableViewerDgv.Rows[e.RowIndex]);
                isChanged = true;
                saveButton.Enabled = true;
            }
        }

        private void tableViewerDgv_CellEndEdit_OrderItems(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                UpdatePrice(tableViewerDgv.Rows[e.RowIndex]);
                isChanged = true;
                saveButton.Enabled = true;
            }
        }

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

        private void AllowUserToAddNewRowInOrderDataGridView()
        {
            tableViewerDgv.AllowUserToAddRows = true;
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
                isChanged = true;
                saveButton.Enabled = true;
            }
        }

        private void tableViewerDgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            isChanged = true;
            saveButton.Enabled = true;
        }

        private void tableViewerDgv_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            isChanged = true;
            saveButton.Enabled = true;
        }

        private void positionsButton_Click(object sender, EventArgs e)
        {
            OpenPositionsForm();
        }

        private void OpenPositionsForm()
        {
            fmTableViewer positionsForm = new fmTableViewer(true);
            positionsForm.Show();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (isPositionsMode)
                SavePositionsData();
            else if (isCustomersMode)
                SaveCustomersData();
            else if (isOrdersMode)
                SaveOrdersData();
            else if (isOrderItemsMode)
                SaveOrderItemsData();
            else if (isUserControlMode)
            {
                if (!ValidateUserData())
                    return;
                SaveUserData();
            }
            else
                SaveEmployeesData();
        }

        private void SaveOrderItemsData()
        {
            using (var context = Program.context)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        isChanged = false;
                        saveButton.Enabled = false;

                        var order = context.Orders
                                         .Include(o => o.OrderStatu)
                                         .FirstOrDefault(o => o.OrderID == selectedOrderID);

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
                                                  .Where(oi => oi.OrderID == selectedOrderID)
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
                                    OrderID = selectedOrderID.Value
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

                        isChanged = false;
                        saveButton.Enabled = false;

                        if (isOrdersMode)
                        {
                            LoadOrdersData();
                        }
                        else
                        {
                            var ordersForm = Application.OpenForms.OfType<fmTableViewer>()
                                .FirstOrDefault(f => f.isOrdersMode);
                            ordersForm?.LoadOrdersData();
                        }

                        MessageBox.Show("Данные чека клиента успешно сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadOrderItemsData(selectedOrderID ?? 0);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Ошибка при сохранении чека клиента: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

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

                        var employeeId = Convert.ToInt32(row.Cells["EmployeeID"].Value);
                        var employee = context.Employees.Find(employeeId);

                        if (employee != null)
                        {
                            var fullName = row.Cells["FullName"].Value.ToString().Split(' ');
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
                            var fullName = row.Cells["FullName"].Value.ToString().Split(' ');
                            var positionValue = row.Cells["PositionID"].Value;
                            int positionId = (int)positionValue;


                            var newEmployee = new Employee
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
                    isChanged = false;
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

                        var customerId = Convert.ToInt32(row.Cells["CustomerID"].Value ?? 0);
                        var customer = context.Customers.Find(customerId);

                        if (customer != null)
                        {
                            var fullName = row.Cells["FullName"].Value?.ToString()?.Split(' ');
                            if (fullName != null && fullName.Length >= 2)
                            {
                                customer.FirstName = fullName[0];
                                customer.LastName = string.Join(" ", fullName.Skip(1));
                            }
                            else if (fullName != null && fullName.Length == 1)
                            {
                                customer.FirstName = fullName[0];
                                customer.LastName = "";
                            }
                            else
                            {
                                MessageBox.Show("Необходимо ввести Имя и Фамилию", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }


                            customer.PhoneNumber = row.Cells["PhoneNumber"].Value?.ToString();
                            customer.Email = row.Cells["Email"].Value?.ToString();
                        }
                        else
                        {
                            var fullName = row.Cells["FullName"].Value?.ToString()?.Split(' ');

                            if (fullName != null && fullName.Length >= 2)
                            {
                                var newCustomer = new Customer
                                {
                                    FirstName = fullName[0],
                                    LastName = string.Join(" ", fullName.Skip(1)),
                                    PhoneNumber = row.Cells["PhoneNumber"].Value?.ToString(),
                                    Email = row.Cells["Email"].Value?.ToString()
                                };

                                context.Customers.Add(newCustomer);
                            }
                            else if (fullName != null && fullName.Length == 1)
                            {
                                var newCustomer = new Customer
                                {
                                    FirstName = fullName[0],
                                    LastName = "",
                                    PhoneNumber = row.Cells["PhoneNumber"].Value?.ToString(),
                                    Email = row.Cells["Email"].Value?.ToString()
                                };

                                context.Customers.Add(newCustomer);
                            }
                            else
                            {
                                MessageBox.Show("Необходимо ввести Имя и Фамилию", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }

                    context.SaveChanges();
                    isChanged = false;
                    saveButton.Enabled = false;
                    MessageBox.Show("Данные о клиентах успешно сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                        var positionId = Convert.ToInt32(row.Cells["PositionID"].Value ?? 0);
                        var position = context.Positions.Find(positionId);

                        if (position != null)
                        {
                            position.PositionName = row.Cells["PositionName"].Value?.ToString();
                            position.Description = row.Cells["Description"].Value?.ToString();
                        }
                        else
                        {
                            var newPosition = new Position
                            {
                                PositionName = row.Cells["PositionName"].Value?.ToString(),
                                Description = row.Cells["Description"].Value?.ToString()
                            };
                            context.Positions.Add(newPosition);
                        }
                    }


                    context.SaveChanges();
                    isChanged = false;
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

                            var orderId = orderViewModel.OrderID;
                            var order = context.Orders.Find(orderId);

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
                    isChanged = false;
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

        private void SaveUserData()
        {
            using (var context = Program.context)
            {
                try
                {
                    foreach (DataGridViewRow row in tableViewerDgv.Rows)
                    {
                        if (row.IsNewRow) continue;

                        var userId = row.Cells["UserID"].Value == null ? 0 : Convert.ToInt32(row.Cells["UserID"].Value);
                        var employeeId = Convert.ToInt32(row.Cells["EmployeeID"].Value);
                        var password = row.Cells["Password"].Value?.ToString();

                        var user = context.Users.FirstOrDefault(u => u.UserID == userId);

                        if (user != null)
                        {
                            if (!string.IsNullOrEmpty(password) && password != "******")
                            {
                                var newSalt = Guid.NewGuid();
                                string hashedPassword = HashPassword(password, newSalt.ToString());

                                user.PasswordHash = Convert.FromBase64String(hashedPassword);
                                user.PasswordSalt = newSalt;
                            }
                            user.EmployeeID = employeeId;
                        }
                        else
                        {
                            var newSalt = Guid.NewGuid();
                            string hashedPassword = HashPassword(password ?? "defaultpassword", newSalt.ToString());

                            var newUser = new User
                            {
                                EmployeeID = employeeId,
                                PasswordHash = Convert.FromBase64String(hashedPassword),
                                PasswordSalt = newSalt
                            };
                            context.Users.Add(newUser);
                        }
                    }

                    context.SaveChanges();
                    isChanged = false;
                    saveButton.Enabled = false;
                    MessageBox.Show("Данные успешно сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

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

        private bool ValidateData()
        {
            if (!isUserControlMode)
            {
                foreach (DataGridViewRow row in tableViewerDgv.Rows)
                {
                    if (row.IsNewRow) continue;

                    var fullName = row.Cells["FullName"].Value?.ToString();
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

        private bool ValidateUserData()
        {
            var usedEmployees = new HashSet<int>();

            foreach (DataGridViewRow row in tableViewerDgv.Rows)
            {
                if (row.IsNewRow) continue;

                var employeeId = Convert.ToInt32(row.Cells["EmployeeID"].Value);

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
            if (isOrdersMode)
            {
                e.Cancel = true;
                MessageBox.Show("Удаление заказов запрещено.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (isOrderItemsMode)
            {
                isChanged = true;
                saveButton.Enabled = true;
            }

            if (!e.Row.IsNewRow)
            {
                var employee = e.Row.DataBoundItem as EmployeeViewModel;
                if (employee != null)
                {
                    if (employee.EmployeeID > 0)
                    {
                        deletedEmployees.Add(employee);
                        isChanged = true;
                        saveButton.Enabled = true;
                    }
                    ((BindingList<EmployeeViewModel>)tableViewerDgv.DataSource).Remove(employee);
                }
            }
        }

        private void fmTableViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isChanged)
            {
                DialogResult result = MessageBox.Show("Сохранить изменения внесённые изменения?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                    saveButton_Click(sender, e);
            }
        }

        private void clientOrderDishesButton_Click(object sender, EventArgs e)
        {
            if (isOrdersMode)
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
                                fmTableViewer orderItemsForm = new fmTableViewer(false, false, false, order.CustomerID, order.OrderID, true);
                                orderItemsForm.Show();
                            }
                            else
                            {
                                MessageBox.Show("Выбранная строка не содержит данных о заказе.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выбранная строка не содержит данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Не удалось получить данные.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Пожалуйста, выберите заказ.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }

    public class EmployeeViewModel
    {
        public int EmployeeID { get; set; }
        public string FullName { get; set; }
        public int PositionID { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class OrderViewModel
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public int? EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public int OrderStatusID { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public int TableID { get; set; }
        public int TableNumber { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class UserViewModel
    {
        public int UserID { get; set; }
        public int EmployeeID { get; set; }
        public string FullName { get; set; }
        public string PositionName { get; set; }
        public string Password { get; set; }
    }

}
