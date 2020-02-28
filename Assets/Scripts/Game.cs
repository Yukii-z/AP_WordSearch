
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(DataInput.Instance == null) 
            DataInput.Instance = new DataInput();
        if(DictionarySearch.Instance == null) 
            DictionarySearch.Instance = new DictionarySearch();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
