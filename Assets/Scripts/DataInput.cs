using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class DataInput 
{
    public static DataInput Instance;
    public Dictionary<string, List<string>> BookOfWords = new Dictionary<string, List<string>>(); 
    public List<string> dictionary = new List<string>();
    public List<string> wordSearchHorizontal;
    public List<string> wordSearchVertical = new List<string>();

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
        wordSearchHorizontal = wordsearch.text.Split((new[] {"\n"}), StringSplitOptions.None).ToList();

        Debug.Log(wordSearchHorizontal[0]); 
        
        //store every line of search for vertical search 
        foreach (var line in wordSearchHorizontal)
        {
            wordSearchVertical.Add(line.Substring(0,1)); 
        }

        Debug.Log(wordSearchHorizontal[0]);
        Debug.Log(wordSearchVertical[0]);
    }

    public void InputDictionary()
    {
        //save a reference to the dictionary 
        var dic = Resources.Load<TextAsset>("dictionary");
        //everword in the dictionary will be put into an array, they are separated by the next line'
        dictionary = dic.text.Split((new[] {"\n"}), StringSplitOptions.None).ToList();
        dictionary.Remove(dictionary[dictionary.Count - 1]);
        //maybe the dictionary needs to be split into multiple Lists for each letter -
        // BookOfWords = dic.text.Split(ne Char[] {'\n'}).ToDictionary(w => w);

       foreach (var word in dictionary)
       {
           var firstLetter = word.Substring(0, 1); //grabs the first letter from the word
           if (!BookOfWords.ContainsKey(firstLetter.ToLower()))  // if a key doesn't exist add''
           {
               BookOfWords.Add(firstLetter.ToLower(),new List<string>()); // add a lowercase version of the letter
           }
           BookOfWords[firstLetter.ToLower()].Add(word); // add the word to the lowercase of the key
       }

        // Debug.Log(dictionary[0]+" "+ dictionary[1]);
    }
}
