﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class CommonEnemyView : MonoBehaviour, IEnemyView
{

    Animator animator;
    SpriteRenderer spriteRenderer;

    [Header("Hurt")]
    public Color StartColor;
    public Color FinishColor;

    public DamageTextGenerator DamageObject;

    [Header("Death")]
    public GameObject DeathObject;

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.color = StartColor;
    }

    public void Attack()
    {
        animator.Play("attack");
    }

    public void ConfigureForId(string id)
    {
        Debug.Log("--=--");
    }

    public void Death()
    {
        Instantiate(DeathObject, gameObject.transform.parent);
        spriteRenderer.color = new Color(0, 0, 0, 0);
    }

    public void Idle()
    {
        animator.Play("idle");
    }

    public void Hurt(float ratio, int damage, bool showDamage)
    {
        if(showDamage)
        {
            DamageObject.Generate(damage);
        }
        spriteRenderer.color = Color.Lerp(StartColor, FinishColor, 1 - ratio);
    }
}
