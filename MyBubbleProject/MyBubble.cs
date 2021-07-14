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
    public partial class MyBubble : Control
    {
        private Color bubbleColor;//Kabarcığımızın rengini temsil ettmesi için Color türünde bir değişken tanımladım.
        private int opacity;//Opaklık için bir değişken tanımladım.
        private int alpha;//Saydamlık için bir değişken tanımladım.(ARGB) alpha saydamlığı temsil eder.
        /// <summary>
        /// MyBubble sınıfının yapıcı metodudur.Opaklık başlangıç değerini 35 yaptım.Baloncuğun başlangiç rengini
        /// rengini kırmızı yaptım.Arka planını transparan olarak tanımladım.ilk SetStyle yönteminde bool değer olarak
        /// true girerek transparanlık stilini etkinleştirmiş oldum.İkinci SetStyle yöntemiyle de opaklık stilini etkinleştirdim.
        /// Baloncuğumun başlangıçtaki yükseklik ve genişliğini belirledim.
        /// </summary>
        public MyBubble()
        {
            opacity = 35;
            BubbleColor = Color.Red;
            Width = 110;
            Height = 110;
            BringToFront();//Kontrolümün otomotik olarak formda diğer form elemanlarının üzerine geldiğinde en üstte olmasını sağladım.
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.Opaque, true);
            this.BackColor = Color.Transparent;
        }
        /// <summary>
        /// Color türünde baloncuğun rengini temsil edecek özelliktir.Set bloğu içinde kabarcıkrengine değer 
        /// atamayı get bloğu içinde de renk değerini geri döndürmeyi sağladım.
        /// </summary>
        public Color BubbleColor
        {
            set
            {
                this.bubbleColor = value;
            }
            get
            {
                return bubbleColor;
            }
        }
        /// <summary>
        /// Baloncuğun opaklık özelliğini temsil eden Opacity özelliğidir.Get bloğu içinde opacity için girilen değerin
        /// 100 den büyük girilmesi halinde değeri 100 olarak kabul etmeyi;sıfırdan küçük bir dğer girildiğinde ise sıfır olarak
        /// kabul etmeyi sağlayarak opacity nin değerini return anahtar sözcüğüyle geri döndürdüm.Set bloğunda opacity değeri atamayı sağladım.
        /// </summary>
        public int Opacity
        {
            get
            {
                if (this.opacity > 100)
                {
                    opacity = 100;
                }
                if (this.opacity < 0)
                {
                    opacity = 0;
                }
                return opacity;
            }
            set
            {
                this.opacity = value;
                if (this.Parent != null)
                {
                    Parent.Invalidate(this.Bounds, true);
                }
            }
        }
        /// <summary>
        /// Denetim için tanıtıcının tekrar oluşturulmasını sağladım sağladım.
        /// </summary>
        public void Recreatehandle()
        {
            base.RecreateHandle();
        }
        /// <summary>
        /// Trasnparanlık özelliğini oluştururken  kullandım.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams p = base.CreateParams;
                p.ExStyle = p.ExStyle | 0x20;//Genişletilmiş pencere stili değerlerinin bit düzeyinde birleşimini alır veya ayarlar.

                return p;
            }

        }
        /// <summary>
        /// Baloncuğumu çizdirmede kullandığım metottur.Geçersiz kılıp ek özellikler ekledim. alpha değerini ayarladım.Baloncuk 
        /// çizdirme işlemlerini bu metot içinde yaptım.Baloncuğun kenarlığı için Pen sınıfından nesne türetip nesne üzerinden
        /// işlem yaptım.
        /// </summary>
        /// <param name="pe"></param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            alpha = Opacity * 255 / 100;//alpha değeri 0-255 arası değer alır.opacity 0 olduğunda 0;100 olduğunda ise alpha 255 olur.
            pe.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;//Kabarcığımın kenarlığının daha yumuşak geçişlerle
                                                                                         //daha düz çizilmesini belirttim.

            Pen penBorder = new Pen(BubbleColor, 1);//Kabarcığın renginde ve 1 kalınlığında kabarcık çerçevesi çizdirdim.

            Pen penBackGround = new Pen(Color.FromArgb(255, 0, 0, 0), 1);
            penBackGround.Brush = new SolidBrush(Color.FromArgb(alpha, BubbleColor.R, BubbleColor.G, BubbleColor.B));

            Rectangle r = this.ClientRectangle;//İstemci dikdörtgenini baz aldım.Onun yükseklik ve genişliği
            r.Width = r.Width - 1;               //yardımıyla elips çizdirebileceğim.
            r.Height = r.Height - 1;


            pe.Graphics.FillEllipse(penBackGround.Brush, r);//İçi dolu çizgi çizilmesi kabarcığımın içi dolu oldu..
            pe.Graphics.DrawEllipse(penBorder, r);//Kabarcığa kenarlık çizdirdim.
        }
    }
}
