namespace Framework.Core.Drawing
{
    #region usings

    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;

    #endregion

    [DefaultProperty("Text")]
    public class CaptchaImage
    {
        public HatchStyle _textStyle = HatchStyle.Horizontal;

        public HatchStyle BackStyle = HatchStyle.DottedGrid;

        private readonly Random _random = new Random();

        private string _charSet = "ابتثجحخدذرزسشصضطظعغفقكلمنهوي1234567890";

        private int _height = 60;

        private int _length = 5;

        private int _lines = 100;

        private int _noise = 100;

        private string _text = "";

        private bool _unique = true;

        private int _warp = 100;

        private int _width = 100;

        public CaptchaImage()
        {
            this.Text = "";
        }

        [Description("Hatch Brush Background Background Color")]
        [Category("Hatch Brush Background")]
        public Color BackgroundBackColor { get; set; } = Color.White;

        [Category("Hatch Brush Background")]
        [Description("Hatch Brush Background Fore Color")]
        public Color BackgroundForeColor { get; set; } = Color.LightGray;

        [Description("Hatch Brush Background Style")]
        [Category("Hatch Brush Background")]
        public HatchStyle BackgroundStyle
        {
            get => this.BackStyle;
            set => this.BackStyle = value;
        }

        [Category("Text")]
        [Description("Character set for auto-text generation")]
        public string CharacterSet
        {
            get => this._charSet;
            set
            {
                if ((value == null) || (value.Length < 2))
                    throw new Exception("Minimum character set size is 2");
                this._charSet = value;
                this.Text = "";
            }
        }

        [Description("Font Name")]
        [Category("Font")]
        public string FontName { get; set; } = "Tahoma";

        [Description("Font Size")]
        [Category("Font")]
        public int FontSize { get; set; } = 20;

        [Category("Font")]
        [Description("Font Style")]
        public FontStyle FontStyle { get; set; } = FontStyle.Regular;

        [Description("Image Height")]
        [Category("Bitmap")]
        public int Height
        {
            get => this._height;
            set
            {
                if ((value < 10) || (value > 1000))
                    throw new Exception("Image Height must be between 10 and 1000");
                this._height = value;
            }
        }

        [Description("Generated image")]
        [Browsable(false)]
        [Category("Bitmap")]
        public Bitmap Image
        {
            get
            {
                var bitmap = new Bitmap(this._width, this._height, PixelFormat.Format32bppPArgb);
                Graphics graphics = null;
                Font font = null;
                HatchBrush hatchBrush1 = null;
                HatchBrush hatchBrush2 = null;
                try
                {
                    graphics = Graphics.FromImage(bitmap);
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    var rectangle = new Rectangle(0, 0, this._width, this._height);
                    hatchBrush1 = new HatchBrush(this._textStyle, this.TextForeColor, this.TextBackColor);
                    hatchBrush2 = new HatchBrush(this.BackStyle, this.BackgroundForeColor, this.BackgroundBackColor);
                    graphics.FillRectangle(hatchBrush2, rectangle);
                    var format = new StringFormat
                                     {
                                         Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center
                                     };
                    font = new Font(this.FontName, this.FontSize, this.FontStyle);
                    var path = new GraphicsPath();
                    path.AddString(this._text, font.FontFamily, (int)font.Style, font.Size, rectangle, format);
                    if (this._warp > 0)
                    {
                        var matrix = new Matrix();
                        float num = 10 - this._warp * 6 / 100;
                        var destPoints = new PointF[4]
                                             {
                                                 new PointF(
                                                     this._random.Next(rectangle.Width) / num,
                                                     this._random.Next(rectangle.Height) / num),
                                                 new PointF(
                                                     rectangle.Width - this._random.Next(rectangle.Width) / num,
                                                     this._random.Next(rectangle.Height) / num),
                                                 new PointF(
                                                     this._random.Next(rectangle.Width) / num,
                                                     rectangle.Height - this._random.Next(rectangle.Height) / num),
                                                 new PointF(
                                                     rectangle.Width - this._random.Next(rectangle.Width) / num,
                                                     rectangle.Height - this._random.Next(rectangle.Height) / num)
                                             };
                        path.Warp(destPoints, rectangle, matrix, WarpMode.Perspective, 0.0f);
                    }

                    graphics.FillPath(hatchBrush1, path);
                    if (this._noise > 0)
                    {
                        var maxValue = Math.Max(rectangle.Width, rectangle.Height) * this._noise / 3000;
                        var num = rectangle.Width * rectangle.Height / (100 - (this._noise >= 90 ? 90 : this._noise));
                        for (var index = 0; index < num; ++index)
                            graphics.FillEllipse(
                                hatchBrush1,
                                this._random.Next(rectangle.Width),
                                this._random.Next(rectangle.Height),
                                this._random.Next(maxValue),
                                this._random.Next(maxValue));
                    }

                    if (this._lines > 0)
                    {
                        var num = this._lines / 30 + 1;
                        using (var pen = new Pen(hatchBrush1, 1f))
                        {
                            for (var index1 = 0; index1 < num; ++index1)
                            {
                                var points = new PointF[num > 2 ? num - 1 : 2];
                                for (var index2 = 0; index2 < points.Length; ++index2)
                                    points[index2] = new PointF(
                                        this._random.Next(rectangle.Width),
                                        this._random.Next(rectangle.Height));
                                graphics.DrawCurve(pen, points, 1.75f);
                            }
                        }
                    }
                }
                finally
                {
                    if (graphics != null)
                        graphics.Dispose();
                    if (font != null)
                        font.Dispose();
                    if (hatchBrush1 != null)
                        hatchBrush1.Dispose();
                    if (hatchBrush2 != null)
                        hatchBrush2.Dispose();
                }

                return bitmap;
            }
        }

        [Description("Text Length")]
        [Category("Text")]
        public int Length
        {
            get => this._length;
            set
            {
                if ((value < 2) || (value > 10))
                    throw new Exception("Text Length must be between 2 and 10");
                this._length = value;
                this.Text = "";
            }
        }

        [Description("Lines Factor")]
        [Category("Effects")]
        public int LinesFactor
        {
            get => this._lines;
            set
            {
                if ((value < 0) || (value > 100))
                    throw new Exception("Lines Factor must be between 0 and 100");
                this._lines = value;
            }
        }

        [Description("Noise Factor")]
        [Category("Effects")]
        public int NoiseFactor
        {
            get => this._noise;
            set
            {
                if ((value < 0) || (value > 100))
                    throw new Exception("Noise Factor must be between 0 and 100");
                this._noise = value;
            }
        }

        [Description("Text string. Empty to auto-generate random string.")]
        [Category("Text")]
        public string Text
        {
            get => this._text;
            set
            {
                if ((value == null) || ((value.Length != 0) && (value.Length < 2)) || (value.Length > 10))
                    throw new Exception("Text Length must be between 2 and 10");
                this._text = value;
                if (this._text.Length == 0)
                {
                    for (var index = 0; index < this._length; ++index)
                    {
                        char ch;
                        do
                        {
                            ch = this._charSet[this._random.Next(0, this._charSet.Length)];
                        }
                        while (this._unique && (this._length <= this._charSet.Length) && (this._text.IndexOf(ch) >= 0));

                        this._text += ch.ToString();
                    }
                }

                this._length = this._text.Length;
            }
        }

        [Description("Hatch Brush Text Background Color")]
        [Category("Hatch Brush Text")]
        public Color TextBackColor { get; set; } = Color.Black;

        [Category("Hatch Brush Text")]
        [Description("Hatch Brush Text Fore Color")]
        public Color TextForeColor { get; set; } = Color.Black;

        [Description("Hatch Brush Text Style")]
        [Category("Hatch Brush Text")]
        public HatchStyle TextStyle
        {
            get => this._textStyle;
            set => this._textStyle = value;
        }

        [Category("Text")]
        [Description("Unique characters or not")]
        public bool Unique
        {
            get => this._unique;
            set
            {
                this._unique = value;
                this.Text = "";
            }
        }

        [Description("Warp Factor")]
        [Category("Effects")]
        public int WarpFactor
        {
            get => this._warp;
            set
            {
                if ((value < 0) || (value > 100))
                    throw new Exception("Warp Factor must be between 0 and 100");
                this._warp = value;
            }
        }

        [Description("Image Width")]
        [Category("Bitmap")]
        public int Width
        {
            get => this._width;
            set
            {
                if ((value < 10) || (value > 1000))
                    throw new Exception("Image Width must be between 10 and 1000");
                this._width = value;
            }
        }
    }
}