using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Adressverwaltung

{
    public partial class Form1 : Form
    {

        static DataSet ds = new DataSet("Data");
        static DataTable table = new DataTable();



        public bool IsPostBack { get; private set; }

        public Form1()
        {
            InitializeComponent();

        }
        //protected void Page_Load(object sender, EventArgs e)

        //{

        //  if (!IsPostBack)

        //{

        //  ds = new DataSet();

        //ds.ReadXml(MapPath("adress.xml"));

        //dt = ds.Tables["Data"];

        //}

        //        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void Lastname_Click(object sender, EventArgs e)
        {

        }

        private void save_Click_1(object sender, EventArgs e)
        {
            if (firstname.Text != "" || lastname.Text != "" || mailaddress.Text != "" || phonenumber.Text != "" || street.Text != "" || housenumber.Text != "" || postalcode.Text != "" || city.Text != "")
            {
                SaveXML();
                MessageBox.Show("Vielen Dank. Ihre Adressdaten wurden gespeichert");
            }
            else
            {
                MessageBox.Show("Bitte alle Felder ausfüllen", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void SaveXML()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("H:/Documents/Adressverwaltung-master/Adressverwaltung-master/adress.xml");
            XmlNode address = doc.CreateElement("adresse");
            XmlNode Firstname = doc.CreateElement("Firstname");
            Firstname.InnerText = firstname.Text;
            address.AppendChild(Firstname);
            XmlNode Lastname = doc.CreateElement("Lastname");
            Lastname.InnerText = lastname.Text;
            address.AppendChild(Lastname);
            XmlNode Mail = doc.CreateElement("E-Mail");
            Mail.InnerText = mailaddress.Text;
            address.AppendChild(Mail);
            XmlNode Phone = doc.CreateElement("Phonenumber");
            Phone.InnerText = phonenumber.Text;
            address.AppendChild(Phone);
            XmlNode Street = doc.CreateElement("Street");
            Street.InnerText = street.Text;
            address.AppendChild(Street);
            XmlNode House = doc.CreateElement("House-Number");
            House.InnerText = housenumber.Text;
            address.AppendChild(House);
            XmlNode Postalcode = doc.CreateElement("Postcode");
            Postalcode.InnerText = postalcode.Text;
            address.AppendChild(Postalcode);
            XmlNode City = doc.CreateElement("City");
            City.InnerText = city.Text;
            address.AppendChild(City);
            doc.DocumentElement.AppendChild(address);
            doc.Save("H:/Documents/Adressverwaltung-master/Adressverwaltung-master/adress.xml");
        }

        private XmlReader MapPath(string v)
        {
            throw new NotImplementedException();
        }

        private void mailaddress_TextChanged(object sender, EventArgs e)
        {
            String UserEmail = mailaddress.Text;
            if (IsValidEmail(UserEmail))
            {
                label9.Text = "Diese E-Mail ist valide";
            }
            else
            {
                label9.Text = "Bítte eine gültige E-Mail angeben";
            }
        }
        public static bool IsValidEmail(string email)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            var regex = new Regex(pattern, RegexOptions.IgnoreCase);

            return regex.IsMatch(email);
        }

        private void search_TextChanged(object sender, EventArgs e)
        {

        }


        private void firstname_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }
        int nRow;
        
        private void show_Click(object sender, EventArgs e)
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(@"H:/Documents/Adressverwaltung-master/Adressverwaltung-master/adress.xml");
            dataGridView1.DataSource = dataSet.Tables[0];
            nRow = dataGridView1.CurrentCell.RowIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (nRow < dataGridView1.RowCount -1 && nRow != 0)
            {
                dataGridView1.Rows[nRow].Selected = false;
                dataGridView1.Rows[--nRow].Selected = true;
            }
            else
            {

            }
            
            
            
        }
        //int nRow;
        private void button2_Click(object sender, EventArgs e)
        {
            // nRow = dataGridView1.CurrentCell.RowIndex;
            if (nRow < dataGridView1.RowCount - 1 && !(nRow > dataGridView1.RowCount))
            {
                dataGridView1.Rows[nRow].Selected = false;
                dataGridView1.Rows[++nRow].Selected = true;
                
                }
                else
                {
                nRow = 0;
                dataGridView1.Rows[nRow].Selected = false;
                dataGridView1.Rows[0].Selected = true;

            }
            
            
        }
    }
}
