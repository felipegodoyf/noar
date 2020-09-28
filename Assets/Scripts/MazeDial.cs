using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MazeDial : MonoBehaviour
{
    [SerializeField] PlayerMazeInteraction playerMazeInteraction;
    [SerializeField] UnityEvent successEvent;
    Vector3 startPosition;

    void Start ()
    {
        startPosition = transform.position;
    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.name == "Maze")
        {
            transform.position = startPosition;
            playerMazeInteraction.UnselectDial();
            Debug.Log("Resetting dial");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "MazeGoal")
        {
            this.gameObject.SetActive(false);
            successEvent.Invoke();
        }
    }

    public void SelectDial()
    {
        playerMazeInteraction.SetDial(transform);
    }

    public void UnselectDial()
    {
        playerMazeInteraction.UnselectDial();
    }
}
