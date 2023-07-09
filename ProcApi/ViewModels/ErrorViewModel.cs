using ProcApi.Enums;

namespace ProcApi.ViewModels
{
    public class ErrorViewModel
    {
        public string ErrorCode { get; set; }
        public string Messgae { get; set; }
        public MessageType MessageType { get; set; }
    }
}
