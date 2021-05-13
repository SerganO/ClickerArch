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

            ResultItem = new Item() {id = "hero_sword", name = "HERO SWORD", count = 1, modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|DPS+Coef+2+1|Permanent|Remove"),
               }, Category = ItemCategory.Weapon
                }
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


    List<Recipe> AllRecipes = new List<Recipe>
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
                id = "mock_sword",
                Category = ItemCategory.Weapon,
                name = "Sword",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("CurrentDPC|OnAttack|DPC+Coef+1+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("CurrentDPS|OnAttack|DPC+Const+-2+1|Permanent|Remove"),
                }
            }
        },
        // ПРИМЕР ОРУЖИЯ
        /*
         
         id: 1011.
Название: "Меч героев".
Описание: "Такой острый, что можно порезаться, едва взглянув на него… Ой!!"
Характеристики: "+17 DPS"
Качество: Обычный
Слот: Оружие
Материалы: 10 обычных материалов
Комплект: -
         */
        new Recipe
        {
            id = "1011",
            name = "Меч героев",
            Category = ItemCategory.Weapon,
            RequiredGold = 0,
            rarity = Resource.Rarity.Common,
            RequiredResources = new List<Resource>
            {
                 new Resource { rarity = Resource.Rarity.Common, count = 10 },
            },

            ResultItem = new Item
            {
                id = "1011",
                Category = ItemCategory.Weapon,
                count = 1,
                rarity = Resource.Rarity.Common,
                name = "Меч героев",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+17+1|Permanent|Remove"),

                },

            }
        },

        //ПРИМЕР АРТЕФАКТА
        /*
         
         id: 21.
Название: "Серебрянный витой перстень".
Описание: "Напоминает кольца бамбукового питона"
Характеристики: "+10 DPS, -5 HP"
Качество: Обычный
Слот: Артефакт
Материалы: 9 обычных материалов, 1 редкий материал
Комплект: "HP"
         
         */
        new Recipe
        {
            id = "21",
            name = "Серебрянный витой перстень",
            Category = ItemCategory.Thing,
            RequiredGold = 0,
            rarity = Resource.Rarity.Common,
            RequiredResources = new List<Resource>
            {
                 new Resource { rarity = Resource.Rarity.Common, count = 9 },
                 new Resource { rarity = Resource.Rarity.Rare, count = 1 },
            },

            ResultItem = new Item
            {
                id = "21",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Common,
                name = "Серебрянный витой перстень",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+10+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("HP|OnStart|NONE+Const+-5+1|Permanent|Remove"),

                },

            }
        },

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
            case "Level1":
                result.Add("Archer");
                result.Add("RedHood");
                result.Add("inquisitor");
                result.Add("darkDoctor");
                result.Add("DarkWarrior");
                result.Add("Vampire");
                result.Add("Mimic");
                result.Add("Knight");
                result.Add("Deamon");
                result.Add("DarkWizard2");
                break;

            case "Level2":
                result.Add("Angel");
                result.Add("CaveExplorer");
                result.Add("HellBeast1");
                result.Add("HellBeast2");
                result.Add("DarkWizard2");
                result.Add("DeamonRed");
                result.Add("FireSkull");
                result.Add("FlyingEye");
                result.Add("Ghost");
                result.Add("FireWizard");
                break;

            case "Level3":
                result.Add("Archer2");
                result.Add("HeavyBandit");
                result.Add("Ronin");
                result.Add("BaldPirate");
                result.Add("BigGuy");
                result.Add("BombGuy");
                result.Add("Cucumber");
                result.Add("Whale");
                result.Add("Shadow");
                result.Add("ShieldDroid");
                break;

            case "Level4":
                result.Add("Slug");
                result.Add("Slug1");
                result.Add("Slug2");
                result.Add("Worm");
                result.Add("Worm1");
                result.Add("Mushroom");
                result.Add("Death");
                result.Add("DeathTeeth");
                result.Add("Goblin");
                result.Add("Vampire");
                break;

            case "Level5":
                result.Add("DarkWizard");
                result.Add("DarkWizard3");
                result.Add("CaveExplorer");
                result.Add("Skeleton1");
                result.Add("Skeleton2");
                result.Add("Skeleton3");
                result.Add("Skeleton4");
                result.Add("Skeleton5");
                result.Add("Skeleton6");
                result.Add("Mimic");
                break;

            case "Level6":
                result.Add("Dryad");
                result.Add("DeathTeeth");
                result.Add("Archer");
                result.Add("Archer2");
                result.Add("Shadow");
                result.Add("Shadow2");
                result.Add("Goblin");
                result.Add("Death");
                result.Add("Mushroom");
                result.Add("FlyingEye");
                break;

            case "Level7":
                result.Add("BaldPirate");
                result.Add("BigGuy");
                result.Add("BombGuy");
                result.Add("Captain");
                result.Add("Cucumber");
                result.Add("Whale");
                result.Add("DeathTeeth");
                result.Add("Worm");
                result.Add("Worm1");
                result.Add("Warrior");
                break;

            case "Level8":
                result.Add("Slug");
                result.Add("Slug1");
                result.Add("Slug2");
                result.Add("Mushroom");
                result.Add("Mimic");
                result.Add("DeathTeeth");
                result.Add("ShieldDroid");
                result.Add("Bot");
                result.Add("Whale");
                result.Add("Cucumber");
                break;

            case "Level9":
                result.Add("Skeleton1");
                result.Add("Skeleton2");
                result.Add("Skeleton3");
                result.Add("Skeleton4");
                result.Add("Skeleton5");
                result.Add("Skeleton6");
                result.Add("Death");
                result.Add("FireSkull");
                result.Add("Ghost");
                result.Add("Shadow");
                break;

            case "Level10":
                result.Add("Worm");
                result.Add("Worm1");
                result.Add("DeathTeeth");
                result.Add("Mimic");
                result.Add("BaldPirate");
                result.Add("BigGuy");
                result.Add("Cucumber");
                result.Add("Captain");
                result.Add("Whale");
                result.Add("Shadow2");
                break;

            case "Level11":
                result.Add("Archer");
                result.Add("Archer2");
                result.Add("CaveExplorer");
                result.Add("Knight");
                result.Add("HeavyBandit");
                result.Add("Warrior");
                result.Add("RedHood");
                result.Add("Vampire");
                result.Add("DarkDoctor");
                result.Add("Inquisitor");
                break;

            case "Level12":
                result.Add("Angel");
                result.Add("Bot");
                result.Add("Deamon");
                result.Add("FlyingEye");
                result.Add("FireSkull");
                result.Add("FireWizard");
                result.Add("DarkWizard3");
                result.Add("Death");
                result.Add("Shadow");
                result.Add("Ronin");
                break;

            case "Level13":
                result.Add("Archer");
                result.Add("Archer2");
                result.Add("DarkWizard2");
                result.Add("DarkWarrior");
                result.Add("DeathTeeth");
                result.Add("RedHood");
                result.Add("Mushroom");
                result.Add("Shadow2");
                result.Add("Dryad");
                result.Add("Goblin");
                break;

            case "Level14":
                result.Add("Angel");
                result.Add("Archer2");
                result.Add("BaldPirate");
                result.Add("BigGuy");
                result.Add("BombGuy");
                result.Add("Captain");
                result.Add("Cucumber");
                result.Add("Whale");
                result.Add("RedHood");
                result.Add("Mushroom");
                break;

            case "Level15":
                result.Add("Archer");
                result.Add("Skeleton1");
                result.Add("Skeleton3");
                result.Add("Skeleton4");
                result.Add("Skeleton5");
                result.Add("Skeleton6");
                result.Add("Shadow2");
                result.Add("DarkWizard");
                result.Add("Death");
                result.Add("Dryad");
                break;
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
        double base_hp = 10;
        double base_dmg = 1;

        double actual_hp = 10;
        double actual_dmg = 1;

        for (int lvl = 1; lvl <= level; lvl++)
        {
            actual_hp = actual_hp * base_hp * 0.105 + 9;
            actual_dmg = actual_dmg * 0.956 * (base_dmg * 1.1000000000000000000000001) + 1.1;
        }
        

        var hp = (int)actual_hp;// (int)(50 * Mathf.Pow((float)1.07, level));
        var dmg = (int)actual_dmg;//(1 + 1 * Mathf.Pow((float)1.1, level));
        return new EnemyData(hp, 1.0, dmg, new Drop { xpBaseLevel = level, gold = 10 * level * Mathf.Pow((float)1.1, level - 1),
            Resources = new List<DropResource> {
            new DropResource { Resource = new Resource { count = 1, rarity = Resource.Rarity.Common },      probability = level <= 25 ? 17 : (level <= 50 ? 4 : ( level <= 75 ? 3 : 2)) },
            new DropResource { Resource = new Resource { count = 1, rarity = Resource.Rarity.Rare },        probability = level <= 25 ? 7 : (level <= 50 ? 14 : ( level <= 75 ? 6 : 4)) },
            new DropResource { Resource = new Resource { count = 1, rarity = Resource.Rarity.Epic },        probability = level <= 25 ? 4 : (level <= 50 ? 8 : ( level <= 75 ? 17 : 7)) },
            new DropResource { Resource = new Resource { count = 1, rarity = Resource.Rarity.Legendary },   probability = level <= 25 ? 2 : (level <= 50 ? 4 : ( level <= 75 ? 4 : 17)) },
        },
            Recipes = RecipesForLevel(level)
        } );
    }

    List<Recipe> CommonRecipes = new List<Recipe> {new Recipe {
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
                id = "mock_sword",
                Category = ItemCategory.Weapon,
                name = "Sword",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("CurrentDPC|OnAttack|DPC+Coef+1+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("CurrentDPS|OnAttack|DPC+Const+-2+1|Permanent|Remove"),
                }
            }
        } };
    List<Recipe> RareRecipes = new List<Recipe> { new Recipe {
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
                id = "mock_sword",
                Category = ItemCategory.Weapon,
                name = "Sword",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("CurrentDPC|OnAttack|DPC+Coef+1+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("CurrentDPS|OnAttack|DPC+Const+-2+1|Permanent|Remove"),
                }
            }
        }};
    List<Recipe> EpicRecipes = new List<Recipe> {new Recipe {
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
                id = "mock_sword",
                Category = ItemCategory.Weapon,
                name = "Sword",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("CurrentDPC|OnAttack|DPC+Coef+1+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("CurrentDPS|OnAttack|DPC+Const+-2+1|Permanent|Remove"),
                }
            }
        } };
    List<Recipe> LegendaryRecipes = new List<Recipe> {new Recipe {
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
                id = "mock_sword",
                Category = ItemCategory.Weapon,
                name = "Sword",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("CurrentDPC|OnAttack|DPC+Coef+1+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("CurrentDPS|OnAttack|DPC+Const+-2+1|Permanent|Remove"),
                }
            }
        } };

    public T RandomElement<T>(List<T> list)
    {

        var count = list.Count;
        if (count <= 0) return default(T);
        int index = Random.Range(0, count);
        return list[index];


    }

    public List<DropRecipe> RecipesForLevel(int level)
    {
        var res = new List<DropRecipe> {
            new DropRecipe { Recipe = (Recipe)RandomElement(CommonRecipes).Clone(),     probability = level <= 25 ? 17 / 2.0 : (level <= 50 ? 4/ 2.0 : ( level <= 75 ? 3/ 2.0 : 2/ 2.0)) },
            new DropRecipe { Recipe = (Recipe)RandomElement(RareRecipes).Clone(),       probability = level <= 25 ? 7/ 2.0 : (level <= 50 ? 14/ 2.0 : ( level <= 75 ? 6/ 2.0 : 4/ 2.0)) },
            new DropRecipe { Recipe = (Recipe)RandomElement(EpicRecipes).Clone(),       probability = level <= 25 ? 4/ 2.0 : (level <= 50 ? 8/ 2.0 : ( level <= 75 ? 17/ 2.0 : 7/ 2.0)) },
            new DropRecipe { Recipe = (Recipe)RandomElement(LegendaryRecipes).Clone(),  probability = level <= 25 ? 2/ 2.0 : (level <= 50 ? 4/ 2.0 : ( level <= 75 ? 4/ 2.0 : 17/ 2.0)) },
        };


        return res;
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
            id = "hero_sword",
            name = "HERO SWORD",

            Category = ItemCategory.Weapon,
            RequiredGold = 7500,

            ResultItem = new Item(){id = "hero_sword", name = "HERO SWORD", count = 1,  modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|DPS+Coef+2+1|Permanent|Remove"),
                }, Category=  ItemCategory.Weapon }
        },
           new Recipe {
               name = "SWORD",
               Category = ItemCategory.Weapon,

            RequiredGold = 3000,

            ResultItem = new Item
            {
                name = "Sword",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPC|OnAttack|DPC+Coef+1+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|DPC+Const+-2+1|Permanent|Remove"),
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

    List<int> a = new List<int>{ 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281, 283, 293, 307, 311, 313, 317, 331, 337, 347, 349, 353, 359, 367, 373, 379, 383, 389, 397, 401, 409, 419, 421, 431, 433, 439, 443, 449, 457, 461, 463, 467, 479, 487, 491, 499, 503, 509, 521, 523, 541, 547, 557 };

    public double BaseDamagePerClickForLevel(int level)
    {
        double res = 0;
        for(int i=0;i<= level; i++)
        {
            res += (int)((a[i] * 4.8 - 4) / 2.1);
        }
        return res;
    }

    public double BaseDamagePerSecondForLevel(int level)
    {
        double res = 0;
        for (int i = 0; i <= level; i++)
        {
            res += (int)((a[i] * 4.8 - 5) / 2.2);
        }
        return res;
    }

    public double BaseBlockForLevel(int level)
    {
        double res = 0;
        for (int i = 0; i < level; i++)
        {
            res += (int)((a[i] * 1.01 + 1.9) / 3.9);
        }
        return res / 100;
    }

    public double BaseReflectForLevel(int level)
    {
        double res = 0;
        for (int i = 0; i < level; i++)
        {
            res += (int)((a[i] * 1.01 + 7.9) / 8.9);
        }
        return res / 100;
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
        double res = 0;
        for (int i = 0; i <= level; i++)
        {
            res += (int)(a[i] * 4.8 - 4);
        }
        return res;
    }

    public int CostForBaseDamagePerClickForLevel(int level)
    {
        return (int)(a[level] * 5.048 * (level * 3.0 * 0.699) + 10);
    }

    public int CostForBaseDamagePerSecondForLevel(int level)
    {
        return (int)(a[level] * 5.049 * (level * 3.0 * 0.699) + 19);
    }

    public int CostForBaseBlockForLevel(int level)
    {
        return (int)(a[level] * 268.049 * (level * 2.5 * 0.699) + 199);
    }

    public int CostForBaseReflectForLevel(int level)
    {
        return (int)(a[level] * 218.049 * (level * 2.5 * 0.699) + 175);
    }

    public int CostForAdditionalGoldForLevel(int level)
    {
        return (int)(a[level] * 44.049 * (level * 2.5 * 0.699) + 175);
    }


    public int CostForAdditionalXPForLevel(int level)
    {
        return (int)(a[level] * 44.049 * (level * 2.5 * 0.699) + 175);
    }

    public int CostForMaximumHealthPointForLevel(int level)
    {
        return (int)(a[level] * 5.048 * (level * 3.0 * 0.699) + 10);
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

        bool bigParameter = parameter == HeroParameter.HP || parameter == HeroParameter.DPC || parameter == HeroParameter.DPS;

        return player.Gold >= CostForParameterForLevel(parameter, level + 1) && level + 1 < (bigParameter ? 100: 10);
    }

    public double ValueForParameterForLevel(HeroParameter parameter, int level)
    {
        switch (parameter)
        {
            case HeroParameter.HP:
                return MaximumHealthPointForLevel(level);
            case HeroParameter.DPC:
                return BaseDamagePerClickForLevel(level);
            case HeroParameter.DPS:
                return BaseDamagePerSecondForLevel(level);
            case HeroParameter.Block:
                return BaseBlockForLevel(level);
            case HeroParameter.Reflect:
                return BaseReflectForLevel(level);
            case HeroParameter.AdditionalGold:
                return AdditionalGoldForLevel(level);
            case HeroParameter.AdditionalXP:
                return AdditionalXPForLevel(level);
        }
        return 0;
    }

    public int CostForClothes(string heroID)
    {

        return 5000;


    }

    public void GetHeroList(StringList completion)
    {
        List<string> heroes = new List<string> { 
        //COMMON
        "Adventurer",
        "ArenaWarrior",
        "ArmorWarrior",
        "Assassin",
        "CityBouncer",
        "Cyberclockwerk",
        "Gunslinger",
        "Hastat",
        "LightBandit",
        "MedievalKing",
        "Ninja",
         };

        var player = Services.GetInstance().GetPlayer();
        heroes.RemoveAll((id) => {
            return player.availableHeroes.Contains(id) || player.CurrentHeroId == id ;
        });



        completion(heroes);


    }
}
