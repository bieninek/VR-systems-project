using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 5, -10);
    public float smoothSpeed = 0.1f;

    public bool useLookAt = true;
    public Vector3 lookAtOffset;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.TransformPoint(offset);
        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed
        );

        if (useLookAt)
        {
            transform.LookAt(target.position + lookAtOffset);
        }
    }
}
