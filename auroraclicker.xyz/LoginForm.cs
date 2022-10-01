using System;
using System.Diagnostics;
using System.Windows.Forms;

using static helpers.WinAPI;

namespace auroraas_recodes {
    public partial class LoginForm : Form {
        public LoginForm( ) {
            InitializeComponent( );
        }
        public static string username;

        private void player_button_Click( object sender , EventArgs e ) {
            //--------------------------------------------------------//
                new MainForm( ).Show( );
        }

        private void LoginForm_FormClosing( object sender , FormClosingEventArgs e ) {
            Process.GetCurrentProcess( ).Kill( );
            Application.Exit( );
        }
    }
}
