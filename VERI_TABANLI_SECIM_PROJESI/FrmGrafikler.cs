using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VERI_TABANLI_SECIM_PROJESI
{
    public partial class FrmGrafikler : Form
    {
        public FrmGrafikler()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection();
        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select ILCEAD from TBLILCE",conn);
            SqlDataReader dr=cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            conn.Close();

            conn.Open();
            SqlCommand cmd2 = new SqlCommand("select SUM(APARTI),SUM(BPARTI),SUM(CPARTI),SUM(DPARTI),SUM(EPARTI) FROM TBLILCE", conn);
            SqlDataReader dr2 =cmd2.ExecuteReader();
            while (dr2.Read())
            {
                chart1.Series["PARTILER"].Points.AddXY("A PARTİ",dr2[0]);
                chart1.Series["PARTILER"].Points.AddXY("B PARTİ", dr2[1]);
                chart1.Series["PARTILER"].Points.AddXY("C PARTİ", dr2[2]);
                chart1.Series["PARTILER"].Points.AddXY("D PARTİ", dr2[3]);
                chart1.Series["PARTILER"].Points.AddXY("E PARTİ", dr2[4]);
            }
            conn.Close ();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open ();
            SqlCommand cmd3 = new SqlCommand("select * from TBLILCE where ILCEAD=@p1", conn);
            cmd3.Parameters.AddWithValue("@p1",comboBox1.Text);
            SqlDataReader dr3 =cmd3.ExecuteReader();
            while (dr3.Read())
            {
                progressBar1.Value = int.Parse(dr3[2].ToString());
                progressBar2.Value = int.Parse(dr3[3].ToString());
                progressBar3.Value = int.Parse(dr3[4].ToString());
                progressBar4.Value = int.Parse(dr3[5].ToString());
                progressBar5.Value = int.Parse(dr3[6].ToString());

                LBLA.Text= dr3[2].ToString();
                LBLB.Text= dr3[3].ToString();
                LBLC.Text= dr3[4].ToString();
                LBLD.Text= dr3[5].ToString();
                LBLE.Text= dr3[6].ToString();

            }
            conn.Close ();
        }
    }
}
