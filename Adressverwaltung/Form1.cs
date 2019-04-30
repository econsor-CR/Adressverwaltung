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

namespace Adressverwaltung
{
    public partial class Form1 : Form
    {
        static DataSet ds;
        static DataTable dt;
        static DataRow dr;

        public bool IsPostBack { get; private set; }

        public Form1()
        {
            InitializeComponent();

        }
        protected void Page_Load(object sender, EventArgs e)

        {

            if (!IsPostBack)

            {

                ds = new DataSet();

                ds.ReadXml(MapPath("data.xml"));

                dt = ds.Tables["student"];

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Lastname_Click(object sender, EventArgs e)
        {

        }

        private void save_Click(object sender, EventArgs e)
        {

            dr = dt.NewRow();//System.NullReferenceException: "Der Objektverweis wurde nicht auf eine Objektinstanz festgelegt."

            dr["Firstname"] = firstname.Text;

            dr["Lastname"] = Lastname.Text;

            dr["E-Mail"] = mailaddress.Text;

            dr["Telefon"] = phonenumber.Text;

            dr["Straße"] = street.Text;

            dr["Hausnummer"] = housenumber.Text;

            dr["Postleitzahl"] = Postcode.Text;

            dr["Ort"] = city.Text;

            dt.Rows.Add(dr);

            XmlTextWriter xmlSave = new XmlTextWriter("./Adressverwaltung/adress.xml", Encoding.UTF8);
            xmlSave.Formatting = Formatting.Indented;
            ds.DataSetName = "Data";
            ds.WriteXml(xmlSave);
            xmlSave.Close();
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

        private void label10_Click(object sender, EventArgs e)
        {
            ds = new DataSet();

            ds.ReadXml(MapPath("data.xml"));

            dt = ds.Tables["student"];
        }
    }
}
