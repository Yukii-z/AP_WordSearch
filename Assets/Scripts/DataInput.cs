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
    public List<string> dictionary = new List<string>();
    public string[] search; 

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

        //store every line of the search 
        search = wordsearch.text.Split((new[] {"\n"}), StringSplitOptions.None); 
        
        Debug.Log(search[0]);
    }

    public void InputDictionary()
    {
        //save a reference to the dictionary 
        var dic = Resources.Load<TextAsset>("dictionary");
        //everword in the dictionary will be put into an array, they are separated by the next line'
        //dictionary = dic.text.Split((new[] {"\n"}), StringSplitOptions.None).ToList(); 

        //maybe the dictionary needs to be split into multiple Lists for each letter 
        
        Debug.Log(dictionary[0]+" "+ dictionary[1]);
    }
}
