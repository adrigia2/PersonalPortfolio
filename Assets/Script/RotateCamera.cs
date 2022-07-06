using UnityEngine;


public class RotateCamera : MonoBehaviour
{

    public Transform cameraObject;

    public float Sensitivity;

    [Range(0.1f, 9f)][SerializeField] float sensitivity = 2f;
    [Range(0f, 90f)][SerializeField] float yRotationLimit = 88f;

    Vector2 rotation = Vector2.zero;

    void Update()
    {
        rotation.x += Input.GetAxis("Mouse X") * sensitivity;
        rotation.y += Input.GetAxis("Mouse Y") * sensitivity;
        rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);

        var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
        var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);

        cameraObject.transform.localRotation = xQuat * yQuat;

        cameraObject.transform.localRotation = Quaternion.Euler(cameraObject.transform.localRotation.eulerAngles - transform.rotation.eulerAngles);

    }
}