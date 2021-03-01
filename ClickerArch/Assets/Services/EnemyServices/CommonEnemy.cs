using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CommonEnemy : IEnemy
{
    
    public string ID;
    IEnemyModel model;
    IEnemyView view;


    double timer = 0;
    //double mockTimer = 0;

    bool isDie = false;

    public event VoidFunc onDie;

    private void Start()
    {
        model = new CommonEnemyModel();
        view = GetComponent<IEnemyView>();
        view.ConfigureForId(ID);
        ConfigureForLevel(1);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        //mockTimer += Time.deltaTime;

        //if(mockTimer >= 0.1)
        //{
        //    mockTimer -= 0.1;
        //    Hurt(3);
        //}

        if(timer >= model.DurationBetweenAttack)
        {
            timer -= model.DurationBetweenAttack;
            Attack();
        }

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
        Services.GetInstance().GetHero().Hurt(model.Damage);
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

    public override void Hurt(int damage, bool isManualDamage = true)
    {
        if (isDie) return;
        model.CurrentHealthPoint -= damage;
        if (model.CurrentHealthPoint <= 0)
        {
            Death();
        }
        else
        {
            float ratio = (float)model.CurrentHealthPoint / model.MaximumHealthPoint;
            view.Hurt(ratio, damage, isManualDamage);
        }
    }
}
