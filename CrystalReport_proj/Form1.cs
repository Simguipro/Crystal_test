using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;

namespace CrystalReport_proj
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            sqlcon();
            try
            {
               // DataTable ds = ds1.Tables["T"];
#if DEBUG
                MessageBox.Show("!");
#endif
                ReportDocument rdoc = new ReportDocument();
                rdoc.Load("CrystalReport1.rpt");
                rdoc.SetDataSource(ds1.Tables["DataTable1"]);
                rdoc.SetParameterValue("NO", "SG00956");
                crystalReportViewer1.ReportSource = rdoc;
            }
            catch (Exception)
            {
                
                throw;
            }
          


        }
        DataSet1 ds1=new DataSet1();
        private void sqlcon()
        {
            using (SqlConnection scon = new SqlConnection("Password=Simgui123;Persist Security Info=True;User ID=mes;Initial Catalog=Simgui;Data Source=192.168.0.13"))
            {
                if (scon.State!=ConnectionState.Open)
                {
                    scon.Open();
                }
                SqlCommand scom = new SqlCommand(@"SELECT     PM_UserList.UserN no, PM_UserList.UserName Area, PM_UserList.PWD f3, PM_UserList.Limit f4, PM_DEP.depart_name f5
FROM         PM_UserList INNER JOIN
                      PM_DEP ON PM_UserList.depart_num = PM_DEP.depart_n",scon);
                SqlDataAdapter sada=new SqlDataAdapter(scom);
                try
                {
                    sada.Fill(ds1.Tables["DataTable1"]);
                }
                catch (Exception)
                {
                    
                    throw;
                }
             
            }
            
            
        }
    }
}