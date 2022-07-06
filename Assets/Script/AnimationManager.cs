using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{

    Animator animator;
    // Update is called once per frame

    private void Start()
    {
        if(animator==null)
            animator = GetComponent<Animator>();
    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Walking", Mathf.Abs(horizontal) > Mathf.Abs(vertical) ? horizontal : vertical);

    }

    public void setShotTrue()
    {
        animator.SetBool("Shoot", true);
    }

    public void setShotFalse()
    {
        animator.SetBool("Shoot", false);
    }
}
