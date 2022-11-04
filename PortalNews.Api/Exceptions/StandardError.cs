using System.Reflection.Metadata;

namespace PortalNews.Api.Exceptions
{
    public class StandardError
    {
        public DateTime TimesStamp { get; set; }

        public int Status { get; set; }

        public string Error { get; set; }

        public string Message { get; set; }

        public string Path { get; set; }

        public StandardError() { }
    }
}
