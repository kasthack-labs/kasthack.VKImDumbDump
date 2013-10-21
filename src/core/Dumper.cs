using System.Threading.Tasks;
using EpicMorg.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
namespace core {
    public class Dumper {
        
        private bool _loggedIn;
        private const string DialogsListURL = "https://vk.com/al_im.php?act=a_get_dialogs&al=1&offset=";
        private CookieCollection _loginCookies;
        public bool LoggedIn {
            get { return this._loggedIn; }
        }
        
        private static CookieCollection DoLoginVk(string email, string password) {
            return Helper.SyncTask(DoLoginVkAsync(email, password));
        }
        static async Task<CookieCollection> DoLoginVkAsync( string email, string password ) {
            const string authURL = "http://m.vk.com/login?fast=1&hash=&s=0&to=";
            try {
                #region Send password
                email = email.Replace( "@", "%40" );
                var getHash = await AWC.DownloadStringAsync( authURL );
                var posturl = new Regex( "https:\\/\\/login\\.vk.com\\/.*\"" ).Match( getHash ).ToString();
                posturl = posturl.Substring( 0, posturl.Length - 1 );
                var data = new ASCIIEncoding().GetBytes( "email=" + email + "&pass=" + password );
                ServicePointManager.ServerCertificateValidationCallback += ( a, b, c, d ) => true;
                var request = (HttpWebRequest) WebRequest.Create( posturl );
                #region Headers
                request.UserAgent = "Opera/9.80 (Windows NT 6.1; U; ru) Presto/2.7.62 Version/11.00";
                request.Method = "POST";
                request.Referer = authURL;
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                request.CookieContainer = new CookieContainer();
                request.CookieContainer.Add( new Cookie( "remixlang", "0", "/", "login.vk.com" ) );
                request.CookieContainer.Add( new Cookie( "remixchk", "5", "/", "login.vk.com" ) );

                request.MaximumAutomaticRedirections = 1;
                #endregion
                using(var stream = await request.GetRequestStreamAsync()){
                    await stream.WriteAsync( data, 0, data.Length );
                    await stream.FlushAsync();
                }
                //stream.Dispose();
                var z = (HttpWebResponse) await request.GetResponseAsync();
                await new StreamReader( z.GetResponseStream() ).ReadToEndAsync();
                #endregion
            }
            catch ( WebException ex ) {
                #region Get cookies from valid response
                if ( ex.Response == null ) throw;
                var cook = ( (HttpWebResponse) ex.Response ).Cookies;
                var cookie = cook[ "remixsid" ];
                if ( cookie != null && cookie.Value != "deleted" )
                    return cook;
                throw;

                #endregion
            }
            catch ( Exception ) {
                return null;
            }
            return null;
        }

        public void Connect(string login,string password) {
            Helper.VSyncTask(this.ConnectAsync(login, password));
        }
        public async Task ConnectAsync( string login, string password ) {
            this._loginCookies = await DoLoginVkAsync( login, password );
            try {
                if ( this._loginCookies == null ) return ;
                var cook = this._loginCookies[ "remixsid" ];
                if ( cook == null || String.IsNullOrEmpty( cook.Value.Trim() ) || cook.Value.Trim() == "deleted" ) return;
                this._loginCookies.Add( new Cookie( "audio_vol", "100", cook.Path, cook.Domain ) );
                this._loginCookies.Add( new Cookie( "remixseenads", "1", cook.Path, cook.Domain ) );
                this._loginCookies.Add( new Cookie( "remixdt", "-3600", cook.Path, cook.Domain ) );
                this._loggedIn = true;
            }
            catch (Exception) {
                this._loggedIn = false;
            }
        }
        
        public void Disconnect() {
            this._loginCookies = null;
            this._loggedIn = false;
        }

        public void Dump(string path, IEnumerable<Dialog> dialogs, bool savePhotos) {
            Helper.VSyncTask(this.DumpAsync(path, dialogs, savePhotos));
        }
        public async Task DumpAsync( string path, IEnumerable<Dialog> dialogs, bool savePhotos ) {
            if ( !this.LoggedIn )
                throw new InvalidOperationException( "User must be logged in" );
            foreach ( var v in dialogs ) {
                var tmpPath = Path.Combine(path, v.Name);
                var dump = await v.GetHistoryAsync();
                string historyPath;
                if ( savePhotos ) {
                    MkDirIfNE(tmpPath);
                    historyPath = Path.Combine(tmpPath, "history.html");
                    var imgPath = Path.Combine(tmpPath, "images");
                    MkDirIfNE(imgPath);
                    
                }
                else {
                    historyPath = tmpPath + ".html";
                }
                File.WriteAllText( historyPath,  dump);
            }
        }
        
        private static void MkDirIfNE(string path) {
            if ( !Directory.Exists( path ) )
                Directory.CreateDirectory( path );
        }

        public Dialog[] GetDialogs() {
            return Helper.SyncTask(this.GetDialogsAsync());
        }
        public async Task<Dialog[]> GetDialogsAsync() {
            try {
                var d = new List<Dialog[]>();
                var vkEncoding = Encoding.GetEncoding( 1251 );
                var offset = 0;
                while ( true ) {
                    var temp = Dialog.ParseDialogsFromHtml( await AWC.DownloadStringAsync( DialogsListURL + offset, vkEncoding, Helper.CCollectoion2Container(this._loginCookies) ) );
                    offset += temp.Length;
                    if ( temp.Length == 0 ) break;
                    d.Add( temp );
                }
                var ret = d.SelectMany( a => a ).ToArray();
                foreach ( var v in ret )
                    v.Cookies = this._loginCookies;
                return ret;
            }
            catch { return new Dialog[] { }; }
        }
    }
    public class Dialog {
        private const string DialogFetchURL = "http://vk.com/al_im.php?act=a_history&al=1&offset=0&rev=0&whole=1&peer=";
        static readonly Encoding VkEnc = Encoding.GetEncoding( 1251 );
        static readonly char[] Spl = { 'g' };
        private int _id;
        public string Name;
        public CookieCollection Cookies;

        public override string ToString() {
            return Name;
        }

        public string GetHistory() {
            return Helper.SyncTask(this.GetHistoryAsync());
        }

        public async Task<string> GetHistoryAsync() {
            var sb = new StringBuilder();
            sb.Append(
                await 
                AWC
                .DownloadStringAsync(
                    DialogFetchURL + this._id,
                    VkEnc,
                    Helper.CCollectoion2Container(this.Cookies)
                )
            );
            sb.Replace("<!--", "");
            var str = sb.ToString();
            const string tbl = "</table>";
            var tind = str.LastIndexOf(tbl, StringComparison.InvariantCulture) + tbl.Length;
            sb.Remove(tind, str.Length - tind);
            return sb.ToString();
        }
        public static Dialog[] ParseDialogsFromHtml( string str ) {
            try {
                using ( var m = new MemoryStream() ) {
                    using ( var w = new StreamWriter( m, Encoding.UTF8 ) ) {
                        int del = str.IndexOf( "<div", StringComparison.Ordinal );
                        if ( del < 0 )
                            return new Dialog[] { };
                        str = "<root>" + str.Remove( 0, del ).Replace( "<!>", "" ) + "</root>";
                        var doc = new HtmlAgilityPack.HtmlDocument();
                        doc.LoadHtml( str );
                        doc.OptionDefaultStreamEncoding = Encoding.UTF8;
                        doc.OptionOutputAsXml = true;
                        doc.OptionFixNestedTags = true;
                        doc.OptionAutoCloseOnEnd = true;
                        doc.Save( w );
                        w.Flush();
                        m.Seek( 0, SeekOrigin.Begin );
// ReSharper disable once PossibleNullReferenceException
                        return XDocument.Load( m ).Root.Elements().Select( Parse ).Where( a => a != null ).ToArray();
                    }
                }
            }
            catch { return new Dialog[] { }; }
        }

        private static Dialog Parse( XElement n ) {
            try {
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
                    _id = int.Parse( n.Attribute( "id" ).Value.Split( Spl ).Last() ),
                    Name = info.Value
                };
            }
            catch { return null; }
        }
    }
}
