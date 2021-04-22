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
            return model.Effects.FindAll(efc => efc.activationType == Effect.ActivationType.Tick); ;
        }
    }

    List<Effect> OneShotEffects
    {
        get
        {
            return model.Effects.FindAll(efc => efc.activationType == Effect.ActivationType.Immediately); ;
        }
    }


    List<Modificator> TickModificators
    {
        get
        {
            return model.Modificators.FindAll(mod => mod.activationType == Modificator.ActivationType.Tick); ;
        }
    }

    List<Modificator> OneShotModificators
    {
        get
        {
            return model.Modificators.FindAll(mod => mod.activationType == Modificator.ActivationType.Immediately); ;
        }
    }

    double GetValue(Modificator.Parameter parameter)
    {
        switch (parameter)
        {
            case Modificator.Parameter.NONE:
                break;
            case Modificator.Parameter.HP:
                return model.MaximumHealthPoint;
            case Modificator.Parameter.DPC:
                return model.BaseDamage;
            case Modificator.Parameter.DPS:
                break;
            case Modificator.Parameter.Reflect:
                break;
            case Modificator.Parameter.Block:
                break;
            case Modificator.Parameter.CurrentHP:
                return model.CurrentHealthPoint;
            case Modificator.Parameter.CurrentDPC:
                return model.CurrentDamage;
            case Modificator.Parameter.CurrentDPS:
                break;
            case Modificator.Parameter.CurrentReflect:
                break;
            case Modificator.Parameter.CurrentBlock:
                break;
            case Modificator.Parameter.AdditionalXP:
                break;
            case Modificator.Parameter.AdditionalGold:
                break;
            case Modificator.Parameter.EnemyHP:
                break;
            case Modificator.Parameter.HeroDPC:
                return handler.GetCommonParameters(parameter);
            case Modificator.Parameter.Gold:
                break;
        }

        return 0;
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
        double changeValue = 0;

        modificator.values.ForEach(value =>
        {
            switch (value.changeType)
            {
                case Modificator.ChangeValue.ValueChangeType.Const:
                    changeValue += value.value;
                    break;
                case Modificator.ChangeValue.ValueChangeType.Coef:
                    changeValue += GetValue(value.baseParameter) * value.value;
                    break;
            }
        });

        switch (modificator.parameter)
        {
            case Modificator.Parameter.NONE:
                break;
            case Modificator.Parameter.HP:
                model.MaximumHealthPoint += changeValue;
                break;
            case Modificator.Parameter.DPC:
                model.BaseDamage += changeValue;
                break;
            case Modificator.Parameter.DPS:
                break;
            case Modificator.Parameter.Reflect:
                break;
            case Modificator.Parameter.Block:
                break;
            case Modificator.Parameter.CurrentHP:
                if (changeValue < 0)
                {
                    Hurt(changeValue);
                }
                else
                {
                    Heal(changeValue);
                }
                break;
            case Modificator.Parameter.CurrentDPC:
                break;
            case Modificator.Parameter.CurrentDPS:
                break;
            case Modificator.Parameter.CurrentReflect:
                break;
            case Modificator.Parameter.CurrentBlock:
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

        effect.values.ForEach(value =>
        {
            switch (value.changeType)
            {
                case Effect.ChangeValue.ValueChangeType.Const:
                    constPart += value.value;
                    break;
                case Effect.ChangeValue.ValueChangeType.Coef:
                    coefPart += value.value;
                    break;
            }
        });



        switch (effect.type)
        {
            case Effect.Type.NONE:
                break;
            case Effect.Type.ConstDamage:
                Hurt(constPart + coefPart * model.MaximumHealthPoint);
                break;
            case Effect.Type.Heal:
                Heal(constPart + coefPart * model.MaximumHealthPoint);
                break;
            case Effect.Type.Stun:
                isStun = true;
                StartCoroutine(Helper.Wait((float)effect.checker.time, () => { isStun = false; }));
                break;
            case Effect.Type.Color:
                break;
            case Effect.Type.OponentDPCDamage:
                Hurt(constPart + coefPart * GetValue(Modificator.Parameter.HeroDPC));
                break;
        }

        view.ReactOnEffect(effect);

    }

    public void UpdateEffects(double time)
    {

        var tempEfc = model.Effects.FindAll(efc => efc.checker.endCheckType != Effect.CheckObject.EndCheckType.Permanent);
        tempEfc.ForEach(mod => mod.UpdateTime(time));


        var efcsForRemove = model.Effects.FindAll(efc => efc.Check());
        model.RemoveEffects(efcsForRemove);

    }

    public void UpdateModificators(double time)
    {

        var tempMods = model.Modificators.FindAll(mod => mod.checker.endCheckType != Modificator.CheckObject.EndCheckType.Permanent);

        tempMods.ForEach(mod => {
            mod.UpdateTime(time);
        });

        var modsForRemove = model.Modificators.FindAll(mod => mod.Check());
        model.RemoveModificators(modsForRemove);

    }

    private void OnDestroy()
    {
        model.OnDestroyClear();
        StopAllCoroutines();
    }

}
