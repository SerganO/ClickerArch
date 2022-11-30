using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuHeroClick : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        animator.Play("attack");
    }
}
