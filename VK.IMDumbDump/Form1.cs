using core;
using System;
using System.Windows.Forms;
using System.Linq;
namespace VK.IMDumbDump {
	public partial class frm_main : Form {
		Dumper dmp = new Dumper();
		public frm_main() {
			InitializeComponent();
		}

		private void btn_login_Click( object sender, EventArgs e ) {
			dmp.Connect( txt_login.Text, txt_pass.Text );
			btn_login.Enabled = !( btn_logout.Enabled = grp_dump.Enabled = dmp.LoggedIn );
			lst_dialogs.Items.Clear();
			lst_dialogs.Items.AddRange( dmp.GetDialogs() );
		}

		private void btn_logout_Click( object sender, EventArgs e ) {
			dmp.Disconnect();
		}

		private void btn_dump_Click( object sender, EventArgs e ) {
			dmp.Dump( txt_save_path.Text, lst_dialogs.CheckedItems.OfType<Dialog>().ToArray() );
			MessageBox.Show( "Winrar!","Finished", MessageBoxButtons.OK, MessageBoxIcon.Information );
		}

		private void btn_browse_Click( object sender, EventArgs e ) {
			if ( sfd.ShowDialog() == DialogResult.OK )
				txt_save_path.Text = sfd.SelectedPath;
		}

		private void btn_check_all_dialogs_Click( object sender, EventArgs e ) {
			check( true );
		}
		private void check( bool b ) {
			int cnt = lst_dialogs.Items.Count;
			for ( int i = 0; i < cnt; lst_dialogs.SetItemChecked( i++, b ) ) ;
		}
		private void btn_uncheck_all_dialogs_Click( object sender, EventArgs e ) {
			check( false );
		}
	}
}
