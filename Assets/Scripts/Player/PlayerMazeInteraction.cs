using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMazeInteraction : MonoBehaviour
{
    [SerializeField] float maxDistance;
    [SerializeField] LayerMask mazeLayerMask;
    [SerializeField] float dialSpeed;
    Transform dial;

    void FixedUpdate ()
    {
        if (Physics.Raycast(transform.position, transform.forward, maxDistance, mazeLayerMask))
        {
            RaycastHit hit;
            Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, mazeLayerMask);

            if (dial != null && hit.collider.gameObject.name != "Maze")
            {
                dial.position = Vector3.Lerp(dial.position, new Vector3(hit.point.x, hit.point.y, dial.position.z), dialSpeed * Time.deltaTime);
            }
            else if (hit.collider.gameObject.name == "Maze")
            {
                if (dial != null)
                {
                    dial.GetComponent<MazeDial>().Reset();
                }
            }
        }
    }

    public void SetDial(Transform dial)
    {
        this.dial = dial;
    }

    public void UnselectDial()
    {
        this.dial = null;
    }
}
