using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Xml;
using System.IO;
using System.Net;
using System.Text;
using LibraryDemo_1.App_Code;
using System.Web.SessionState;
using System.Data.SqlClient;
using System.Data;

namespace LibraryDemo_1
{
    /// <summary>
    /// wechat 的摘要说明
    /// </summary>
    public class wechat : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string postString = string.Empty;
            if (HttpContext.Current.Request.HttpMethod.ToUpper() == "POST")
            {
                using (Stream stream = HttpContext.Current.Request.InputStream)
                {
                    Byte[] postBytes = new Byte[stream.Length];
                    stream.Read(postBytes, 0, (Int32)stream.Length);
                    postString = Encoding.UTF8.GetString(postBytes);
                }
                if (!string.IsNullOrEmpty(postString))
                {
                    //返回给微信用户信息
                    ReturnMessage(postString);
                }

                string access_token = GetAccessToken();
                access_token = access_token.Substring(17, access_token.Length - 37);
                string menuUrl = "https://api.weixin.qq.com/cgi-bin/menu/create?access_token=" + access_token;
                
                menuCreat(menuUrl);
            }
            else
            {
                Valid();
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private void Valid()    //服务器与微信服务器签名有效性验证
        {
            string echoStr = HttpContext.Current.Request.QueryString["echoStr"];
            if (CheckSignature())
            {
                if (!string.IsNullOrEmpty(echoStr))
                {
                    HttpContext.Current.Response.Write(echoStr);
                    HttpContext.Current.Response.End();

                }
            }
        }

        private bool CheckSignature()   //签名验证方法
        {
            string Token = "library";

            string signature = HttpContext.Current.Request.QueryString["signature"];
            string timestamp = HttpContext.Current.Request.QueryString["timestamp"];
            string nonce = HttpContext.Current.Request.QueryString["nonce"];

            string[] ArrTmp = { Token, timestamp, nonce };
            Array.Sort(ArrTmp);//字典排序  
            string tmpStr = string.Join("", ArrTmp);
            tmpStr = FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");//对该字符串进行sha1加密  
            tmpStr = tmpStr.ToLower();//对字符串中的字母部分进行小写转换，非字母字符不作处理  
            if (tmpStr == signature)//开发者获得加密后的字符串可与signature对比，标识该请求来源于微信。开发者通过检验signature对请求进行校验，若确认此次GET请求来自微信服务器，请原样返回echostr参数内容，则接入生效，否则接入失败  
            {
                return true;
            }
            else
                return false;
        }

        private string GetAccessToken()     //获取accesstoken
        {
            string url_token = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=wx524e8a5c06356c87&secret=01806472f2072e545a012cd1b9fec8db";
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url_token);
            myRequest.Method = "GET";
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
            string content = reader.ReadToEnd();
            reader.Close();
            return content;
        }


        private void menuCreat(string accesstoken)  //建立菜单
        {
            //读取建立菜单文本
            /****FileStream fs1 = new FileStream(Server.MapPath(".") + "\\WeChatmenu.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs1, Encoding.GetEncoding("UTF-8"));
            string menu = sr.ReadToEnd();
            sr.Close();
            fs1.Close();***/

            StringBuilder menu = menutext();

            //变量初始化
            Stream outstream = null;
            Stream instream = null;
            HttpWebResponse response = null;
            HttpWebRequest request = null;
            Encoding encoding = Encoding.UTF8;
            byte[] data = Encoding.UTF8.GetBytes(menu.ToString());

            try
            {
                request = WebRequest.Create(accesstoken) as HttpWebRequest;
                CookieContainer cookieContainer = new CookieContainer();
                request.CookieContainer = cookieContainer;
                request.AllowAutoRedirect = true;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                //发送请求
                outstream = request.GetRequestStream();
                outstream.Write(data, 0, data.Length);
                outstream.Close();
                response = request.GetResponse() as HttpWebResponse;

                instream = response.GetResponseStream();
                StreamReader sr = new StreamReader(instream, Encoding.Default);

                //获取返回结果
                string content = sr.ReadToEnd();
                string err = string.Empty;
                HttpContext.Current.Response.Write(content);
                //return content;
            }
            catch (Exception e)
            {
                string err = e.Message;
                //return string.Empty;
            }
        }

        private StringBuilder menutext()  //菜单字段
        {
            StringBuilder sb = new StringBuilder();
            //sb.Append("{\"button\":[{\"type\":\"view\",\"name\":\"书籍查询\",\"url\":\"http://sakurayard.net/Wechat_pages/BookSearch.aspx\"},{\"name\":\"个人中心\",\"sub_button\":[{\"type\":\"view\",\"name\":\"用户登录\",\"url\":\"http://sakurayard.net/Wechat_pages/UserLogin.aspx\"},{\"type\":\"click\",\"name\":\"借阅查询\",\"key\":\"lendsearch\"},{\"type\":\"click\",\"name\":\"预约查询\",\"key\":\"ordersearch\"}]}]}");
            sb.Append("{\"button\":[{\"type\":\"view\",\"name\":\"书籍查询\",\"url\":\"http://106.15.186.200/Wechat_pages/BookSearch.aspx\"},{\"type\":\"view\",\"name\":\"个人中心\",\"url\":\"http://106.15.186.200/Wechat_pages/UserPage.aspx\"}]}");
            
            return sb;
        }


        #region   微信消息处理部分

        public void ReturnMessage(string postStr)        //返回消息
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(postStr);

            XmlElement rootElement = xmldoc.DocumentElement;//获取文档根
            XmlNode MsgType = rootElement.SelectSingleNode("MsgType");

            RequestXML requestXML = new RequestXML();//声明实例，获取各个属性并赋值
            requestXML.ToUserName = rootElement.SelectSingleNode("ToUserName").InnerText;//公众号
            requestXML.FromUserName = rootElement.SelectSingleNode("FromUserName").InnerText;//用户
            requestXML.CreateTime = rootElement.SelectSingleNode("CreateTime").InnerText;//创建时间
            requestXML.MsgType = MsgType.InnerText.Trim().ToString();//消息类型

            if (MsgType.InnerText.Trim().ToLower() == "event")
            {
                requestXML.EventName = rootElement.SelectSingleNode("Event").InnerText;
                requestXML.EventKey = rootElement.SelectSingleNode("EventKey").InnerText;

            }
            else if (MsgType.InnerText.Trim().ToLower() == "text")
            {
                requestXML.Content = rootElement.SelectSingleNode("Content").InnerText;
            }

            ResponseMsg(requestXML);
        }

        private void ResponseMsg(RequestXML requestXML)     //回应消息
        {
            string MsgType = requestXML.MsgType;

            try
            {
                //根据消息类型判断发送何种类型消息
                switch (MsgType)
                {
                    case "text":
                        SendTextCase(requestXML);//发送文本消息
                        break;
                    case "event"://发送事件消息
                        if (!string.IsNullOrWhiteSpace(requestXML.EventName) && requestXML.EventName.ToString().Trim().Equals("subscribe"))
                        {
                            SendWelComeMsg(requestXML);//关注时返回的消息
                        }
                        else if (!string.IsNullOrWhiteSpace(requestXML.EventName) && requestXML.EventName.ToString().Trim().Equals("CLICK"))
                        {
                            SendEventMsg(requestXML);//发送菜单点击事件消息
                        }
                        break;
                    default:
                        break;

                }
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(ex.ToString());
            }
        }

        private void SendTextCase(RequestXML requestXML) //发送文本消息
        {
            string text = "欢迎使用本系统，本系统由shihang完成，仅供学习与交流。建议在登录后使用相关功能。有问题与想法欢迎交流！";

            string responseContent = FormatTextXML(requestXML.FromUserName, requestXML.ToUserName, text);

            HttpContext.Current.Response.ContentType = "text/xml";
            HttpContext.Current.Response.ContentEncoding = Encoding.UTF8;
            HttpContext.Current.Response.Write(responseContent);
            HttpContext.Current.Response.End();
        }

        private void SendEventMsg(RequestXML requestXML) //发送事件消息
        {
            String keyStr = requestXML.EventKey.ToString();
            
            string responseContent = String.Empty;
            string text = String.Empty;

            //string textLend=SendLendMsg(); //借阅资料
            //string textOrder=SendOrderMsg(); //预约资料

            string username = HttpContext.Current.Session["UserName"].ToString();
            string userid = HttpContext.Current.Session["UserNumber"].ToString();

            
            if (keyStr == "lendsearch")
            {
                text = username;
            }
            else if (keyStr == "ordersearch")
            {
                text = userid;
            }
            else
            {
                text = "Emmmmm...出现了一些些问题，抱歉...";              
            }

            responseContent = FormatTextXML(requestXML.FromUserName, requestXML.ToUserName, text);
            HttpContext.Current.Response.ContentType = "text/xml";
            HttpContext.Current.Response.ContentEncoding = Encoding.UTF8;
            HttpContext.Current.Response.Write(responseContent);
            HttpContext.Current.Response.End();
            
        }

        private void SendWelComeMsg(RequestXML requestXML) //关注发送消息
        {
            string welstr = "欢迎使用LibraryDemo！该模型仅供学习交流。";

            string responseContent = FormatTextXML(requestXML.FromUserName, requestXML.ToUserName, welstr);

            HttpContext.Current.Response.ContentType = "text/xml";
            HttpContext.Current.Response.ContentEncoding = Encoding.UTF8;
            HttpContext.Current.Response.Write(responseContent);
            HttpContext.Current.Response.End();
        }

        private string SendLendMsg() //借阅查询菜单发送消息
        {
            //session引入
            string username = HttpContext.Current.Session["UserName"].ToString();  
            string userid = HttpContext.Current.Session["UserNumber"].ToString();

            string text = String.Empty;

            if(username==null||userid==null)
            {
                text = "请先登录！";
            }
            else
            {
                //查询数据
                DataManage dm = new DataManage();
                string sql = "select * from [Library].[library].[Borrow] where [BorrowRname] like '" + username + "' and [BorrowRnum] like '" + userid + "' and [Bookstate] like 'Unreturn'";
                DataTable dt = dm.ReadTable(sql);
                string lendmsg = String.Empty;

                foreach(DataRow dr in dt.Rows)
                    {
                        lendmsg = lendmsg + "图书名称：" + dr[3].ToString() + ", 借书日期：" + dr[6].ToString() + ", 应还日期：" + dr[7].ToString() + "；" + System.Environment.NewLine;
                    }
                text = lendmsg;
            }

            return text;           
        }

        private string SendOrderMsg() //预约查询菜单发送消息
        {
            //session引入
            string username = HttpContext.Current.Session["UserName"].ToString();
            string userid = HttpContext.Current.Session["UserNumber"].ToString();

            string text = String.Empty;

            if (username == null || userid == null)
            {
                text = "请先登录！";
            }
            else
            {
                //查询数据
                DataManage dm = new DataManage();
                string sql = "select * from [Library].[library].[Order] where [OrderRname] like '" + username + "' and [OrderRnum] like '" + userid + "'";
                DataTable dt = dm.ReadTable(sql);
                string ordermsg = String.Empty;
                foreach (DataRow dr in dt.Rows)
                {
                    int bookid = Convert.ToInt32(dr[4]);
                    string sql_1 = "select count(*) from [Library].[library].[Borrow] where [BorrowBid] like " + bookid + " and [Bookstate] like 'Unreturn'";
                    DataTable dt_1 = dm.ReadTable(sql_1);

                    string sql_2 = "select [Bamount] from [Library].[library].[Book] where [Bid] like " + bookid;
                    DataTable dt_2 = dm.ReadTable(sql_2);

                    int remains = Convert.ToInt32(dt_2.Rows[0][0]) - Convert.ToInt32(dt_1.Rows[0][0]);

                    ordermsg = ordermsg + "图书名称：" + dr[3].ToString() + ", 馆中剩余：" + remains + "；" + Environment.NewLine;
                }

                text = ordermsg;
            }

            return text;
        }

        private string FormatTextXML(string p1, string p2, string p3) //消息格式化
        {
            return "<xml><ToUserName><![CDATA[" + p1 + "]]></ToUserName><FromUserName><![CDATA[" + p2 + "]]></FromUserName><CreateTime>" + DateTime.Now.Subtract(new DateTime(1970, 1, 1, 8, 0, 0)).TotalSeconds.ToString() + "</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[" + p3 + "]]></Content><FuncFlag>1</FuncFlag></xml>";
        }

        #endregion


    }
}