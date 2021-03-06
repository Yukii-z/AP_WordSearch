﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class DataInput 
{
    public static DataInput Instance;
    public Dictionary<string, List<string>> bookOfWords = new Dictionary<string, List<string>>(); 
    public Dictionary<string, List<string>> bookOfBackWords = new Dictionary<string, List<string>>(); 
    public List<string> dictionary = new List<string>();
    public List<string> search; 

    public void StartData()
    {
        InputDictionary();
        InputMap();
    }
    public void InputMap() //change which wordsearch is added 
    {
        //save a reference to the wordsearch
        var wordsearch = Resources.Load<TextAsset>("wordsearch_1");
        var wordsearch2 = Resources.Load <TextAsset>("wordsearch_2");
        var wordsearch3 = Resources.Load<TextAsset>("wordsearch_3");

        //store every line of the search for horizontal search
        search = wordsearch.text.Split((new[] {"\n"}), StringSplitOptions.None).ToList();
        search.Remove(search[search.Count - 1]);
        for(int i = 0; i < search.Count; i++)
            search[i] = search[i].Substring(0, search[i].Length - 1);
        search = new List<string> {search[0].Substring(0,20)};
        
        //store every line of search for vertical search 

        Debug.Log(search[0].Substring(search[0].Length-1, 1));
    }

    public void InputDictionary()
    {
        //save a reference to the dictionary 
        var dic = Resources.Load<TextAsset>("dictionary");
        //everword in the dictionary will be put into an array, they are separated by the next line'
        dictionary = dic.text.Split((new[] {"\n"}), StringSplitOptions.None).ToList();
        dictionary.Remove(dictionary[dictionary.Count - 1]);

        //maybe the dictionary needs to be split into multiple Lists for each letter -
        
       // BookOfWords = dic.text.Split(new Char[] {'\n'}).ToDictionary(w => w);

       foreach (var word in dictionary)
       {
           var firstLetter = word.Substring(0, 1); //grabs the first letter from the word
           var lastLetter = word.Substring(word.Length - 1, 1);
           if (!bookOfWords.ContainsKey(firstLetter.ToLower()))  // if a key doesn't exist add''
               bookOfWords.Add(firstLetter.ToLower(),new List<string>()); // add a lowercase version of the letter
           if (!bookOfBackWords.ContainsKey(lastLetter.ToLower()))  // if a key doesn't exist add''
               bookOfBackWords.Add(lastLetter.ToLower(),new List<string>()); // add a lowercase version of the letter
           bookOfWords[firstLetter.ToLower()].Add(word); // add the word to the lowercase of the key
           bookOfBackWords[lastLetter.ToLower()].Add(word); // add the word to the lowercase of the key
       }

        // Debug.Log(dictionary[0]+" "+ dictionary[1]);
    }
}
