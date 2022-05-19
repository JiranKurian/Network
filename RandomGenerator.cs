using System;

namespace NetworkAdmin
{
    public static class RandomGenerator
    {
        public static string GetRandomData(int length)
        {
            Random random = new Random();
            const string charactors = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+-=[]{},./<>?";
            return new string(Enumerable.Repeat(charactors, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}