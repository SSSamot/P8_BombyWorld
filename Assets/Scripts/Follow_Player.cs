using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Player : MonoBehaviour
{
    [SerializeField] GameObject ObjectToFollow;
    [SerializeField] Vector3 Distance;
    Transform objectTransform;
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        objectTransform = ObjectToFollow.transform;
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = objectTransform.position+ Distance;
    }
}
