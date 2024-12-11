using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ns;

public class BackTitle : MonoBehaviour
{
    public void Awake()
    {
        EventTriggerListener.Get(transform.Find("Back").gameObject).onClick = (go) =>
        {
            LevelManager.Instance.EnterLevel("StartScene");
        };

        EventTriggerListener.Get(transform.Find("Reset").gameObject).onClick = (go) =>
        {
            EventManager.Instance.SendEvent(EventManager.EventEnum.ResetLevel);
        };
    }
}
