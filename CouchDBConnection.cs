using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Neural
{
    public class CouchDBConnection
    {
        public string Username { get; set; }
        
        public string Password { get; set; }

        public string BaseURL { get; set; }

        public int Port { get; set; }

        public string Database { get; set; }

        HttpClient mClient;
        UriBuilder mUriBuilder;

        // Overloaded to allow for no username or password
        public CouchDBConnection(string aBaseURL, int aPort, string aDatabase) : this(aBaseURL, aPort, aDatabase, "", "")
        {
        }

        public CouchDBConnection(string aBaseURL, int aPort, string aDatabase, string aUsername, string aPassword)
        {
            Username = aUsername;
            Password = aPassword;
            BaseURL = aBaseURL;
            Port = aPort;
            Database = aDatabase;

            mClient = new HttpClient();
            mUriBuilder = new UriBuilder("http", BaseURL, Port);
            if (!String.IsNullOrEmpty(Username) && !String.IsNullOrEmpty(Password))
            {
                mUriBuilder.UserName = Username;
                mUriBuilder.Password = Password;
            }
            if (!String.IsNullOrEmpty(Database))
            {
                mUriBuilder.Path = Database;
            }
            // Add an Accept header for JSON format.
            mClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public string Get(string id)
        {
            string uri = mUriBuilder.Uri + "/" + id;
            var response = mClient.GetStringAsync(uri);
            return response.Result;
        }

    }
}
