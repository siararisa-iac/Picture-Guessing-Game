using System.Collections.Generic;
using UnityEngine;

public static class ListExtensions 
{
    public static void Shuffle<T>(this List<T> list)
    {
        int count = list.Count;
        for(int i = count - 1; i > 0; i--){
            int randomIndex = Random.Range(0, i+1);
            (list[i], list[randomIndex]) = (list[randomIndex], list[i]);
        }
    }
}
