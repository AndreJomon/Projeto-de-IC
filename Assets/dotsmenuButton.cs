using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dotsmenuButton : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OpenMenu()
    {
        animator.SetBool("menuOn", !animator.GetBool("menuOn"));
    }
}
