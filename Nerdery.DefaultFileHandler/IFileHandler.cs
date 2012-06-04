using System.Web;

namespace Nerdery.Handlers
{
	public interface IFileHandler
	{
		void ProcessRequest(HttpContext context);
	}
}