using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace WebApi_JwtAuthTest
{
    public interface IClient
    {
        public string aaa { get; set; }
    }
    public class Client: IClient
    {
        public string aaa { get; set; } = string.Empty;
        public string bbb { get; set; } = string.Empty;

        public Client()
        {
        }

        public Client(Client client)
        {
            this.ToCopy(client);
        }

        public void ToCopy(Client client)
        {
            this.aaa = client.aaa;
            this.bbb = client.bbb;
        }
    }

}
