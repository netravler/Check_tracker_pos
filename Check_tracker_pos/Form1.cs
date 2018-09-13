using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace Check_tracker_pos
{
    public partial class check_tracker_pos : Form
    {
        public check_tracker_pos()
        {
            InitializeComponent();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
 
        }

        void check_tracker_pos_Load(object sender, EventArgs e)
        {
            // transaction history
             DataSet ds = new DataSet("Info");
            DataTable dt = new DataTable("Record");

            string xsd = @"c:\pos\transaction.xsd";
            string xml = @"c:\pos\transaction.xml";

            if (!File.Exists(xsd))
            {
                dt.Columns.Add("Sequence");
                dt.Columns.Add("TransID");
                ds.Tables.Add(dt);

                ds.WriteXmlSchema(xsd);
                ds.WriteXml(xml);
            }
            else
            {
                ds.ReadXmlSchema(xsd);
                ds.ReadXml(xml);
            }

            //Binds datagrid
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "TransactionHistory"; 
            
            // Items
            DataSet ds1 = new DataSet("Info");
            DataTable dt1 = new DataTable("Record");

            string xsd1 = @"c:\pos\Items.xsd";
            string xml1 = @"c:\pos\Items.xml";

            if (!File.Exists(xsd))
            {
                dt1.Columns.Add("Sequence");
                dt1.Columns.Add("ItemNumber");
                ds1.Tables.Add(dt1);

                ds1.WriteXmlSchema(xsd1);
                ds1.WriteXml(xml1);
            }
            else
            {
                ds1.ReadXmlSchema(xsd1);
                ds1.ReadXml(xml1);
            }

            //Binds datagrid
            dataGridView3.DataSource = ds1;
            dataGridView3.DataMember = "Items"; 

            // Ticket
            DataSet ds2 = new DataSet("Info");
            DataTable dt2 = new DataTable("Record");

            string xsd2 = @"c:\pos\Ticket.xsd";
            //string xml2 = @"c:\pos\Items.xml";

            if (!File.Exists(xsd))
            {
                dt2.Columns.Add("Sequence");
                dt2.Columns.Add("ItemNumber");
                ds2.Tables.Add(dt2);

                ds2.WriteXmlSchema(xsd2);
                //ds2.WriteXml(xml2);
            }
            else
            {
                ds2.ReadXmlSchema(xsd2);
                //ds1.ReadXml(xml2);
            }

            //Binds datagrid
            dataGridView2.DataSource = ds2;
            dataGridView2.DataMember = "Ticket"; 
            

        }

        private void lblTransHistory_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
 
        }

        void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataSet ds = (DataSet)dataGridView1.DataSource;
            ds.WriteXml(@"c:\pos\transaction.xml", XmlWriteMode.IgnoreSchema);
        }

        void dataGridView3_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataSet ds1 = (DataSet)dataGridView1.DataSource;
            ds1.WriteXml(@"c:\pos\Items.xml", XmlWriteMode.IgnoreSchema);
        }
    }
}
