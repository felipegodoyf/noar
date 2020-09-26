using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator[] animators;

    public void Open()
    {
        Debug.Log("Opening door");
        foreach (Animator a in animators)
        {
            a.SetTrigger("Open");
        }
    }
}
