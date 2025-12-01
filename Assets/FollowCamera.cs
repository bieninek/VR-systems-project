using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 5, -10);

    public float smoothSpeed = 0.05f;

    public bool useLookAt = true;
    public Vector3 lookAtOffset;   

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition =
            Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;

        if (useLookAt)
        {
            Vector3 lookTarget = target.position + lookAtOffset;
            transform.LookAt(lookTarget);
        }
    }
}
