using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform playerTransform;
    public float smoothSpeed = 0.125f; 
    public Vector3 offset;            

    private void LateUpdate()
    {
        if (playerTransform == null) return;

        Vector3 desiredPosition = playerTransform.position + offset;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }
}
