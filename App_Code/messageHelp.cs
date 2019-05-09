using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using System.Web.Security;
using System.Xml;
using LibraryDemo_1.App_Code;
using System.Data.SqlClient;
using System.Data;

namespace LibraryDemo_1.App_Code
{
    public class messageHelp
    {
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
            requestXML.MsgType = MsgType.InnerText;//消息类型

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
            string responseContent = FormatTextXML(requestXML.FromUserName, requestXML.ToUserName, requestXML.Content);

            HttpContext.Current.Response.ContentType = "text/xml";
            HttpContext.Current.Response.ContentEncoding = Encoding.UTF8;
            HttpContext.Current.Response.Write(responseContent);
            HttpContext.Current.Response.End();
        }

        private void SendEventMsg(RequestXML requestXML) //发送事件消息
        {
            String keyStr = requestXML.EventKey.ToString();

            switch (keyStr)
            {
                case "lendsearch": SendLendMsg(requestXML); //借阅查询菜单
                    break;
                case "ordersearch": SendOrderMsg(requestXML); //预约查询菜单
                    break;
                default:
                    String responseContent = String.Empty;
                    responseContent = FormatTextXML(requestXML.FromUserName, requestXML.ToUserName, "此功能暂未开放！敬请期待！");
                    HttpContext.Current.Response.ContentType = "text/xml";
                    HttpContext.Current.Response.ContentEncoding = Encoding.UTF8;
                    HttpContext.Current.Response.Write(responseContent);
                    HttpContext.Current.Response.End();
                    
                    break;
            }
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

        private void SendLendMsg(RequestXML requestXML) //借阅查询菜单发送消息
        {
            
            string responseContent = FormatTextXML(requestXML.FromUserName, requestXML.ToUserName, "借阅查询！");

            HttpContext.Current.Response.ContentType = "text/xml";
            HttpContext.Current.Response.ContentEncoding = Encoding.UTF8;
            HttpContext.Current.Response.Write(responseContent);
            HttpContext.Current.Response.End();
        }

        private void SendOrderMsg(RequestXML requestXML) //预约查询菜单发送消息
        {
            string responseContent = FormatTextXML(requestXML.FromUserName, requestXML.ToUserName, "预约查询！");

            HttpContext.Current.Response.ContentType = "text/xml";
            HttpContext.Current.Response.ContentEncoding = Encoding.UTF8;
            HttpContext.Current.Response.Write(responseContent);
            HttpContext.Current.Response.End();
        }

        private string FormatTextXML(string p1, string p2, string p3) //消息格式化
        {
            return "<xml><ToUserName><![CDATA[" + p1 + "]]></ToUserName><FromUserName><![CDATA[" + p2 + "]]></FromUserName><CreateTime>" + DateTime.Now.Subtract(new DateTime(1970, 1, 1, 8, 0, 0)).TotalSeconds.ToString() + "</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[" + p3 + "]]></Content><FuncFlag>1</FuncFlag></xml>";
        }
    }
}