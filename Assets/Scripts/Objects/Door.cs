using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator[] animators;
    bool opened = false;

    public void Open()
    {
        if (opened) return;
        opened = true;
        Debug.Log("Opening door");
        foreach (Animator a in animators)
        {
            a.SetTrigger("Open");
        }
        AudioManager.instance.PlaySound("Door_Open", animators[0].gameObject.transform.position);
    }

    public void Close()
    {
        if (!opened) return;
        opened = false;
        Debug.Log("Closing door");
        foreach (Animator a in animators)
        {
            a.SetTrigger("Close");
        }
        AudioManager.instance.PlaySound("Door_Open", animators[0].gameObject.transform.position);
    }
}
