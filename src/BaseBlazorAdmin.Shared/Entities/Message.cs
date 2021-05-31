using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBlazorAdmin.Shared.Entities
{
    public class Message
    {
        public MessageType MessageType { get; set; }
        public string MessageText { get; set; }
    }

    public enum MessageType
    {
        Information,
        Error,
        Success
    }
}
