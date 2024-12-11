using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ns;

public class LevelManager : SingletonBase<LevelManager>
{
    public bool firstEnter = true;
    public bool running = true;
    public int curLevel = 0;
    public string[] levelName =
    {
        "Level1",
        "Level2"
    };
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    public void EnterLevel(string levelScene)
    {
        firstEnter = false;
        SceneManager.LoadSceneAsync(levelScene);
    }

    public void EnterLevel(int lvlIndex)
    {
        if (lvlIndex >= levelName.Length)
        {
            EnterLevel("StartScene");
            return;
        }
        firstEnter = false;
        curLevel = lvlIndex;
        SceneManager.LoadSceneAsync(levelName[lvlIndex]);
    }
}
