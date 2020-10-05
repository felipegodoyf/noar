using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeDoor : MonoBehaviour
{
    public Transform keyPosition;

    void OnTriggerStay(Collider other)
    {
        if (other.name == "Key")
        {
            other.transform.SetParent(keyPosition);
            other.transform.localPosition = Vector3.zero;
            other.transform.localRotation = Quaternion.identity;
            other.gameObject.GetComponent<Animator>().enabled = false;
            foreach (SimpleRotation s in other.gameObject.GetComponentsInChildren<SimpleRotation>())
            {
                s.enabled = false;
            }
            foreach (FakeBillboard f in other.gameObject.GetComponentsInChildren<FakeBillboard>())
            {
                f.gameObject.SetActive(false);
            }
            GetComponent<Animator>().SetTrigger("Open");
            this.enabled = false;
        }
    }
}
