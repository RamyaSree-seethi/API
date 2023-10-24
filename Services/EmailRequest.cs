using System;
namespace StayHappy
{
    public class EmailRequest
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public byte[] AttachmentBytes { get; set; }
        public string AttachmentFileName { get; set; }
    }
}
