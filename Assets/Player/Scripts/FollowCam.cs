using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FollowCam : MonoBehaviour
{
    [Header("Object to follow")]
    public Transform target;

    // Link to camera
    private Camera cam;

    // Start is called before the first frame update
    void Awake()
    {
        cam = GetComponent<Camera>();

        if (target == null)
            enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = target.position;
        pos.z -= 10;
        transform.position = pos;
    }
} // class FollowCam
