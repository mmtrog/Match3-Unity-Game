using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using URandom = UnityEngine.Random;

public class Utils
{
    public static NormalItem.eNormalType GetLeastExcept(NormalItem.eNormalType[] types, int[] frequency)
    {
        var min = 999;
        
        var list = Enum.GetValues(typeof(NormalItem.eNormalType)).Cast<NormalItem.eNormalType>().Except(types).ToList();

        if (list.Contains(NormalItem.eNormalType.NO_TYPE)) list.Remove(NormalItem.eNormalType.NO_TYPE);

        var result = NormalItem.eNormalType.NO_TYPE;
        
        foreach (var type in list)
        {
            if (frequency[(int)type] < min)
            {
                result = type;

                min = frequency[(int)type];
            }
        }
        
        return result;
    }

    public static NormalItem.eNormalType GetRandomExcept(NormalItem.eNormalType[] types)
    {
        List<NormalItem.eNormalType> list = Enum.GetValues(typeof(NormalItem.eNormalType)).Cast<NormalItem.eNormalType>().Except(types).ToList();

        if (list.Contains(NormalItem.eNormalType.NO_TYPE)) list.Remove(NormalItem.eNormalType.NO_TYPE);
        
        int rnd = URandom.Range(0, list.Count);
        NormalItem.eNormalType result = list[rnd];
        
        return result;
    }
}
