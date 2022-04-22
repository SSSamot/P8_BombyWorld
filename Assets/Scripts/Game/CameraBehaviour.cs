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
        cam.cullingMatrix = Matrix4x4.Ortho(-99999, 99999, -99999, 99999, 0.001f, 99999) *
                             Matrix4x4.Translate(Vector3.forward * -99999 / 2f) *
                             cam.worldToCameraMatrix;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = objectTransform.position+ Distance;
        transform.LookAt(objectTransform);
        if(Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position,transform.forward,out hit,100))
            {
                Instantiate(Torch, hit.transform);
            }
        }
    }
    void OnDisable()
    {
        cam.ResetCullingMatrix();
    }
}
