using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinishManager : MonoBehaviour
{

    [SerializeField]
    UnityEvent onFinish;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            GetComponent<Collider>().enabled = false;
            onFinish?.Invoke();
        }
    }


}
