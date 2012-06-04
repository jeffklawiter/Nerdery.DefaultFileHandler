using System;
using System.Web;

namespace Nerdery.Handlers
{
	public class RobotsHandler : IFileHandler
	{
		public void ProcessRequest(HttpContext context)
		{
			context.Response.ContentType = "text/plain";
			context.Response.Cache.SetExpires(new DateTime(2066, 1, 1));
			context.Response.Cache.SetLastModified(new DateTime(2010, 12, 1));
			context.Response.CacheControl = "public";
			context.Response.Write(@"User-agent: *" + Environment.NewLine + "Disallow: / ");
		}
	}
}
