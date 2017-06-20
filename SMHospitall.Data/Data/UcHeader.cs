using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SMHospitall.Data
{
    public partial class UcHeader : DevExpress.XtraEditors.XtraUserControl
    {
        public UcHeader()
        {
            InitializeComponent();
        }
        public Image Image
        {
            get
            {
                Bitmap b = new Bitmap(Width, Height);
                this.DrawToBitmap(b, new Rectangle(0, 0, Width, Height));
                return b;
            }
        }
        public Data.EndUser EndUser
        {
            set
            {
                endUserBindingSource.DataSource = value;
                if (value!=null && value.Logo!=null)
                {
                    pictureBox1.Image = value.LogoImage;
                    //faxLabel.Visible = !value.Fax.IsNullOrEmpty();
                    pictureBox1.Width = pictureBox1.Height * (pictureBox1.Width / pictureBox1.Height) + 15;
                }
                else
                {
                    pictureBox1.Width = 0;
                }
            }
        }
        public Image ImageMin
        {
            get
            {
                if (pictureBox1.Image==null)
                {
                    pictureBox1.Width = 0;
                }
                var a = Image;
                Width = panelControl1.Width + pictureBox1.Width;
                return Image;
            }
        }
    }
}
