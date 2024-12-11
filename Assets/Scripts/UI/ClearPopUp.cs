using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ns;

public class ClearPopUp : UIPanel
{
    private void Awake()
    {
        EventTriggerListener.Get(transform.Find("BtnBack").gameObject).onClick = (go) =>
        {
            LevelManager.Instance.EnterLevel("StartScene");
            UIManager.Instance.CloseUI("ClearPopUp");
        };

        EventTriggerListener.Get(transform.Find("BtnNext").gameObject).onClick = (go) =>
        {
            LevelManager.Instance.EnterLevel(LevelManager.Instance.curLevel + 1);
            UIManager.Instance.CloseUI("ClearPopUp");
        };
    }
}
