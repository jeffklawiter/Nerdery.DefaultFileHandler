using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Web;

namespace Nerdery.Handlers
{
	public class DefaultFileHandler : IHttpHandler
	{
		private readonly Dictionary<string, IFileHandler> _fileHandlers = new Dictionary<string, IFileHandler>
		                                                        	{
		                                                        		{"robots.txt", new RobotsHandler()}
		                                                        	};
		/// <summary>
		/// Enables processing of HTTP Web requests by a custom HttpHandler that implements the <see cref="T:System.Web.IHttpHandler"/> interface.
		/// </summary>
		/// <param name="context">An <see cref="T:System.Web.HttpContext"/> object that provides references to the intrinsic server objects (for example, Request, Response, Session, and Server) used to service HTTP requests. </param>
		public void ProcessRequest(HttpContext context)
		{
			//Debugger.Launch();
			try
			{
				foreach (var item in _fileHandlers)
				{
					if (context.Request.FilePath.ToLower().EndsWith(item.Key))
						item.Value.ProcessRequest(context);
				}
			}
			catch
			{
				//todo: log to event log
			}

		}


		/// <summary>
		/// Gets a value indicating whether another request can use the <see cref="T:System.Web.IHttpHandler"/> instance.
		/// </summary>
		/// <returns>
		/// true if the <see cref="T:System.Web.IHttpHandler"/> instance is reusable; otherwise, false.
		/// </returns>
		public bool IsReusable
		{
			get { return true; }
		}
	}
}
