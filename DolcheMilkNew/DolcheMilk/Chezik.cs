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
    public partial class Chezik : Form
    {
        DataBase database = new DataBase();
        public Chezik()
        {
            InitializeComponent();
        }

        private void Chezik_Load(object sender, EventArgs e)
        {
            string querry = $"select Name, Weight,Fat, Post, Photo from Cheese";
            SqlCommand command = new SqlCommand(querry, database.getConnection());
            database.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            int yPosition = 40; // Начальная позиция по оси Y
            int number = 1;
            while (reader.Read())
            {
                System.Windows.Forms.Label labelNum = new System.Windows.Forms.Label();
                labelNum.Text = $"{number}";
                labelNum.Location = new Point(12, yPosition);
                labelNum.Font = new Font("Arial", 14, FontStyle.Bold);
                labelNum.MaximumSize = new Size(30, 0);
                labelNum.AutoSize = true;
                panel1.Controls.Add(labelNum);
                number++;

                System.Windows.Forms.PictureBox picture = new System.Windows.Forms.PictureBox();
                var imageData = (byte[])reader["Photo"];
                var memoryStream = new MemoryStream(imageData);
                picture.Image = Image.FromStream(memoryStream);
                picture.Location = new Point(70, yPosition);
                picture.Size = new Size(150,100) ;
                picture.SizeMode = PictureBoxSizeMode.StretchImage;
                panel1.Controls.Add(picture);

                System.Windows.Forms.Label labelName = new System.Windows.Forms.Label();
                labelName.Text = reader.GetString(0);
                labelName.Location = new Point(235, yPosition);
                labelName.Font = new Font("Arial", 14, FontStyle.Bold);
                labelName.MaximumSize = new Size(220, 0);
                labelName.AutoSize = true;
                panel1.Controls.Add(labelName);

                System.Windows.Forms.Label labelWeight = new System.Windows.Forms.Label();
                labelWeight.Text = "Вес:" + reader.GetInt32(1).ToString() + "g";
                labelWeight.Location = new Point(420, yPosition);
                labelWeight.Font = new Font("Arial", 14, FontStyle.Bold);
                labelWeight.MaximumSize = new Size(220, 0);
                labelWeight.AutoSize = true;
                panel1.Controls.Add(labelWeight);

                System.Windows.Forms.Label labelFat = new System.Windows.Forms.Label();
                labelFat.Text = "Жирность:" + reader.GetInt32(2).ToString() + "%";
                labelFat.Location = new Point(420, yPosition + 30);
                labelFat.Font = new Font("Arial", 14, FontStyle.Bold);
                labelFat.MaximumSize = new Size(220, 0);
                labelFat.AutoSize = true;
                panel1.Controls.Add(labelFat);

                System.Windows.Forms.Label labelPost = new System.Windows.Forms.Label();
                labelPost.Text = reader.GetString(3);
                labelPost.Location = new Point(570, yPosition );
                labelPost.Font = new Font("Arial", 14, FontStyle.Bold);
                labelPost.MaximumSize = new Size(225, 0);
                labelPost.AutoSize = true;
                panel1.Controls.Add(labelPost);

               


                yPosition += labelPost.Height + 20;
            }

        }
    }
}

