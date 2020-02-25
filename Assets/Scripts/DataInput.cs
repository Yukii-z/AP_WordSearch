using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEditor;
using UnityEngine;

public class DataInput
{
    public static DataInput Instance;
    public List<string> dictionary = new List<string>();
    public void InputMap()
    {
        
    }

    public void InputDictionary()
    {
        var dic = Resources.Load<TextAsset>("dictionary");
    }
}
