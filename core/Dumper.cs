using EpicMorg.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
namespace core
{
    public class Dumper {
		private bool _LoggedIn;
		static string _dialogs_list_url = "https://vk.com/al_im.php?act=a_get_dialogs&al=1&offset=";
		public CookieCollection LoginCookies;
		public bool LoggedIn {
			get { return _LoggedIn; }
		}
		static CookieCollection DoLoginVk( string email, string password ) {
			var auth_url = "http://m.vk.com/login?fast=1&hash=&s=0&to=";
			try {
				#region Send password
				email = email.Replace( "@", "%40" );
				string getHash = AdvancedWebClient.DownloadString(auth_url );
				string posturl = new Regex( "https:\\/\\/login\\.vk.com\\/.*\"" ).Match( getHash ).ToString();
				posturl = posturl.Substring( 0, posturl.Length - 1 );
				byte[] data = new System.Text.ASCIIEncoding().GetBytes( "email=" + email + "&pass=" + password );
				ServicePointManager.ServerCertificateValidationCallback += ( a, b, c, d ) => true;
				HttpWebRequest request = ( HttpWebRequest ) WebRequest.Create( posturl );
				#region Headers
				request.UserAgent = "Opera/9.80 (Windows NT 6.1; U; ru) Presto/2.7.62 Version/11.00";
				request.Method = "POST";
				request.Referer = auth_url;
				request.ContentType = "application/x-www-form-urlencoded";
				request.ContentLength = data.Length;
				request.CookieContainer = new CookieContainer();
				request.CookieContainer.Add( new Cookie( "remixlang", "0", "/", "login.vk.com" ) );
				request.CookieContainer.Add( new Cookie( "remixchk", "5", "/", "login.vk.com" ) );

				request.MaximumAutomaticRedirections = 1;
				#endregion
				Stream stream = request.GetRequestStream();
				stream.Write( data, 0, data.Length );
				stream.Close();
				//stream.Dispose();
				var z = ( HttpWebResponse ) request.GetResponse();
				var xx = new StreamReader( z.GetResponseStream() ).ReadToEnd();
				#endregion
			}
			catch ( WebException Ex ) {
				#region Get cookies from valid response
				if ( Ex.Response != null ) {
					var cook = ( ( HttpWebResponse ) Ex.Response ).Cookies;
					if ( cook.Count > 0 && cook[ "remixsid" ].Value != "deleted" )
						return cook;
					else throw;
				}
				#endregion
				else throw;
			}
			catch ( Exception ex ) {
				return null;
			}
			return null;
		}		
		public void Connect( string Login, string Password ) {
			LoginCookies = DoLoginVk( Login, Password );
			try {
				if ( LoginCookies != null && !String.IsNullOrEmpty( LoginCookies[ "remixsid" ].Value.Trim() ) && LoginCookies[ "remixsid" ].Value.Trim() != "deleted" ) {
					LoginCookies.Add( new Cookie( "audio_vol", "100", LoginCookies[ "remixsid" ].Path, LoginCookies[ "remixsid" ].Domain ) );
					LoginCookies.Add( new Cookie( "remixseenads", "1", LoginCookies[ "remixsid" ].Path, LoginCookies[ "remixsid" ].Domain ) );
					LoginCookies.Add( new Cookie( "remixdt", "-3600", LoginCookies[ "remixsid" ].Path, LoginCookies[ "remixsid" ].Domain ) );
					this._LoggedIn = true;
					return;
				}
			}
			catch { }
			this._LoggedIn=false;
		}
		public void Disconnect() {
			this.LoginCookies = null;
			this._LoggedIn = false;
		}
		public void Dump(string path, Dialog[] _dialogs) {
			if ( !this.LoggedIn )
				throw new InvalidOperationException( "User must be logged in" );
			foreach ( var v in _dialogs )
				File.WriteAllText( Path.Combine( path, v.Name )+".html", v.GetHistory() );
		}
		public Dialog[] GetDialogs() {
		try{
			List<Dialog[]> _d = new List<Dialog[]>();
			Dialog[] _temp = null;
			Encoding vk_encoding = Encoding.GetEncoding( 1251 );
			int offset = 0;
			bool listing = true;
			while(listing){
				_temp = Dialog.ParseDialogsFromHtml( AdvancedWebClient.DownloadString( _dialogs_list_url + offset, vk_encoding,this.LoginCookies ) );
				offset += _temp.Length;
				if ( _temp.Length == 0 ) {
					listing = false;
					break;
				}
				_d.Add( _temp);
			}
			var _ret = _d.SelectMany( a => a ).ToArray();
			foreach ( var v in _ret )
				v._Cookies = this.LoginCookies;
			return _ret;
			}catch{return new Dialog[]{};} 
		}
	}
	public class Dialog {
		static string _dialog_fetch_url = "http://vk.com/al_im.php?act=a_history&al=1&offset=0&rev=0&whole=1&peer=";
		static Encoding vk_enc = Encoding.GetEncoding( 1251 );
		static char[] _spl = new char[] { 'g' }; 
		public int ID;
		public string Name;
		public CookieCollection _Cookies;

		public override string ToString() {
			return Name;
		}
		public string GetHistory() {
			return AdvancedWebClient.DownloadString( _dialog_fetch_url + ID, vk_enc, this._Cookies ).Replace( "<!--", "" );
		}
		public static Dialog[] ParseDialogsFromHtml( string str ) {
			try{
			MemoryStream m = new MemoryStream();
			StreamWriter w = new StreamWriter( m, Encoding.UTF8 );
			int del = str.IndexOf( "<div", StringComparison.Ordinal );
			if (del<0)
				return new Dialog[]{};
			str="<root>"+ str.Remove( 0,  del).Replace( "<!>", "" )+"</root>";
			var doc  = new HtmlAgilityPack.HtmlDocument();
			doc.LoadHtml( str );
			doc.OptionDefaultStreamEncoding = Encoding.UTF8;
			doc.OptionOutputAsXml = true;
			doc.OptionFixNestedTags = true;
			doc.OptionAutoCloseOnEnd = true;
			doc.Save( w );
			w.Flush();
			m.Seek( 0, SeekOrigin.Begin );
			return XDocument.Load( m ).Root.Elements().Select( a => Parse( a ) ).Where(a=>a!=null).ToArray();
			}catch{return new Dialog[]{};} 
		}
		public static Dialog Parse( XElement n) {
			//return null;
			try{
			var info = n.
				Element( "table" ).
				Element( "tr" ).
				Elements().
				Where(
					a => a.
						Attributes( "class" ).
						Any(
							b => b.Value == "dialogs_info"
						)
				).
				First().
				Element( "div" ).
				Element( "a" );
			return new Dialog() {
				ID=int.Parse(n.Attribute("id").Value.Split(_spl).Last()),
				Name=info.Value
			};
			}catch{return null;} 
		}
	}
}
