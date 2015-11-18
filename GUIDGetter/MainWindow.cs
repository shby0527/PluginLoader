using System;
using System.Security.Cryptography;
using System.Text;
using System.Security;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnButton1Clicked (object sender, EventArgs e)
	{
		using (SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider ()) {
			string input = entry1.Text;
			//we should add the time to compute the hash value
			input += DateTime.UtcNow.ToString ();
			byte[] indata = Encoding.UTF8.GetBytes (input);
			byte[] outdata = sha256.ComputeHash (indata);
			this.entry1.Text = BitConverter.ToString (outdata).Replace ("-", "");
		}
	}
}
