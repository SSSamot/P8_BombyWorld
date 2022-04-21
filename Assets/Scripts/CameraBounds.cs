using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraBounds : MonoBehaviour
{
    private Camera _camera;
    Vector4 _xzCameraBounds;

    void Start()
    {
        _camera = GetComponent<Camera>();

        _xzCameraBounds = new Vector4(_camera.transform.position.x - _camera.orthographicSize,  // min X
                                     _camera.transform.position.x + _camera.orthographicSize,   // max X
                                     _camera.transform.position.z - _camera.orthographicSize,   // min Z
                                     _camera.transform.position.z + _camera.orthographicSize);  // max Z

        Shader.SetGlobalVector("_XZ_CameraBounds", _xzCameraBounds);
    }

    private void OnDrawGizmos()
    {
        if (_camera == null)
            return;

        Gizmos.color = Color.red;

        Vector3 pos = _camera.transform.position - new Vector3(_camera.orthographicSize, 0f, 0f);
        Gizmos.DrawWireSphere(pos, 0.3f);

        pos = _camera.transform.position + new Vector3(_camera.orthographicSize, 0f, 0f);
        Gizmos.DrawWireSphere(pos, 0.3f);

        pos = _camera.transform.position - new Vector3(0f, 0f, _camera.orthographicSize);
        Gizmos.DrawWireSphere(pos, 0.3f);

        pos = _camera.transform.position + new Vector3(0f, 0f, _camera.orthographicSize);
        Gizmos.DrawWireSphere(pos, 0.3f);
    }
}
