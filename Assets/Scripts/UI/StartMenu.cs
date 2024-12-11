using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ns;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject levelMenu;

    private void Awake()
    {
        EventTriggerListener.Get(startMenu).onClick = (go) =>
        {
            startMenu.SetActive(false);
        };

        EventTriggerListener.Get(levelMenu.transform.Find("Button1").gameObject).onClick = (go) =>
        {
            LevelManager.Instance.EnterLevel(0);
        };

        EventTriggerListener.Get(levelMenu.transform.Find("Button2").gameObject).onClick = (go) =>
        {
            LevelManager.Instance.EnterLevel(1);
        };
    }

    private void Start()
    {
        if (!LevelManager.Instance.firstEnter)
        {
            startMenu.SetActive(false);
        }
    }
}
