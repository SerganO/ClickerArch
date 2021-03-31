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


    List<Modificator> TickModificators
    {
        get
        {
            return model.Modificators.FindAll(mod => mod.activationType == ModificatorActivationType.Tick); ;
        }
    }

    List<Modificator> OneShotModificators
    {
        get
        {
            return model.Modificators.FindAll(mod => mod.activationType == ModificatorActivationType.OneShot); ;
        }
    }


    double timer = 0;

    bool isDie = false;
    bool isStun = false;

    public override event VoidFunc onDie;

    private void Awake()
    {
        model = new CommonEnemyModel();
        view = GetComponent<IEnemyView>();
    }

    private void Start()
    {
        
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
        ReactOnEffects(OneShotEffects);
        ReactOnModificators(OneShotModificators);


        tick += time;
        if (tick >= TICK_TIME)
        {
            tick -= TICK_TIME;
            ReactOnEffects(TickEffects);
            ReactOnModificators(TickModificators);
        }

        UpdateEffects(time);
        UpdateModificators(time);
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
        Services.GetInstance().GetHeroService().Hero.Hurt(model.CurrentDamage);
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

    public void ReactOnModificators(List<Modificator> modificators)
    {
        modificators.ForEach(mod => Debug.Log(mod));
        modificators.ForEach(mod => ReactOnModificator(mod));
    }

    public void ReactOnModificator(Modificator modificator)
    {
        double constPart = 0;
        double coefPart = 0;

        switch (modificator.changeType)
        {
            case ModificatorValueChangeType.Const:
                constPart += modificator.value;
                break;
            case ModificatorValueChangeType.Coef:
                coefPart += modificator.value;
                break;
            case ModificatorValueChangeType.AddConst:
                break;
            case ModificatorValueChangeType.AddCoef:
                break;
        }

        switch (modificator.valueType)
        {
            case ModificatorValueType.Base:
                switch (modificator.parameter)
                {
                    case ModificatorParameter.HP:
                        model.MaximumHealthPoint += constPart + model.MaximumHealthPoint * coefPart;
                        break;
                    case ModificatorParameter.DPC:
                        model.BaseDamage += constPart + model.BaseDamage * coefPart;
                        break;
                    case ModificatorParameter.DPS:
                        break;
                    case ModificatorParameter.Reflect:
                        break;
                    case ModificatorParameter.Block:
                        break;
                }
                break;
            case ModificatorValueType.Current:
                switch (modificator.parameter)
                {
                    case ModificatorParameter.HP:
                        var change = constPart + model.CurrentHealthPoint * coefPart;
                        Debug.Log("HP: " + change);
                        if (change < 0)
                        {
                            Hurt(change);
                        }
                        else
                        {
                            Heal(change);
                        }
                        break;
                    case ModificatorParameter.DPC:
                        break;
                    case ModificatorParameter.DPS:
                        break;
                    case ModificatorParameter.Reflect:
                        break;
                    case ModificatorParameter.Block:
                        break;
                }
                break;
        }
    }


    public void ReactOnEffects(List<Effect> effects)
    {
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
            case EffectType.Color:
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

    public void UpdateModificators(double time)
    {

        var tempMods = model.Modificators.FindAll(mod => mod.endType != ModificatorEndType.Permanent);
        tempMods.ForEach(mod => mod.time -= time);


        var modsForRemove = model.Modificators.FindAll(mod => mod.Check());
        model.RemoveModificators(modsForRemove);


    }

    private void OnDestroy()
    {
        model.OnDestroyClear();
        StopAllCoroutines();
    }

}
