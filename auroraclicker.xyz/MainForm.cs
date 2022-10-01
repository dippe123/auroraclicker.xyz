using helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

using static helpers.WinAPI;
using static helpers.WinStructs;

namespace auroraas_recodes {
    public partial class MainForm : Form {
        public MainForm( ) {
            InitializeComponent( );
            var values = Enum.GetValues( typeof( Keys ) );
            foreach ( Keys key in values )
                if ( key != Keys.LButton && key != Keys.MButton && key != Keys.RButton )
                    bindList.Add( key );
            Opacity = 0;
            AllowTransparency = true;
            clickBox.Items.Add( "butterfly a" );
            clickBox.Items.Add( "butterfly b" );
            clickBox.Items.Add( "jitter a" );
            clickBox.Items.Add( "jitter b" );
            clickBox.SelectedItem = "butterfly a";
        }
        #region Variables
        Random r = new Random( );
        Stopwatch MouseClickTimer = new Stopwatch( );
        Keys PlayerKey, Hidekey;
        private List<Keys> bindList = new List<Keys>( );
        bool isVisible = true, isFirstClick, player_searching = false, hide_searching = false;
        private static string [ ] clicksLines;
        int counter, shufflecounter;
        #endregion
        #region ScrollBars
        private void shakechance_scrollbar_Scroll( object sender , ScrollEventArgs e ) => chance_lbl.Text = Convert.ToInt32( shakechance_scrollbar.Value ).ToString( ) + "%";
        private void MultiplierScrollbar_Scroll_1( object sender , ScrollEventArgs e ) => MultiplierLbL.Text = ( MultiplierScrollbar.Value / 100 ).ToString( "F2" ) + "x";
        private void verticalShakeScroll_Scroll( object sender , ScrollEventArgs e ) => VerticalValuelbl.Text = Convert.ToInt32( verticalShakeScroll.Value / 10 ).ToString( );
        private void HorizontalShakeScroll_Scroll( object sender , ScrollEventArgs e ) => HorizontalValuelbl.Text = Convert.ToInt32( HorizontalShakeScroll.Value / 10 ).ToString( );
        #endregion
        #region KeyBindings
        public static bool IsKeyDown( Keys key ) {
            return KeyStates.Down == ( GetKeyState( key ) & KeyStates.Down );
        }
        [DllImport( "user32.dll" , CharSet = CharSet.Auto , ExactSpelling = true )] private static extern short GetKeyState( int keyCode );
        private static KeyStates GetKeyState( Keys key ) {
            KeyStates keyStates = KeyStates.None;
            short keyState = GetKeyState( ( int ) key );
            if ( ( keyState & 32768 ) == 32768 ) {
                keyStates |= KeyStates.Down;
            }

            if ( ( keyState & 1 ) == 1 ) {
                keyStates |= KeyStates.Toggled;
            }
            return keyStates;
        }
        [Flags]
        private enum KeyStates {
            None = 0,
            Down = 1,
            Toggled = 2
        }
        private void bindListener_Tick( object sender , EventArgs e ) {
            if ( !IsKeyDown( Keys.LButton ) && !IsKeyDown( Keys.RButton ) ) {
                foreach ( Keys keys in bindList ) {
                    if ( IsKeyDown( keys ) && player_searching ) {
                        if ( !IsKeyDown( Keys.Escape ) ) {
                            PlayerKey = keys;
                            player_button.Text = PlayerKey.ToString( ).ToLower( );
                            player_searching = false;
                        } else {
                            player_button.Text = "click to bind";
                            player_searching = false;
                        }
                    }
                    if ( IsKeyDown( keys ) && hide_searching ) {
                        if ( !IsKeyDown( Keys.Escape ) ) {
                            Hidekey = keys;
                            hidebtn.Text = Hidekey.ToString( ).ToLower( );
                            hide_searching = false;
                        } else {
                            hidebtn.Text = "hide";
                            hide_searching = false;
                        }
                    }
                }
            }
        }

        private void bindTimer_Tick( object sender , EventArgs e ) {
            if ( IsKeyDown( PlayerKey ) ) {
                enabled_clicker.Checked = !enabled_clicker.Checked;
                Thread.Sleep( 250 );
            }
            if ( IsKeyDown( Hidekey ) ) {
                Thread.Sleep( 250 );
                if ( isVisible ) {
                    Opacity = 1.0;
                    fadeOut.Start( );
                    isVisible = false;
                } else {
                    Opacity = 0.0;
                    Show( );
                    fadeIn.Start( );
                    isVisible = true;
                }
            }
        }

        #endregion
        #region Methods
        private void ClickingThread( ) {
            try {
                if ( enabled_clicker.Checked ) {
                    if ( !isCursorVisible( ) ) {
                        if ( custompat_chck.Checked ) {
                            SendClicks( );
                        } else {
                            PatternClicker( );
                        }
                    }
                    if ( inventory_click.Checked ) {
                        if ( custompat_chck.Checked ) {
                            SendClicks( );
                        } else {
                            PatternClicker( );
                        }
                    }
                }
                if ( GetAsyncKeyState( Keys.LButton ) >= 0 ) {
                    isFirstClick = true;
                    MouseClickTimer.Stop( );
                }
            } catch { }
        }
        private int PatternRand( ) {
            // removed randomizer
            return 0;
        }
        public void PatternClicker( ) {
            if ( isFirstClick ) {
                MouseClickTimer.Reset( );
                MouseClickTimer.Start( );
                isFirstClick = false;
            }
            if ( counter % 2 == 0 ) { counter++; }
            try {
                if ( Locator.GetMinecraftWindow( ) ) {
                    if ( MouseClickTimer.ElapsedMilliseconds > r.Next( 75 , 100 ) ) {
                        if ( !isFirstClick ) {
                            if ( GetAsyncKeyState( Keys.LButton ) < 0 ) {
                                PostMessage( GetForegroundWindow( ) , 513U , 0 , 0 );
                                Thread.Sleep( PatternRand( ) );
                                if ( jitterenable_checkbox.Checked ) { Jitter( ); }
                                PostMessage( GetForegroundWindow( ) , 514U , 0 , 0 );
                                Thread.Sleep( PatternRand( ) );
                                if ( jitterenable_checkbox.Checked ) { Jitter( ); }
                            }
                        }
                    }
                }
            } catch { }
        }
        public void SendClicks( ) {
            if ( isFirstClick ) {
                MouseClickTimer.Reset( );
                MouseClickTimer.Start( );
                isFirstClick = false;
            }
            if ( counter % 2 == 0 ) { counter++; }
            try {
                if ( Locator.GetMinecraftWindow( ) ) {
                    if ( MouseClickTimer.ElapsedMilliseconds > r.Next( 75 , 100 ) ) {
                        if ( !isFirstClick && counter < clicksLines.Length - 1 ) {
                            if ( GetAsyncKeyState( Keys.LButton ) < 0 ) {
                                PostMessage( GetForegroundWindow( ) , 513U , 0 , 0 );
                                Thread.Sleep( Convert.ToInt32( getDelay( counter++ ) ) );
                                shufflecounter++;
                                if ( jitterenable_checkbox.Checked ) { Jitter( ); }
                                PostMessage( GetForegroundWindow( ) , 514U , 0 , 0 );
                                Thread.Sleep( Convert.ToInt32( getDelay( counter++ ) ) );
                                if ( jitterenable_checkbox.Checked ) { Jitter( ); }
                                shufflecounter++;
                                if ( jitterenable_checkbox.Checked ) { Jitter( ); }
                                if ( shuffle_clicks.Checked ) {
                                    if ( shufflecounter >= 100 ) {
                                        shufflecounter = 0;
                                        counter = r.Next( 0 , clicksLines.Length / r.Next( 3 , 5 ) );
                                        startingpoint_lbl.Text = counter.ToString( );
                                        if ( counter % 2 == 1 ) { counter++; }
                                    }
                                }
                            }
                        } else {
                            counter = r.Next( 0 , clicksLines.Length / r.Next( 3 , 5 ) );
                            startingpoint_lbl.Text = counter.ToString( );
                            if ( counter % 2 == 1 ) { counter++; }
                        }
                    }
                }
            } catch { }
        }
        private double getDelay( int counter ) {
            return Convert.ToDouble( Math.Round( Convert.ToDouble( clicksLines [ counter ] ) ) ) / Convert.ToDouble( MultiplierScrollbar.Value / 100 );
        }

        private static void SetTimerResolution( ) {
            uint timer = 0U;
            NtSetTimerResolution( 5000 , true , ref timer );
            MM_BeginPeriod( 1U );
        }

        public void Jitter( ) {
            Random r = new Random( );
            int x = ( int ) Math.Round( Cursor.Position.X * 0.002 + Convert.ToInt32( verticalShakeScroll.Value / 10 / 2 ) );
            int x_ = ( int ) Math.Round( Cursor.Position.X * 0.003 + Convert.ToInt32( verticalShakeScroll.Value / 10 / 2 ) );
            int y = ( int ) Math.Round( Cursor.Position.Y * 0.002 + Convert.ToInt32( HorizontalShakeScroll.Value / 10 / 2 ) );
            int y_ = ( int ) Math.Round( Cursor.Position.Y * 0.003 + Convert.ToInt32( HorizontalShakeScroll.Value / 10 / 2 ) );
            if ( !isCursorVisible( ) && r.Next( 0 , 100 ) <= shakechance_scrollbar.Value )
                Cursor.Position = checked(new Point( Cursor.Position.X + r.Next( -1 * x , x_ ) , Cursor.Position.Y + r.Next( -1 * y , y_ ) ));
        }
        public static bool isCursorVisible( ) {
            CURSORINFO cursorInfo = new CURSORINFO( );
            cursorInfo.cbSize = Marshal.SizeOf( cursorInfo );
            if ( GetCursorInfo( out cursorInfo ) ) {
                int mousehandle_int = ( int ) cursorInfo.hCursor;
                if ( mousehandle_int > 50000 & mousehandle_int < 100000 )
                    return true;
                else
                    return false;
            }
            return false;
        }
        #endregion
        #region Buttons
        private void destructbtn_Click( object sender , EventArgs e ) {
            destructbtn.Text = "cleaning strings.";
            destructbtn.Refresh( );
            Thread.Sleep( 500 );
            destructbtn.Text = "cleaning strings..";
            destructbtn.Refresh( );
            Thread.Sleep( 500 );
            destructbtn.Text = "cleaning strings...";
            destructbtn.Refresh( );
            Thread.Sleep( 500 );
            destruct.Destruct.InitDestruct( );
        }
        private void hidebtn_Click_1( object sender , EventArgs e ) {
            if ( player_searching ) return;
            Hidekey = Keys.None;
            hide_searching = true;
            hidebtn.Text = "...";
        }

        private void select_clicks_Click( object sender , EventArgs e ) {
            select_clicks.Text = "...";
            OpenFileDialog openFileDialog = new OpenFileDialog {
                Filter = "Data Files (.txt)|*.txt" ,
                Multiselect = false ,
                Title = "Select Your Clicks Delays" ,
            };
            if ( openFileDialog.ShowDialog( ) == DialogResult.OK && openFileDialog.FileName != null ) {
                clicksLines = File.ReadAllLines( openFileDialog.FileName );
                counter = r.Next( 0 , clicksLines.Length / r.Next( 3 , 5 ) );
                if ( counter % 2 == 1 ) { counter++; } else counter++;
                startingpoint_lbl.Text = counter.ToString( );
                select_clicks.Text = openFileDialog.SafeFileName;
                delays_lbl.Text = clicksLines.Length.ToString( );
            }
        }
        private void player_button_Click_1( object sender , EventArgs e ) {
            if ( hide_searching ) return;
            PlayerKey = Keys.None;
            player_searching = true;
            player_button.Text = "...";
        }
        #endregion
        #region CheckBox
        private void scrnshr_proof_CheckedChanged( object sender , EventArgs e ) {
            if ( scrnshr_proof.Checked ) {
                ShowInTaskbar = false;
                SetWindowDisplayAffinity( Handle , 0x00000011 );
            } else {
                ShowInTaskbar = true;
                SetWindowDisplayAffinity( Handle , 0 );
            }
        }


        #endregion

        #region Threads
        private void timer1_Tick( object sender , EventArgs e ) {
            if ( Opacity < 1 ) {
                Opacity += 0.185;
            } else {
                fadeIn.Stop( );
            }
        }
        private void ColorTimer_Tick( object sender , EventArgs e ) {
            if ( jitterenable_checkbox.Checked ) {
                jitterenable_checkbox.ForeColor = Color.LimeGreen;
            } else {
                jitterenable_checkbox.ForeColor = Color.FromArgb( 150 , 153 , 155 );
            }
            if ( clear_strings_lbl.Checked ) {
                clear_strings_lbl.ForeColor = Color.LimeGreen;
            } else {
                clear_strings_lbl.ForeColor = Color.FromArgb( 150 , 153 , 155 );
            }
            if ( custompat_chck.Checked ) {
                custompat_chck.ForeColor = Color.LimeGreen;
                clickBox.Enabled = false;
                select_clicks.Enabled = true;
                shuffle_clicks.Enabled = true;
                MultiplierScrollbar.Enabled = true;
            } else {
                custompat_chck.ForeColor = Color.FromArgb( 150 , 153 , 155 );
                clickBox.Enabled = true;
                select_clicks.Enabled = false;
                shuffle_clicks.Enabled = false;
                MultiplierScrollbar.Enabled = false;
            }
            if ( enabled_clicker.Checked ) {
                enabled_clicker.ForeColor = Color.LimeGreen;
            } else {
                enabled_clicker.ForeColor = Color.FromArgb( 150 , 153 , 155 );
            }
            if ( inventory_click.Checked ) {
                inventory_click.ForeColor = Color.LimeGreen;
            } else {
                inventory_click.ForeColor = Color.FromArgb( 150 , 153 , 155 );
            }
            if ( shuffle_clicks.Checked ) {
                shuffle_clicks.ForeColor = Color.LimeGreen;
            } else {
                shuffle_clicks.ForeColor = Color.FromArgb( 150 , 153 , 155 );
            }
            if ( scrnshr_proof.Checked ) {
                scrnshr_proof.ForeColor = Color.LimeGreen;
            } else {
                scrnshr_proof.ForeColor = Color.FromArgb( 150 , 153 , 155 );
            }
        }
        private void fadeOut_Tick( object sender , EventArgs e ) {
            if ( Opacity > 0 )
                Opacity -= 0.185;
            else {
                fadeOut.Stop( );
                Hide( );
            }
        }
        private void clickThread_Tick( object sender , EventArgs e ) {
            ClickingThread( );
            SetTimerResolution( );
        }
        #endregion
        #region Form_Events
        private void MainForm_Load( object sender , EventArgs e ) {
            Thread.Sleep( 100 );
            fadeIn.Start( );
        }
        private void MainForm_FormClosing( object sender , FormClosingEventArgs e ) {
            destruct.Destruct.InitDestruct( );
            Hide( );
            fadeOut.Start( );
            Environment.Exit( 0 );
        }
        #endregion
    }
}

