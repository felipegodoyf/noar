using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeBillboard : MonoBehaviour
{
    private Transform camera;

    void Start ()
    {
        camera = Camera.main.transform;
    }

    void LateUpdate ()
    {
        transform.LookAt(camera);
    }
}
