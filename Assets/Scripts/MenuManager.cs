using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{
    public InputField inputNameField;
    public Text bestScore;
    private void Start()
    {
        Init();//调用初始化方法
    }

    public void Init()//信息的初始化
    {
        if (StaticValue.Instance.LoadData())
        {
            bestScore.text = StaticValue.Instance.updateBestScore();
            inputNameField.text = StaticValue.Instance.enterName;
        }
    }

    //变量
    public void StartButton()//点击Start按钮，加载main场景
    {
        SceneManager.LoadScene(1);
    }

    public void QuitButton()//点击Quit按钮，关闭应用程序
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void NameChanged()//输入框名字更改,将结束编辑的name赋值给静态变量
    {
        StaticValue.Instance.enterName = inputNameField.text;
    }
}
