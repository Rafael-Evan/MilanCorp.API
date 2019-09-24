using System;
using System.DirectoryServices;

namespace UsersAD.poc
{
    class Program
    {
        private const string SAMAccountNameAttribute = "SAMAccountName";
        static void Main(string[] args)
        {

            var userName = "Monitoramento";
            var password = "Monitor@123*";

            //active directory properties attribute names
            string propUsername = "samaccountname";
            string propFirstName = "givenName";
            string propLastName = "sn";
            string propMail = "mail";

            using (DirectoryEntry entry = new DirectoryEntry("LDAP://192.168.0.200/DC=milan,DC=local", "milan" + "\\" + userName, password))
            {
                using (DirectorySearcher searcher = new DirectorySearcher(entry))
                {
                    searcher.Filter = String.Format("({0}={1})", SAMAccountNameAttribute, userName);
                    searcher.PropertiesToLoad.Add(propUsername);
                    searcher.PropertiesToLoad.Add(propFirstName);
                    searcher.PropertiesToLoad.Add(propLastName);
                    searcher.PropertiesToLoad.Add(propMail);

                    //Set Search Options
                    searcher.SearchScope = SearchScope.Subtree;
                    searcher.SearchRoot.AuthenticationType = AuthenticationTypes.Secure;
                    searcher.PageSize = 100;

                    var result = searcher.FindOne();
                    {
                        //get poperties and write them to the console
                        if (result.Properties.Contains(propUsername) && result.Properties.Contains(propMail))
                        {
                            Console.WriteLine("Full Name: " + result.Properties[propFirstName][0]);
                            Console.WriteLine("User Name: " + result.Properties[propUsername][0]);
                            Console.WriteLine("Email: " + result.Properties[propMail][0]);
                        }

                    }
                    //release resources
                    searcher.Dispose();
                    searcher.Dispose();
                }
            }
        }
    }

}
