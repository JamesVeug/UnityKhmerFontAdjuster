using System.Collections.Generic;
using System.Text;
using UnityEngine;

// List of characters: https://en.wikipedia.org/wiki/Khmer_script
public static class KhmerFontAdjuster
{
    public static bool IsKhmerString(string s)
    {
        var length = s.Length;
        for (var i = 0; i < length; i++)
        {
            var c = s[i];
            if (c >= '\x1780' && c <= '\x17FF')
                return true; // Khmer
            if (c >= '\x19E0' && c <= '\x19FF')
                return true; // Khmer Symbols
        }
        return false;
    }

    // ========== EXTENDED CHARACTER TABLE ==========
    public static char ConsonantJoiner = '្'; 
    
    public static Dictionary<char, string> ConsonantToSubscriptForm = new Dictionary<char, string>
    {
        {'ក', "<sprite=0>"},
        {'ខ', "<sprite=1>"},
        {'គ', "<sprite=2>"},
        {'ឃ', "<sprite=3>"},
        {'ង', "<sprite=4>"},
        {'ច', "<sprite=5>"},
        {'ឆ', "<sprite=6>"},
        {'ជ', "<sprite=7>"},
        {'ឈ', "<sprite=8>"},
        {'ញ', "<sprite=9>"},
        {'ដ', "<sprite=10>"},
        {'ឋ', "<sprite=11>"},
        {'ឌ', "<sprite=12>"},
        {'ឍ', "<sprite=13>"},
        {'ណ', "<sprite=14>"},
        {'ត', "<sprite=15>"},
        {'ថ', "<sprite=16>"},
        {'ទ', "<sprite=17>"},
        {'ធ', "<sprite=18>"},
        {'ន', "<sprite=19>"},
        {'ប', "<sprite=20>"},
        {'ផ', "<sprite=21>"},
        {'ព', "<sprite=22>"},
        {'ភ', "<sprite=23>"},
        {'ម', "<sprite=24>"},
        {'យ', "<sprite=25>"},
        {'រ', "<sprite=26>"},
        {'ល', "<sprite=27>"},
        {'វ', "<sprite=28>"},
        {'ឝ', "<sprite=29>"},
        {'ឞ', "<sprite=30>"},
        {'ស', "<sprite=31>"},
        {'ហ', "<sprite=32>"},
        //{'ឡ', "<sprite=33>"}, // None!
        {'អ', "<sprite=33>"},
    };
    
    // ==============================================

    public static string Adjust(string s)
    {
        var length = s.Length;
        var sb = new StringBuilder(length);
        for (var i = 0; i < length; i++)
        {
            var c = s[i];
            if (IsConsonantJoiner(c))
            {
                if (i + 1 < length)
                {
                    char d = s[++i];
                    string text = "" + d;
                    if (!ConsonantToSubscriptForm.TryGetValue(d, out text))
                    {
                        Debug.Log("Missing!");
                    }
                    
                    sb.Append(text);
                    continue;
                }
            }

            sb.Append(c);
        }

        return sb.ToString();
    }

    // A character that joins a consonant to another by place the second consonant underneath the first
    // Khmer Sign Coeng - https://unicode-table.com/en/17D2/
    // ្
    // U+17D2
    // &#6098;
    public static bool IsConsonantJoiner(char c)
    {
        return c == ConsonantJoiner; // TODO: get windows encoding of this in the form of '\x0E48'!
    }
    
    public static bool IsEmpty(char c)
    {
        return c == ' ';
    }
}
