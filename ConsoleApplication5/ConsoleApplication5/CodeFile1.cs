using System.Net;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;
public struct LinkItem
{
    public string Href;
    public string Text;

    public override string ToString()
    {
        return Href + "\n\t" + Text;
    }
}

static class LinkFinder
{
    public static List<LinkItem> Find(string file)
    {
        List<LinkItem> list = new List<LinkItem>();

        
        // Find all matches in file.
        MatchCollection m1 = Regex.Matches(file, @"(<a.*?>.*?</a>)",RegexOptions.Singleline);
        
       
        
        // Loop over each match.
        foreach (Match m in m1)
        {

            //Console.WriteLine("hello and hi");
            string value = m.Groups[1].Value;
            LinkItem i = new LinkItem();
            Console.WriteLine("\t"+value);
            
            // Get href attribute.
            Match m2 = Regex.Match(value, @"href=\""(.*?)\""",RegexOptions.Singleline);
            

            if (m2.Success)
            {
                i.Href = m2.Groups[1].Value;
                Console.WriteLine("\t\t"+ i);
            }

            
            // Remove inner tags from text.
            string t = Regex.Replace(value, @"\s*<.*?>\s*", "",RegexOptions.Singleline);
            i.Text = t;
            Console.WriteLine(t);
            list.Add(i);
            
        }
        return list;
    }

    public static void Main()
    {
       
        
        WebClient w = new WebClient();
        string[] a = { "http://www.phonearena.com/", "http://www.gsmarena.com/", "http://www.whatmobile.com.pk/" };

        for (int i = 0; i < 3; i++)
        {
            string s = w.DownloadString(a[i]);
            LinkFinder.Find(s);
            Console.ReadLine();

        }

       
       
    }
}