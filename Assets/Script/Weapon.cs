using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;

    [SerializeField]
    UnityEvent onShotEvent;

    [SerializeField]
    Transform startingPoint;

    [SerializeField]
    float bulletForce;


    public void onShot()
    {
        onShotEvent?.Invoke();

        RaycastHit hit;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Vector3 direction;
        if (Physics.Raycast(ray, out hit))
        {
            direction = (hit.point - startingPoint.position).normalized;
        }
        else
            direction = transform.TransformDirection(Vector3.forward);


        GameObject currentBullet = Instantiate(bullet, startingPoint.position, Quaternion.identity);
        var rb = currentBullet.GetComponent<Rigidbody>();
        rb.AddForce(direction * bulletForce, ForceMode.Impulse);
    }
}
