using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class StaticValue : MonoBehaviour
{
    public static StaticValue Instance;
    public  string enterName;
    public  string bestName;
    public  int bestScore;

    private void Awake()//将gameobject进行场景持久化处理
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void CompareScore(string name,int score)//比较分数
    {
        if (score > bestScore)
        {
            Instance.bestName = name;
            Instance.bestScore = score;
        }
    }

    public string updateBestScore()//更新最高分数
    {
        if (Instance.bestName=="")
        {
            Debug.Log("最好的名字为空");
            return "Best Score : No Record";
        }
        else
        {
            Debug.Log("最好的名字不为空");
            return $"Best Score : {bestName} : {bestScore}";
        }
    }
    
    [System.Serializable]
    class Data
    {
        public  string enterName;
        public  string bestName;
        public  int bestScore;
    }//游戏数据类

    public void SaveData()//保存数据
    {
        Data data = new Data();
        data.enterName = enterName;
        data.bestName = bestName;
        data.bestScore = bestScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath+"savefile.json",json);
    }

    public bool LoadData()//返回是否有存档并加载数据
    {
        string path = Application.persistentDataPath + "savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Data data = JsonUtility.FromJson<Data>(json);
            enterName = data.enterName;
            bestName = data.bestName;
            bestScore = data.bestScore;
            return true;
        }

        return false;
    }
}
