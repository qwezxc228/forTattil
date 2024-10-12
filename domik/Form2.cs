using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace domik
{
    public partial class Form2 : Form
    {
        private List<Commands> commands = new List<Commands>();
        public Form2(List<Commands> commands)
        {
InitializeComponent();
            this.commands = commands;
        }


        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new(Color.Black);
            int x = 200;
            int y = 200;
            float engle = 0;
            for (int i = 0; i < commands.Count; i++)
            {
                Point point1 = new(x, y);
                if (commands[i].key == "right")
                    engle += float.Parse(commands[i].value);
                if (commands[i].key == "left")
                    engle -= float.Parse(commands[i].value);
                if (commands[i].key == "forward")
                {
                    y += (int)(Math.Sin(engle / 180 * Math.PI) * float.Parse(commands[i].value));
                    x += (int)(Math.Cos(engle / 180 * Math.PI) * float.Parse(commands[i].value));
                }
                Point point2 = new(x, y);
                e.Graphics.DrawLine(pen, point1, point2);
            }
        }
    }
    }

