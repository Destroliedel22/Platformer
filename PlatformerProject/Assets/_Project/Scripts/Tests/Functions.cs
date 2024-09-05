using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class Functions : MonoBehaviour
{
    int maxLength = 0;

    public int LongestWordLength(string sentence)
    {
        string[] Words = sentence.Split(' ');
        foreach(string word in Words)
        {
            if(word.Length > maxLength) 
            {
                maxLength = word.Length;
            }
        }
        return maxLength;
    }

    private void Start()
    {
        LongestWordLength("hello world, what a beautiful day innit?");
    }
}
