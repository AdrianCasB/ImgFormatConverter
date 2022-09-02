using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2_AdrianCastillo_
{
    public partial class Form1 : Form
    {
        Image img1;
        Bitmap Image1;
        String ruta;
        private Size oldSize;
        private SaveFileDialog saveFileDialog;
        private void Form1_Load(object sender, EventArgs e) => oldSize = base.Size;
        

        public Form1()
        {
            InitializeComponent();
            

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.saveFileDialog = new SaveFileDialog();
           saveFileDialog.Filter = this.comboBox2.Text + "|" + this.comboBox2.Text; ;
            DialogResult drd = saveFileDialog.ShowDialog();
        
            if (drd == DialogResult.OK ) ;
            {

                //MÉTODO CON FILESTREAM + SWITCH

                /*  
                    System.IO.FileStream fs =
                       (System.IO.FileStream)saveFileDialog.OpenFile();
                 String formato = comboBox2.Text.ToString();
                    switch (formato)
                    {
                        case "*.jpg":
                            img1.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;

                        case "*.bmp":
                            img1.Save(fs,System.Drawing.Imaging.ImageFormat.Bmp);
                            break;

                        case "*.gif":
                            img1.Save(fs,System.Drawing.Imaging.ImageFormat.Gif);
                            break;

                        case "*.tiff":
                            img1.Save(fs,System.Drawing.Imaging.ImageFormat.Tiff);
                            break;
                    }
                  fs.Close();
                 /*

                 //MÉTODO CON FILESTREAM + IF ELSE

                 /* 
                  System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog.OpenFile();

                   if (this.comboBox2.Text == "*.bmp")
                  {
                      img1.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
                  }
                  else if (this.comboBox2.Text == "*.jpg")
                  {
                      img1.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                  }else if (this.comboBox2.Text == "*.gif")
                  {
                      img1.Save(fs, System.Drawing.Imaging.ImageFormat.Gif);
                  }else if(this.comboBox2.Text == "*.tiff")
                  {
                      img1.Save(fs, System.Drawing.Imaging.ImageFormat.Tiff);
                  }

                  fs.Close();*/



                //MÉTODO CON IF SIN FILESTREAM

                /* String formato = comboBox2.Text.ToString();
                  if (formato == "*.bmp")
                  {
                      img1.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Bmp);

                  } else if ( formato == "*.jpg")
                  {
                      img1.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);

                  }else if ( formato == "*.tiff")
                  {
                      img1.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Tiff);

                  }else if ( formato == "*.gif")
                  {
                      img1.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Gif);
                  }*/




                //MÉTODO CON SWITCH SIN FILESTREAM

                String formato = comboBox2.Text.ToString();
                switch (formato)
                {
                    case "*.jpg":
                        img1.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;

                    case "*.bmp":
                        img1.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;

                    case "*.gif":
                        img1.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Gif);
                        break;

                    case "*.tiff":
                        img1.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Tiff);
                        break;
                }

            }


            string text = "Imagen convertida con éxito"; 
            MessageBox.Show(text); //VENTANA EMERGENTE

        }
    
           
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = this.comboBox1.Text + "|" + this.comboBox1.Text;
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK )
            {
                this.ruta = ofd.FileName;

                Image1 = new Bitmap(ruta);

                pictureBox1.Image = Image1;
                this.img1 = Image1;

                int Altura = Image1.Height;
                int Anchura = Image1.Width;

                Size = new Size(Altura + 200, Anchura + 200);

              

              

            }

           
            
            
        }
       


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        protected override void OnResize(System.EventArgs e) 
        {
            base.OnResize(e);

            foreach (Control cnt in this.Controls)
                ResizeAll(cnt, base.Size);

            oldSize = base.Size;
        }
        private void ResizeAll(Control control, Size newSize)
        {
            int width = newSize.Width - oldSize.Width;
            control.Left += (control.Left * width) / oldSize.Width;
            control.Width += (control.Width * width) / oldSize.Width;

            int height = newSize.Height - oldSize.Height;
            control.Top += (control.Top * height) / oldSize.Height;
            control.Height += (control.Height * height) / oldSize.Height;
        }

        
    }
}
