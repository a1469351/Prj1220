using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ns;
using UnityEngine.EventSystems;

public class StartPoint : MonoBehaviour
{
    [SerializeField] private Vector3 ShootVelocity;
    private bool ballIn = true;

    private void Awake()
    {
        EventTriggerListener.Get(gameObject).onClick = (go) =>
        {
            Collider[] cd = Physics.OverlapSphere(transform.position, 3);
            foreach (var c in cd)
            {
                Ball b = c.GetComponent<Ball>();
                if (b != null)
                {
                    b.SetVelocity(ShootVelocity);
                }
            }
        };
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!ballIn)
        {
            Ball b = other.GetComponent<Ball>();
            if (b != null)
            {
                ballIn = true;
                b.SetPos(transform.position);
                b.SetVelocity(Vector3.zero);

                if (LevelManager.Instance.running)
                {
                    LevelManager.Instance.running = false;
                    UIManager.Instance.OpenUI("ClearPopUp");
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Ball b = other.GetComponent<Ball>();
        if (b != null)
        {
            ballIn = false;
            LevelManager.Instance.running = true;
        }
    }
}
