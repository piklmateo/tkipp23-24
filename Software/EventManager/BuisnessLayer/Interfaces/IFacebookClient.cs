using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Interfaces
{
    public interface IFacebookClient
    {
        string AppId { get; set; }
        string AppSecret { get; set; }
        string AccessToken { get; set; }
        void Post(string path, IDictionary<string, object> parameters);
    }
}
