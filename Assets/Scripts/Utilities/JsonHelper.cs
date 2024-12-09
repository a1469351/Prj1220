using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

/// <summary>
///
/// </summary>

namespace ns
{
    [Serializable]
    public class Wrapper<T>
    {
        public T[] data;
    }
    [Serializable]
    public class Test1
    {
        public string ID;
        public int Value;
    }
    [Serializable]
    public class Test2
    {
        public string ID; // ID
        public int Value; // 值
        public int AnaValue; // 另一个值
        public string Name; // 名字
    }

    public class ConfigBase
    {
        public string ID;
    }
    [Serializable]
    public class Level : ConfigBase
    {
        //public int ID; // 关卡ID
        public string Wave; // 包含波次
    }
    [Serializable]
    public class Wave : ConfigBase
    {
        //public int ID; // 波次ID
        public string Group; // 包含组
        public int Trigger; // 触发方式
    }
    [Serializable]
    public class Group : ConfigBase
    {
        //public int ID; // 组ID
        public string Enemy; // prefab名
        public int Num; // 数量
    }

    public class JsonHelper
	{
        public static T[] GetJsonArray<T>(string json)
        {
            Wrapper<T> t1 = JsonUtility.FromJson<Wrapper<T>>("{\"data\": " + json + "}");
            return t1.data;
        }

        public static T[] GetConfig<T>(string path)
        {
            TextAsset textFile = Resources.Load<TextAsset>(path) as TextAsset;
            if (textFile != null)
            {
                string json = textFile.text;
                if (json.Length > 0)
                {
                    T[] t1 = JsonHelper.GetJsonArray<T>(json);
                    return t1;
                }
            }
            return null;
        }

        [MenuItem("Tools/Test1")]
        private static void TestJson()
        {

            //string path = Application.dataPath + "/Resources/Config/Test2.json";
            TextAsset textFile = Resources.Load<TextAsset>("Config/LevelConfig") as TextAsset;
            if (textFile != null)
            {
                string json = textFile.text;
                if (json.Length > 0)
                {
                    Level[] t1 = JsonHelper.GetJsonArray<Level>(json);
                    foreach (Level t in t1)
                    {
                        Debug.Log(string.Format("ID : {0} Wave : {1} ", t.ID, t.Wave));
                    }
                }
            }
        }
    }
}