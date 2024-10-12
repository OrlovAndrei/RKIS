using System;
string? input = Console.ReadLine();
string[]? result  = input.Split(separator: ' ');
double P = Double.Parse(result[0]);
var N = Double.Parse(result[1]);
N = N/100;
var T = Double.Parse(result[2]);
var result1 = P*Math.Pow(1+(N/12),T);
Console.WriteLine(result1);

