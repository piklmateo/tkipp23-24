using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuisnessLayer.Interfaces;
using DataAccessLayer.Iznimke;
using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using Facebook;

namespace BuisnessLayer.Services
{
    ///<author>Toni Leo Modrić Dragičević</author>
    public class FacebookService
    {
        private readonly IFacebookClient _facebookClient;

        public FacebookService(IFacebookClient facebookClient)
        {
            _facebookClient = facebookClient;
            _facebookClient.AppId = "596681999284443";
            _facebookClient.AppSecret = "812d3af8350a55ed52608e2427103ff7";
            _facebookClient.AccessToken = "EAAIerdqceNsBOymZCwpz2sN5gO5dkdSBrUkHTrgfD4T66iZCs4Pyv0ZAKVpU8bE9TZBf7gK01DKuVv2htZCmzSG2Ex7s6UYujGpO7ubhVtwvKirY7SA22sTmnOM2P9AlslgCDfhowzXu99AT3FlK0U2R7F5XG1eHFtpfOLzBR0At8kY88E6Vky56M4ZBhe5tgmOSYblZAsZD";
        }

        public void ShareFacebook(string message, string image)
        {
            
            if (string.IsNullOrEmpty(message))
            {
                throw new FacebookException("Message can't be null or empty");
            }

            try
            {
                if (string.IsNullOrEmpty(image))
                {
                    var parameters = new Dictionary<string, object>
                    {
                        { "message", message }
                    };

                    _facebookClient.Post("/me/feed", parameters);
                }
                else
                {
                    var parameters = new Dictionary<string, object>
                    {
                        { "message", message },
                        { "url", image }
                    };

                    _facebookClient.Post("/me/photos", parameters);
                }
            }
            catch (FacebookException ex)
            {
                throw new FacebookException("Error sending Facebook post: " + ex);
            }
        }
    }
}
