using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuChange : MonoBehaviour
{
    public Animator animator;

    public void ChangeMenu()
    {
        animator.SetTrigger("BumpDown");
    }
}
