using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetection : MonoBehaviour
{
    [SerializeField] Door door;

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "PuzzleArea")
        {
            door.Close();
        }
    }
}
