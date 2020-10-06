using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeShine : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "RedButton_Barrier")
        {
            other.gameObject.GetComponent<Animator>().SetTrigger("Open");
        }
    }
}
