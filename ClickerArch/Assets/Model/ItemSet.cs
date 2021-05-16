using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSet
{

    public string id = "";
    public List<Modificator> Modificators = new List<Modificator>();
    public List<string> RequiredIds = new List<string>();

    public bool CheckSet()
    {
        Debug.Log("TRUCK SET");

        RequiredIds.ForEach(x =>
        {
            Debug.Log(x);

        });
        Debug.Log("-----------");
        var items = Services.GetInstance().GetPlayer().AllActiveItems;
        items.ForEach(x =>
        {
            Debug.Log(validateId(x.id));

        });
        Debug.Log("=========");

        return RequiredIds.TrueForAll(id => { return items.Find(item => validateId(item.id) == id) != null; });
      
    }

    string validateId(string id)
    {
        var valideID = id;

        switch (id)
        {
            case "1011":
            case "1012":
            case "1013":
            case "1014":
                valideID = "hero_sword";
                break;
            case "1021":
            case "1022":
            case "1023":
            case "1024":
                valideID = "item_id_10";
                break;
            case "11":
            case "12":
            case "13":
            case "14":
                valideID = "item_id_2";
                break;
            case "21":
            case "22":
            case "23":
            case "24":
                valideID = "item_id_3";
                break;
            case "31":
            case "32":
            case "33":
            case "34":
                valideID = "item_id_4";
                break;
            case "41":
            case "42":
            case "43":
            case "44":
                valideID = "item_id_5";
                break;
            case "51":
            case "52":
            case "53":
            case "54":
                valideID = "item_id_6";
                break;
            case "61":
            case "62":
            case "63":
            case "64":
                valideID = "item_id_7";
                break;
            case "71":
            case "72":
            case "73":
            case "74":
                valideID = "item_id_8";
                break;
            case "81":
            case "82":
            case "83":
            case "84":
                valideID = "item_id_9";
                break;
            default:
                //Debug.Log(id);
                break;
        }

        return valideID;
    }
}

public static class ItemSetManager
{

    public static ItemSet CurrentSet
    {
        get
        {
            return Sets.Find(set => set.CheckSet());
        }
    }

    public static List<ItemSet> Sets = new List<ItemSet>
    {
        new ItemSet
        {
            id = "HP",
            RequiredIds = new List<string>
            {
                "item_id_2",
                "item_id_3",
                "item_id_4",
                "item_id_5",
            },

            Modificators = new List<Modificator>
            {
                ModificatorFactory.ModificatorForString("HP|OnStart|HP+Coef+1+1|Permanent|Remove"),
            }
        },

       new ItemSet
        {
            id = "TMNT",
            RequiredIds = new List<string>
            {
                "item_id_6",
                "item_id_7",
                "item_id_8",
                "item_id_9",
            },

            Modificators = new List<Modificator>
            {
                 ModificatorFactory.ModificatorForString("DPC|OnAttack|NONE+Const+100+1|Permanent|Remove"),
                 ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+100+1|Permanent|Remove"),
            }
        },
    };


}