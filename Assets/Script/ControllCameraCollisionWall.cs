using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllCameraCollisionWall : MonoBehaviour
{

    float initDistance;
    [SerializeField]
    float radiusSphere=0.3f;

    [SerializeField]
    bool debug=false;

    public Transform ipoteticalPositionCamera;
    public Transform camera;
    Vector3 startCameraOffset;

    // Start is called before the first frame update
    void Start()
    {
        if (camera == null)
            camera = Camera.main.transform;

        startCameraOffset = camera.localPosition;

        initDistance = camera.localPosition.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posCameraIpotetical = camera.rotation * startCameraOffset;

        RaycastHit hit;


        if (Physics.SphereCast(new Ray(transform.position, posCameraIpotetical), radiusSphere, out hit, initDistance))
        {
            
            camera.position = transform.position + posCameraIpotetical.normalized * hit.distance;
            if(debug)
            Debug.Log("the camera collided with: "+hit.collider.gameObject.name);
        }
        else
            camera.position=ipoteticalPositionCamera.position;
        //Vector3 posCameraWithoutWall = camera.rotation * ipoteticalPositionCamera.position;

        Debug.DrawRay(transform.position- (transform.rotation * camera.localPosition).normalized, transform.rotation *  camera.localPosition);
		//transform.rotation = target.rotation;
    }
}
