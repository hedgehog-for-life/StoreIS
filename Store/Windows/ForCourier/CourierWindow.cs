using Store.Controllers;
using Store.DataBase.Context;
using Store.DataBase.Entities;
using Store.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store.Windows.ForCourier
{
    public partial class CourierWindow : Form
    {
        private string userEmail;
        private Person activeUser;

        private OrderController orderController;
        private PersonController personController;
        private AddressController addressController;

        private BindingList<Order> orders;
        private BindingList<Order> currOrders;
        private stuff_shopContext db;

        private bool newTaken = false;

        private CultureInfo provider = CultureInfo.InvariantCulture;

        private List<int> rowsTaken;

        private DateTimeValidator dtValidator;

        public CourierWindow(string userEmail)
        {
            InitializeComponent();

            db = new stuff_shopContext();
            orderController = new OrderController(db);
            personController = new PersonController();
            addressController = new AddressController(db);

            this.userEmail = userEmail;
            activeUser = personController.FindPersonByEmail(userEmail);

            rowsTaken = new List<int>();


            dtValidator = new DateTimeValidator();

            RetrieveDataFromDB();
        }

        public void RetrieveDataFromDB()
        {
            orders = new BindingList<Order>(orderController.GetAwaitingCourier(activeUser.Id));
            dataGridViewOrders.DataSource = orders;

            currOrders = new BindingList<Order>(orderController.GetCurrentCourierOrders(activeUser.Id));
            dataGridView1.DataSource = currOrders;

            InPrColumnStatus.Items.Add("В пути");
            InPrColumnStatus.Items.Add("Прибыл в город назначения");
            InPrColumnStatus.Items.Add("Выполняется доставка по нужному адресу");
            InPrColumnStatus.Items.Add("Доставлен и оплачен");
        }

        public void UpdateDataOrders()
        {
            orders = new BindingList<Order>(orderController.GetAwaitingCourier(activeUser.Id));
            dataGridViewOrders.DataSource = null;
            dataGridViewOrders.DataSource = orders;
        }

        private void dataGridViewOrders_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            for (int i = 0; i < dataGridViewOrders.Rows.Count; i++)
            {
                Person user = personController.GetUser(Convert.ToInt32(dataGridViewOrders.Rows[i].Cells[ColumnUserId.Index].Value));
                dataGridViewOrders.Rows[i].Cells[ColumnUser.Index].Value = user.PersonSurname + " " + user.PersonName + " " + user.PersonPatronymic;

                switch(dataGridViewOrders.Rows[i].Cells[ColumnPaymentMethodId.Index].Value.ToString())
                {
                    case "0":
                        dataGridViewOrders.Rows[i].Cells[ColumnPaymentMethod.Index].Value = "Наличными при получении";
                        break;
                    case "1":
                        dataGridViewOrders.Rows[i].Cells[ColumnPaymentMethod.Index].Value = "Картой при получении";
                        break;
                }

                Address address = addressController.GetAddress(Convert.ToInt32(dataGridViewOrders.Rows[i].Cells[ColumnAddressId.Index].Value));
                dataGridViewOrders.Rows[i].Cells[ColumnAddress.Index].Value = address.AddIndex + ", " + address.Street.City.Region.Country.CountryName + ", " +
                    address.Street.City.Region.RegionName + ", " + address.Street.City.CityName + ", " + address.Street.StreetName + ", " + address.House + ", " +
                    address.ApartmentNum;

                if (dataGridViewOrders.Rows[i].Cells[ColumnCourierId.Index].Value != null)
                    dataGridViewOrders.Rows[i].Cells[ColumnCourier.Index].Value = activeUser.PersonSurname + " " + activeUser.PersonName + " " + activeUser.PersonPatronymic;

            }
        }

        private void dataGridViewOrders_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            dataGridViewOrders.Rows[e.RowIndex].ErrorText = "";
            DataGridViewColumn currentColumn = dataGridViewOrders.Columns[e.ColumnIndex];
            DataGridViewRow currentRow = dataGridViewOrders.Rows[e.RowIndex];
            DataGridViewCell currentCell = currentRow.Cells[e.ColumnIndex];

            if (currentColumn.HeaderText == "Дата доставки")
            {
                try
                {
                    DateTime convertedData = Convert.ToDateTime(e.FormattedValue);
                    if (dtValidator.IsDataCorrect(convertedData))
                    {
                        e.Cancel = true;
                        dataGridViewOrders.Rows[e.RowIndex].ErrorText = "Доставка не может осуществиться раньше сегодняшнего дня";
                    }
                }
                catch (Exception)
                {
                    e.Cancel = true;
                    dataGridViewOrders.Rows[e.RowIndex].ErrorText = "Некорректная дата";
                }
            }
        }

        private void dataGridViewOrders_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewOrders.Rows[e.RowIndex].ErrorText = null;
            buttonSubmitChanges.Enabled = true;
        }

        async private void dataGridViewOrders_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn currentColumn = dataGridViewOrders.Columns[e.ColumnIndex];
            DataGridViewRow currentRow = dataGridViewOrders.Rows[e.RowIndex];
            DataGridViewCell currentCell = currentRow.Cells[e.ColumnIndex];

            if (currentColumn.HeaderText == "Взять")
            {
                if(Convert.ToBoolean(currentCell.Value))
                {
                    Order orderFound = orders.First(order => order.OrderNumber == currentRow.Cells[ColumnOrderNumber.Index].Value.ToString());
                    orderFound.OrderStatus = 1;
                    currentRow.Cells[ColumnCourierId.Index].Value = activeUser.Id;
                    currentRow.Cells[ColumnCourier.Index].Value = activeUser.PersonSurname + " " + activeUser.PersonName + " " + activeUser.PersonPatronymic;
                    orderFound.Courier = activeUser;

                    rowsTaken.Add(currentRow.Index);

                    await orderController.UpdateOrderAsync(orderFound);

                }
                else if (!Convert.ToBoolean(currentCell.Value))
                {
                    Order orderFound = orders.First(order => order.OrderNumber == currentRow.Cells[ColumnOrderNumber.Index].Value.ToString());
                    orderFound.OrderStatus = 0;
                    orderFound.Courier = null;

                    rowsTaken.Remove(currentRow.Index);

                    currentRow.Cells[ColumnCourierId.Index].Value = null;
                    currentRow.Cells[ColumnCourier.Index].Value = "";

                    await orderController.UpdateOrderAsync(orderFound);
                }
            }

            orders = new BindingList<Order>(orderController.GetAwaitingCourier(activeUser.Id));
            dataGridViewOrders.Refresh();

        }

        private void dataGridViewOrders_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            orders = new BindingList<Order>(orderController.GetAwaitingCourier(activeUser.Id));
            dataGridViewOrders.Refresh();
        }

        private void buttonSubmitChanges_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rowsTaken.Count; i++)
            {
                Order orderFound = orders.First(order => order.OrderNumber == dataGridViewOrders.Rows[rowsTaken[i]].Cells[ColumnOrderNumber.Index].Value.ToString());
                orderFound.DeliveryDate = Convert.ToDateTime(dataGridViewOrders.Rows[rowsTaken[i]].Cells[ColumnDeliveryDate.Index].EditedFormattedValue);
                orderFound.OrderStatus = 2;

                orderController.UpdateOrder(orderFound);

                dataGridViewOrders.DataSource = null;
                orders = new BindingList<Order>(orderController.GetAwaitingCourier(activeUser.Id));
                dataGridViewOrders.DataSource = orders;

                currOrders.Add(orderFound);

            }
            rowsTaken.Clear();
            newTaken = true;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(newTaken)
            {

                currOrders = new BindingList<Order>(orderController.GetCurrentCourierOrders(activeUser.Id));
                dataGridView1.Refresh();

                newTaken = false;
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                Person user = personController.GetUser(Convert.ToInt32(dataGridView1.Rows[i].Cells[InPrColumnUserId.Index].Value));
                dataGridView1.Rows[i].Cells[InPrColumnUserFIO.Index].Value = user.PersonSurname + " " + user.PersonName + " " + user.PersonPatronymic;
                dataGridView1.Rows[i].Cells[InPrColumnUserPhone.Index].Value = "+7" + user.Phone;

                Person courier = personController.GetUser(Convert.ToInt32(dataGridView1.Rows[i].Cells[InPrColumnCourierId.Index].Value));
                dataGridView1.Rows[i].Cells[InPrColumnCourier.Index].Value = courier.PersonSurname + " " + courier.PersonName + " " + courier.PersonPatronymic;

                switch (dataGridView1.Rows[i].Cells[InPrColumnPaymentMethodId.Index].Value.ToString())
                {
                    case "0":
                        dataGridView1.Rows[i].Cells[InPrColumnPaymentMethod.Index].Value = "Наличными при получении";
                        break;
                    case "1":
                        dataGridView1.Rows[i].Cells[InPrColumnPaymentMethod.Index].Value = "Картой при получении";
                        break;
                }
                switch (dataGridView1.Rows[i].Cells[InPrColumnStatusId.Index].Value.ToString())
                {
                    case "3":
                        dataGridView1.Rows[i].Cells[InPrColumnStatus.Index].Value = "В пути";
                        break;
                    case "4":
                        dataGridView1.Rows[i].Cells[InPrColumnStatus.Index].Value = "Прибыл в город назначения";
                        break;
                    case "5":
                        dataGridView1.Rows[i].Cells[InPrColumnStatus.Index].Value = "Выполняется доставка по нужному адресу";
                        break;
                    case "6":
                        dataGridView1.Rows[i].Cells[InPrColumnStatus.Index].Value = "Доставлен и оплачен";
                        dataGridView1.Rows[i].Frozen = true;
                        break;
                }

                Address address = addressController.GetAddress(Convert.ToInt32(dataGridView1.Rows[i].Cells[InPrColumnAddressId.Index].Value));
                dataGridView1.Rows[i].Cells[InPrColumnAddress.Index].Value = address.AddIndex + ", " + address.Street.City.Region.Country.CountryName + ", " +
                    address.Street.City.Region.RegionName + ", " + address.Street.City.CityName + ", " + address.Street.StreetName + ", " + address.House + ", " +
                    address.ApartmentNum;
            }
        }

        async private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn currentColumn = dataGridView1.Columns[e.ColumnIndex];
            DataGridViewRow currentRow = dataGridView1.Rows[e.RowIndex];
            DataGridViewCell currentCell = currentRow.Cells[e.ColumnIndex];
            Order orderFound = currOrders.First(order => order.OrderNumber == currentRow.Cells[ColumnOrderNumber.Index].Value.ToString());

            if (currentColumn.HeaderText == "Статус")
            {
                switch (currentRow.Cells[InPrColumnStatus.Index].EditedFormattedValue.ToString())
                {
                    case "В пути":
                        orderFound.OrderStatus = 3;
                        break;
                    case "Прибыл в город назначения":
                        orderFound.OrderStatus = 4;
                        break;
                    case "Выполняется доставка по нужному адресу":
                        orderFound.OrderStatus = 5;
                        break;
                    case "Доставлен и оплачен":
                        orderFound.OrderStatus = 6;
                        currentRow.ReadOnly = true;
                        break;
                }
                await orderController.UpdateOrderAsync(orderFound);
            }
            else if(currentColumn.HeaderText == "Дата доставки")
            {
               orderFound.DeliveryDate = DateTime.ParseExact(currentCell.EditedFormattedValue.ToString(), "dd.MM.yyyy", provider);
            }
            currOrders = new BindingList<Order>(orderController.GetCurrentCourierOrders(activeUser.Id));
            dataGridView1.Refresh();
        }

        private void pictureBoxLogOut_Click(object sender, EventArgs e)
        {
            LoginForm loginWindow = new LoginForm();
            loginWindow.Show();
            this.Hide();
        }

        private void pictureBoxExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
