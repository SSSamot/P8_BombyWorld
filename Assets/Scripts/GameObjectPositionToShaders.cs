using UnityEngine;

[ExecuteInEditMode]
public class GameObjectPositionToShaders : MonoBehaviour
{
    string _positionRefName = string.Empty;
    string _forwardRefName = string.Empty;

    private void Start()
    {
        _positionRefName = "WorldPos_" + gameObject.name;
        _forwardRefName = "Forward_" + gameObject.name;
    }

    void Update()
    {
        Shader.SetGlobalVector(_positionRefName, transform.position);
        Shader.SetGlobalVector(_forwardRefName, transform.forward);
    }
}
