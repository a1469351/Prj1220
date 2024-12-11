using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private Color EnterColor;
    [SerializeField] private Color ExitColor;
    [SerializeField] private Vector3 ExitVelocity;

    GameObject enter;
    GameObject exit;

    private void OnTriggerEnter(Collider other)
    {
        Ball b = other.GetComponent<Ball>();
        if (b != null)
        {
            b.SetPos(exit.transform.position);
            b.SetVelocity(ExitVelocity);
        }
    }

    private void ChangeColor()
    {
        ChangeMaterialColor(enter, EnterColor);
        ChangeMaterialColor(exit, ExitColor);
    }

    private void ChangeMaterialColor(GameObject go, Color c)
    {
        Renderer rd = go.GetComponent<Renderer>();
        MaterialPropertyBlock newBlock = new MaterialPropertyBlock();
        rd.GetPropertyBlock(newBlock);
        newBlock.SetColor("_Color", c);
        rd.SetPropertyBlock(newBlock);
    }

    private void OnValidate()
    {
        if (enter == null) enter = gameObject;
        if (exit == null) exit = transform.Find("PortalExit").gameObject;
        ChangeColor();
    }
}
