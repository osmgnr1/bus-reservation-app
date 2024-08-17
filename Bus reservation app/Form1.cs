using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtobusOdevi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region FORM LOAD
        int xKoor;
        int yKoor;

        Label lbl = new Label();
        Label lblListBox = new Label();
        TextBox txt = new TextBox();
        ListBox ltBox = new ListBox();
        Button kaydet = new Button();

        Button[] btnTravego1;
        Button[] btnSafir1;
        Button[] btnRahat1;
        Button[] btnTravego11;
        Button[] btnSafir11;
        Button[] btnRahat11;

        private void Form1_Load(object sender, EventArgs e)
        {
            btnTravego11 = TravegoKoltukYarat(btnTravego1);
            btnSafir11 = SafirKoltukYarat(btnSafir1);
            btnRahat11 = RahatKoltukYarat(btnRahat1);

            lbl.Text = "Adı ve Soyadı:";
            lbl.Top = 50;
            lbl.Left = 325;
            lbl.AutoSize = true;
            this.Controls.Add(lbl);

            txt.Size = new Size(150, 60);
            txt.Top = lbl.Bottom + 10;
            txt.Left = lbl.Left;
            this.Controls.Add(txt);

            lblListBox.Text = "KAYITLAR";
            lblListBox.Size = new Size(75, 13);
            lblListBox.Top = txt.Bottom + 20;
            lblListBox.Left = lbl.Left;
            this.Controls.Add(lblListBox);

            ltBox.Size = new Size(400, 300);
            ltBox.Top = lblListBox.Bottom + 5;
            ltBox.Left = lbl.Left;
            this.Controls.Add(ltBox);

            kaydet.Size = new Size(60, 50);
            kaydet.Text = "KAYDET";
            kaydet.Top = lbl.Top;
            kaydet.Left = lbl.Left + 160;
            this.Controls.Add(kaydet);

            kaydet.Click += new EventHandler(kaydeteTikla);

        }
        #endregion

        #region KOLTUK SEÇİMİ VE KONTROL
        DialogResult dialog = new DialogResult();
        string seciliKoltuk;

        void Secim(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt.Text))
            {
                MessageBox.Show("Lütfen İsim soyisim giriniz.");
            }
            else
            {
                Button x = sender as Button;
                seciliKoltuk = x.Text;
                dialog = MessageBox.Show(seciliKoltuk + " nolu koltuğu onaylıyor musunuz?", "ONAY EKRANI", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    x.Enabled = false;
                    x.BackColor = Color.Red;
                    kaydet.Focus();

                }
                else
                {
                    MessageBox.Show("Tekrar koltuk seçimi yapınız.");
                    seciliKoltuk = null;
                }

            }

        }

        void CmbBoxKontrolu(object sender1, EventArgs b)
        {
            ComboBox cmb = sender1 as ComboBox;

            if (seciliKoltuk != null)
            {
                MessageBox.Show("Lütfen işlemi tamamlayınız..");
            }
            else
            {
                cmb.SelectedIndexChanged += new EventHandler(cbOtobusSec_SelectedIndexChanged);
            }
        }
        #endregion

        #region KOLTUK GETİRME
        private void cbOtobusSec_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (cbOtobusSec.SelectedItem)
            {
                case "Travego":
                    foreach (Control item in this.Controls)
                    {
                        if (item is Button && item.Text != "KAYDET")
                        {
                            item.Visible = false;
                        }
                    }
                    for (int i = 0; i < 46; i++)
                    {
                        btnTravego11[i].Visible = true;
                    }
                    break;
                case "Safir":
                    foreach (Control item in this.Controls)
                    {
                        if (item is Button && item.Text != "KAYDET")
                        {
                            item.Visible = false;
                        }
                    }
                    for (int i = 0; i < 54; i++)
                    {
                        btnSafir11[i].Visible = true;
                    }
                    break;
                case "Rahat":
                    foreach (Control item in this.Controls)
                    {
                        if (item is Button && item.Text != "KAYDET")
                        {
                            item.Visible = false;
                        }
                    }
                    for (int i = 0; i < 37; i++)
                    {
                        btnRahat11[i].Visible = true;
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region TRAVEGO KOLTUK YARAT
        Button[] TravegoKoltukYarat(Button[] btnTravego)
        {
            xKoor = 40;
            yKoor = 40;
            btnTravego = new Button[46];

            //Orta Kapı hizası olan 20 e kadar
            for (int i = 1; i < 23; i++)
            {

                xKoor += 40;
                btnTravego[i - 1] = new Button();
                btnTravego[i - 1].Text += i;

                Size boyut = new Size(30, 30);
                btnTravego[i - 1].Size = boyut;

                if (i % 4 == 0)
                {
                    btnTravego[i - 1].Location = new Point(xKoor, yKoor);
                    this.Controls.Add(btnTravego[i - 1]);
                    xKoor = 40;
                    yKoor += 40;
                }
                else
                {
                    if (i % 2 == 0 && i % 4 == 2)
                    {
                        btnTravego[i - 1].Location = new Point(xKoor, yKoor);
                        this.Controls.Add(btnTravego[i - 1]);
                        xKoor += 30;
                    }
                    else
                    {
                        btnTravego[i - 1].Location = new Point(xKoor, yKoor);
                        this.Controls.Add(btnTravego[i - 1]);
                    }
                }

                btnTravego[i - 1].Visible = false;
                btnTravego[i - 1].Click += new EventHandler(Secim);
            }

            //Orta Kapı hizası olan 21 den sonrası
            xKoor = 40;
            yKoor += 40;

            for (int i = 23; i < 47; i++)
            {
                xKoor += 40;
                btnTravego[i - 1] = new Button();
                btnTravego[i - 1].Text += i;
                Size boyut = new Size(30, 30);
                btnTravego[i - 1].Size = boyut;

                if (i % 2 == 0 && i % 4 == 2)
                {
                    btnTravego[i - 1].Location = new Point(xKoor, yKoor);
                    this.Controls.Add(btnTravego[i - 1]);
                    xKoor = 40;
                    yKoor += 40;
                }
                else
                {
                    if (i % 4 == 0)
                    {

                        btnTravego[i - 1].Location = new Point(xKoor, yKoor);
                        this.Controls.Add(btnTravego[i - 1]);
                        xKoor += 30;
                    }
                    else
                    {
                        btnTravego[i - 1].Location = new Point(xKoor, yKoor);
                        this.Controls.Add(btnTravego[i - 1]);
                    }
                }
                btnTravego[i - 1].Visible = false;
                btnTravego[i - 1].Click += new EventHandler(Secim);
            }
            return btnTravego;
        }
        #endregion

        #region SAFİR KOLTUK YARAT
        Button[] SafirKoltukYarat(Button[] btnSafir)
        {
            xKoor = 40;
            yKoor = 40;

            btnSafir = new Button[54];
            //Orta Kapı hizası olan 28 e kadar
            for (int i = 1; i < 31; i++)
            {
                xKoor += 40;
                btnSafir[i - 1] = new Button();
                btnSafir[i - 1].Text += i;
                Size boyut = new Size(30, 30);
                btnSafir[i - 1].Size = boyut;


                if (i % 4 == 0)
                {
                    btnSafir[i - 1].Location = new Point(xKoor, yKoor);
                    this.Controls.Add(btnSafir[i - 1]);
                    xKoor = 40;
                    yKoor += 40;
                }
                else
                {
                    if (i % 2 == 0 && i % 4 == 2)
                    {

                        btnSafir[i - 1].Location = new Point(xKoor, yKoor);
                        this.Controls.Add(btnSafir[i - 1]);
                        xKoor += 30;
                    }
                    else
                    {
                        btnSafir[i - 1].Location = new Point(xKoor, yKoor);
                        this.Controls.Add(btnSafir[i - 1]);
                    }
                }
                btnSafir[i - 1].Visible = false;
                btnSafir[i - 1].Click += new EventHandler(Secim);
            }

            //Orta Kapı hizası olan 28 den sonrası
            xKoor = 40;
            yKoor += 40;

            for (int i = 31; i < 55; i++)
            {
                xKoor += 40;
                btnSafir[i - 1] = new Button();
                btnSafir[i - 1].Text += i;
                Size boyut = new Size(30, 30);
                btnSafir[i - 1].Size = boyut;

                if (i % 2 == 0 && i % 4 == 2)
                {
                    btnSafir[i - 1].Location = new Point(xKoor, yKoor);
                    this.Controls.Add(btnSafir[i - 1]);
                    xKoor = 40;
                    yKoor += 40;
                }
                else
                {
                    if (i % 4 == 0)
                    {

                        btnSafir[i - 1].Location = new Point(xKoor, yKoor);
                        this.Controls.Add(btnSafir[i - 1]);
                        xKoor += 30;
                    }
                    else
                    {
                        btnSafir[i - 1].Location = new Point(xKoor, yKoor);
                        this.Controls.Add(btnSafir[i - 1]);
                    }
                }

                btnSafir[i - 1].Visible = false;
                btnSafir[i - 1].Click += new EventHandler(Secim);
            }
            return btnSafir;
        }
        #endregion

        #region RAHAT KOLTUK YARAT
        Button[] RahatKoltukYarat(Button[] btnRahat)
        {
            xKoor = 40;
            yKoor = 40;

            btnRahat = new Button[37];
            //Orta Kapı hizası olan 20 e kadar
            for (int i = 1; i < 23; i++)
            {
                xKoor += 40;
                btnRahat[i - 1] = new Button();
                btnRahat[i - 1].Text += i;
                Size boyut = new Size(30, 30);
                btnRahat[i - 1].Size = boyut;

                if ((i + 2) % 3 == 0)
                {
                    btnRahat[i - 1].Location = new Point(xKoor, yKoor);
                    this.Controls.Add(btnRahat[i - 1]);
                    xKoor += 60;
                }
                else
                {
                    if (i % 3 == 0)
                    {
                        btnRahat[i - 1].Location = new Point(xKoor, yKoor);
                        this.Controls.Add(btnRahat[i - 1]);
                        xKoor = 40;
                        yKoor += 40;
                    }
                    else
                    {
                        btnRahat[i - 1].Location = new Point(xKoor, yKoor);
                        this.Controls.Add(btnRahat[i - 1]);
                    }
                }
                btnRahat[i - 1].Visible = false;
                btnRahat[i - 1].Click += new EventHandler(Secim);
            }

            //Orta Kapı hizası olan 21 den sonrası

            xKoor = 40;
            yKoor += 40;

            for (int i = 23; i < 38; i++)
            {
                xKoor += 40;
                btnRahat[i - 1] = new Button();
                btnRahat[i - 1].Text += i;
                //btn.Name = "btn" + i;
                Size boyut = new Size(30, 30);
                btnRahat[i - 1].Size = boyut;

                if ((i - 2) % 3 == 0)
                {
                    btnRahat[i - 1].Location = new Point(xKoor, yKoor);
                    this.Controls.Add(btnRahat[i - 1]);
                    xKoor += 60;
                }
                else
                {
                    if (i % 3 == 0)
                    {

                        btnRahat[i - 1].Location = new Point(xKoor, yKoor);
                        this.Controls.Add(btnRahat[i - 1]);

                    }
                    else
                    {
                        btnRahat[i - 1].Location = new Point(xKoor, yKoor);
                        this.Controls.Add(btnRahat[i - 1]);
                        xKoor = 40;
                        yKoor += 40;
                    }
                }
                btnRahat[i - 1].Visible = false;
                btnRahat[i - 1].Click += new EventHandler(Secim);
            }
            return btnRahat;
        }
        #endregion

        #region KAYDET
        string[,] TravegoYolcular = new string[46, 2];
        string[,] SafirYolcular = new string[54, 2];
        string[,] RahatYolcular = new string[37, 2];

        void kaydeteTikla(object sender, EventArgs e)
        {
            switch (cbOtobusSec.SelectedItem)
            {
                case "Travego":
                    if (string.IsNullOrEmpty(txt.Text) || seciliKoltuk == null)
                    {
                        MessageBox.Show("Lütfen İsim soyisim giriniz ve koltuk seçiniz.");
                        txt.Clear();
                    }
                    else
                    {
                        int a = Convert.ToInt32(seciliKoltuk);
                        if (TravegoYolcular[a - 1, 1] == null)
                        {
                            ltBox.Items.Add("Otobüs: Travego >>" + " Yolcu adı soyadı: " + txt.Text + " >> Koltuk no: " + seciliKoltuk);
                            TravegoYolcular[a - 1, 0] = txt.Text;
                            TravegoYolcular[a - 1, 1] = a.ToString();
                            txt.Clear();
                            MessageBox.Show("\nOtobüs: Travego" + "\nYolcu adı: " + TravegoYolcular[a - 1, 0] + "\nKoltuk no: " + TravegoYolcular[a - 1, 1]);
                            kaydet.Focus();
                        }
                    }
                    break;

                case "Safir":
                    if (string.IsNullOrEmpty(txt.Text) || seciliKoltuk == null)
                    {
                        MessageBox.Show("Lütfen İsim soyisim giriniz ve koltuk seçiniz.");
                        txt.Clear();
                    }
                    else
                    {
                        int a = Convert.ToInt32(seciliKoltuk);
                        if (SafirYolcular[a - 1, 1] == null)
                        {
                            ltBox.Items.Add("Otobüs: Safir >>" + " Yolcu adı soyadı: " + txt.Text + " >> Koltuk no: " + seciliKoltuk);
                            SafirYolcular[a - 1, 0] = txt.Text;
                            SafirYolcular[a - 1, 1] = a.ToString();
                            txt.Clear();
                            MessageBox.Show("\nOtobüs: Safir" + "\nYolcu adı: " + SafirYolcular[a - 1, 0] + "\nKoltuk no: " + SafirYolcular[a - 1, 1]);
                            kaydet.Focus();
                        }
                    }
                    break;

                case "Rahat":
                    if (string.IsNullOrEmpty(txt.Text) || seciliKoltuk == null)
                    {
                        MessageBox.Show("Lütfen İsim soyisim giriniz ve koltuk seçiniz.");
                        txt.Clear();
                    }
                    else
                    {
                        int a = Convert.ToInt32(seciliKoltuk);
                        if (RahatYolcular[a - 1, 1] == null)
                        {
                            ltBox.Items.Add("Otobüs: Rahat >>" + " Yolcu adı soyadı: " + txt.Text + " >> Koltuk no: " + seciliKoltuk);
                            RahatYolcular[a - 1, 0] = txt.Text;
                            RahatYolcular[a - 1, 1] = a.ToString();
                            txt.Clear();
                            MessageBox.Show("\nOtobüs: Rahat" + "\nYolcu adı: " + RahatYolcular[a - 1, 0] + "\nKoltuk no: " + RahatYolcular[a - 1, 1]);
                            kaydet.Focus();
                        }
                    }
                    break;
                default:
                    MessageBox.Show("Lütfen otobüs seçimi yapınız.");
                    break;
            }

            seciliKoltuk = null;
        }
        #endregion


    }
}
