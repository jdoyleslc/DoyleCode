using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;


using DoyleCode;
/// <summary>
/// Author: Jason Doyle, jdoyleslc@gmail, josiah.us
/// This is a hack that queries github user repositories with the curl utility then parses the returned JSON string.
/// See http://developer.github.com/v3/repos/ for api info.
/// 
/// The proper way to perform this would be to use C# classes to perform the web opertations, then create a Json serialization object.
/// Example using DataContractJsonSerializer:
///  See http://msdn.microsoft.com/en-us/library/hh674188.aspx
///  See http://msdn.microsoft.com/en-us/library/system.runtime.serialization.json.datacontractjsonserializer.aspx
///  
/// This program also exercises the Project1 class when the "return" statement below is removed.
/// </summary>


class DoyleProgram
{
    static void Main(string[] args)
    {
        //Project 2
        //===========
        //Directions:
        //Write a simple program that uses GitHub's (https://github.com/) JSON API to take input of a
        //GitHub username and return the list of public repositories associated
        //with that username. Please use C#. You may use any toolkit or method you
        //desire to accomplish this. The program may be console or graphical.

        //Sample git hub users: sjuxax or danhakes


        String reporesp = "";
        try
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
       
            p.StartInfo.Arguments = @"/c .\..\..\..\curl.exe -k https://api.github.com/users/danhakes/repos";
            p.Start();
            reporesp = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            p.StartInfo.Arguments = @"/c .\..\..\..\curl.exe -k https://api.github.com/users/sjuxax/repos";
            p.Start();
            reporesp += p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            //Console.WriteLine(reporesp);

            Console.WriteLine("\n\nGitHub repos owned by sjuxax and danhakes\n");
            foreach (Match m in Regex.Matches(reporesp, "\"full_name\".*"))
            {
                //Console.WriteLine(m);
                String repostr = Regex.Match(m.ToString(), "[^/]+[a-zA-Z0-9-]+\",").ToString();
                repostr = Regex.Match(repostr, "[a-zA-Z0-9-]+").ToString();
                Console.WriteLine(repostr);

               }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: " + ex);
        }
        Console.WriteLine("\nI see a bitcoin repo.  Ask me about my FPGA HW and bitcoin hasher that I intend to write.");
        Console.ReadLine();

        
        return; // remove to exercise proj1


        // Project1 Testing
        var proj1 = new Project1();

        Console.WriteLine("\nAll Ints (count=" + proj1.GetInts().Count + ")");
        foreach (var v in proj1.GetInts())
            Console.WriteLine(v.ToString());

        Console.WriteLine("\nAll Ints in Ascescending Order");
        foreach (var v in proj1.GetInts(SortingDirection.ASCENDING))
            Console.WriteLine(v.ToString());

        Console.WriteLine("\nAll Ints in Descending Order");
        foreach (var v in proj1.GetInts(SortingDirection.DESCENDING))
            Console.WriteLine(v.ToString());

        Console.WriteLine("\nInts between 200 and 2000 (count=" + proj1.GetIntsBetween200and2000().Count + ")");
        foreach (var v in proj1.GetIntsBetween200and2000())
            Console.WriteLine(v.ToString());

        Console.WriteLine("\nAllEvens (count=" + proj1.GetEvenInts().Count + ")");
        foreach (var v in proj1.GetEvenInts())
            Console.WriteLine(v.ToString());

        Console.WriteLine("\nAllOdds (count=" + proj1.GetOddInts().Count + ")");
        foreach (var v in proj1.GetOddInts())
            Console.WriteLine(v.ToString());

        Console.WriteLine("\nFizzbuzzified");
        foreach (var item in proj1.Fizzbuzzify())
            Console.WriteLine(item);

        System.Console.ReadLine();
    }
}