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

            
            // Get href attribute.
            Match m2 = Regex.Match(value, @"href=\""(.*?)\""",
            RegexOptions.Singleline);
            if (m2.Success)
            {
                i.Href = m2.Groups[1].Value;
                //Console.WriteLine("hello and hi");
            }

            
            // Remove inner tags from text.
            string t = Regex.Replace(value, @"\s*<.*?>\s*", "",RegexOptions.Singleline);
            i.Text = t;
            //Console.WriteLine("hello and hi");
            list.Add(i);
        }
        return list;
    }

    public static void Main()
    {
       
        
        WebClient w = new WebClient();
        string s = w.DownloadString("http://www.gsmarena.com/");

        

        
        foreach (LinkItem i in LinkFinder.Find(s))
        {
            //Console.WriteLine("hello and hi");
           // Debug.WriteLine(i);
            Console.WriteLine(i);
        }

        Console.ReadLine();

        WebClient w2 = new WebClient();
        string s2 = w2.DownloadString("http://www.phonearena.com/");



        foreach (LinkItem i in LinkFinder.Find(s2))
        {
            //Console.WriteLine("hello and hi");
            // Debug.WriteLine(i);
            Console.WriteLine(i);
        }
        Console.ReadLine();


        WebClient w3 = new WebClient();
        string s3 = w3.DownloadString("http://www.whatmobile.com.pk/");



        
        foreach (LinkItem i in LinkFinder.Find(s3))
        {
            //Console.WriteLine("hello and hi");
            // Debug.WriteLine(i);
            Console.WriteLine(i);
        }
        Console.ReadLine();
    }
}