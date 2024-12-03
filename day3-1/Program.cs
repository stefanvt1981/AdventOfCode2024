// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;

var inputText = File.ReadAllText("input.txt");

var matches = Regex.Matches(inputText, @"mul\(\d{1,3},\d{1,3}\)");

var total = 0;

foreach (Match match in matches)
{
    //Console.WriteLine(match.Value);
    
    var factoren = Regex.Matches(match.Value, @"\d{1,3}");
    
    var factor1 = int.Parse(factoren[0].Value);
    var factor2 = int.Parse(factoren[1].Value);
    
    total += factor1 * factor2;
}

Console.WriteLine(total);
