using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace VERI_TABANLI_SECIM_PROJESI
{
    public partial class FrmOyGiris : Form
    {
        public FrmOyGiris()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection();
        private void BTNOYGİRİS_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into TBLILCE(ILCEAD,APARTI,BPARTI,CPARTI,DPARTI,EPARTI) VALUES (@P1,@P2,@P3,@P4,@P5,@P6)", conn);
            cmd.Parameters.AddWithValue("@P1",TXTILCEAD.Text);
            cmd.Parameters.AddWithValue("@P2", TXTAPARTI.Text);
            cmd.Parameters.AddWithValue("@P3", TXTBPARTI.Text);
            cmd.Parameters.AddWithValue("@P4", TXTCPARTI.Text);
            cmd.Parameters.AddWithValue("@P5", TXTDPARTI.Text);
            cmd.Parameters.AddWithValue("@P6", TXTEPARTI.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("oy kaydedildi");
        }

        private void BTNGARAFIKLER_Click(object sender, EventArgs e)
        {
            FrmGrafikler frm = new FrmGrafikler();
            frm.Show();
        }
    }
}
