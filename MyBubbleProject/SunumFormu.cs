using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyBubbleProject
{
    public partial class SunumFormu : Form
    {
       

        public SunumFormu()
        {
            InitializeComponent();
            myBubble1.Parent = this;
        }
        /// <summary>
        /// Scrollbarın değeri olarak baloncuğumun opacity değerini belirledim.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SunumFormu_Load(object sender, EventArgs e)
        {
            vScrollBar1.Value = myBubble1.Opacity;
            
        }
        /// <summary>
        /// Scrollbar ile baloncuğun transparanlığının değiştirilebilmesini sağladım.Sunum amaçlı.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            myBubble1.Opacity = vScrollBar1.Value;
            myBubble1.Recreatehandle();
        }
        /// <summary>
        /// Buton bire tıklandığında baloncuğun kırmızı olmasını sağladım.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            myBubble1.BubbleColor = Color.Red;
            myBubble1.Recreatehandle();
        }
        /// <summary>
        /// Buton ikiye tıklandığında baloncuğun mavi olmasını sağladım.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            myBubble1.BubbleColor = Color.Blue;
            myBubble1.Recreatehandle();
        }
        /// <summary>
        /// Buton üçe tıklandığında baloncuğun sarı olmasını sağladım.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            myBubble1.BubbleColor = Color.Yellow;
            myBubble1.Recreatehandle();
        }
        /// <summary>
        /// Buton dörde tıklandığında baloncuğun yeşil olmasını sağladım.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            myBubble1.BubbleColor = Color.Green;
            myBubble1.Recreatehandle();
        }
    }
}
