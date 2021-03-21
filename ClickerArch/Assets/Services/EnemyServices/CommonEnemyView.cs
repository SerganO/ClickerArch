using System.Collections;
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
   
    public float coef = 0.85f;

    Vector3 baseTr;

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.color = StartColor;
        baseTr = spriteRenderer.transform.localScale;

        DamageObject = GameObject.FindGameObjectWithTag("DamageTextGenerator").GetComponent<DamageTextGenerator>();
    }

    public void Attack()
    {
        animator.Play("attack");
    }

    public void ConfigureForId(string id)
    {
        //Debug.Log("--=--");
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

    public void Hurt(float ratio, double damage, bool showDamage)
    {
        if(showDamage)
        {
            DamageObject.Generate((int)damage);
        }
        spriteRenderer.color = Color.Lerp(StartColor, FinishColor, 1 - ratio);

        spriteRenderer.transform.localScale = baseTr * coef;
        StartCoroutine(Helper.Wait(0.1f,() => { spriteRenderer.transform.localScale = baseTr; }));
    }
}
