using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryDemo_1.App_Code
{
    public class RequestXML
    {
        private String toUserName = String.Empty;

        /// <summary>
        /// 本公众号
        /// </summary>
        public String ToUserName { get; set; }

        /// <summary>
        /// 用户微信号
        /// </summary>
        public String FromUserName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public String CreateTime { get; set; }

        /// <summary>
        /// 信息类型 
        /// </summary>
        public String MsgType { get; set; }

        /// <summary>
        /// 信息内容
        /// </summary>
        public String Content { get; set; }



        /*以下为事件类型的消息特有的属性*/
        /// <summary>
        /// 事件名称
        /// </summary>
        public String EventName { get; set; }
        /// <summary>
        /// 事件值
        /// </summary>
        public string EventKey { get; set; }
 
    }
}