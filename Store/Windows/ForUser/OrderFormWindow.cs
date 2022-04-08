using Store.Controllers;
using Store.DataBase.Context;
using Store.DataBase.Entities;
using Store.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Region = Store.DataBase.Entities.Region;

namespace Store.Windows.ForUser
{
    public partial class OrderFormWindow : Form
    {
        private Person user;
        private Order order;

        private StringValidator validator;
        private InputValidator iValidator;

        private OrderController orderController;
        private PersonController personController;
        private ShoppingCartController shoppingCartController;
        private RegionController regionController;
        private AddressController addressController;
        private CityController cityController;
        private CountryController countryController;
        private StreetController streetController;
        private OrderGoodController orderGoodController;

        private stuff_shopContext db;

        private bool first1 = true, first2 = true, first3 = true;

        public OrderFormWindow(string userEmail, Order order)
        {
            InitializeComponent();

            iValidator = new InputValidator();
            validator = new StringValidator();

            db = new stuff_shopContext();

            orderController = new OrderController(db);
            personController = new PersonController();
            shoppingCartController = new ShoppingCartController(db);
            streetController = new StreetController(db);
            regionController = new RegionController(db);
            addressController = new AddressController(db);
            cityController = new CityController(db);
            countryController = new CountryController(db);
            orderGoodController = new OrderGoodController(db);

            this.order = order;
            user = personController.FindPersonByEmail(userEmail);

            comboBoxPaymentMethod.Items.Add("Наличными при получении"); // 0
            comboBoxPaymentMethod.Items.Add("Картой при получении"); // 1
            comboBoxPaymentMethod.SelectedItem = comboBoxPaymentMethod.Items[0];

            comboBoxDeliveryMethod.Items.Add("Курьерская"); // 0
            comboBoxDeliveryMethod.Items.Add("Самовывоз"); // 1
            comboBoxDeliveryMethod.SelectedItem = comboBoxDeliveryMethod.Items[0];
            comboBoxDeliveryMethod.SelectedItem = comboBoxDeliveryMethod.Items[0];

            List<Country> countries = countryController.GetCountries();
            foreach (Country c in countries)
            {
                comboBoxDcountry.Items.Add(c.CountryName);
                comboBoxPcountry.Items.Add(c.CountryName);
            }
            comboBoxDcountry.SelectedItem = comboBoxDcountry.Items[0];
            comboBoxPcountry.SelectedItem = comboBoxPcountry.Items[0];

            List<DataBase.Entities.Region> regions = regionController.GetRegions();
            foreach (Region r in regions)
            {
                comboBoxDregion.Items.Add(r.RegionName);
                comboBoxPregion.Items.Add(r.RegionName);
            }
            comboBoxDregion.SelectedItem = comboBoxDregion.Items[0];
            comboBoxPregion.SelectedItem = comboBoxPregion.Items[0];

            List<City> cities = cityController.GetCities();
            //foreach (City c in cities)
            //{
            //    comboBoxDcity.Items.Add(c.CityName);
            //    comboBoxPcity.Items.Add(c.CityName);
            //}
            //comboBoxDcity.SelectedItem = comboBoxDcity.Items[0];
            //comboBoxPcity.SelectedItem = comboBoxPcity.Items[0];

            //List<Address> addresses = addressController.FindByCountryAndRegionAndCity(countries[0], regions[0], cities[0]);
            //foreach (Address a in addresses)
            //{
            //    checkedListBoxPaddresses.Items.Add(a.AddIndex + "," + a.Street.City.Region.Country.CountryName + "," + a.Street.City.Region.RegionName + "," + a.Street.City.CityName + "," + a.Street.StreetName + "," + a.House + "," + a.ApartmentNum);
            //}

            DateTime deliveryDate = DateTime.Now.AddDays(14);
            order.DeliveryDate = deliveryDate;
            labelDeliveryDate.Text = deliveryDate.ToShortDateString();

            // Свыше 8000 - 560, меньше - 490
            if (order.TotalCost > 8000)
                labelDeliveryCost.Text = "560,00";
            else labelDeliveryCost.Text = "490,00";

            foreach (OrderGood og in order.OrderGood)
            {
                listBoxGoodsNames.Items.Add(og.Good.Article + ", " + og.Good.GoodName);
                listBoxGoodsPrices.Items.Add(og.Good.Price);
                listBoxGoodsDiscounts.Items.Add(og.Discount);
                listBoxResultNumber.Items.Add((og.GoodNum + og.FreeGoodNum).ToString());
                decimal cost = og.GoodNum * og.Good.Price * (decimal)(1 - 0.01f * og.Discount);
                listBoxGoodsResultCost.Items.Add(cost);

            }

            labelResultCost.Text = order.TotalCost.ToString();

            labelBuyer.Text = user.PersonSurname + " " + user.PersonName + " " + user.PersonPatronymic + ", " + user.BirthDate.ToShortDateString() + ", +7" + user.Phone;
        }


        private void pictureBoxExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBoxLogOut_Click(object sender, EventArgs e)
        {
            LoginForm loginWindow = new LoginForm();
            loginWindow.Show();
            this.Hide();
        }

        private void textBoxDindex_Validating(object sender, CancelEventArgs e)
        {
            TextBox data = (TextBox)sender;
            if (!validator.IsCorrectName(data.Text))
            {
                e.Cancel = true;
                textBoxDindex.Select(0, textBoxDindex.Text.Length);

                this.errorProvider1.SetError(textBoxDindex, "Поле должно быть заполнено");
            }
        }

        private void textBoxDindex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!iValidator.IsCorrectIndex(e.KeyChar))
                e.Handled = true;
        }

        private void textBoxDindex_Validated(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            errorProvider1.SetError(textBox, "");
        }

        private void textBoxDstreet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!iValidator.isNameSymbolsControl(e.KeyChar))
                e.Handled = true;
        }

        private void checkedListBoxPaddresses_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            List<int> indexesToDelete = new List<int>();
            for (int i = 0; i < checkedListBoxPaddresses.Items.Count; i++)
            {
                if (i != e.Index && checkedListBoxPaddresses.GetItemChecked(i))
                    indexesToDelete.Add(i);
                foreach (int el in indexesToDelete)
                {
                    checkedListBoxPaddresses.SetItemChecked(i, false);
                }
            }
        }

        private void comboBoxDeliveryMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDeliveryMethod.SelectedIndex == 0)
            {
                if (order.TotalCost > 8000)
                    labelDeliveryCost.Text = "560,00";
                else labelDeliveryCost.Text = "490,00";


                panelAddressDelivery.Visible = true;
                panelPickupAddress.Visible = false;
            }
            else
            {
                labelDeliveryCost.Text = "0,00";

                panelAddressDelivery.Visible = false;
                panelPickupAddress.Visible = true;
            }
            order.TotalCost = order.TotalCost - order.DeliveryPrice + Convert.ToDecimal(labelDeliveryCost.Text);
            order.DeliveryPrice = Convert.ToDecimal(labelDeliveryCost.Text);
            labelResultCost.Text = order.TotalCost.ToString();


        }

        private void buttonAddToSC_Click(object sender, EventArgs e)
        {
        //    order.DeliveryPrice = Convert.ToDecimal(labelDeliveryCost.Text);
          //  order.TotalCost += order.DeliveryPrice;
            order.OrderStatus = 0;
            order.PaymentMethod = Convert.ToInt16(comboBoxPaymentMethod.SelectedIndex);
            order.DeliveryMethod = Convert.ToInt16(comboBoxDeliveryMethod.SelectedIndex);
            order.Verified = false;

            string orderNum = "";
            Random rnd = new Random();
            for (int i = 0; i < 11; i++)
            {
                orderNum += rnd.Next(0, 9);
            }
            for (int i = 0; i < 2; i++)
            {
                orderNum += Convert.ToChar(rnd.Next(65, 90));
            }
            for (int i = 0; i < 2; i++)
            {
                orderNum += rnd.Next(0, 9);
            }
            order.OrderNumber = orderNum;

            Address deliveryAddress;
            if (order.DeliveryMethod == 0)
            {
                deliveryAddress = new Address();
                deliveryAddress.AddIndex = textBoxDindex.Text;
                deliveryAddress.House = textBoxDhouse.Text;
                deliveryAddress.ApartmentNum = textBoxDappartment.Text;

                deliveryAddress.AddType = 2;

                Country country = countryController.GetCountry(comboBoxDcountry.SelectedItem.ToString());
                Region region = regionController.GetRegion(comboBoxDregion.SelectedItem.ToString(), country);
                City city = cityController.GetCity(comboBoxDcity.SelectedItem.ToString(), region);

                string name = textBoxDstreet.Text;
                Street street = streetController.GetStreet(name, city);
                if (street != null)
                    deliveryAddress.Street = street;
                else if (street == null)
                {
                    street = new Street();
                    street.StreetName = name;
                    street.City = city;
                    streetController.AddDetachedStreet(street);
                    deliveryAddress.Street = streetController.GetStreet(name, city);
                }

                Address address = addressController.GetByAll(deliveryAddress.Street, deliveryAddress.AddIndex, deliveryAddress.AddType, deliveryAddress.House, deliveryAddress.ApartmentNum);
                if (address == null)
                {
                    addressController.AddAddress(deliveryAddress);
                    deliveryAddress = addressController.GetByAll(deliveryAddress.Street, deliveryAddress.AddIndex, deliveryAddress.AddType, deliveryAddress.House, deliveryAddress.ApartmentNum);
                }
                else
                {
                    deliveryAddress = address;
                }
                order.Address = deliveryAddress;
            }
            else
            {
                string[] address = checkedListBoxPaddresses.CheckedItems[0].ToString().Split(',');
                Country country = countryController.GetCountry(address[1]);
                Region region = regionController.GetRegion(address[2], country);
                City city = cityController.GetCity(address[3], region);
                order.Address = addressController.GetByAll(streetController.GetStreet(address[4], city), address[0], 0, address[5], address[6]);
            }

            orderController.AddOrder(order);
            foreach (OrderGood og in order.OrderGood)
                orderGoodController.AddGoodOrder(og);
            List<ShoppingCart> items = shoppingCartController.GetShoppingCarts(user);
            int count = items.Count;
            for (int i = 0; i < count; i++)
            {
                shoppingCartController.RemoveItem(items[0].Id);

                items.Remove(items[0]);
            }

            OrderWindow orderWindow = new OrderWindow(user.Email);
            orderWindow.Show();

            SuccessWindow successWindow = new SuccessWindow("Заказ успешно оформлен");
            successWindow.Show();


            this.Hide();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            ShoppingCartWindow shoppingCartWindow = new ShoppingCartWindow(user.Email);
            shoppingCartWindow.Show();
            this.Hide();
        }

        private void comboBoxPregion_SelectedIndexChanged(object sender, EventArgs e)
        {
                Country country = countryController.GetCountry(comboBoxPcountry.SelectedItem.ToString());
            if (comboBoxPregion.SelectedItem == null) comboBoxPregion.SelectedIndex = 0;
            Region region = regionController.GetRegion(comboBoxPregion.SelectedItem.ToString(), country);
            List<City> cities = cityController.GetCitiesByRegion(region);
            comboBoxPcity.Items.Clear();
            foreach (City c in cities)
                comboBoxPcity.Items.Add(c.CityName);
            if (comboBoxPcity.Items.Count > 0)
            {
                comboBoxPcity.SelectedItem = comboBoxPcity.Items[0];
                //  City city = cityController.GetCity(comboBoxPcity.SelectedItem.ToString(), region);
                City city = cities[0];
                List<Address> addresses = addressController.FindByCountryAndRegionAndCity(country, region, city);


                checkedListBoxPaddresses.Items.Clear();
                foreach (Address a in addresses)
                    checkedListBoxPaddresses.Items.Add(a.AddIndex + "," + a.Street.City.Region.Country.CountryName + "," + a.Street.City.Region.RegionName + "," + a.Street.City.CityName + "," + a.Street.StreetName + "," + a.House + "," + a.ApartmentNum);
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ShoppingCartWindow shoppingCartWindow = new ShoppingCartWindow(user.Email);
            shoppingCartWindow.Show();
            this.Hide();
        }

        private void comboBoxDregion_SelectedIndexChanged(object sender, EventArgs e)
        {
            Country country = countryController.GetCountry(comboBoxDcountry.SelectedItem.ToString());
            if (comboBoxDregion.SelectedItem == null) comboBoxDregion.SelectedIndex = 0;
            Region region = regionController.GetRegion(comboBoxDregion.SelectedItem.ToString(), country);
            List<City> cities = cityController.GetCitiesByRegion(region);
            comboBoxDcity.Items.Clear();
            foreach (City c in cities)
                comboBoxDcity.Items.Add(c.CityName);
            if(comboBoxDcity.Items.Count > 0)
            comboBoxDcity.SelectedItem = comboBoxDcity.Items[0];
        }

        private void comboBoxPcity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!first2)
            {
                Country country = countryController.GetCountry(comboBoxPcountry.SelectedItem.ToString());
                Region region = regionController.GetRegion(comboBoxPregion.SelectedItem.ToString(), country);
                City city = cityController.GetCity(comboBoxPcity.SelectedItem.ToString(), region);
                List<Address> addresses = addressController.FindByCountryAndRegionAndCity(country, region, city);

                checkedListBoxPaddresses.Items.Clear();
                foreach (Address a in addresses)
                    checkedListBoxPaddresses.Items.Add(a.AddIndex + "," + a.Street.City.Region.Country.CountryName + "," + a.Street.City.Region.RegionName + "," + a.Street.City.CityName + "," + a.Street.StreetName + "," + a.House + "," + a.ApartmentNum);
            }
            else first2 = false;
        }

        private void comboBoxPcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!first3)
            {
                Country country = countryController.GetCountry(comboBoxPcountry.SelectedItem.ToString());
                Region region = regionController.GetRegion(comboBoxPregion.SelectedItem.ToString(), country);
                City city = cityController.GetCity(comboBoxPcity.SelectedItem.ToString(), region);
                List<Address> addresses = addressController.FindByCountryAndRegionAndCity(country, region, city);

                checkedListBoxPaddresses.Items.Clear();
                foreach (Address a in addresses)
                    checkedListBoxPaddresses.Items.Add(a.AddIndex + "," + a.Street.City.Region.Country.CountryName + "," + a.Street.City.Region.RegionName + "," + a.Street.City.CityName + "," + a.Street.StreetName + "," + a.House + "," + a.ApartmentNum);
            }
            else first3 = false;
        }
    }
}
