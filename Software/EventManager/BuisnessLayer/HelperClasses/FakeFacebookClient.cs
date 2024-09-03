using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facebook;

namespace BuisnessLayer.Interfaces
{
    public class FakeFacebookClient : IFacebookClient
    {
        private readonly FacebookClient _facebookClient;

        public FakeFacebookClient()
        {
            _facebookClient = new FacebookClient();
        }

        public string AppId
        {
            get => _facebookClient.AppId;
            set => _facebookClient.AppId = value;
        }

        public string AppSecret
        {
            get => _facebookClient.AppSecret;
            set => _facebookClient.AppSecret = value;
        }

        public string AccessToken
        {
            get => _facebookClient.AccessToken;
            set => _facebookClient.AccessToken = value;
        }

        public void Post(string path, IDictionary<string, object> parameters)
        {
            _facebookClient.Post(path, parameters);
        }
    }
}
