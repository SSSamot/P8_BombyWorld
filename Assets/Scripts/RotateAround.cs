using UnityEngine;

//[ExecuteInEditMode]
public class RotateAround : MonoBehaviour
{
    public Transform Target;
    public Vector3 Axis;

    [Range(0f, 60f)]
    public float Speed = 10f;

    void Update()
    {
        if (Target == null)
            return;

        transform.RotateAround(Target.position, Axis.normalized, Time.deltaTime * Speed);
    }
}
