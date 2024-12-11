using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ns;

public class Ball : MonoBehaviour
{
    [SerializeField] private Vector3 originPos;
    private Rigidbody rb;
    private System.Action ac;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        ac = () =>
        {
            Reset();
        };
    }

    private void OnEnable()
    {
        EventManager.Instance.RegisterEvent(EventManager.EventEnum.ResetLevel, ac);
    }

    private void OnDisable()
    {
        EventManager.Instance.RemoveEvent(EventManager.EventEnum.ResetLevel, ac);
    }

    public void Reset()
    {
        LevelManager.Instance.running = false;
        transform.position = originPos;
        SetVelocity(Vector3.zero);
    }

    public void SetPos(Vector3 pos)
    {
        transform.position = pos;
    }

    public void SetVelocity(Vector3 v)
    {
        rb.velocity = v;
    }
}
