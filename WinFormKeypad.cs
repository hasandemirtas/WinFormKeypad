using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomWinFormControls.WinFormKeypad
{
    public delegate void EventDelegate(object sender, EventArgs e);
    class WinFormKeypad : Panel
    {
        private string pin;

        private Label lblPin;
        private TableLayoutPanel TLPKeypad;
        private TableLayoutPanel TLPButtons;
        private Button btnOne;
        private Button btnTwo;
        private Button btnThree;
        private Button btnFour;
        private Button btnFive;
        private Button btnSix;
        private Button btnSeven;
        private Button btnEight;
        private Button btnNine;
        private Button btnZero;
        private Button btnBackspace;
        private Button btnLogin;
        private Button[] pinButtons;

        private Color keypadBackColor;
        private Color lblOutputBackColor;
        private Color lblOutputForeColor;
        private Color btnPinBackColor;
        private Color btnBackspaceBackColor;
        private Color btnLoginBackColor;
        private Color btnFontColor;

        private Color btnPinHighlightColor;
        private Color btnBackspaceHighlightColor;
        private Color btnLoginHighlightColor;
        private Color btnHighlightFontColor;

        private Bitmap iconBackspace;
        private Bitmap iconBackspaceHighlight;
        private Bitmap iconLogin;
        private Bitmap iconLoginHighlight;

        private int charLimit;
        private string placeholder;

        public WinFormKeypad()
        {
            pin = "";
            lblPin = new Label();
            TLPKeypad = new TableLayoutPanel();
            TLPButtons = new TableLayoutPanel();
            btnOne = new Button();
            btnTwo = new Button();
            btnThree = new Button();
            btnFour = new Button();
            btnFive = new Button();
            btnSix = new Button();
            btnSeven = new Button();
            btnEight = new Button();
            btnNine = new Button();
            btnZero = new Button();
            btnBackspace = new Button();
            btnLogin = new Button();
            pinButtons = new Button[] { btnOne, btnTwo, btnThree, btnFour, btnFive, btnSix, btnSeven, btnEight, btnNine, btnZero };
            // 
            // Button Colors
            // 
            KeypadBackColor = Color.Transparent;
            lblOutputBackColor = Color.FromArgb(255, 255, 255);
            lblOutputForeColor = Color.FromArgb(0, 0, 0);
            btnPinBackColor = Color.FromArgb(255, 255, 255);
            btnBackspaceBackColor = Color.FromArgb(255, 255, 255);
            btnLoginBackColor = Color.FromArgb(255, 255, 255);
            btnFontColor = Color.FromArgb(0, 0, 0);
            // 
            // Highlight Button Colors
            // 
            btnPinHighlightColor = Color.FromArgb(42, 111, 151);
            btnBackspaceHighlightColor = Color.FromArgb(255, 211, 45);
            btnLoginHighlightColor = Color.FromArgb(27, 114, 47);
            btnHighlightFontColor = Color.FromArgb(255, 255, 255);
            //
            //Icon Porp Values
            //
            iconBackspace = Properties.Resources.backspace_yellow_255_211_45_;
            iconBackspaceHighlight = Properties.Resources.backspace_highlight_icon;
            iconLogin = Properties.Resources.login_green_27_114_47_;
            iconLoginHighlight = Properties.Resources.login_highlight_icon;
            //
            //Other Porp Values
            //
            charLimit = 5;
            placeholder = "Pin";
            // 
            // TLPKeypad
            // 
            TLPKeypad.RowCount = 2;
            TLPKeypad.ColumnCount = 1;
            TLPKeypad.Size = new Size(350, 350);
            TLPKeypad.Dock = DockStyle.Fill;
            TLPKeypad.RowStyles.Add(new RowStyle(SizeType.Percent, 16F));
            TLPKeypad.RowStyles.Add(new RowStyle(SizeType.Percent, 84F));
            TLPKeypad.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TLPKeypad.Controls.Add(lblPin, 0, 0);
            TLPKeypad.Controls.Add(TLPButtons, 0, 1);
            // 
            // TLPButtons
            // 
            TLPButtons.ColumnCount = 3;
            TLPButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            TLPButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33334F));
            TLPButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33334F));
            TLPButtons.Controls.Add(btnLogin, 2, 3);
            TLPButtons.Controls.Add(btnZero, 1, 3);
            TLPButtons.Controls.Add(btnBackspace, 0, 3);
            TLPButtons.Controls.Add(btnNine, 2, 2);
            TLPButtons.Controls.Add(btnEight, 1, 2);
            TLPButtons.Controls.Add(btnSeven, 0, 2);
            TLPButtons.Controls.Add(btnSix, 2, 1);
            TLPButtons.Controls.Add(btnFive, 1, 1);
            TLPButtons.Controls.Add(btnFour, 0, 1);
            TLPButtons.Controls.Add(btnThree, 2, 0);
            TLPButtons.Controls.Add(btnTwo, 1, 0);
            TLPButtons.Controls.Add(btnOne, 0, 0);
            TLPButtons.Dock = DockStyle.Fill;
            TLPButtons.Location = new Point(0, 70);
            TLPButtons.Margin = new Padding(0, 10, 0, 0);
            TLPButtons.Name = "TLPButtons";
            TLPButtons.RowCount = 4;
            TLPButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            TLPButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            TLPButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            TLPButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            TLPButtons.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            TLPButtons.Size = new Size(384, 306);
            TLPButtons.TabIndex = 0;
            // 
            // btnLogin
            // 
            btnLogin.AutoSize = true;
            btnLogin.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnLogin.BackgroundImage = iconLogin;
            btnLogin.BackgroundImageLayout = ImageLayout.Stretch;
            btnLogin.BackColor = Color.White;
            btnLogin.Dock = DockStyle.Fill;
            btnLogin.FlatAppearance.BorderColor = Color.FromArgb(153, 167, 153);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Microsoft JhengHei UI Light", 16F);
            btnLogin.ForeColor = Color.Black;
            btnLogin.Location = new Point(260, 233);
            btnLogin.Margin = new Padding(5);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(119, 68);
            btnLogin.TabIndex = 11;
            btnLogin.TabStop = false;
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += new EventHandler(btnLogin_Click);
            btnLogin.MouseLeave += new EventHandler(btnLogin_MouseLeave);
            btnLogin.MouseMove += new MouseEventHandler(btnLogin_MouseMove);
            // 
            // btnZero
            // 
            btnZero.AutoSize = true;
            btnZero.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnZero.BackColor = Color.White;
            btnZero.Dock = DockStyle.Fill;
            btnZero.FlatAppearance.BorderColor = Color.FromArgb(153, 167, 153);
            btnZero.FlatStyle = FlatStyle.Flat;
            btnZero.Font = new Font("Microsoft JhengHei UI Light", 16F);
            btnZero.ForeColor = Color.Black;
            btnZero.Location = new Point(132, 233);
            btnZero.Margin = new Padding(5);
            btnZero.Name = "btnZero";
            btnZero.Size = new Size(118, 68);
            btnZero.TabIndex = 10;
            btnZero.TabStop = false;
            btnZero.Text = "0";
            btnZero.UseVisualStyleBackColor = false;
            btnZero.Click += new EventHandler(btnZero_Click);
            btnZero.MouseLeave += new EventHandler(btnZero_MouseLeave);
            btnZero.MouseMove += new MouseEventHandler(btnZero_MouseMove);
            // 
            // btnBackspace
            // 
            btnBackspace.AutoSize = true;
            btnBackspace.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnBackspace.BackgroundImage = iconBackspace;
            btnBackspace.BackgroundImageLayout = ImageLayout.Stretch;
            btnBackspace.BackColor = Color.White;
            btnBackspace.Dock = DockStyle.Fill;
            btnBackspace.FlatAppearance.BorderColor = Color.FromArgb(153, 167, 153);
            btnBackspace.FlatStyle = FlatStyle.Flat;
            btnBackspace.Font = new Font("Microsoft JhengHei UI Light", 16F);
            btnBackspace.ForeColor = Color.Black;
            btnBackspace.Location = new Point(5, 233);
            btnBackspace.Margin = new Padding(5);
            btnBackspace.Name = "btnBackspace";
            btnBackspace.Size = new Size(117, 68);
            btnBackspace.TabIndex = 9;
            btnBackspace.TabStop = false;
            btnBackspace.UseVisualStyleBackColor = false;
            btnBackspace.Click += new EventHandler(btnBackspace_Click);
            btnBackspace.MouseLeave += new EventHandler(btnBackspace_MouseLeave);
            btnBackspace.MouseMove += new MouseEventHandler(btnBackspace_MouseMove);
            // 
            // btnNine
            // 
            btnNine.AutoSize = true;
            btnNine.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnNine.BackColor = Color.White;
            btnNine.Dock = DockStyle.Fill;
            btnNine.FlatAppearance.BorderColor = Color.FromArgb(153, 167, 153);
            btnNine.FlatStyle = FlatStyle.Flat;
            btnNine.Font = new Font("Microsoft JhengHei UI Light", 16F);
            btnNine.ForeColor = Color.Black;
            btnNine.Location = new Point(260, 157);
            btnNine.Margin = new Padding(5);
            btnNine.Name = "btnNine";
            btnNine.Size = new Size(119, 66);
            btnNine.TabIndex = 8;
            btnNine.TabStop = false;
            btnNine.Text = "9";
            btnNine.UseVisualStyleBackColor = false;
            btnNine.Click += new EventHandler(btnNine_Click);
            btnNine.MouseLeave += new EventHandler(btnNine_MouseLeave);
            btnNine.MouseMove += new MouseEventHandler(btnNine_MouseMove);
            // 
            // btnEight
            // 
            btnEight.AutoSize = true;
            btnEight.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnEight.BackColor = Color.White;
            btnEight.Dock = DockStyle.Fill;
            btnEight.FlatAppearance.BorderColor = Color.FromArgb(153, 167, 153);
            btnEight.FlatStyle = FlatStyle.Flat;
            btnEight.Font = new Font("Microsoft JhengHei UI Light", 16F);
            btnEight.ForeColor = Color.Black;
            btnEight.Location = new Point(132, 157);
            btnEight.Margin = new Padding(5);
            btnEight.Name = "btnEight";
            btnEight.Size = new Size(118, 66);
            btnEight.TabIndex = 7;
            btnEight.TabStop = false;
            btnEight.Text = "8";
            btnEight.UseVisualStyleBackColor = false;
            btnEight.Click += new EventHandler(btnEight_Click);
            btnEight.MouseLeave += new EventHandler(btnEight_MouseLeave);
            btnEight.MouseMove += new MouseEventHandler(btnEight_MouseMove);
            // 
            // btnSeven
            // 
            btnSeven.AutoSize = true;
            btnSeven.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSeven.BackColor = Color.White;
            btnSeven.Dock = DockStyle.Fill;
            btnSeven.FlatAppearance.BorderColor = Color.FromArgb(153, 167, 153);
            btnSeven.FlatStyle = FlatStyle.Flat;
            btnSeven.Font = new Font("Microsoft JhengHei UI Light", 16F);
            btnSeven.ForeColor = Color.Black;
            btnSeven.Location = new Point(5, 157);
            btnSeven.Margin = new Padding(5);
            btnSeven.Name = "btnSeven";
            btnSeven.Size = new Size(117, 66);
            btnSeven.TabIndex = 6;
            btnSeven.TabStop = false;
            btnSeven.Text = "7";
            btnSeven.UseVisualStyleBackColor = false;
            btnSeven.Click += new EventHandler(btnSeven_Click);
            btnSeven.MouseLeave += new EventHandler(btnSeven_MouseLeave);
            btnSeven.MouseMove += new MouseEventHandler(btnSeven_MouseMove);
            // 
            // btnSix
            // 
            btnSix.AutoSize = true;
            btnSix.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSix.BackColor = Color.White;
            btnSix.Dock = DockStyle.Fill;
            btnSix.FlatAppearance.BorderColor = Color.FromArgb(153, 167, 153);
            btnSix.FlatStyle = FlatStyle.Flat;
            btnSix.Font = new Font("Microsoft JhengHei UI Light", 16F);
            btnSix.ForeColor = Color.Black;
            btnSix.Location = new Point(260, 81);
            btnSix.Margin = new Padding(5);
            btnSix.Name = "btnSix";
            btnSix.Size = new Size(119, 66);
            btnSix.TabIndex = 5;
            btnSix.TabStop = false;
            btnSix.Text = "6";
            btnSix.UseVisualStyleBackColor = false;
            btnSix.Click += new EventHandler(btnSix_Click);
            btnSix.MouseLeave += new EventHandler(btnSix_MouseLeave);
            btnSix.MouseMove += new MouseEventHandler(btnSix_MouseMove);
            // 
            // btnFive
            // 
            btnFive.AutoSize = true;
            btnFive.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnFive.BackColor = Color.White;
            btnFive.Dock = DockStyle.Fill;
            btnFive.FlatAppearance.BorderColor = Color.FromArgb(153, 167, 153);
            btnFive.FlatStyle = FlatStyle.Flat;
            btnFive.Font = new Font("Microsoft JhengHei UI Light", 16F);
            btnFive.ForeColor = Color.Black;
            btnFive.Location = new Point(132, 81);
            btnFive.Margin = new Padding(5);
            btnFive.Name = "btnFive";
            btnFive.Size = new Size(118, 66);
            btnFive.TabIndex = 4;
            btnFive.TabStop = false;
            btnFive.Text = "5";
            btnFive.UseVisualStyleBackColor = false;
            btnFive.Click += new EventHandler(btnFive_Click);
            btnFive.MouseLeave += new EventHandler(btnFive_MouseLeave);
            btnFive.MouseMove += new MouseEventHandler(btnFive_MouseMove);
            // 
            // btnFour
            // 
            btnFour.AutoSize = true;
            btnFour.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnFour.BackColor = Color.White;
            btnFour.Dock = DockStyle.Fill;
            btnFour.FlatAppearance.BorderColor = Color.FromArgb(153, 167, 153);
            btnFour.FlatStyle = FlatStyle.Flat;
            btnFour.Font = new Font("Microsoft JhengHei UI Light", 16F);
            btnFour.ForeColor = Color.Black;
            btnFour.Location = new Point(5, 81);
            btnFour.Margin = new Padding(5);
            btnFour.Name = "btnFour";
            btnFour.Size = new Size(117, 66);
            btnFour.TabIndex = 3;
            btnFour.TabStop = false;
            btnFour.Text = "4";
            btnFour.UseVisualStyleBackColor = false;
            btnFour.Click += new EventHandler(btnFour_Click);
            btnFour.MouseLeave += new EventHandler(btnFour_MouseLeave);
            btnFour.MouseMove += new MouseEventHandler(btnFour_MouseMove);
            // 
            // btnThree
            // 
            btnThree.AutoSize = true;
            btnThree.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnThree.BackColor = Color.White;
            btnThree.Dock = DockStyle.Fill;
            btnThree.FlatAppearance.BorderColor = Color.FromArgb(153, 167, 153);
            btnThree.FlatStyle = FlatStyle.Flat;
            btnThree.Font = new Font("Microsoft JhengHei UI Light", 16F);
            btnThree.ForeColor = Color.Black;
            btnThree.Location = new Point(260, 5);
            btnThree.Margin = new Padding(5);
            btnThree.Name = "btnThree";
            btnThree.Size = new Size(119, 66);
            btnThree.TabIndex = 2;
            btnThree.TabStop = false;
            btnThree.Text = "3";
            btnThree.UseVisualStyleBackColor = false;
            btnThree.Click += new EventHandler(btnThree_Click);
            btnThree.MouseLeave += new EventHandler(btnThree_MouseLeave);
            btnThree.MouseMove += new MouseEventHandler(btnThree_MouseMove);
            // 
            // btnTwo
            // 
            btnTwo.AutoSize = true;
            btnTwo.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnTwo.BackColor = Color.White;
            btnTwo.Dock = DockStyle.Fill;
            btnTwo.FlatAppearance.BorderColor = Color.FromArgb(153, 167, 153);
            btnTwo.FlatStyle = FlatStyle.Flat;
            btnTwo.Font = new Font("Microsoft JhengHei UI Light", 16F);
            btnTwo.ForeColor = Color.Black;
            btnTwo.Location = new Point(132, 5);
            btnTwo.Margin = new Padding(5);
            btnTwo.Name = "btnTwo";
            btnTwo.Size = new Size(118, 66);
            btnTwo.TabIndex = 1;
            btnTwo.TabStop = false;
            btnTwo.Text = "2";
            btnTwo.UseVisualStyleBackColor = false;
            btnTwo.Click += new EventHandler(btnTwo_Click);
            btnTwo.MouseLeave += new EventHandler(btnTwo_MouseLeave);
            btnTwo.MouseMove += new MouseEventHandler(btnTwo_MouseMove);
            // 
            // btnOne
            // 
            btnOne.AutoSize = true;
            btnOne.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnOne.BackColor = Color.White;
            btnOne.Dock = DockStyle.Fill;
            btnOne.FlatAppearance.BorderColor = Color.FromArgb(153, 167, 153);
            btnOne.FlatStyle = FlatStyle.Flat;
            btnOne.Font = new Font("Microsoft JhengHei UI Light", 16F);
            btnOne.ForeColor = Color.Black;
            btnOne.Location = new Point(5, 5);
            btnOne.Margin = new Padding(5);
            btnOne.Name = "btnOne";
            btnOne.Size = new Size(117, 66);
            btnOne.TabIndex = 0;
            btnOne.TabStop = false;
            btnOne.Text = "1";
            btnOne.UseVisualStyleBackColor = false;
            btnOne.Click += new EventHandler(btnOne_Click);
            btnOne.MouseLeave += new EventHandler(btnOne_MouseLeave);
            btnOne.MouseMove += new MouseEventHandler(btnOne_MouseMove);
            // 
            // lblPin
            // 
            lblPin.BackColor = Color.White;
            lblPin.ForeColor = Color.Black;
            lblPin.BorderStyle = BorderStyle.FixedSingle;
            lblPin.Dock = DockStyle.Fill;
            lblPin.FlatStyle = FlatStyle.Flat;
            lblPin.Font = new Font("Microsoft JhengHei UI Light", 16F);
            lblPin.Location = new Point(5, 0);
            lblPin.Margin = new Padding(5, 0, 5, 0);
            lblPin.Name = "lblPin";
            lblPin.Size = new Size(374, 60);
            lblPin.TabIndex = 0;
            lblPin.Text = "Pin";
            lblPin.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // TLPButtons
            // 
            Size = new Size(350, 350);
            Padding = new Padding(3, 3, 3, 3);
            Controls.Add(TLPKeypad);
        }

        #region Properties

        [Category("Customize")]
        public Color KeypadBackColor
        {
            get { return keypadBackColor; }
            set
            {
                keypadBackColor = value;
                BackColor = keypadBackColor;
            }
        }

        [Category("Customize")]
        public Color OutputBackColor
        {
            get { return lblOutputBackColor; }
            set
            {
                lblOutputBackColor = value;
                lblPin.BackColor = lblOutputBackColor;
            }
        }

        [Category("Customize")]
        public Color OutputForeColor
        {
            get { return lblOutputForeColor; }
            set
            {
                lblOutputForeColor = value;
                lblPin.ForeColor = OutputForeColor;
            }
        }


        [Category("Customize")]
        public Color PinBackColor
        {
            get { return btnPinBackColor; }
            set
            {
                btnPinBackColor = value;
                foreach (Button pinBtn in pinButtons)
                {
                    pinBtn.BackColor = btnPinBackColor;
                }
            }
        }

        [Category("Customize")]
        public Color BackspaceBackColor
        {
            get { return btnBackspaceBackColor; }
            set
            {
                btnBackspaceBackColor = value;
                btnBackspace.BackColor = btnBackspaceBackColor;
            }
        }

        [Category("Customize")]
        public Color LoginBackColor
        {
            get { return btnLoginBackColor; }
            set
            {
                btnLoginBackColor = value;
                btnLogin.BackColor = btnLoginBackColor;
            }
        }

        [Category("Customize")]
        public Color FontColor
        {
            get { return btnFontColor; }
            set
            {
                btnFontColor = value;
                foreach (Button pinBtn in pinButtons)
                {
                    pinBtn.ForeColor = btnFontColor;
                }
            }
        }

        [Category("Customize")]
        public Color PinHighlightColor
        {
            get { return btnPinHighlightColor; }
            set
            {
                btnPinHighlightColor = value;
                foreach (Button pinBtn in pinButtons)
                {
                    pinBtn.FlatAppearance.MouseOverBackColor = btnPinHighlightColor;
                }
            }
        }

        [Category("Customize")]
        public Color BackspaceHighlightColor
        {
            get { return btnBackspaceHighlightColor; }
            set
            {
                btnBackspaceHighlightColor = value;
                btnBackspace.FlatAppearance.MouseOverBackColor = btnBackspaceHighlightColor;
            }
        }

        [Category("Customize")]
        public Color LoginHighlightColor
        {
            get { return btnLoginHighlightColor; }
            set
            {
                btnLoginHighlightColor = value;
                btnLogin.FlatAppearance.MouseOverBackColor = btnLoginHighlightColor;
            }
        }

        [Category("Customize")]
        public Color HighlightFontColor
        {
            get { return btnHighlightFontColor; }
            set
            {
                btnHighlightFontColor = value;
            }
        }

        [Category("Customize")]
        public int CharLimit
        {
            get { return charLimit; }
            set
            {
                if (value > 0 && value < 31)
                    charLimit = value;
            }
        }

        [Category("Customize")]
        public string Placeholder
        {
            get { return placeholder; }
            set
            {
                if (value.Length > 0 && value.Length < 31)
                {
                    placeholder = value;
                    lblPin.Text = placeholder;
                }

            }
        }

        [Category("Customize")]
        public Bitmap IconBackspace
        {
            get { return iconBackspace; }
            set
            {
                iconBackspace = value;
                btnBackspace.BackgroundImage = iconBackspace;
            }
        }

        [Category("Customize")]
        public Bitmap IconBackspaceHighlight
        {
            get { return iconBackspaceHighlight; }
            set
            {
                iconBackspaceHighlight = value;
            }
        }

        [Category("Customize")]
        public Bitmap IconLogin
        {
            get { return iconLogin; }
            set
            {
                iconLogin = value;
                btnLogin.BackgroundImage = iconLogin;
            }
        }

        [Category("Customize")]
        public Bitmap IconLoginHighlight
        {
            get { return iconLoginHighlight; }
            set
            {
                iconLoginHighlight = value;
            }
        }

        #endregion

        #region Custom Events
        [Category("Customize")]
        public event EventDelegate LoginButtonClick;
        #endregion

        #region Button Events
        #region btnOne Events
        private void btnOne_Click(object sender, EventArgs e)
        {
            if (pin.Length != charLimit)
                addCharToPin(btnOne.Text);
        }
        private void btnOne_MouseMove(object sender, EventArgs e)
        {
            btnOne.ForeColor = btnHighlightFontColor;
        }
        private void btnOne_MouseLeave(object sender, EventArgs e)
        {
            btnOne.ForeColor = btnFontColor;
        }
        #endregion

        #region btnTwo Events
        private void btnTwo_Click(object sender, EventArgs e)
        {
            if (pin.Length != charLimit)
                addCharToPin(btnTwo.Text);
        }
        private void btnTwo_MouseMove(object sender, EventArgs e)
        {
            btnTwo.ForeColor = btnHighlightFontColor;
        }
        private void btnTwo_MouseLeave(object sender, EventArgs e)
        {
            btnTwo.ForeColor = btnFontColor;
        }

        #endregion

        #region btnThree Events
        private void btnThree_Click(object sender, EventArgs e)
        {
            if (pin.Length != charLimit)
                addCharToPin(btnThree.Text);
        }
        private void btnThree_MouseMove(object sender, EventArgs e)
        {
            btnThree.ForeColor = btnHighlightFontColor;
        }
        private void btnThree_MouseLeave(object sender, EventArgs e)
        {
            btnThree.ForeColor = btnFontColor;
        }
        #endregion

        #region btnFour Events
        private void btnFour_Click(object sender, EventArgs e)
        {
            if (pin.Length != charLimit)
                addCharToPin(btnFour.Text);
        }
        private void btnFour_MouseMove(object sender, EventArgs e)
        {
            btnFour.ForeColor = btnHighlightFontColor;
        }
        private void btnFour_MouseLeave(object sender, EventArgs e)
        {
            btnFour.ForeColor = btnFontColor;
        }

        #endregion

        #region btnFive Events
        private void btnFive_Click(object sender, EventArgs e)
        {
            if (pin.Length != charLimit)
                addCharToPin(btnFive.Text);
        }
        private void btnFive_MouseMove(object sender, EventArgs e)
        {
            btnFive.ForeColor = btnHighlightFontColor;
        }
        private void btnFive_MouseLeave(object sender, EventArgs e)
        {
            btnFive.ForeColor = btnFontColor;
        }
        #endregion

        #region btnSix Events
        private void btnSix_Click(object sender, EventArgs e)
        {
            if (pin.Length != charLimit)
                addCharToPin(btnSix.Text);
        }
        private void btnSix_MouseMove(object sender, EventArgs e)
        {
            btnSix.ForeColor = btnHighlightFontColor;
        }
        private void btnSix_MouseLeave(object sender, EventArgs e)
        {
            btnSix.ForeColor = btnFontColor;
        }
        #endregion

        #region btnSeven Events
        private void btnSeven_Click(object sender, EventArgs e)
        {
            if (pin.Length != charLimit)
                addCharToPin(btnSeven.Text);
        }
        private void btnSeven_MouseMove(object sender, EventArgs e)
        {
            btnSeven.ForeColor = btnHighlightFontColor;
        }
        private void btnSeven_MouseLeave(object sender, EventArgs e)
        {
            btnSeven.ForeColor = btnFontColor;
        }
        #endregion

        #region btnEight Events
        private void btnEight_Click(object sender, EventArgs e)
        {
            if (pin.Length != charLimit)
                addCharToPin(btnEight.Text);
        }
        private void btnEight_MouseMove(object sender, EventArgs e)
        {
            btnEight.ForeColor = btnHighlightFontColor;
        }
        private void btnEight_MouseLeave(object sender, EventArgs e)
        {
            btnEight.ForeColor = btnFontColor;
        }
        #endregion

        #region btnNine Events
        private void btnNine_Click(object sender, EventArgs e)
        {
            if (pin.Length != charLimit)
                addCharToPin(btnNine.Text);
        }
        private void btnNine_MouseMove(object sender, EventArgs e)
        {
            btnNine.ForeColor = btnHighlightFontColor;
        }
        private void btnNine_MouseLeave(object sender, EventArgs e)
        {
            btnNine.ForeColor = btnFontColor;
        }
        #endregion

        #region btnBackspace Events
        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(pin))
            {
                string pinText = lblPin.Text;

                pin = pin.Substring(0, pin.Length - 1);
                lblPin.Text = pinText.Substring(0, pinText.Length - 1);
            }
        }
        private void btnBackspace_MouseMove(object sender, EventArgs e)
        {
            btnBackspace.BackColor = btnBackspaceHighlightColor;
            btnBackspace.BackgroundImage = iconBackspaceHighlight;
        }
        private void btnBackspace_MouseLeave(object sender, EventArgs e)
        {
            btnBackspace.BackColor = btnBackspaceBackColor;
            btnBackspace.BackgroundImage = iconBackspace;
        }
        #endregion

        #region btnZero Events
        private void btnZero_Click(object sender, EventArgs e)
        {
            if (pin.Length != charLimit)
                addCharToPin(btnZero.Text);
        }
        private void btnZero_MouseMove(object sender, EventArgs e)
        {
            btnZero.ForeColor = btnHighlightFontColor;
        }
        private void btnZero_MouseLeave(object sender, EventArgs e)
        {
            btnZero.ForeColor = btnFontColor;
        }
        #endregion

        #region btnLogin Events
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (LoginButtonClick != null)
            {
                LoginButtonClick(pin, EventArgs.Empty);
            }
        }
        private void btnLogin_MouseMove(object sender, EventArgs e)
        {
            btnLogin.BackColor = btnLoginHighlightColor;
            btnLogin.BackgroundImage = iconLoginHighlight;
        }
        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = btnLoginBackColor;
            btnLogin.BackgroundImage = iconLogin;
        }

        #endregion
        #endregion

        private void addCharToPin(string c)
        {
            if (!String.IsNullOrEmpty(pin))
            {
                pin += c;
                lblPin.Text += "*";
            }
            else
            {
                pin = c;
                lblPin.Text = "*";
            }
        }
    }
}
