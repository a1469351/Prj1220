using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    private bool ballIn = true;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        if (!ballIn)
        {
            PlayerController pc = other.GetComponent<PlayerController>();
            if (pc != null)
            {
                pc.Reset();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        ballIn = true;
    }

    private void OnTriggerExit(Collider other)
    {
        ballIn = false;
    }
}
