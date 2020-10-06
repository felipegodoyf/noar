using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeDoor : MonoBehaviour
{
    public Transform keyPosition;
    bool locked = true;

    void OnTriggerStay(Collider other)
    {
        if (locked)
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
                AudioManager.instance.PlaySound("MazeDoor_Open", transform.position);
                this.enabled = false;
                locked = false;
            }
        }
    }
}
