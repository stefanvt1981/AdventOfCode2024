// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;

var inputText = File.ReadAllText("input.txt");

var mulMatches = Regex.Matches(inputText, @"mul\(\d{1,3},\d{1,3}\)");
var doMatches = Regex.Matches(inputText, @"do\(\)");
var dontMatches = Regex.Matches(inputText, @"don't\(\)");

var total = 0;

Console.WriteLine(mulMatches.Count);
Console.WriteLine(doMatches.Count);
Console.WriteLine(dontMatches.Count);

var isDo = true;

for (var i = 0; i < inputText.Length; i++)
{
    var mul = mulMatches.FirstOrDefault(m => m.Index == i);
    var doMul = doMatches.FirstOrDefault(m => m.Index == i);
    var dontMul = dontMatches.FirstOrDefault(m => m.Index == i);
    
    if(mul is not null && isDo)
    {
        var factoren = Regex.Matches(mul.Value, @"\d{1,3}");
        
        var factor1 = int.Parse(factoren[0].Value);
        var factor2 = int.Parse(factoren[1].Value);
        
        total += factor1 * factor2;
    }
    
    if(doMul is not null)
    {
        isDo = true;
    }
    
    if(dontMul is not null)
    {
        isDo = false;
    }
}

Console.WriteLine(total);