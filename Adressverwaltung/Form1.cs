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

namespace Adressverwaltung

{
    public partial class Form1 : Form
    {

        static DataSet ds = new DataSet ("Data");
        static DataTable table = new DataTable ();

        

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

            if (!File.Exists("H:/Documents/Adressverwaltung-master/adress.xml"))
            {
                XmlWriter xmlWriter = XmlWriter.Create("H:/Documents/Adressverwaltung-master/adress.xml");
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("users");
                xmlWriter.WriteStartElement("adresse");

                xmlWriter.WriteStartElement("Firstname");
                xmlWriter.WriteString(firstname.Text);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("Lastname");
                xmlWriter.WriteString(lastname.Text);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("E-Mail");
                xmlWriter.WriteString(mailaddress.Text);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("Phonenumber");
                xmlWriter.WriteString(phonenumber.Text);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("Street");
                xmlWriter.WriteString(street.Text);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("House-Number");
                xmlWriter.WriteString(housenumber.Text);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("Postcode");
                xmlWriter.WriteString(Postcode.Text);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("City");
                xmlWriter.WriteString(city.Text);
                xmlWriter.WriteEndDocument();
                xmlWriter.Close();
            }
            else
            {
                XDocument xDocument = XDocument.Load("H:/Documents/Adressverwaltung-master/adress.xml");
                XElement root = xDocument.Element("users");
                IEnumerable<XElement> rows = root.Descendants("adresse");
                XElement firstRow = xDocument.Element("City");
                xDocument.Add(
                   new XElement("adresse",
                   new XElement("Firstname", firstname.Text),
                   new XElement("Lastname", lastname.Text),
                   new XElement("E-Mail", mailaddress.Text),
                   new XElement("Phonenumber", phonenumber.Text),
                   new XElement("Street", street.Text),
                   new XElement("House-Number", housenumber.Text),
                   new XElement("Postcode", Postcode.Text),
                   new XElement("City", city.Text)));


                xDocument.Save("H:/Documents/Adressverwaltung-master/adress.xml");
            }


        }

        private XmlReader MapPath(string v)
        {
            throw new NotImplementedException();
        }

        private void mailaddress_TextChanged_1(object sender, EventArgs e)
        {
            String UserEmail = mailaddress.Text;
            if (IsValidEmail(UserEmail))
            {
                label9.Text = "This email is correct formate";
            }
            else
            {
                label9.Text = "This email isn't correct formate";
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

       
    }
}
