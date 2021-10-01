using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

public class TransparentLabel : Label
{
    public TransparentLabel()
    {
        this.transparentBackColor = Color.Blue;
        this.opacity = 90;
        this.AutoSize = false;

        this.AutoEllipsis = true;
        this.BackColor = Color.Transparent;
    }
    public int price = 0;
    protected override void OnPaint(PaintEventArgs e)
    {
        if (Parent != null)
        {
            Size sz = new Size(this.Width, Int32.MaxValue);
            sz = TextRenderer.MeasureText(this.Text, this.Font, sz, TextFormatFlags.WordBreak);
           if(price==1)
            {
                this.AutoSize = false;
                this.Height = sz.Height;
                this.Width = sz.Width;
            }
            else
            this.Height = sz.Height + Padding.Bottom + Padding.Top;

            using (var bmp = new Bitmap(Parent.Width, Parent.Height))
            {
                Parent.Controls.Cast<Control>()
                      .Where(c => Parent.Controls.GetChildIndex(c) > Parent.Controls.GetChildIndex(this))
                      .Where(c => c.Bounds.IntersectsWith(this.Bounds))
                      .OrderByDescending(c => Parent.Controls.GetChildIndex(c))
                      .ToList()
                      .ForEach(c => c.DrawToBitmap(bmp, c.Bounds));


                e.Graphics.DrawImage(bmp, -Left, -Top);
                using (var b = new SolidBrush(Color.FromArgb(this.Opacity, this.TransparentBackColor)))
                {
                    e.Graphics.FillRectangle(b, this.ClientRectangle);
                }
                TextFormatFlags flags = TextFormatFlags.HorizontalCenter |
       TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak;

                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                TextRenderer.DrawText(e.Graphics, this.Text, this.Font, this.ClientRectangle, this.ForeColor, Color.Transparent, flags);
            }
        }
    }

    private int opacity;
    public int Opacity
    {
        get { return opacity; }
        set
        {
            if (value >= 0 && value <= 255)
                opacity = value;
            this.Invalidate();
        }
    }

    public Color transparentBackColor;
    public Color TransparentBackColor
    {
        get { return transparentBackColor; }
        set
        {
            transparentBackColor = value;
            this.Invalidate();
        }
    }
#pragma warning disable CS0169 // The field 'TransparentLabel.mGrowing' is never used
    private bool mGrowing;
#pragma warning restore CS0169 // The field 'TransparentLabel.mGrowing' is never used
    [Browsable(false)]
    public override Color BackColor
    {
        get
        {
            return Color.Transparent;
        }
        set
        {
            base.BackColor = Color.Transparent;
        }
    }

    }
