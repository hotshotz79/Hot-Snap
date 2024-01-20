using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hot_Snap
{
    public partial class Message : CSWinFormLayeredWindow.PerPixelAlphaForm
    {
        private Timer tmr;

        public Message(Bitmap emote, Int16 displayTime)
        {
            InitializeComponent();

            //Set Emote image
            this.SelectBitmap(emote);

            //Play Sound

            tmr = new Timer();
            tmr.Tick += delegate {
                this.Close();
            };
            tmr.Interval = displayTime;
            tmr.Start();
        }

        private void Message_Click(object sender, EventArgs e)
        {
        }
    }
}
