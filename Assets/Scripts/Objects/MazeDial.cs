using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MazeDial : MonoBehaviour
{
    [SerializeField] PlayerMazeInteraction playerMazeInteraction;
    [SerializeField] UnityEvent successEvent;
    Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        GetComponent<Rigidbody>().sleepThreshold = 0;
    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.name == "Maze")
        {
            Reset();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "MazeGoal")
        {
            this.gameObject.SetActive(false);
            successEvent.Invoke();
            AudioManager.instance.PlaySound("Maze_Finish", transform.position);
        }
    }

    public void Reset()
    {
        transform.position = startPosition;
        playerMazeInteraction.UnselectDial();
        Debug.Log("Resetting dial");
        AudioManager.instance.PlaySound("Maze_Wrong", transform.position);
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
