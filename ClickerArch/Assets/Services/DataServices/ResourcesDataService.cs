using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesDataService : IDataService
{
    public AudioClip GetAudioClipForID(string id)
    {
        return Resources.Load("AudioClips/" + id) as AudioClip;
    }

    public List<string> GetEnemiesIdsForLevelId(string levelId)
    {
        var result = new List<string>();

        
        switch (levelId)
        {
            default:
                result.Add("Angel");
                result.Add("Bot");
                result.Add("Slug");
                result.Add("Slug1");
                result.Add("RedHood");
                result.Add("Skeleton2");
                result.Add("Deamon");
                result.Add("inquisitor");
                result.Add("darkDoctor");
                break;
        }
        
        return result;
    }

    public EnemyData GetEnemyDataForIdAndLevel(string id, int level)
    {
        
        var hp = 1;// (int)(50 * Mathf.Pow((float)1.07, level));
        return new EnemyData(hp, 1.0, (int)(1 + 1 * Mathf.Pow((float)1.1, level)), new Drop { xp = level, gold = 10, Resources = new List<DropResource> { new DropResource { Resource = new Resource { count = 1, rarity = Resource.Rarity.Common }, probability = 75 } } } );
    }

    public void GetGoodsList(ItemCategory Category, RecipeList completion)
    {
        var Recipes = new List<Recipe>();
        switch (Category)
        {
            case ItemCategory.Thing:
                Recipes.AddRange(new List<Recipe> {
            new Recipe {
                Category = ItemCategory.Thing,
            RequiredGold = 10,

            ResultResource = new Resource { count = 1, rarity = Resource.Rarity.Common },
            IsPermanent = true

        },

        new Recipe {
            Category = ItemCategory.Thing,
            RequiredGold = 100,

            ResultResource = new Resource { count = 1, rarity = Resource.Rarity.Rare },
            IsPermanent = true

        } });
                break;
            case ItemCategory.Clothes:
                break;
            case ItemCategory.Weapon:
                Recipes.AddRange(new List<Recipe> {
           new Recipe {

               Category = ItemCategory.Weapon,

            RequiredGold = 3000,

            ResultItem = new Item
            {
                name = "Sword",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("CurrentDPC|OnAttack|DPC+Coef+1+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("CurrentDPS|OnAttack|DPC+Const+-2+1|Permanent|Remove"),
                }
            }
           }
                }
                );
                break;
            case ItemCategory.Transport:
                break;
            case ItemCategory.Skill:
                break;
        }


        completion(Recipes);
    }

    public Sprite GetSpriteForID(string id)
    {
        //var  a = Resources.Load<Sprite>("Sprites/" + id);
        //Debug.Log(a);
        return Resources.Load<Sprite>("Sprites/" + id);
    }

    public double GetXpForNextLevel(int currentLevel)
    {
        return 1000 + 500 * currentLevel;
    }
}
