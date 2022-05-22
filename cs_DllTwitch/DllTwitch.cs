using Leaf.xNet;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using WebSocketSharp;

 
namespace cs_DllTwitch { 
    public class DllTwitch {
        #region Step1
        //*********************************************************************************
        /// <summary>
        /// https://www.twitch.tv/login
        /// </summary>
        /// <returns></returns>
        public string Step1(string proxyHostPortSocket4) {
            string result = string.Empty;

            try {
                Console.WriteLine($"Step1 start...");

                httprequest = new HttpRequest();
                httprequest.Proxy = HttpProxyClient.Parse(proxyHostPortSocket4);
                httprequest.Cookies = new CookieStorage(true);
                httprequest.Cookies.IsLocked = false;

                httprequest.AddHeader("Host", "www.twitch.tv");
                httprequest.UserAgent = Http.ChromeUserAgent();
                httprequest.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,*/*;q=0.8");
                httprequest.AddHeader("Accept-Language", "ru,en-US;q=0.7,en;q=0.3");
                httprequest.AddHeader("DNT", "1");
                httprequest.AddHeader("Connection", "keep-alive");
                httprequest.AddHeader("Upgrade-Insecure-Requests", "1");
                httprequest.AddHeader("Sec-Fetch-Dest", "document");
                httprequest.AddHeader("Sec-Fetch-Mode", "navigate");
                httprequest.AddHeader("Sec-Fetch-Site", "none");
                httprequest.AddHeader("Sec-Fetch-User", "?1");

                result = httprequest.Get("https://www.twitch.tv/login").ToString();

                string ClientVersion = Regex.Match(result, "twilightBuildID=\"(.*?)\"").Groups[1].Value;
                Console.WriteLine($"ClientVersion: {ClientVersion}");

                var cookies = httprequest.Cookies.GetCookies("https://www.twitch.tv/login");
                foreach (Cookie cookie in cookies) {
                    // concat your string or do what you want
                    Console.WriteLine($"{cookie.Name}: {cookie.Value}");
                }

            } catch (HttpException ex) {
                Errors.errors.Add(ex.Message);
            } catch (Exception ex) {
                Errors.errors.Add(ex.Message);
            } finally {
                httprequest?.Dispose();
            }

            return result;

        }
        //*********************************************************************************
        #endregion
        #region Step2
        //*********************************************************************************
        /// <summary>
        /// https://p.twitchcdn.net/v3/polyfill.min.js?unknown=polyfill&flags=gated&features=Array.prototype.find,Array.prototype.findIndex,Array.prototype.includes,default,fetch,Intl.~locale.en,Math.sign,Object.entries%7Calways%7Cgated,Object.values%7Calways%7Cgated,String.prototype.repeat,URL,HTMLCanvasElement.prototype.toBlob,IntersectionObserver
        /// </summary>
        /// <returns></returns>
        public string Step2(string step1) {
            string result = string.Empty;
            if (!step1.Equals(string.Empty)) {
                try {
                    Console.WriteLine($"Step2 start...");

                    httprequest.AddHeader("Host", "p.twitchcdn.net");
                    httprequest.UserAgent = Http.ChromeUserAgent();
                    httprequest.AddHeader("Accept", "*/*");
                    httprequest.AddHeader("Accept-Language", "ru,en-US;q=0.7,en;q=0.3");
                    httprequest.AddHeader("Referer", "https://www.twitch.tv/");
                    httprequest.AddHeader("Origin", "https://www.twitch.tv");
                    httprequest.AddHeader("DNT", "1");
                    httprequest.AddHeader("Connection", "keep-alive");
                    httprequest.AddHeader("Sec-Fetch-Dest", "script");
                    httprequest.AddHeader("Sec-Fetch-Mode", "cors");
                    httprequest.AddHeader("Sec-Fetch-Site", "cross-site");
                    httprequest.AddHeader("Accept-Encoding", "gzip, deflate");

                    result = httprequest.Get("https://p.twitchcdn.net/v3/polyfill.min.js?unknown=polyfill&flags=gated&features=Array.prototype.find,Array.prototype.findIndex,Array.prototype.includes,default,fetch,Intl.~locale.en,Math.sign,Object.entries%7Calways%7Cgated,Object.values%7Calways%7Cgated,String.prototype.repeat,URL,HTMLCanvasElement.prototype.toBlob,IntersectionObserver").ToString();

                    var cookies = httprequest.Cookies.GetCookies("https://www.twitch.tv/login");
                    Console.WriteLine($"Cookie step 2");
                    foreach (Cookie cookie in cookies) {
                        // concat your string or do what you want
                        Console.WriteLine($"{cookie.Name}: {cookie.Value}");
                    }

                } catch (Exception e) {
                    Errors.errors.Add($"{e.Message}  {e.InnerException}");
                } finally {
                    httprequest?.Dispose();
                }
            } else { Errors.errors.Add("Страница авторизации пустая"); }
            return result;
        }
        //*********************************************************************************
        #endregion
        #region Step3
        //*********************************************************************************
        /// <summary>
        /// https://static.twitchcdn.net/config/settings.b70b24f0db288e02f0cb75f253978dab.js
        /// </summary>
        /// <returns></returns>
        public string Step3(string step2) {
            string result = string.Empty;
            if (!step2.Equals(string.Empty)) {
                try {
                    Console.WriteLine($"Step3 start...");

                    httprequest.AddHeader("Host", "static.twitchcdn.net");
                    httprequest.UserAgent = Http.ChromeUserAgent();
                    httprequest.AddHeader("Accept", "*/*");
                    httprequest.AddHeader("Accept-Language", "ru,en-US;q=0.7,en;q=0.3");
                    httprequest.AddHeader("Referer", "https://www.twitch.tv/");
                    httprequest.AddHeader("Origin", "https://www.twitch.tv");
                    httprequest.AddHeader("DNT", "1");
                    httprequest.AddHeader("Connection", "keep-alive");
                    httprequest.AddHeader("Sec-Fetch-Dest", "script");
                    httprequest.AddHeader("Sec-Fetch-Mode", "cors");
                    httprequest.AddHeader("Sec-Fetch-Site", "cross-site");
                    httprequest.AddHeader("Accept-Encoding", "gzip, deflate");


                    result = httprequest.Get("https://static.twitchcdn.net/config/settings.b70b24f0db288e02f0cb75f253978dab.js").ToString();

                    var cookies = httprequest.Cookies.GetCookies("https://www.twitch.tv/login");
                    Console.WriteLine($"Cookie step 3");
                    foreach (Cookie cookie in cookies) {
                        // concat your string or do what you want
                        Console.WriteLine($"{cookie.Name}: {cookie.Value}");
                    }

                } catch (Exception e) {
                    Errors.errors.Add($"{e.Message}  {e.InnerException}");
                } finally {
                    httprequest?.Dispose();
                }
            } else { Errors.errors.Add("Страница авторизации пустая"); }
            return result;
        }
        //*********************************************************************************
        #endregion
        #region Step4
        //*********************************************************************************
        public string Step4(string step1, string nickName_, string password_, string chanallName_, string message_) {
            nickName = nickName_;
            password = password_;
            chanallName = chanallName_;
            message = message_;
            string result = string.Empty;
            if (!step1.Equals(string.Empty)) {
                try {
                    Console.WriteLine($"Step4 start...");
                    var c = httprequest.Cookies.GetCookies("https://www.twitch.tv/login");
                    string cookieAll = string.Empty;
                    foreach (Cookie cookie in c) {
                        cookieAll += cookie.Name + "=" + cookie.Value + ";";
                    }
                    Console.WriteLine($"step4 cookie: {cookieAll}");

                    httprequest.AddHeader("Host", "passport.twitch.tv");
                    httprequest.UserAgent = Http.ChromeUserAgent();
                    httprequest.AddHeader("Accept", "*/*");
                    httprequest.AddHeader("Accept-Language", "ru,en-US;q=0.7,en;q=0.3");
                    httprequest.AddHeader("Referer", "https://www.twitch.tv/");
                    httprequest.AddHeader("Content-Type", "text/plain;charset=UTF-8");
                    httprequest.AddHeader("Origin", "https://www.twitch.tv");
                    httprequest.AddHeader("DNT", "1");
                    httprequest.AddHeader("Connection", "keep-alive");
                    httprequest.AddHeader("Cookie", cookieAll);
                    httprequest.AddHeader("Sec-Fetch-Dest", "empty");
                    httprequest.AddHeader("Sec-Fetch-Mode", "cors");
                    httprequest.AddHeader("Sec-Fetch-Site", "same-site");
                    httprequest.AddHeader("Accept-Encoding", "gzip, deflate");

                    string requestParam = "{\"username\":" + "\"" + nickName + "\"" + ",\"password\":" + "\"" + password + "\"" + ",\"client_id\":\"kimne78kx3ncx6brgo4mv6wki5h1ko\",\"undelete_user\":false}";
                    Console.WriteLine(requestParam);

                    result = httprequest.Post("https://passport.twitch.tv/login", requestParam, "text/plain").ToString();
                    string accessToken = Regex.Match(result, "\"access_token\":\"(.*?)\"").Groups[1].Value;
                    oauth = accessToken;
                    commandsWss = new List<string> { "CAP REQ :twitch.tv/tags twitch.tv/commands" ,
                                                      "PASS oauth:"+oauth+"\r\n",
                                                      "NICK "+nickName.ToLower()+"\r\n",
                                                      "USER "+nickName.ToLower()+" 8 * :"+nickName.ToLower()+"\r\n",
                                                      "JOIN #"+chanallName,
                                                      "PRIVMSG #"+chanallName+" :"+message
                    };

                    Console.WriteLine($"accessToken: {accessToken}");
                    var cookies = httprequest.Cookies.GetCookies("https://passport.twitch.tv/login");
                    Console.WriteLine($"Cookie step 4");
                    foreach (Cookie cookie in cookies) {
                        // concat your string or do what you want
                        Console.WriteLine($"{cookie.Name}: {cookie.Value}");
                    }

                } catch (Exception e) {
                    Errors.errors.Add($"{e.Message}  {e.InnerException}");
                    Console.WriteLine($"{e.Message}  {e.StackTrace} ");
                } finally {
                    httprequest?.Dispose();
                }
            } else { Errors.errors.Add("Страница авторизации пустая"); }
            return result;
        }
        //*********************************************************************************
        #endregion
        //*********************************************************************************
        public List<string> LoadProxysList(string path) {
            List<string> result = new List<string>();
            var file = System.IO.File.ReadLines(path);
            foreach (var l in file)
                result.Add(l);
            return result;
        }
        //*********************************************************************************
        public List<string> CheckProxys(List<string> proxyList, string proxyType) {
            List<string> result = new List<string>();
            checkProxy = new HttpRequest();
            foreach (var proxy in proxyList) {
                bool flag = true;
                switch (proxyType) {
                    case "http": checkProxy.Proxy = HttpProxyClient.Parse(proxy);  break;
                    case "socket4": checkProxy.Proxy = Socks4ProxyClient.Parse(proxy); break;
                    case "socket5": checkProxy.Proxy = Socks5ProxyClient.Parse(proxy); break;
                }
               
                Console.WriteLine("--------------------");
                checkProxy.Proxy.ConnectTimeout = 1000;
                checkProxy.Cookies = new CookieStorage(true);
                checkProxy.Cookies.IsLocked = false;

                checkProxy.AddHeader("Host", "www.twitch.tv");
                checkProxy.UserAgent = Http.ChromeUserAgent();
                checkProxy.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,*/*;q=0.8");
                checkProxy.AddHeader("Accept-Language", "ru,en-US;q=0.7,en;q=0.3");
                checkProxy.AddHeader("DNT", "1");
                checkProxy.AddHeader("Connection", "keep-alive");
                checkProxy.AddHeader("Upgrade-Insecure-Requests", "1");
                checkProxy.AddHeader("Sec-Fetch-Dest", "document");
                checkProxy.AddHeader("Sec-Fetch-Mode", "navigate");
                checkProxy.AddHeader("Sec-Fetch-Site", "none");
                checkProxy.AddHeader("Sec-Fetch-User", "?1");

                try {
                    var page = checkProxy.Get("https://www.twitch.tv/login").ToString();
                } catch (Exception) {
                    flag = false;
                    Console.WriteLine("no");
                    
                }
                if (flag) {
                    Console.WriteLine(proxy);
                    result.Add(proxy);
                }

            }

            return result;
        }
        //*********************************************************************************
        public Task OnError(ErrorEventArgs errorEventArgs) {
            Console.Write("Error: {0}, Exception: {1}", errorEventArgs.Message, errorEventArgs.Exception);
            return Task.FromResult(0);
        }
        //*********************************************************************************
        public Task OnMessage(MessageEventArgs messageEventArgs) {
            Console.Write("Message received: {0}", messageEventArgs.Text.ReadToEnd());
            return Task.FromResult(0);
        }
        //*********************************************************************************
        public void Wss() {
            if (!oauth.Equals(string.Empty)) {
                using (var ws = new WebSocket(url: "wss://irc-ws.chat.twitch.tv:443", onMessage: OnMessage, onError: OnError)) {
                    ws.Connect().Wait();
                    ws.Send(commandsWss[0]);
                    Thread.Sleep(570);
                    ws.Send(commandsWss[1]);
                    Thread.Sleep(640);
                    ws.Send(commandsWss[2]);
                    Thread.Sleep(680);
                    ws.Send(commandsWss[3]);
                    Thread.Sleep(640);
                    ws.Send(commandsWss[4]);
                    Thread.Sleep(580);
                    ws.Send(commandsWss[5]).Wait();
                    Console.ReadKey(true);
                }
            } else {
                Console.WriteLine($"Error oauth");
            }

        }
        //*********************************************************************************
        //*********************************************************************************
        private HttpRequest checkProxy { get; set; } = null;
        //*********************************************************************************
        private HttpRequest httprequest { get; set; } = null;
        public HttpRequest Httprequest { get => httprequest; set => httprequest = value; }
        //*********************************************************************************
        private RequestParams requestParams { get; set; } = null;

        public RequestParams RequestParams { get => requestParams; set => requestParams = value; }
        //*********************************************************************************
        private static string oauth = string.Empty;
        private static string nickName = string.Empty;
        private static string password = string.Empty;
        private string chanallName = string.Empty;
        private string message = string.Empty;
        //*********************************************************************************
        private List<string> commandsWss;
        //*********************************************************************************
    }
}
