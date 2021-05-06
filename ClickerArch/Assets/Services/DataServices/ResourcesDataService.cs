using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ResourcesDataService : IDataService
{
    /*
     
         
         
         Материалы

3 обычных - 1 редкий
5 редких - 1 эпический
7 эпических - 1 легендарный
--------------------------------------------------------------------------------------------------
Предметы

id: 1.
Название: "Меч героев".
Описание: "Такой острый, что можно порезаться, едва взглянув на него… Ой!!"
Характеристики: "+300 DPS"
Качество: Легендарный
Слот: Оружие
Материалы: 5 легендарных материалов
Комплект: -

{
id: 2.
Название: "Меч Храброго сердца".
Описание: "Только истинный король может достать этот меч из ножен"
Характеристики: "+35 DPС"
Качество: Редкий
Слот: Оружие
Материалы: 7 редких материалов
Комплект: "HP"

id: 3.
Название: "Серебрянный витой перстень".
Описание: "Напоминает кольца бамбукового питона"
Характеристики: "+10 DPS, -5 HP"
Качество: Обычный
Слот: Артефакт
Материалы: 10 обычных материалов
Комплект: "HP"

id: 4.
Название: "Тиара сизого сокола".
Описание: "Миниатюрная корона, предназначеная для юных принцесс"
Характеристики: "+10 DPS, -5 HP"
Качество: Обычный
Слот: Артефакт
Материалы: 10 обычных материалов
Комплект: "HP"

id: 5.
Название: "Кубок барского плеча".
Описание: "Он всегда наполовину пуст или наполовину полон ?"
Характеристики: "+20 HP, -5 DPC"
Качество: Обычный
Слот: Артефакт
Материалы: 10 обычных материалов
Комплект: "HP"
}
Комплект "HP" - "ЗДОРОВЬЕ УДВОЕНО"

{
id: 6.
Название: "Парные катаны".
Описание: "Их носитель часто слышыт: на кой те 2 меча"
Характеристики: "+45 DPС, -10 HP"
Качество: Редкий
Слот: Оружие
Материалы: 7 редких материалов
Комплект: "TMNT"

id: 7.
Название: "Странная вилка".
Описание: "Странно, но эта вилка имеет только 3 зубца"
Характеристики: "+5 DPS" 
Качество: Обычный
Слот: Артефакт
Материалы: 10 обычных материалов
Комплект: "TMNT"

id: 8.
Название: "Палка о двух концах".
Описание: "Палица с перебинтованной серединой для удобного хвата"
Характеристики: "+5 DPS" 
Качество: Обычный
Слот: Артефакт
Материалы: 10 обычных материалов
Комплект: "TMNT"

id: 9.
Название: "Китайские палочки"
Описание: "Есть этим сложно, но в глаз тыкнуть можно. Но почему они связаны ниткой ?"
Характеристики: "+15 DPС, -5 DPS"
Качество: Обычный
Слот: Артефакт
Материалы: 10 обычных материалов
Комплект: "TMNT"
}
Комплект: "TMNT" - "DPS+100, DPC+100"

id: 10.
Название: "Царский волкобой".
Описание: "Про это оружие ходит множество мифов, но никто не уверен насколько они правдивы"
Характеристики: "+150 DPC -30 HP"
Качество: Эпический
Слот: Оружие
Материалы: 5 эпических материалов
Комплект: -
         
         
         
         
         */


    static List<Recipe> TMNTRecipes = new List<Recipe>
    {
        new Recipe {
            id = "hero_sword",
            name = "HERO SWORD",

            Category = ItemCategory.Weapon,
            RequiredResources = new List<Resource>
            {
                new Resource { rarity = Resource.Rarity.Legendary, count = 5 },
            },

            RequiredGold = 500,

            ResultItem = new Item("hero_sword","HERO SWORD", 1,  new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|DPS+Coef+2+1|Permanent|Remove"),
                }, ItemCategory.Weapon)
        }


    };



    static List<Recipe> ResourceRecipes = new List<Recipe>
    {
        new Recipe {
            id = "rare_resource",
            name = "RARE RESOURCE",
            Category = ItemCategory.Thing,

            RequiredResources = new List<Resource>
            {
                new Resource { rarity = Resource.Rarity.Common, count = 3 },
            },

            RequiredGold = 10,

            ResultResource = new Resource { count = 1, rarity = Resource.Rarity.Rare },
            IsPermanent = true

        },

        new Recipe {
            id = "epic_resource",
            name = "EPIC RESOURCE",
            Category = ItemCategory.Thing,

            RequiredResources = new List<Resource>
            {
                new Resource { rarity = Resource.Rarity.Rare, count = 5 },
            },

            RequiredGold = 100,

            ResultResource = new Resource { count = 1, rarity = Resource.Rarity.Epic },
            IsPermanent = true

        },

        new Recipe {
            id = "legendary_resource",
            name = "LEGENDARY RESOURCE",
            Category = ItemCategory.Thing,

            RequiredResources = new List<Resource>
            {
                new Resource { rarity = Resource.Rarity.Epic, count = 7 },
            },

            RequiredGold = 1000,

            ResultResource = new Resource { count = 1, rarity = Resource.Rarity.Legendary },
            IsPermanent = true

        }
    };


    List <Recipe> AllRecipes = new List<Recipe>
    {

        new Recipe {
            id = "mock_sword",
            name = "SWORD",

            Category = ItemCategory.Weapon,
            RequiredResources = new List<Resource>
            {
                new Resource { rarity = Resource.Rarity.Common, count = 4 },
                new Resource { rarity = Resource.Rarity.Rare, count = 1 },
            },

            RequiredGold = 678,

            ResultItem = new Item
            {
                Category = ItemCategory.Weapon,
                name = "Sword",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("CurrentDPC|OnAttack|DPC+Coef+1+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("CurrentDPS|OnAttack|DPC+Const+-2+1|Permanent|Remove"),
                }
            }
        }
    };

    public AudioClip GetAudioClipForID(string id)
    {
        return Resources.Load("AudioClips/" + id) as AudioClip;
    }

    public ResourcesDataService()
    {
        AllRecipes.AddRange(ResourceRecipes);
        AllRecipes.AddRange(TMNTRecipes);
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
        
        var hp = (int)(50 * Mathf.Pow((float)1.07, level));
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
            id = "common_resource",
            name = "COMMON RESOURCE",
                Category = ItemCategory.Thing,
            RequiredGold = 10,

            ResultResource = new Resource { count = 1, rarity = Resource.Rarity.Common },
            IsPermanent = true

        },

        new Recipe {
            id = "rare_resource",
            name = "RARE RESOURCE",
            Category = ItemCategory.Thing,
            RequiredGold = 100,

            ResultResource = new Resource { count = 1, rarity = Resource.Rarity.Rare },
            IsPermanent = true

        },
                new Recipe {
            id = "epic_resource",
            name = "EPIC RESOURCE",
            Category = ItemCategory.Thing,
            RequiredGold = 1000,

            ResultResource = new Resource { count = 1, rarity = Resource.Rarity.Epic },
            IsPermanent = true

        },
                new Recipe {
            id = "legendary_resource",
            name = "LEGENDARY RESOURCE",
            Category = ItemCategory.Thing,
            RequiredGold = 10000,

            ResultResource = new Resource { count = 1, rarity = Resource.Rarity.Legendary },
            IsPermanent = true

        }});
                break;
            case ItemCategory.Clothes:
                break;
            case ItemCategory.Weapon:
                Recipes.AddRange(new List<Recipe> {
           new Recipe {
               name = "SWORD",
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
        Debug.Log(id);
        return Resources.Load<Sprite>("Sprites/" + id);
    }

    public double GetXpForNextLevel(int currentLevel)
    {
        return 1000 + 500 * currentLevel;
    }

    public Recipe GetRecipeForId(string id)
    {
        return AllRecipes.Find(recipe => recipe.id == id);
    }

    public double BaseDamagePerClickForLevel(int level)
    {
        return 5 + 1 * level;
    }

    public double BaseDamagePerSecondForLevel(int level)
    {
        return 1 + 0.25 * level;
    }

    public double BaseBlockForLevel(int level)
    {
        return 0 + 0.01 * level;
    }

    public double BaseReflectForLevel(int level)
    {
        return 0 + 0.1 * level;
    }

    public double AdditionalGoldForLevel(int level)
    {
        return 0 + 0.01 * level;
    }

    public double AdditionalXPForLevel(int level)
    {
        return 0 + 0.01 * level;
    }

    public double MaximumHealthPointForLevel(int level)
    {
        return 10 + 5 * level;
    }

    public int CostForBaseDamagePerClickForLevel(int level)
    {
        return 100 * (level + 1);
    }

    public int CostForBaseDamagePerSecondForLevel(int level)
    {
        return 100 * (level + 1);
    }

    public int CostForBaseBlockForLevel(int level)
    {
        return 100 * (level + 1);
    }

    public int CostForBaseReflectForLevel(int level)
    {
        return 100 * (level + 1);
    }

    public int CostForAdditionalGoldForLevel(int level)
    {
        return 100 * (level + 1);
    }


    public int CostForAdditionalXPForLevel(int level)
    {
        return 100 * (level + 1);
    }

    public int CostForMaximumHealthPointForLevel(int level)
    {
        return 100 * (level + 1);
    }

    public int CostForParameterForLevel(HeroParameter parameter, int level)
    {
        switch (parameter)
        {
            case HeroParameter.HP:
                return CostForMaximumHealthPointForLevel(level);
            case HeroParameter.DPC:
                return CostForBaseDamagePerClickForLevel(level);
            case HeroParameter.DPS:
                return CostForBaseDamagePerSecondForLevel(level);
            case HeroParameter.Block:
                return CostForBaseBlockForLevel(level);
            case HeroParameter.Reflect:
                return CostForBaseReflectForLevel(level);
            case HeroParameter.AdditionalGold:
                return CostForAdditionalGoldForLevel(level);
            case HeroParameter.AdditionalXP:
                return CostForAdditionalXPForLevel(level);
        }

        return 0;
    }

    public bool CanUpgradeParameter(HeroParameter parameter)
    {
        var player = Services.GetInstance().GetPlayer();

        var level = player.LevelForParameter(parameter);

        return player.Gold >= CostForParameterForLevel(parameter, level + 1) && level + 1 <= (player.CoolLevel + 1) * 5;
    }
}
