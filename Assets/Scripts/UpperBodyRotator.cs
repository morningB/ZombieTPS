using UnityEngine;

public class UpperBodyRotator : MonoBehaviour
{
    public Transform upperBodyBone; // 예: Spine_02
    public float rotateSpeed = 10f;

    void LateUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            Vector3 direction = hit.point - upperBodyBone.position;

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            upperBodyBone.rotation = Quaternion.Slerp(
                upperBodyBone.rotation, targetRotation, Time.deltaTime * rotateSpeed
            );
        }
    }
}
