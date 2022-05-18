using System;
using System.Net.NetworkInformation;

namespace NetworkAdmin
{
    public class Admin
    {
        public static void Main()
        {
            IPFinder iPFinder = new IPFinder();
            Console.WriteLine(iPFinder.GetPersonalIP());
        }
    }
}