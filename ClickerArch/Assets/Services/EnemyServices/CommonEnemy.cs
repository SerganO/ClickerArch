using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CommonEnemy : IEnemy
{
    double TICK_TIME = 1.0;
    double tick = 0;

    IEnemyModel model;
    IEnemyView view;

    List<Effect> TickEffects
    {
        get
        {
            return model.Effects.FindAll(efc => efc.activationType == EffectActivationType.Tick); ;
        }
    }

    List<Effect> OneShotEffects
    {
        get
        {
            return model.Effects.FindAll(efc => efc.activationType == EffectActivationType.OneShot); ;
        }
    }


    double timer = 0;

    bool isDie = false;
    bool isStun = false;

    public override event VoidFunc onDie;

    private void Start()
    {
        model = new CommonEnemyModel();
        view = GetComponent<IEnemyView>();
        view.ConfigureForId(ID);
        ConfigureForLevel(1);


    }

    private void Update()
    {
        if (isDie || isStun)
        {
            return;

        }
        timer += Time.deltaTime;

        if(timer >= model.DurationBetweenAttack)
        {
            timer -= model.DurationBetweenAttack;
            Attack();
        }

        UpdateOnTick(Time.deltaTime);

    }

    public void UpdateOnTick(double time)
    {
        Debug.LogWarning("ENEMYTICK: " + model.Id + " " + model.Effects.Count);
        model.Effects.ForEach(efc => Debug.LogWarning(efc));
        ReactOnEffects(OneShotEffects);


        tick += time;
        if (tick >= TICK_TIME)
        {
            tick -= TICK_TIME;
            ReactOnEffects(TickEffects);
        }

        UpdateEffects(time);
    }


    public override IEnemyModel GetEnemyModel()
    {
        return model;
    }

    public override IEnemyView GetEnemyView()
    {
        return view;
    }

    public override void ConfigureForLevel(int level)
    {
        model.ConfigureForIdAndLevel(ID, level);
    }

    public override void Idle()
    {

    }

    public override void Attack()
    {
        if (isDie) return;
        Services.GetInstance().GetHeroService().Hero.Hurt(model.Damage);
        view.Attack();
    }

    public override void Death()
    {
        if (isDie) return;
        isDie = true;
        view.Death();
        StartCoroutine(Helper.Wait(0.67f, () => {
            onDie();
            Destroy(gameObject);
        }));
    }

    public override void Hurt(double damage, bool isManualDamage = true)
    {
        if (isDie) return;
        model.CurrentHealthPoint -= damage;
        float ratio = (float)(model.CurrentHealthPoint / model.MaximumHealthPoint);
        view.Hurt(ratio, damage, isManualDamage);
        if (model.CurrentHealthPoint <= 0)
        {
            Death();
        }
    }

    public override void Heal(double value)
    {
        if (isDie) return;
        model.CurrentHealthPoint = Mathf.Min((float)model.MaximumHealthPoint, (float)(model.CurrentHealthPoint + value));
        float ratio = (float)(model.CurrentHealthPoint / model.MaximumHealthPoint);
        view.UpdateRatio(ratio);
    }


    public void ReactOnEffects(List<Effect> effects)
    {
        Debug.Log("Effects: " + effects.Count);
        effects.ForEach(efc => Debug.Log(efc));
        effects.ForEach(efc => ReactOnEffect(efc));
    }

    public void ReactOnEffect(Effect effect)
    {
        double constPart = 0;
        double coefPart = 0;

        switch (effect.changeType)
        {
            case EffectValueChangeType.Const:
                constPart += effect.value;
                break;
            case EffectValueChangeType.Coef:
                coefPart += effect.value;
                break;
            case EffectValueChangeType.AddConst:
                break;
            case EffectValueChangeType.AddCoef:
                break;
        }


        switch (effect.parameter)
        {
            case EffectType.Damage:
                Hurt(constPart + coefPart * model.MaximumHealthPoint);
                break;
            case EffectType.Heal:
                Heal(constPart + coefPart * model.MaximumHealthPoint);
                break;
            case EffectType.Stun:
                isStun = true;
                StartCoroutine(Helper.Wait((float)effect.time, () => { isStun = false; }));
                
                break;
        }

        view.ReactOnEffect(effect);

    }

    public void UpdateEffects(double time)
    {

        var tempEfc = model.Effects.FindAll(efc => efc.endType != EffectEndType.Permanent);
        tempEfc.ForEach(mod => mod.time -= time);


        var efcsForRemove = model.Effects.FindAll(efc => efc.Check());
        model.RemoveEffects(efcsForRemove);

    }

    private void OnDestroy()
    {
        model.OnDestroyClear();
        StopAllCoroutines();
    }

}
