using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] GameObject ObjectToFollow;
    [SerializeField] Vector3 Distance;
    [SerializeField] GameObject Torch;
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
        if(Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position,transform.forward,out hit,100))
            {
                Instantiate(Torch, hit.transform);
            }
        }
    }
}
