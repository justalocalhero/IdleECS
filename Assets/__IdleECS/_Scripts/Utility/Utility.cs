using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Utility
{
    public static T[] ExtendArrayByList<T>(T[] array, List<T> extentions)
    {
        List<T> toReturn = new List<T>();

        for(int i = 0; i < array.Length; i++)
        {
            toReturn.Add(array[i]);
        }

        toReturn.AddRange(extentions);

        return toReturn.ToArray();
    }

    public static int EnumLength(System.Enum e)
    {
        return System.Enum.GetNames(e.GetType()).Length;
    }
	
    public static T[] ArrayFromEnum<T>(System.Enum e)
    {
        return new T[EnumLength(e)];
    }

	public static T[] ExtendArrayByArray<T>(T[] array, T[] extention)
	{
        if(array == null || extention == null) return array;

		T[] toReturn = new T[array.Length + extention.Length];
		
		int i = 0;

		for(i = 0; i < array.Length; i++)
		{
			toReturn[i] = array[i];
		}

		for(int j = 0 ; j < extention.Length; j++)
		{
			toReturn[i + j] = extention[j];
		}

		return toReturn;
	}

    public static List<T> CloneList<T>(List<T> toClone)
    {
        List<T> toReturn = new List<T>();

        foreach(T t in toClone)
        {
            toReturn.Add(t);
        }

        return toReturn;
    }

    public static T[] CloneArray<T>(T[] toClone)
    {
        T[] toReturn = new T[toClone.Length];

        for(int i = 0; i < toClone.Length; i++)
        {
            toReturn[i] = toClone[i];
        }

        return toReturn;
    }
        
    public static bool IsNonEmpty<T>(T[] array)
    {
        return array != null && array.Length > 0;
    }

	public static bool IsNonEmpty<T>(List<T> list)
	{
		return list != null && list.Count > 0;
	}

	public static string ToCamelCase(this string the_string)
	{
		// If there are 0 or 1 characters, just return the string.
		if (the_string == null || the_string.Length < 2)
			return the_string;

		// Split the string into words.
		string[] words = the_string.Split(
			new char[] { },
			StringSplitOptions.RemoveEmptyEntries);

		// Combine the words.
		string result = words[0].ToLower();
		for (int i = 1; i < words.Length; i++)
		{
			result +=
				words[i].Substring(0, 1).ToUpper() +
				words[i].Substring(1);
		}

		return result;
	}

    public static string ToProperCase(this string the_string)
    {
        // If there are 0 or 1 characters, just return the string.
        if (the_string == null) return the_string;
        if (the_string.Length < 2) return the_string.ToUpper();

        // Start with the first character.
        string result = the_string.Substring(0, 1).ToUpper();

        // Add the remaining characters.
        for (int i = 1; i < the_string.Length; i++)
        {
            if (char.IsUpper(the_string[i])) result += " ";
            result += the_string[i];
        }

        return result;
    }

	public static string ToPercent(float x)
	{
        return string.Format("{0:0%}", x);
	}

	public static string ToX(float x)
	{
		return (x.ToString("n2") + "x");
	}

	public static float Truncate(float x, int decimals)
	{
		decimal dec = Convert.ToDecimal(x);
		dec = Math.Round(dec, decimals);

		return (float)dec;
	}

    public static int RandomRound(float f)
    {
        int floored = Mathf.FloorToInt(f);
        float dec = f - floored;
        float r = UnityEngine.Random.Range(0, 1.0f);
        bool toRoundUp = r < dec;
        int rounded = (toRoundUp) ? floored + 1 : floored;

        return rounded;
    }

    public static int RoundToNearest(float value, int roundTo)
    {
        return roundTo * Mathf.RoundToInt(value / roundTo);
    }

    public static int CeilToNearest(float value, int roundTo)
    {
        return roundTo * Mathf.CeilToInt(value / roundTo);
    }

    public static T RandomFromList<T>(List<T> list)
    {
        return list[UnityEngine.Random.Range(0, list.Count)];
    }

    public static T RemoveRandomFromList<T>(List<T> list)
    {
        int index = UnityEngine.Random.Range(0, list.Count);
        T toReturn = list[index];
        list.RemoveAt(index);

        return toReturn;
    }

    public static float Greater(float f1, float f2)
    {
        return (f1 > f2) ? f1 : f2;
    }

    public static float Lesser(float f1, float f2)
    {
        return (f1 < f2) ? f1 : f2;
    }

    public static bool IsBetween(int target, int lowerBound, int upperBound)
    {
        if(target < lowerBound) return false;
        if(target > upperBound) return false;
        return true;
    }

    public static List<T> ToList<T>(T[] array)
    {
        List<T> toReturn = new List<T>();

        foreach(T t in array)
        {
            toReturn.Add(t);
        }

        return toReturn;
    }

    public static T RandomFromEnum<T>()
    {
        Array values = Enum.GetValues(typeof(T));
        System.Random random = new System.Random();
        T toReturn = (T)values.GetValue(random.Next(values.Length));

        return toReturn;
    }
}

