using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class SearchTextBox : TextBox
{
    private const int EM_SETMARGINS = 0xd3;

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

    private PictureBox searchPictureBox;

    private Button cancelSearchButton;
    [System.Runtime.InteropServices.DllImport("gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
    private static extern IntPtr CreateRoundRectRgn
    (
        int nLeftRect, // X-coordinate of upper-left corner or padding at start
        int nTopRect,// Y-coordinate of upper-left corner or padding at the top of the textbox
        int nRightRect, // X-coordinate of lower-right corner or Width of the object
        int nBottomRect,// Y-coordinate of lower-right corner or Height of the object
                        //RADIUS, how round do you want it to be?
        int nheightRect, //height of ellipse 
        int nweightRect //width of ellipse
    );
    private void WaterMark_Toggel(object sender, EventArgs args)
    {
        if (this.Text.Length <= 0)
            EnableWaterMark();
        else
            DisbaleWaterMark();
    }

    private void EnableWaterMark()
    {
        //Save current font until returning the UserPaint style to false (NOTE:
        //It is a try and error advice)
        oldFont = new System.Drawing.Font(Font.FontFamily, Font.Size, Font.Style,
           Font.Unit);
        //Enable OnPaint event handler
        this.SetStyle(ControlStyles.UserPaint, true);
        this.waterMarkTextEnabled = true;
        //Triger OnPaint immediatly
        Refresh();
    }
    private void DisbaleWaterMark()
    {
        //Disbale OnPaint event handler
        this.waterMarkTextEnabled = false;
        this.SetStyle(ControlStyles.UserPaint, false);
        //Return back oldFont if existed
        if (oldFont != null)
            this.Font = new System.Drawing.Font(oldFont.FontFamily, oldFont.Size,
                oldFont.Style, oldFont.Unit);
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        System.Drawing.Font drawFont = new System.Drawing.Font(Font.FontFamily,
                   Font.Size, Font.Style, Font.Unit);
        //Create new brush with gray color or 
        SolidBrush drawBrush = new SolidBrush(WaterMarkColor);//use Water mark color
                                                              //Draw Text or WaterMark
        e.Graphics.DrawString((waterMarkTextEnabled ? WaterMarkText : Text),
            drawFont, drawBrush, new PointF(20.0f, 0.0F));
        base.OnPaint(e);
    }

    protected override void OnCreateControl()
    {
        base.OnCreateControl();
        this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(2, 3, this.Width, this.Height, 15, 15)); //play with these values till you are happy
        WaterMark_Toggel(null, null);
    }
    public SearchTextBox()
    {
        WaterMarkText = "اكتب شيأ للبحث ...";
        cancelSearchButton = new Button();
        cancelSearchButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        cancelSearchButton.Size = new Size(16, 16);
        cancelSearchButton.TabIndex = 0;
        cancelSearchButton.TabStop = false;
        cancelSearchButton.FlatStyle = FlatStyle.Flat;
        cancelSearchButton.FlatAppearance.BorderSize = 0;
        cancelSearchButton.Text = "";
        cancelSearchButton.Cursor = Cursors.Arrow;

        Controls.Add(cancelSearchButton);

        cancelSearchButton.Click += delegate
        {
            Text = "";
            Focus();
        };

        searchPictureBox = new PictureBox();
        searchPictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        searchPictureBox.Size = new Size(16, 16);
        searchPictureBox.TabIndex = 0;
        searchPictureBox.TabStop = false;
        Controls.Add(searchPictureBox);

        // Send EM_SETMARGINS to prevent text from disappearing underneath the button
        SendMessage(Handle, EM_SETMARGINS, (IntPtr)2, (IntPtr)(16 << 16));

        UpdateControlsVisibility();
        JoinEvents(true);
    }
      private void JoinEvents(Boolean join)
        {
            if (join)
            {
                this.TextChanged += new System.EventHandler(this.WaterMark_Toggel);
                this.LostFocus += new System.EventHandler(this.WaterMark_Toggel);
                this.FontChanged += new System.EventHandler(this.WaterMark_FontChanged);
                //No one of the above events will start immeddiatlly 
                //TextBox control still in constructing, so,
                //Font object (for example) couldn't be catched from within
                //WaterMark_Toggle
                //So, call WaterMark_Toggel through OnCreateControl after TextBox
                //is totally created
                //No doupt, it will be only one time call
                
                //Old solution uses Timer.Tick event to check Create property
            }
        }

    private void WaterMark_FontChanged(object sender, EventArgs e)
    {  if (waterMarkTextEnabled)
            {
                oldFont = new System.Drawing.Font(Font.FontFamily, Font.Size, Font.Style,
                    Font.Unit);
                Refresh();
}
    }

    private Font oldFont = null;
    private Boolean waterMarkTextEnabled = false;

    #region Attributes 
    private Color _waterMarkColor = Color.Gray;
    public Color WaterMarkColor
    {
        get { return _waterMarkColor; }
        set
        {
            _waterMarkColor = value; Invalidate();/*thanks to Bernhard Elbl
                                                              for Invalidate()*/
        }
    }

    private string _waterMarkText ;
    public string WaterMarkText
    {
        get { return _waterMarkText; }
        set { _waterMarkText = value; Invalidate(); }
    }
    #endregion
    protected override void OnSizeChanged(EventArgs e)
    {
        base.OnSizeChanged(e);
        this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(2, 3, this.Width, this.Height, 15, 15)); //play with these values till you are happy
        searchPictureBox.Left = 4;
        cancelSearchButton.Left = 4;
        Invalidate();
    }

    protected override void OnTextChanged(EventArgs e)
    {
        base.OnTextChanged(e);
        UpdateControlsVisibility();
    }

    private void UpdateControlsVisibility()
    {
        if (string.IsNullOrEmpty(Text))
        {
            cancelSearchButton.Visible = false;
            searchPictureBox.Visible = true;
        }
        else
        {
            cancelSearchButton.Visible = true;
            searchPictureBox.Visible = false;
        }
    }

    [Browsable(true)]
    public Image SearchImage
    {
        set
        {
            searchPictureBox.Image = value;
            searchPictureBox.Left =  4;
            searchPictureBox.Top = Height - searchPictureBox.Size.Height - 4;
        }

        get { return searchPictureBox.Image; }
    }

    [Browsable(true)]
    public Image CancelSearchImage
    {
        set
        {
            cancelSearchButton.Image = value;
            cancelSearchButton.Left = 4;
            cancelSearchButton.Top = Height - searchPictureBox.Size.Height - 4;
        }

        get { return cancelSearchButton.Image; }
    }
}