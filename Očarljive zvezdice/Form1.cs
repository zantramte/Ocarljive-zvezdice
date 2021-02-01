using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Očarljive_zvezdice
{
    public partial class Form1 : Form
    {
        WindowsMediaPlayer Player = new WindowsMediaPlayer();
        WindowsMediaPlayer Player_2 = new WindowsMediaPlayer();

        public void Uredi_vse_zvezdice()
        {
            Zvezde.Zvezdice.Clear();
            Zvezde.Vrni_prvo();
            Zvezde.Vrni_drugo();
            Zvezde.Rezultat = Zvezde.Prvo_stevilo * Zvezde.Drugo_stevilo;
            label1.Text = Zvezde.Rezultat + " ÷ " + Zvezde.Drugo_stevilo;

            for (int indeks = 0; indeks < panel1.Controls.Count; indeks++)
            {
                if ((panel1.Controls[indeks] is Label) && (panel1.Controls[indeks].Location.Y < 670))
                {
                    panel1.Controls[indeks].Text = Convert.ToString(Zvezde.Nakljucno.Next(0, 101));
                    Zvezde.Zvezdice.Add(panel1.Controls.IndexOf(panel1.Controls[indeks]));
                }
            }

            if ((Zvezde.Rezultat >= 10) && (Zvezde.Drugo_stevilo < 10))
            {
                label1.Location = new Point(275, 676);
            }

            if ((Zvezde.Rezultat < 10) && (Zvezde.Drugo_stevilo < 10))
            {
                label1.Location = new Point(285, 677);
            }

            if ((Zvezde.Rezultat >= 10) && (Zvezde.Prvo_stevilo >= 10))
            {
                label1.Location = new Point(260, 677);
            }

            Zvezde.Sedaj = Zvezde.Nakljucno.Next(Zvezde.Zvezdice.Count);

            panel1.Controls[Zvezde.Sedaj].Text = Convert.ToString(Zvezde.Prvo_stevilo);
        }

        public Form1()
        {
            InitializeComponent();

            Show();
            Player.URL = "morje.mp3";
            MessageBox.Show("POZDRAV! Z nami boš vadil/a deljenje do 100! Izberi zvezdico s pravim razultatom!", "Zvezdice sporočajo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Player_2.URL = "morjee.mp3";
            Player_2.settings.setMode("loop", true);
            Player_2.settings.volume = 50;
            Uredi_vse_zvezdice();
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            Player.URL = "smeh.mp3";
            PictureBox zvezdica = sender as PictureBox;
            zvezdica.Image = Properties.Resources.z2;
            Cursor = Cursors.Hand;

            for (int indeks = 0; indeks < panel1.Controls.Count; indeks++)
            {
                if ((panel1.Controls[indeks] is Label) && (panel1.Controls[indeks].Location.X == (zvezdica.Location.X + 54)))
                {
                    panel1.Controls[indeks].ForeColor = Color.FromArgb(231, 66, 73);
                }
            }
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            PictureBox zvezdica = sender as PictureBox;
            zvezdica.Image = Properties.Resources.z1;
            Cursor = Cursors.Default;

            for (int indeks = 0; indeks < panel1.Controls.Count; indeks++)
            {
                if ((panel1.Controls[indeks] is Label) && (panel1.Controls[indeks].Location.X == (zvezdica.Location.X + 54)))
                {
                    panel1.Controls[indeks].ForeColor = Color.White;
                }
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Player.URL = "next.mp3";
            Uredi_vse_zvezdice();
        }

        private void pictureBox8_MouseEnter(object sender, EventArgs e)
        {
            pictureBox8.Image = Properties.Resources.s33;
            Cursor = Cursors.Hand;
        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            pictureBox8.Image = Properties.Resources.s3;
            Cursor = Cursors.Default;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            PictureBox zvezdica = sender as PictureBox;

            for (int indeks = 0; indeks < panel1.Controls.Count; indeks++)
            {
                if ((panel1.Controls[indeks] is Label) && (panel1.Controls[indeks].Location.X == (zvezdica.Location.X + 54)))
                {
                    Zvezde.Prvo_stevilo = Convert.ToInt32(panel1.Controls[indeks].Text);

                    if (Zvezde.Preveri_zvezdo() == true)
                    {
                        Player.URL = "prav.mp3";
                        MessageBox.Show("BRAVO! Odlično ti gre!", "Zvezdica sporoča", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Uredi_vse_zvezdice();
                    }

                    else
                    {
                        Player.URL = "wrong.mp3";
                        MessageBox.Show("HMMMM! Ne bo držalo!", "Zvezdica sporoča", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Uredi_vse_zvezdice();
                    }
                }
            }
        }
    }
}
