using Newtonsoft.Json;

namespace Application.Models
{
    public class Configuration
    {
        public string DBConnectionText { get; set; }
        public string LogDirectory { get; set; }
        public bool EventViewerErrorLogging { get; set; }
        public bool SendErrorFromMail { get; set; }
        public string ResetPasswordUrl { get; set; }
        public string ResetPasswordTestUrl { get; set; }
        public SmtpServer SmtpServer { get; set; }
    }
}
