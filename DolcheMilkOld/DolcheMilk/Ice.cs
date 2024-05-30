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
    public partial class Ice : Form
    {
        DataBase database = new DataBase();
        public Ice()
        {
            InitializeComponent();
        }

        private void Ice_Load(object sender, EventArgs e)
        {
            string querry = $"select Name, Format,Fat, SG, Photo, Type from Milk where Type= 'Мороженое'";
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
                picture.Location = new Point(80, yPosition);
                picture.Size = new Size(140, 200);
                picture.SizeMode = PictureBoxSizeMode.Zoom;
                panel1.Controls.Add(picture);

                System.Windows.Forms.Label labelName = new System.Windows.Forms.Label();
                labelName.Text = reader.GetString(0);
                labelName.Location = new Point(235, yPosition);
                labelName.Font = new Font("Arial", 14, FontStyle.Bold);
                labelName.MaximumSize = new Size(220, 0);
                labelName.AutoSize = true;
                panel1.Controls.Add(labelName);

                System.Windows.Forms.Label labelFormat = new System.Windows.Forms.Label();
                labelFormat.Text = "Формат:" + reader.GetString(1);
                labelFormat.Location = new Point(444, yPosition);
                labelFormat.Font = new Font("Arial", 14, FontStyle.Bold);
                labelFormat.MaximumSize = new Size(220, 0);
                labelFormat.AutoSize = true;
                panel1.Controls.Add(labelFormat);

                System.Windows.Forms.Label labelFat = new System.Windows.Forms.Label();
                labelFat.Text = "Жирность:" + reader.GetInt32(2).ToString() + "%";
                labelFat.Location = new Point(444, yPosition + 30);
                labelFat.Font = new Font("Arial", 14, FontStyle.Bold);
                labelFat.MaximumSize = new Size(220, 0);
                labelFat.AutoSize = true;
                panel1.Controls.Add(labelFat);

                System.Windows.Forms.Label labelSG = new System.Windows.Forms.Label();
                labelSG.Text = "Срок годности:" + reader.GetInt32(3).ToString();
                labelSG.Location = new Point(444, yPosition + 60);
                labelSG.Font = new Font("Arial", 14, FontStyle.Bold);
                labelSG.MaximumSize = new Size(220, 0);
                labelSG.AutoSize = true;
                panel1.Controls.Add(labelSG);

                System.Windows.Forms.Label labelType = new System.Windows.Forms.Label();
                labelType.Text = reader.GetString(5);
                labelType.Location = new Point(670, yPosition);
                labelType.Font = new Font("Arial", 14, FontStyle.Bold);
                labelType.MaximumSize = new Size(450, 0);
                labelType.AutoSize = true;
                panel1.Controls.Add(labelType);


                yPosition += picture.Height + 20;
            }
        }
    }
}
