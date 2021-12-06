using MessagingToolkit.QRCode.Codec.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QR_Code_Application
{
    public partial class QR_Code_Form : Form
    {
        public QR_Code_Form()
        {
            InitializeComponent();
        }

        Bitmap bitmap;


        private void button1_Click(object sender, EventArgs e)
        {
            if (EncoderTextBox.Text!=null)
            {
                SaveFileDialog sfd = new SaveFileDialog()
                {
                    Filter = "*JPEG| *.jpg",
                    ValidateNames = true
                };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    bitmap.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog()
            {
                Filter = "*JPEG| *.jpg",
                ValidateNames = true,
                Multiselect = false
            };
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
                MessagingToolkit.QRCode.Codec.QRCodeDecoder decoder = new MessagingToolkit.QRCode.Codec.QRCodeDecoder();
                DecoderTextBox.Text = decoder.Decode(new QRCodeBitmapImage(pictureBox1.Image as Bitmap));
            }
        }

        private void EncoderTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessagingToolkit.QRCode.Codec.QRCodeEncoder encoder = new MessagingToolkit.QRCode.Codec.QRCodeEncoder();
            encoder.QRCodeScale = 8;
            bitmap = encoder.Encode(EncoderTextBox.Text);
            pictureBox1.Image = bitmap;
        }
    }
}
