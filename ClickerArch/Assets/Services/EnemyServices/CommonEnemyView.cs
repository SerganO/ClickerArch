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

    Color CurrentEndColor;

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

        CurrentEndColor = FinishColor;
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
        if (showDamage)
        {
            DamageObject.Generate(Helper.RedText(string.Format("{0:0.###}", damage)));
        }
        UpdateRatio(ratio);
    }

    public void UpdateRatio(float ratio)
    {
        if (spriteRenderer == null) return;
        spriteRenderer.color = Color.Lerp(StartColor, CurrentEndColor, 1 - ratio);

        spriteRenderer.transform.localScale = baseTr * coef;
        StartCoroutine(Helper.Wait(0.1f, () => { spriteRenderer.transform.localScale = baseTr; }));
    }

    IEnumerator colorEnumerator = null;
    IEnumerator stunEnumerator = null;

    public void ReactOnEffect(Effect effect)
    {
        if (effect.additionalParametrs.ContainsKey("color"))
        {
            //Debug.LogWarning("-=COLOR");
            Color color;
            if (ColorUtility.TryParseHtmlString(effect.additionalParametrs["color"], out color))
                CurrentEndColor = color;

            //Debug.LogWarning("-=" + color);

            if (colorEnumerator != null) StopCoroutine(colorEnumerator);
            colorEnumerator = Helper.Wait((float)effect.checker.time, () => { CurrentEndColor = FinishColor; });
            StartCoroutine(colorEnumerator);            
        }

        switch (effect.type)
        {
            case Effect.Type.ConstDamage:
                break;
            case Effect.Type.Heal:
                break;
            case Effect.Type.Stun:
                if (stunEnumerator != null) StopCoroutine(stunEnumerator);
                GetComponent<Animator>().speed = 0;
                stunEnumerator = Helper.Wait((float)effect.checker.time, () => { GetComponent<Animator>().speed = 1;  });
                StartCoroutine(stunEnumerator);
                break;
        }

    }



    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
