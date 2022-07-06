using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponManager : MonoBehaviour
{
    bool haveWeapon;

    [SerializeField]
    Animator animator;

    [SerializeField]
    Transform weaponPosition;
    // Start is called before the first frame update

    [SerializeField]
    UnityEvent onPlayerFire;

    [SerializeField]
    float Range = 5f;

    [SerializeField]
    Camera cam;

    GameObject _weapon;

    [SerializeField]
    string weaponTag = "Weapon";
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !haveWeapon)
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Range))
            {
                Debug.Log(hit.collider.name);
                if (hit.collider.gameObject.tag == weaponTag)
                {
                    haveWeapon = true;

                    _weapon = hit.collider.gameObject;

                    _weapon.transform.parent = weaponPosition;
                    _weapon.transform.localPosition = Vector3.zero;

                    _weapon.GetComponent<Collider>().enabled = false;

                    Rigidbody rb = _weapon.GetComponent<Rigidbody>();

                    rb.isKinematic = true;

                    _weapon.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);

                }
            }
        }

        if (haveWeapon && Input.GetKeyDown(KeyCode.F))
        {
            _weapon.transform.parent = null;
            _weapon.GetComponent<Collider>().enabled = true;

            _weapon.GetComponent<Rigidbody>().isKinematic = false;

            haveWeapon = false;
        }

        if (Input.GetButtonDown("Fire1") && haveWeapon && !animator.GetBool("Shoot"))
        {
            Weapon weaponScript = _weapon.GetComponent<Weapon>();
            weaponScript.onShot();

            onPlayerFire?.Invoke();
        
            
        }


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)));
    }




}
