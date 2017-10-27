using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Imaging;
using TheArtOfDev;
using TheArtOfDev.HtmlRenderer.WinForms;
namespace TestImage
{
    class Program
    {
        static void Main(string[] args)
        {
            /*string text = System.IO.File.ReadAllText("pagina_test.html");
            var resolution = 300;
            var newWidth = 728.0;
            var newHeight = 890.0;
            var width = (int)((newWidth / 96.0) * resolution);
            var height= (int)((newHeight / 96.0) * resolution);
            
            byte[] imagenbyte = new HtmlToImage.HtmlToImage().Image(text, width, height, "png", (float)resolution);
            Bitmap b = new Bitmap(new System.IO.MemoryStream(imagenbyte));
            Graphics graphics = Graphics.FromImage(b);
           
            b.Save(string.Format("imagen_{0:dd_mm_hh_ss}.png",DateTime.Now));
            graphics.Dispose();*/
            MyImagem();
        }

        public static void MyImagem()
        {
            string text = System.IO.File.ReadAllText("pagina1.html");
            var resolution = 300;
            var newWidth = 728.0f;
            var newHeight = 500f;
            var font = 12;
            //1250 x 1750 px
            var width =  (int)((newWidth / 96) * resolution);
            var height=   (int)((newHeight / 96) * resolution);
            text = text.Replace("#width#", width.ToString());
            text = text.Replace("#font#", (resolution * font / 96.0).ToString("n2").Replace(",",".") );
            //var width = (int)newWidth;
            //var height = (int)newHeight;
            //Bitmap b = new Bitmap(width, height, PixelFormat.Format32bppArgb);
           // b.SetResolution((float)resolution, (float)resolution);
            //var g = Graphics.FromImage(b);
            //g.Clear(Color.White);
            //Bitmap imagen = new Bitmap(b);
            Image imagen = null;
            //g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            //imagen.SetResolution(resolution, resolution);
            //imagen.SetResolution((float)resolution, (float)resolution);
           //HtmlRender.RenderGdiPlus(Graphics.FromImage(imagen), text); //, new PointF(0f, 0f)new SizeF((float)width, (float)height)
            //i = HtmlRender.RenderToImageGdiPlus(text, new Size(width,height), new Size(width, height), TextRenderingHint.AntiAliasGridFit);
            imagen = HtmlRender.RenderToImageGdiPlus(text);
         

            imagen.Save(string.Format("imagen_{0:dd_mm_hh_ss}.png", DateTime.Now), ImageFormat.Png);
            imagen.Dispose();
            //b.Dispose();
        }
           
    }
}
