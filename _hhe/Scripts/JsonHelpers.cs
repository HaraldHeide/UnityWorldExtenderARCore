/*
 * get from webAPI
 *  https://www.youtube.com/watch?v=9rPJeRF7S_8
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonHelpers
{
    //YouObject[] objects = JsonHelper.getJsonArray<YouObject> (jsonString);
    public static T[] getjsonArray<T>(string json)
    {
        string newJson = "{ \"array\": " + json + "}";
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);
        return wrapper.array;
    }


    public static string arrayToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.array = array;
        return JsonUtility.ToJson(wrapper);
    }


    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] array;
    }

}

[System.Serializable]
public class RootObject
{
    public int Id;
    public string Location;
    public string Name;
    public double X;
    public double Y;
    public double Z;
    public string Type;
    public double Temperature;
    public double Humidity;
    public double Pressure;
}

//[System.Serializable]
//public class DevicesList
//{
//    public List<RootObject> Devices;
//}
