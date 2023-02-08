using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Form_task
{
    public class FileHelper
    {
        public static void WriteJsonHuman(Human human)
        {
            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter($"{human.Name}.json"))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                    serializer.Serialize(jw, human);
                }
            }
        }
    }
    public partial class Name : Form
    {
        public Name()
        {
            InitializeComponent();
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                                                                  Color.LightBlue,
                                                                  Color.Pink,
                                                                  90F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
        public bool Check { get; set; } = false;
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string gender = "";
            if (Maleradiobtn.Checked)
            {
                gender = Maleradiobtn.Text;
            }
            else if (Femaleradiobtn.Checked)
            {
                gender = Femaleradiobtn.Text;
            }
            if (Check)
            {
                this.BackColor = Color.Green;
                Human newhuman = new Human
                {
                    Name = NametextBox.Text,
                    Surname = SurnametextBox.Text,
                    Age = int.Parse(AgemaskedTextBox.Text),
                    Email = EmailtextBox.ToString(),
                    Gender = gender,
                    BirthDate = dateTimePicker.ToString()
                };
                MessageBox.Show("Succesfuly", "Form", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FileHelper.WriteJsonHuman(newhuman);
                Application.Exit();
            }
            else
            {
                this.BackColor = Color.Red;
            }
        }
        private void FormLbl_Click(object sender, EventArgs e)
        {

        }
        private void AgeLbl_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void EmailtextBox_TextChanged(object sender, EventArgs e)
        {
            if (!EmailtextBox.Text.Contains("@gmail.com"))
            {
                emailcheck.Text = "Email is invalid!";
                emailcheck.ForeColor = Color.Red;
            }
            else
            {
                emailcheck.Text = "";
                Check = true;
            }
        }
        private void NametextBox_TextChanged(object sender, EventArgs e)
        {
            if (NametextBox.Text.Length <= 0)
            {
                namechecklbl.Text = "Enter name!";
                namechecklbl.ForeColor = Color.Red;
            }
            else
            {
                namechecklbl.Text = "";
                Check = true;
            }
        }
        private void SurnametextBox_TextChanged(object sender, EventArgs e)
        {
            if (SurnametextBox.Text.Length <= 0)
            {
                surnamechecklbl.Text = "Enter surname!";
                surnamechecklbl.ForeColor = Color.Red;
            }
            else
            {
                surnamechecklbl.Text = "";
                Check = true;
            }
        }
        private void Name_Load(object sender, EventArgs e)
        {

        }
    }
    public class Human
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
    }
}
