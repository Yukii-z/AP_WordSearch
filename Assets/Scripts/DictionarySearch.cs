using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DictionarySearch
{
    public static DictionarySearch Instance;
    
    public List<string> foundWords = new List<string>();
    public List<string> GetMatchedWordFromList(string searchChar, int charPos, List<string> dicRange, bool isBackward = false)
    {
        //if there is no possible word, just return the empty list
        if (dicRange.Count == 0) return dicRange;
        
        //remake the list and check one more char
        var targetNewDic = new List<string>();
        foreach (var word in dicRange)
            if (word.Substring(isBackward?word.Length - charPos - 1 : charPos, 1) == searchChar)
                //is checking the last char of a word
                if (charPos == word.Length - 1) foundWords.Add(word);
                else targetNewDic.Add(word); 
        
        return targetNewDic;
    }

    public void SearchWordInOneLine(string line)
    {
        var listCopies = _CreateCopyList(line.Length * 2, DataInput.Instance.dictionary);
        for (int i = 0; i < line.Length; i++)
        for (int m = 0; m <= i; m++)
        {
            listCopies[m] = GetMatchedWordFromList(line.Substring(i, 1), i-m, listCopies[m]);
            listCopies[m+line.Length] = GetMatchedWordFromList(line.Substring(i, 1), i-m, listCopies[m+line.Length],true);
        }
    }

    private List<T> _CopyList<T>(List<T> list)
    {
        var tempArray = new T[0];
        list.CopyTo(tempArray);
        return tempArray.ToList();
    }

    private List<List<T>> _CreateCopyList<T>(int length, List<T> dic)
    {
        var listCopies = new List<List<T>>();
        for(int i = 0; i<length; i++)
            listCopies.Add(_CopyList(dic));
        return listCopies;
    }
}
