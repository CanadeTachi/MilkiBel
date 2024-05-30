using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DolcheMilk
{
    public partial class Menu : Form
    {
        Catalog catalog;
        News news;
        History history;
        Contacts contacts;
        Ice ice;
        LearnForm learnForm;
        Info info;
        Chezik chiz;
        public Menu()
        {
            InitializeComponent();


        }
        bool menushka = false;
        bool informa = false;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timerMenuTrans.Start();

        }

        private void timerMenuTrans_Tick(object sender, EventArgs e)
        {
            if (menushka == false)
            {
                flowLayoutCatalog.Height += 10;
                if (flowLayoutCatalog.Height >= 163)
                {
                    timerMenuTrans.Stop();
                    menushka = true;
                }
            }
            else
            {
                flowLayoutCatalog.Height -= 10;
                if (flowLayoutCatalog.Height <= 57)
                {
                    timerMenuTrans.Stop();
                    menushka = false;
                }
            }
        }

        private void timerInfo_Tick(object sender, EventArgs e)
        {
            if (informa == false)
            {
                flowLayoutInfo.Height += 10;
                if (flowLayoutInfo.Height >= 163)
                {
                    timerInfo.Stop();
                    informa = true;
                }
            }
            else
            {
                flowLayoutInfo.Height -= 10;
                if (flowLayoutInfo.Height <= 57)
                {
                    timerInfo.Stop();
                    informa = false;
                }
            }
        }
        bool sidebar = true;
        private void timerSide_Tick(object sender, EventArgs e)
        {
            if (sidebar)
            {
                flowSide.Width -= 5;
                if (flowSide.Width <= 62)
                {
                    sidebar = false;
                    timerSide.Stop();

                }
            }
            else
            {
                flowSide.Width += 5;
                if (flowSide.Width >= 191)
                {
                    sidebar = true;
                    timerSide.Stop();

                }

            }
        }    
        


        private void btntree_Click(object sender, EventArgs e)
        {
            timerSide.Start();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            timerInfo.Start();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void IceCreamButton_Click(object sender, EventArgs e)
        {
            if (ice == null)
            {
                ice = new Ice();
                ice.FormClosed += Ice_FormClosed;
                ice.MdiParent = this;
                ice.Dock = DockStyle.Fill;
                ice.Show();
            }
            else
            {
                ice.Activate();
            }
        }
        private void Ice_FormClosed(object sender, FormClosedEventArgs e)
        {
            ice = null;
        }

        private void MilkButton_Click(object sender, EventArgs e)
        {
       
            if (catalog == null)
            {
                catalog = new Catalog();
                catalog.FormClosed += Catalog_FormClosed;
                catalog.MdiParent = this;
                catalog.Dock = DockStyle.Fill;
                catalog.Show();
            }
            else
            {
                catalog.Activate();
            }
        }
        private void Catalog_FormClosed(object sender, FormClosedEventArgs e)
        {
            catalog = null;
        }

        private void NovoButton_Click(object sender, EventArgs e)
        {
            if (news == null)
            {
                news = new News();
                news.FormClosed += News_FormClosed;
                news.MdiParent = this;
                news.Dock = DockStyle.Fill;
                news.Show();
            }
            else
            {
                news.Activate();
            }
        }
        private void News_FormClosed(object sender, FormClosedEventArgs e)
        {
            news = null;
        }

        private void ContrackButton_Click(object sender, EventArgs e)
        {
            if (contacts == null)
            {
                contacts = new Contacts();
                contacts.FormClosed += Contrack_FormClosed;
                contacts.MdiParent = this;
                contacts.Dock = DockStyle.Fill;
                contacts.Show();
            }
            else
            {
                contacts.Activate();
            }
        }
        private void Contrack_FormClosed(object sender, FormClosedEventArgs e)
        {
            contacts = null;
        }

        private void ObsheeButton_Click(object sender, EventArgs e)
        {
            if (history == null)
            {
                history = new History();
                history.FormClosed += News_FormClosed;
                history.MdiParent = this;
                history.Dock = DockStyle.Fill;
                history.Show();
            }
            else
            {
                history.Activate();
            }
        }
        private void History_FormClosed(object sender, FormClosedEventArgs e)
        {
            history = null;
        }

        private void LearningButton_Click(object sender, EventArgs e)
        {
            if (learnForm == null)
            {
                learnForm = new LearnForm();
                learnForm.FormClosed += Learn_FormClosed;
                learnForm.MdiParent = this;
                learnForm.Dock = DockStyle.Fill;
                learnForm.Show();
            }
            else
            {
                learnForm.Activate();
            }
        }
        private void Learn_FormClosed(object sender, FormClosedEventArgs e)
        {
            learnForm = null;
        }

        private void CheaseButton_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Goldenrod;
            flowSide.BackColor = Color.DarkGoldenrod;
            panel2.Visible = true;
            panel11.Visible = false;
            panelQuit.Visible = false;
            panelContact.Visible = false;
            panelNews.Visible = false;
            flowLayoutCatalog.Visible = false;
            flowLayoutInfo.Visible = false;
            label2.Text = "Империя Сыровичей | Частная сыроварня";
            button4.Visible = true;
            button8.Visible = true;
            button3.Visible = true;
        }

        private void buttonMilk_Click(object sender, EventArgs e)
        {
            panel1.BackColor = SystemColors.HotTrack;
            flowSide.BackColor = Color.FromArgb(0, 0, 64);
            panel2.Visible = false;
            panel11.Visible = true;
            panelQuit.Visible = true;
            panelContact.Visible = true;
            panelNews.Visible = true;
            flowLayoutCatalog.Visible = true;
            flowLayoutInfo.Visible = true;
            label2.Text = "MilkiБел | Молочная фабрика";
            button4.Visible = false;
            button8.Visible = false;
            button3.Visible = false;

        }


        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (chiz == null)
            {
                chiz = new Chezik();
                chiz.FormClosed += chiz_FormClosed;
                chiz.MdiParent = this;
                chiz.Dock = DockStyle.Fill;
                chiz.Show();
            }
            else
            {
                chiz.Activate();
            }
        }
        private void chiz_FormClosed(object sender, FormClosedEventArgs e)
        {
            chiz = null;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (info == null)
            {
                info = new Info();
                info.FormClosed += Info_FormClosed;
                info.MdiParent = this;
                info.Dock = DockStyle.Fill;
                info.Show();
            }
            else
            {
                info.Activate();
            }
        }
        private void Info_FormClosed(object sender, FormClosedEventArgs e)
        {
            info = null;
        }
    }
}
