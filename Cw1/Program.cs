using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cw1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
          

            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(args[0]);

            if (response.IsSuccessStatusCode) {
                var content =await response.Content.ReadAsStringAsync();

                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+",RegexOptions.IgnoreCase);
                var matches = regex.Matches(content);

                foreach (var email in matches) {
                    Console.WriteLine(email.ToString());
                }
            }

            Console.ReadKey();


        }
    }
}
