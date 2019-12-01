using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Words : MonoBehaviour
{
    public GameContoller gc;

    [Header("Easy")]
    public List<string> easyWords = new List<string>();

    [Header("Normal")]
    public List<string> normalWords = new List<string>();

    [Header("Hard")]
    public List<string> hardWords = new List<string>();


    private void Start()
    {
        easyWords = Shuffle_String(easyWords);
        normalWords = Shuffle_String(normalWords);
        hardWords = Shuffle_String(hardWords);
    }

    public List<string> Shuffle_String(List<string> strList)
    {
        List<int> category = new List<int>();
        List<string> shuffleStringList = new List<string>();
        
        //초기화
        for (int i = 0; i < strList.Count; i++)
        {
            category.Add(i);
        }
        category = Shuffle(category);
        
        for (int i = 0; i < strList.Count; i++)
        {
            shuffleStringList.Add(strList[category[i]]);
        }
        
        return shuffleStringList;
    }
    
    public List<int> Shuffle(List<int> shuffleNum)
    {
        int temp = 0, dest = 0, sour = 0;

        for (int i = 0; i < 1000; i++)
        {
            dest = Random.Range(0, shuffleNum.Count);
            sour = Random.Range(0, shuffleNum.Count);
            temp = shuffleNum[dest];
            shuffleNum[dest] = shuffleNum[sour];
            shuffleNum[sour] = temp;
        }

        return shuffleNum;
    }
}
