using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DolcheMilk
{
    public partial class News : Form
    {
        DataBase database = new DataBase();
        public News()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void News_Load(object sender, EventArgs e)
        {
            string querry = $"select Named, Post,Date from Newsi ORDER BY Date DESC";
            SqlCommand command = new SqlCommand(querry, database.getConnection());
            database.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            int yPosition = 34; // Начальная позиция по оси Y
            int number = 1;
            while (reader.Read())
            {
                System.Windows.Forms.Label labelNum = new System.Windows.Forms.Label();
                labelNum.Text = $"{number}";
                labelNum.Location = new Point(12, yPosition);
                labelNum.Font = new Font("Microsoft YaHei UI", 12, FontStyle.Bold);
                labelNum.MaximumSize = new Size(30, 0);
                labelNum.AutoSize = true;
                panel1.Controls.Add(labelNum);
                number++;

                System.Windows.Forms.Label labelName = new System.Windows.Forms.Label();
                labelName.Text = reader.GetString(0);
                labelName.Location = new Point(142, yPosition);
                labelName.Font = new Font("Microsoft YaHei UI", 12, FontStyle.Bold);
                labelName.MaximumSize = new Size(600, 0);
                labelName.AutoSize = true;
                panel1.Controls.Add(labelName);

                System.Windows.Forms.Label labelPost = new System.Windows.Forms.Label();
                labelPost.Text = reader.GetString(1);
                labelPost.Location = new Point(142, yPosition + 30);
                labelPost.Font = new Font("Microsoft YaHei UI", 12, FontStyle.Regular);
                labelPost.MaximumSize = new Size(600, 0);
                labelPost.AutoSize = true;
                panel1.Controls.Add(labelPost);

                System.Windows.Forms.Label labelDate = new System.Windows.Forms.Label();
                labelDate.Text = Convert.ToString(reader[2]); ;
                labelDate.Location = new Point(35, yPosition);
                labelDate.Font = new Font("Microsoft YaHei UI", 12, FontStyle.Regular);
                panel1.Controls.Add(labelDate);

          
                yPosition += labelPost.Height + 50;
            }
        }
    }
}
