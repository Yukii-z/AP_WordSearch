
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private void Awake()
    {
        InitalizeServices();
    }

    private void InitalizeServices()
    {
        Services._game = this; 
        Services._DataInput = new DataInput();
        Services._dictionarySearch = new DictionarySearch();
    }

    // Start is called before the first frame update
    void Start()
    {
        Services._DataInput.StartData(); // i hate jobs
        // horizontal search
        for (int i = 0; i < Services._DataInput.search.Count; i++)
        {
            Services._dictionarySearch.SearchWordInOneLine(Services._DataInput.search[i]);
        }
        
        // vertical search
        
        // diagonal search 
        
        //print any found words 
        Debug.Log(Services._dictionarySearch.foundWords.Count);
        foreach (var word in Services._dictionarySearch.foundWords)
            Debug.Log(word);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
