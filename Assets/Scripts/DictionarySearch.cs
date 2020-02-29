using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DictionarySearch
{
    public static DictionarySearch Instance;
    
    public List<string> foundWords = new List<string>();
    
    
    /// <summary>
    /// This is the only function that is supposed to be called when looping the data
    /// It take a line and gets the possible words in it reading from both forward and backward
    /// </summary>
    /// <param name="line"></param>
    /// Since word-search is a game based on horizontal, vertical, and diagonal lines
    /// the input should be the data from one whole line that belongs to one category above
    /// so technically this func should be run for all the possible lines
    public void SearchWordInOneLine(string line)
    {
        //to save steps, a lot of works need to be done when loop through all the letters in the line
        //The lists are created first to make sure multiple word checking are being done in the same time
        var listCopies = _CreateCopyList(line.Length * 2, Services._DataInput.dictionary);
        
        //consider only checking forward
        //line[0] can only be the first letter of a word
        //lin2[1] can be the second letter or the first letter, and etc
        //therefore, we have different lists for all the possibilities
        //line.length * 2 = the possible word-start position in the line * the line goes either forwards || backwards
        for (int i = 0; i < line.Length; i++)
        for (int m = 0; m <= i; m++)
        {
            listCopies[m] = GetMatchedWordFromList(line.Substring(i, 1), i-m, listCopies[m]);
            listCopies[m+line.Length] = GetMatchedWordFromList(line.Substring(i, 1), i-m, listCopies[m+line.Length],true);
        }
        
        
    }
    
    /// <summary>
    /// This func takes a list of possible words and one char got from the input line,
    /// checks if the words has the same char in the specific position of it, and returns a list of words that does
    /// say a word list contains {{yes},{yeah},{yellow}}, searchChar = "a", charPos = 2
    /// the function is then searching all the words in the list and returns the words that has the third letter to be s
    /// which is {{yeah}}
    /// it will put the founded words in foundWords but not in the return list
    /// so if searchChar = "s", charPos = 2
    /// return list would be empty
    /// </summary>
    /// <param name="searchChar"></param> the targeted char
    /// <param name="charPos"></param> the position that it would check
    /// <param name="dicRange"></param> the list of possible words
    /// <param name="isBackward"></param> whether the checking is backwards
    /// <returns></returns>
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

    private List<T> _CopyList<T>(List<T> list)
    {
        var tempArray = new T[0];
        list.CopyTo(tempArray);
        return tempArray.ToList();
    }
    
    /// copy list values and make a new list
    private List<List<T>> _CreateCopyList<T>(int length, List<T> dic)
    {
        var listCopies = new List<List<T>>();
        for(int i = 0; i<length; i++)
            listCopies.Add(_CopyList(dic));
        return listCopies;
    }
}
