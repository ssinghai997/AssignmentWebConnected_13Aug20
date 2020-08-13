using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace WebDataAccessConnectedAssign
{
    public partial class Players : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-OO42D65;Initial Catalog=AssignmentData;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader sdr;

        public void ShowData()
        {
            conn.Open();
            cmd = new SqlCommand("select * from Players", conn); 
            sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            sdr.Close();
            conn.Close();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowData();
            }
        }

        protected void btnInsertPlayer_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into Players(PlayerName, Sport) values('" + txtName.Text + "', '" + txtSport.Text + "')", conn);
            int y = cmd.ExecuteNonQuery();
            Label1.Text = "Player Name Inserted";
            conn.Close();
            ShowData();
        }

        protected void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnInsertSp_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("sp_InsertPlayers",conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PlayerName", SqlDbType.VarChar,20).Value = txtName.Text;
            cmd.Parameters.Add("@sport", SqlDbType.VarChar, 20).Value = txtSport.Text;
            cmd.ExecuteNonQuery();
            Label2.Text = "Player Name Inserted with Stored procedure";
            conn.Close();
            ShowData();
        }

        protected void btnInsertPara_Click(object sender, EventArgs e)
        {
            conn.Open();
            
            cmd = new SqlCommand("Insert into Players(PlayerName, Sport) values(@playername, @sport)", conn);
            cmd.Parameters.Add("@playername", SqlDbType.VarChar,20).Value = txtName.Text;
            cmd.Parameters.Add("@sport", SqlDbType.VarChar, 20).Value = txtSport.Text;
            

            if (cmd.ExecuteNonQuery() > 0)
            {
                Label3.Text = "Player Name Inserted with parameters";
            }

            conn.Close();
            ShowData();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Update Players set PlayerName='"+txtName.Text+"' where Sport = '"+txtSport.Text+"' ", conn);
            int y = cmd.ExecuteNonQuery();
            Label4.Text = "Player Name Updated";
            conn.Close();
            ShowData();
        }

        protected void btnUpdateUsingSp_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("sp_UpdatePlayer", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PlayerName", SqlDbType.VarChar, 20).Value = txtName.Text;
            cmd.Parameters.Add("@sport", SqlDbType.VarChar, 20).Value = txtSport.Text;
            cmd.ExecuteNonQuery();
            Label5.Text = "Player Name Updated using stored procedure" ;
            conn.Close();
            ShowData();

        }

        protected void btnUpdatePara_Click(object sender, EventArgs e)
        {
            conn.Open();

            cmd = new SqlCommand("update Players set playername=@playername where sport=@sport", conn);
            cmd.Parameters.Add("@playername", SqlDbType.VarChar, 20).Value = txtName.Text;
            cmd.Parameters.Add("@sport", SqlDbType.VarChar, 20).Value = txtSport.Text;


            if (cmd.ExecuteNonQuery() > 0)
            {
                Label6.Text = "Player Name Updated using parameters";
            }

            conn.Close();
            ShowData();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("delete from Players where Playername='" + txtName.Text + "' ", conn);
            cmd.ExecuteNonQuery();
            Label7.Text = "Player Name Deleted";
            conn.Close();
            ShowData();
        }

        protected void btnDeleteWithSp_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("sp_Deleteplayer", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@playername", SqlDbType.VarChar,20).Value = txtName.Text;
            cmd.ExecuteNonQuery();
            Label8.Text = "Player Name Deleted using Stored procedures";
            conn.Close();
            ShowData();
        }

        protected void btnDeletePara_Click(object sender, EventArgs e)
        {
            conn.Open();

            cmd = new SqlCommand("delete from players where playername=@playername", conn);
            cmd.Parameters.Add("@playername", SqlDbType.VarChar, 20).Value = txtName.Text;
            cmd.Parameters.Add("@sport", SqlDbType.VarChar, 20).Value = txtSport.Text;


            if (cmd.ExecuteNonQuery() > 0)
            {
                Label9.Text = "Player Name deleted using parameters";
            }

            conn.Close();
            ShowData();
        }
    }
    
}