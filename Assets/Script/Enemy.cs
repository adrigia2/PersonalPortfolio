using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float damage = 5;

    GameObject player;
    Health health;
    [SerializeField]
    float rateAttack = 0.2f;

    [SerializeField]
    float distance = 2;


    bool start = false;

    private void Start()
    {
        health = player.GetComponent<Health>();
    }

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, player.transform.position-transform.position);

        if (Physics.Raycast(ray, out hit, distance))
        {
            if (hit.collider.gameObject.tag == "Player" && !start)
            {
                InvokeRepeating("makeDamage", 0, rateAttack);
                start = true;
            }
        }
        else
        {
            start = false;
            CancelInvoke("makeDamage");
        }
    }

    void makeDamage()
    {
        Debug.Log("sono quiiiii");
        health.TakeDamage(damage);
    }


}
