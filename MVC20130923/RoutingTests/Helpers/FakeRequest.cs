using System.Collections.Specialized;
using System.Web;

namespace RoutingTests.Helpers
{
    public class FakeRequest : HttpRequestBase
    {
        private readonly NameValueCollection _values = new NameValueCollection();

        public FakeRequest()
        {
            _values.Add("blogId", "1");
        }

        public override string this[string key]
        {
            get { return _values[key]; }
        }
    }
}