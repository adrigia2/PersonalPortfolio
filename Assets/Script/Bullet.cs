using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage = 5;


    public delegate void Action();
    public event Action onHitSurface;




    private void OnCollisionEnter(Collision collision)
    {
        Health health;
        if (collision.gameObject.TryGetComponent<Health>(out health))
        {
            health.TakeDamage(damage);
        }

        GetComponent<Rigidbody>().isKinematic = true;
        Invoke("DestroyBullet", 1);//this will happen after 2 seconds
        onHitSurface?.Invoke();
        //Destroy(this.gameObject);
        gameObject.transform.rotation = Quaternion.Euler(collision.contacts[0].normal);

        MeshRenderer mr = gameObject.GetComponent<MeshRenderer>();
        mr.enabled = false;
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
