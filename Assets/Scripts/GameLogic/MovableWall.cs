using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ns;

public class MovableWall : MonoBehaviour
{
    [SerializeField] private bool movable;
    [SerializeField] private bool rotatable;

    private void Awake()
    {
        EventTriggerListener.Get(gameObject).onClick = (go) =>
        {
            if (rotatable)
            {
                Vector3 curAngle = transform.rotation.eulerAngles;
                transform.rotation = Quaternion.Euler(new Vector3(curAngle.x, curAngle.y + 90, curAngle.z));
            }
        };
    }
}
