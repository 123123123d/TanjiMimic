using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Design;
using System.ComponentModel;

namespace TanjiMimic.Utilities.Controls
{
    [System.ComponentModel.DesignerCategory("Code")]
    public sealed class TButton : Control, IButtonControl
    {
        #region Private Fields
        private int _mState;
        #endregion

        #region Public Properties
        #region Attributes
        [Browsable(false)]
        #endregion
        public override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        #region Attributes
        [Browsable(false)]
        #endregion
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set { base.ForeColor = value; }
        }

        #region Attributes
        [Browsable(false)]
        #endregion
        public override Image BackgroundImage
        {
            get { return base.BackgroundImage; }
            set { base.BackgroundImage = value; }
        }

        #region Attributes
        [Browsable(false)]
        #endregion
        public override ImageLayout BackgroundImageLayout
        {
            get { return base.BackgroundImageLayout; }
            set { base.BackgroundImageLayout = value; }
        }

        #region Attributes
        [SettingsBindable(true)]
        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        #endregion
        public override string Text
        {
            get { return base.Text; }
            set { base.Text = value; Invalidate(); }
        }

        private Color _buttonColor = Color.DodgerBlue;
        [DefaultValue(typeof(Color), "DodgeBlue")]
        public Color ButtonColor
        {
            get { return _buttonColor; }
            set
            {
                _buttonColor = value;
                Invalidate();
            }
        }
        #endregion

        #region Constructor(s)
        public TButton()
        {
            SetStyle((ControlStyles)2050, true);
            DoubleBuffered = true;

            Size = new Size(100, 23);
            BackColor = Color.Transparent;
        }
        #endregion

        #region Protected Methods (Overrides)
        protected override void OnPaint(PaintEventArgs e)
        {
            if (Enabled)
            {
                e.Graphics.Clear(ButtonColor);
                e.Graphics.DrawBorders(Color.FromArgb(50, Color.Black), ClientRectangle);
                if (_mState == Draw.MStateDown)
                {
                    const int height = 10;
                    e.Graphics.FillGradient(Color.FromArgb(25, Color.Black), Color.Transparent, new Rectangle(0, 0, Width, height));
                    e.Graphics.FillGradient(Color.FromArgb(25, Color.Black), Color.Transparent, new Rectangle(0, Height - height, Width, height), 270);
                }
                e.Graphics.DrawString(Text, Font, Color.FromArgb(_mState != Draw.MStateDown ? 100 : 150, Color.Black), new Rectangle(1, 1, Width, Height + 1), StringAlignment.Center);
                e.Graphics.DrawString(Text, Font, Color.White, new Rectangle(0, 0, Width, Height + 1), StringAlignment.Center);
            }
            else
            {
                e.Graphics.Clear(SystemColors.Control);
                e.Graphics.DrawBorders(Color.FromArgb(50, Color.Black), ClientRectangle);
                e.Graphics.DrawString(Text, Font, Color.FromArgb(150, Color.Black), new Rectangle(0, 0, Width, Height + 1), StringAlignment.Center);
            }
            base.OnPaint(e);
        }
        protected override void OnClick(EventArgs e)
        { }
        protected override void OnMouseLeave(EventArgs e)
        {
            _mState = Draw.MStateNone;
            Invalidate();
            base.OnMouseLeave(e);
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            _mState = Draw.MStateOver;
            Invalidate();
            base.OnMouseEnter(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            bool isLeft = e.Button == MouseButtons.Left;
            if (isLeft)
            {
                _mState = Draw.MStateOver;
                Invalidate();
            }
            base.OnMouseUp(e);
            if (ClientRectangle.Contains(e.Location) && isLeft)
                base.OnClick(e);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _mState = Draw.MStateDown;
                Invalidate();
            }
            base.OnMouseDown(e);
        }
        #endregion

        #region IButtonControl
        #region Attributes
        [Description("Gets or sets a value that is returned to the parent form when the button is clicked.")]
        #endregion
        public DialogResult DialogResult { get; set; }

        public void PerformClick()
        {
            base.OnClick(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
        }
        public void NotifyDefault(bool value)
        { }
        #endregion
    }
}