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
using Microsoft.SqlServer.Server;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AppdevWeek8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        public static string sqlconnection = "server=localhost;uid=root;pwd=;database=premier_league";
        public MySqlCommand sqlcommand;
        public MySqlDataAdapter sqladapter;
        public string sqlQuery;
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        DataTable dt4 = new DataTable();
        DataTable dt5 = new DataTable();
        DataTable dt6 = new DataTable();
        DataTable dt7 = new DataTable();
        DataTable dt8 = new DataTable();

        private void playerDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sqlQuery = "SELECT team_name as 'nama team' , team_id as 'id team' FROM team ;";
            MySqlConnection sqlconnect = new MySqlConnection(sqlconnection);
            sqlcommand = new MySqlCommand(sqlQuery, sqlconnect);
            sqladapter = new MySqlDataAdapter(sqlcommand);
            sqladapter.Fill(dt1);
            comboBox1.DataSource = dt1;
            comboBox1.DisplayMember = "nama team";
            comboBox1.ValueMember = "id team";
            
            comboBox3.Visible = false;
            comboBox4.Visible = false;
            comboBox1.Visible = true;
            comboBox2.Visible = true;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            comboBox4.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;
            label21.Visible = false;
            label22.Visible = false;
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            sqlQuery = $"SELECT p.player_name as 'nama player', p.player_id as 'id player' FROM player p,team t where t.team_id = p.team_id and p.team_id = '{comboBox1.SelectedValue.ToString()}';";
            MySqlConnection sqlconnect = new MySqlConnection(sqlconnection);
            sqlcommand = new MySqlCommand(sqlQuery, sqlconnect);
            sqladapter = new MySqlDataAdapter(sqlcommand);
            sqladapter.Fill(dt2);
            comboBox2.DataSource = dt2;
            comboBox2.DisplayMember = "nama player";
            comboBox2.ValueMember = "id player";
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dt3 = new DataTable();
            dt4 = new DataTable();
            sqlQuery = $"SELECT p.player_name as 'nama player', t.team_name as 'nama team',p.playing_pos as 'posisi', p.team_number as 'nomor team', n.nation as 'nationality' from player p,nationality n,team t where t.team_id = p.team_id and p.nationality_id = n.nationality_id and p.player_id = '{comboBox2.SelectedValue.ToString()}';";
            MySqlConnection sqlconnect = new MySqlConnection(sqlconnection);
            sqlcommand = new MySqlCommand(sqlQuery, sqlconnect);
            sqladapter = new MySqlDataAdapter(sqlcommand);
            sqladapter.Fill(dt3);
            label10.Text = dt3.Rows[0][0].ToString();
            label11.Text = dt3.Rows[0][1].ToString();
            label12.Text = dt3.Rows[0][4].ToString();
            label13.Text = dt3.Rows[0][2].ToString();
            label14.Text = dt3.Rows[0][3].ToString();

            // CY = yellow card
            // GO = Goal
            // GW = OWN GOAL
            // CR = red card
            // GP = Goal Penalty
            sqlQuery = $"select ifnull(sum(if(d.`type` = 'GO',1,0)),0) as 'Goal',ifnull(sum(if(d.`type` = 'GP',1,0)),0) as 'Goal Penalty',ifnull(sum(if(d.`type` = 'GW',1,0)),0) as 'Own Goal' ,ifnull(sum(if(d.`type` = 'CY',1,0)),0) as 'Yellow Card',ifnull(sum(if(d.`type` = 'CR',1,0)),0) as 'Red Card',ifnull(sum(if(d.`type` = 'PM',1,0)),0) as 'Penalty Missed' from player p, dmatch d where p.player_id = d.player_id and p.player_id = '{comboBox2.SelectedValue.ToString()}';";
            sqlcommand = new MySqlCommand(sqlQuery, sqlconnect);
            sqladapter = new MySqlDataAdapter(sqlcommand);
            sqladapter.Fill(dt4);
            label16.Text = dt4.Rows[0][3].ToString();
            label17.Text = dt4.Rows[0][4].ToString();
            label19.Text = dt4.Rows[0][2].ToString();
            label20.Text = dt4.Rows[0][1].ToString();
            label21.Text = dt4.Rows[0][5].ToString();
            label18.Text = dt4.Rows[0][0].ToString();

            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
            label13.Visible = true;
            label14.Visible = true;
            label15.Visible = true;
            label16.Visible = true;
            label17.Visible = true;
            label18.Visible = true;
            label19.Visible = true;
            label20.Visible = true;
            label21.Visible = true;
            label22.Visible = true;
        }

        private void showMatchDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;
            label21.Visible = false;
            label22.Visible = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = true;
            comboBox4.Visible = true;
            sqlQuery = "SELECT team_name as 'nama team' , team_id as 'id team' from team;";
            MySqlConnection sqlconnect = new MySqlConnection(sqlconnection);
            sqlcommand = new MySqlCommand(sqlQuery, sqlconnect);
            sqladapter = new MySqlDataAdapter(sqlcommand);
            sqladapter.Fill(dt1);
            comboBox3.DataSource = dt1;
            comboBox3.DisplayMember = "nama team";
            comboBox3.ValueMember = "id team";
        }

        private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            sqlQuery = $"SELECT m.match_id as 'id match' from `match` m, dmatch d where m.team_home = '{comboBox3.SelectedValue.ToString()}' or m.team_away = '{comboBox3.SelectedValue.ToString()}';";
            MySqlConnection sqlconnect = new MySqlConnection(sqlconnection);
            sqlcommand = new MySqlCommand(sqlQuery, sqlconnect);
            sqladapter = new MySqlDataAdapter(sqlcommand);
            sqladapter.Fill(dt5);
            comboBox4.DataSource = dt5;
            comboBox4.DisplayMember = "id match";
            comboBox4.ValueMember = "id match";
        }

        private void comboBox4_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dataGridView2.Visible = true;
            dataGridView3.Visible = true;
            MySqlConnection sqlconnect = new MySqlConnection(sqlconnection);
            dt6 = new DataTable();
            dt7 = new DataTable();

            //sqlQuery = $"select t.team_name as 'Team Home', t1.team_name as 'Team Away', p.player_name as 'Player Home', p1.player_name as 'Player Away' from match m, team t, team t1, player p, player p1 where p.team_id = t.team_id and p1.team_id = t.team_id and p.team_id = t1.team_id and p1.team_id = t1.team_id and m.team_home = t.team_id or m.team_away = t1.team_id; and t.team_id = '{comboBox3.SelectedValue.ToString()}' or t1.team_id = '{comboBox3.SelectedValue.ToString()}'; ";
            //sqlcommand = new MySqlCommand(sqlQuery, sqlconnect);
            //sqladapter = new MySqlDataAdapter(sqlcommand);
            //sqladapter.Fill(dt6);
            //dataGridView1.DataSource = dt6;

            sqlQuery = $"select t.team_name as'teamhome',p.player_name as'playerhome',p.playing_pos as'pos' from `match` m,team t, player p where  p.team_id = t.team_id and t.team_id = m.team_home and m.match_id = '{comboBox4.SelectedValue.ToString()}' ; ";
            sqlcommand = new MySqlCommand(sqlQuery, sqlconnect);
            sqladapter = new MySqlDataAdapter(sqlcommand);
            sqladapter.Fill(dt6);
            dataGridView1.DataSource = dt6;

            sqlQuery = $"select t.team_name as'teamaway',p.player_name as'playeraway',p.playing_pos as'pos' from `match` m,team t, player p where  p.team_id = t.team_id and t.team_id = m.team_away and m.match_id = '{comboBox4.SelectedValue.ToString()}' ; ";
            sqlcommand = new MySqlCommand(sqlQuery, sqlconnect);
            sqladapter = new MySqlDataAdapter(sqlcommand);
            sqladapter.Fill(dt7);
            dataGridView2.DataSource = dt7;

            sqlQuery = $"select d.`minute` as 'Waktu',p.player_name as 'player name',t.team_name as 'nama team' ,if(d.type='CY','Yellow Card',if(d.type='CR','Red Card',if(d.type='GO','Goal',if(d.type='GW','OwnGoal',if(d.type='Gp','Goal Penalty','Penalty Miss'))))) as 'Cards' from dmatch d, player p, team t where d.team_id = t.team_id and p.player_id = d.player_id and d.match_id = '{comboBox4.SelectedValue.ToString()}' ; ";
            sqlcommand = new MySqlCommand(sqlQuery, sqlconnect);
            sqladapter = new MySqlDataAdapter(sqlcommand);
            sqladapter.Fill(dt8);
            dataGridView3.DataSource = dt8;
        }
    }
}
