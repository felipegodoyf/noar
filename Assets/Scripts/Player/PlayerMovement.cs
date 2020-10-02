using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float maxDistance;
    [SerializeField] LayerMask groundLayerMask;
    [SerializeField] Transform playerRoot;
    [SerializeField] float smoothTime;
    [SerializeField] Transform feetIcon;
    [SerializeField] float feetIconRotationSpeed;
    Vector3 currentVelocity;
    Vector3 targetPosition;
    Transform feetIconRotationPlaceholder;

    void Start()
    {
        targetPosition = playerRoot.position;
        feetIconRotationPlaceholder = new GameObject("FeetIconRotationPlaceholder").transform;
    }

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, maxDistance, groundLayerMask))
        {
            RaycastHit hit;
            Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, groundLayerMask);

            if (hit.collider.gameObject.layer == 8)
            {
                feetIcon.gameObject.GetComponent<Animator>().SetTrigger("Enable");
                feetIcon.position = hit.point;
                feetIconRotationPlaceholder.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
                feetIcon.rotation = Quaternion.Slerp(feetIcon.rotation, feetIconRotationPlaceholder.rotation, feetIconRotationSpeed * Time.deltaTime);

                if (Input.anyKeyDown)
                {
                    targetPosition = new Vector3(hit.point.x, playerRoot.position.y, hit.point.z);
                }
            }
            else
            {
                feetIcon.gameObject.GetComponent<Animator>().SetTrigger("Disable");
            }

        }
        else
        {
            feetIcon.gameObject.GetComponent<Animator>().SetTrigger("Disable");
        }

        playerRoot.position = Vector3.SmoothDamp(playerRoot.position,
                                               targetPosition,
                                               ref currentVelocity,
                                               smoothTime);
    }
}
