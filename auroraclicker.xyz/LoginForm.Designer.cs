namespace auroraas_recodes {
    partial class LoginForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if ( disposing && ( components != null ) ) {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( ) {
            this.components = new System.ComponentModel.Container();
            this.player_button = new Guna.UI2.WinForms.Guna2GradientButton();
            this.left_title = new System.Windows.Forms.Label();
            this.usernametext = new Guna.UI2.WinForms.Guna2TextBox();
            this.pswdtext = new Guna.UI2.WinForms.Guna2TextBox();
            this.left_toggler = new Guna.UI2.WinForms.Guna2Separator();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.SuspendLayout();
            // 
            // player_button
            // 
            this.player_button.Animated = true;
            this.player_button.BackColor = System.Drawing.Color.Transparent;
            this.player_button.BorderRadius = 2;
            this.player_button.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.player_button.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.player_button.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.player_button.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.player_button.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.player_button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(41)))), ((int)(((byte)(58)))));
            this.player_button.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(41)))), ((int)(((byte)(58)))));
            this.player_button.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.player_button.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.player_button.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.player_button.Location = new System.Drawing.Point(91, 125);
            this.player_button.Name = "player_button";
            this.player_button.PressedDepth = 0;
            this.player_button.Size = new System.Drawing.Size(171, 32);
            this.player_button.TabIndex = 49;
            this.player_button.Text = "login";
            this.player_button.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.LowerCase;
            this.player_button.UseTransparentBackground = true;
            this.player_button.Click += new System.EventHandler(this.player_button_Click);
            // 
            // left_title
            // 
            this.left_title.BackColor = System.Drawing.Color.Transparent;
            this.left_title.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.left_title.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.left_title.Location = new System.Drawing.Point(151, 1);
            this.left_title.Name = "left_title";
            this.left_title.Size = new System.Drawing.Size(50, 18);
            this.left_title.TabIndex = 50;
            this.left_title.Text = "Login";
            this.left_title.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // usernametext
            // 
            this.usernametext.BorderColor = System.Drawing.Color.White;
            this.usernametext.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.usernametext.DefaultText = "";
            this.usernametext.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.usernametext.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.usernametext.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.usernametext.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.usernametext.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.usernametext.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.usernametext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.usernametext.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.usernametext.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.usernametext.Location = new System.Drawing.Point(92, 46);
            this.usernametext.Name = "usernametext";
            this.usernametext.PasswordChar = '\0';
            this.usernametext.PlaceholderText = "username";
            this.usernametext.SelectedText = "";
            this.usernametext.Size = new System.Drawing.Size(171, 26);
            this.usernametext.TabIndex = 51;
            // 
            // pswdtext
            // 
            this.pswdtext.BorderColor = System.Drawing.Color.White;
            this.pswdtext.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pswdtext.DefaultText = "";
            this.pswdtext.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.pswdtext.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.pswdtext.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.pswdtext.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.pswdtext.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.pswdtext.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.pswdtext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.pswdtext.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.pswdtext.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.pswdtext.Location = new System.Drawing.Point(92, 85);
            this.pswdtext.Name = "pswdtext";
            this.pswdtext.PasswordChar = '*';
            this.pswdtext.PlaceholderText = "password";
            this.pswdtext.SelectedText = "";
            this.pswdtext.Size = new System.Drawing.Size(171, 26);
            this.pswdtext.TabIndex = 52;
            // 
            // left_toggler
            // 
            this.left_toggler.BackColor = System.Drawing.Color.Transparent;
            this.left_toggler.FillColor = System.Drawing.Color.WhiteSmoke;
            this.left_toggler.FillThickness = 2;
            this.left_toggler.Location = new System.Drawing.Point(0, 22);
            this.left_toggler.Name = "left_toggler";
            this.left_toggler.Size = new System.Drawing.Size(348, 13);
            this.left_toggler.TabIndex = 53;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 1D;
            this.guna2DragControl1.DragStartTransparencyValue = 1D;
            this.guna2DragControl1.TargetControl = this;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.ClientSize = new System.Drawing.Size(346, 173);
            this.Controls.Add(this.left_toggler);
            this.Controls.Add(this.pswdtext);
            this.Controls.Add(this.usernametext);
            this.Controls.Add(this.left_title);
            this.Controls.Add(this.player_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientButton player_button;
        private System.Windows.Forms.Label left_title;
        private Guna.UI2.WinForms.Guna2TextBox usernametext;
        private Guna.UI2.WinForms.Guna2TextBox pswdtext;
        private Guna.UI2.WinForms.Guna2Separator left_toggler;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
    }
}