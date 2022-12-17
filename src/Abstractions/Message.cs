using System.Collections.Generic;

namespace Hestia.MQ.Abstractions
{
    public sealed class Message
    {                
        /// <summary>
        /// 标识号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 上级标识号
        /// </summary>
        public string ChainId { get; set; }
        /// <summary>
        /// 起始标识号
        /// </summary>
        public string OrginId { get; set; }
        /// <summary>
        /// 消息标识号
        /// </summary>
        public string MessageId { get; set; }
        /// <summary>
        /// 实例
        /// </summary>
        public string Instance { get; set; }
        /// <summary>
        /// 主题
        /// </summary>
        public string Topic { get; set; }
        /// <summary>
        /// 当前消费组
        /// </summary>
        public string CurrentGroup { get; set; }
        /// <summary>
        /// 目标消费组
        /// </summary>
        public string TargetGroup { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        public string Tag { get; set; }
        /// <summary>
        /// 消费者
        /// </summary>
        public string Consumer { get; set; }        
        /// <summary>
        /// 正文
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// 投递延迟
        /// </summary>
        public ulong Offset { get; set; }
        /// <summary>
        /// 投递来源
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// 所属应用
        /// </summary>
        public string Application { get; set; }
        /// <summary>
        /// 累计消费次数
        /// </summary>
        public uint TotalConsumed { set; get; }     
        /// <summary>
        /// 消费状态
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 消费结果
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 属性
        /// </summary>
        public Dictionary<string, string> Properties { get; private set; } = new Dictionary<string, string>();
    }
}
