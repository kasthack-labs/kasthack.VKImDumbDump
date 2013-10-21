using core;
using System;
using System.Windows.Forms;
using System.Linq;
namespace VK.IMDumbDump {
	public partial class FrmMain : Form {
	    readonly Dumper _dmp = new Dumper();
		public FrmMain() {
			InitializeComponent();
		}

		private async void btn_login_Click( object sender, EventArgs e ) {
		    btn_login.Enabled = false;
            await this._dmp.ConnectAsync( txt_login.Text, txt_pass.Text );
			btn_login.Enabled = !( btn_logout.Enabled = grp_dump.Enabled = this._dmp.LoggedIn );
			lst_dialogs.Items.Clear();
			lst_dialogs.Items.AddRange( await this._dmp.GetDialogsAsync() );
		}

		private void btn_logout_Click( object sender, EventArgs e ) {
			this._dmp.Disconnect();
		}

		private async void btn_dump_Click( object sender, EventArgs e ) {
		    btn_dump.Enabled = false;
		    btn_dump.Text = @"Dumping";
            await this._dmp.DumpAsync( txt_save_path.Text, lst_dialogs.CheckedItems.OfType<Dialog>().ToArray(), chk_photos.Checked );
            btn_dump.Text = @"Dump!";
            btn_dump.Enabled = true;
			MessageBox.Show( @"Winrar!",@"Finished", MessageBoxButtons.OK, MessageBoxIcon.Information );
		}

		private void btn_browse_Click( object sender, EventArgs e ) {
			if ( sfd.ShowDialog() == DialogResult.OK )
				txt_save_path.Text = sfd.SelectedPath;
		}

		private void btn_check_all_dialogs_Click( object sender, EventArgs e ) {
			this.Check( true );
		}
		private void Check( bool b ) {
			var cnt = lst_dialogs.Items.Count;
			for ( var i = 0; i < cnt; lst_dialogs.SetItemChecked( i++, b ) ) {}
		}
		private void btn_uncheck_all_dialogs_Click( object sender, EventArgs e ) {
			this.Check( false );
		}
	}
}
