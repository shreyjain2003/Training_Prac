// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
public class Program
{
    public static void StringMan(string str, int k){
        char [] arr = str.ToCharArray();
        
        Array.Reverse(arr);
        string ns = new string(arr);
        string res = new string(ns.Distinct().ToArray());
        string right = res.Substring(res.Length - k);
        string left = res.Substring(0, res.Length -k);
        string ms = right+left;
        
        StringBuilder sb = new StringBuilder();
        foreach(var c in ms){
             var rep = c switch{
                'a'=>'e',
                'e'=>'i',
                'i'=>'o',
                'o'=>'u',
                'u'=>'a',
                'A'=>'E',
                'E'=>'I',
                'O'=>'U',
                'U'=>'A',
                _ => c
            };
            sb.Append(rep);
        }
        
        Console.WriteLine(sb.ToString().ToLower());
    }
    public static void Main(string[] args)
    {
        StringMan("Hello",2);
    }
}