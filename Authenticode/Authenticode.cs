using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlLibrary
{
    public partial class Authenticode : UserControl
    {
        private string code;
        private int length,lineNum,dotNum;
        private float width, height;
        private bool pureNumber, specialChar;

        private void Authenticode_Click(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        public bool Check(string input)
        {
            if (input == code)
                return true;
            return false;
        }
        public Authenticode(int length,bool pureNumber,bool specialChar,int lineNum,int dotNum,float width,float height)
        {
            this.length = length;
            this.pureNumber = pureNumber;
            this.specialChar = specialChar;
            this.lineNum = lineNum;
            this.dotNum = dotNum;
            this.width = width;
            this.height = height;
            InitializeComponent();
        }
        private string GenerateCode(int length=4,int lineNum=2,int dotNum=10,bool pureNumber=false,bool specialChar = false)
        {
            StringBuilder chars =new StringBuilder("123456789");
            char[] code=new char[length];
            if (!pureNumber)
            {
                chars.Append("abcdefghijklmnopqrstuvwxyz");
            }
            if (specialChar)
            {
                chars.Append("!@#$%&");
            }
            Random r = new Random();
            for(int i = 0; i < length; i++)
            {
                code[i] = chars[r.Next(0, chars.Length)];
            }
            return string.Join("", code);
        }

        private void Authenticode_Paint(object sender, PaintEventArgs e)
        {
            code = GenerateCode(length,lineNum,dotNum,pureNumber,specialChar);
            Graphics g = e.Graphics;
            Font font;
            Random r = new Random();
            float x=0,offX = width / (length-1)/2.1f;
            for(int i = 0; i < code.Length; i++)
            {
                font = new Font(FontFamily.GenericSansSerif, 16,FontStyle.Regular);
                g.DrawString(code[i].ToString(), font, Brushes.Black, new PointF(x,0));
                x += offX;
            }
        }
    }
}
