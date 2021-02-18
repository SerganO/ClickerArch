using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonEnemy : MonoBehaviour, IEnemy
{
    public string ID;
    IEnemyModel model;
    IEnemyView view;


    private void Start()
    {
        model = new CommonEnemyModel();
        view = GetComponent<IEnemyView>();
        view.ConfigureForId(ID);

        ConfigureForLevel(1);
    }

    double timer = 0;

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer >= model.GetDurationBetweenAttack())
        {
            Debug.Log("aaa");
            timer -= model.GetDurationBetweenAttack();
            view.Attack();
        }

    }


    public IEnemyModel GetEnemyModel()
    {
        return model;
    }

    public IEnemyView GetEnemyView()
    {
        return view;
    }

    public void ConfigureForLevel(int level)
    {
        model.ConfigureForIdAndLevel(ID, level);
    }
}
