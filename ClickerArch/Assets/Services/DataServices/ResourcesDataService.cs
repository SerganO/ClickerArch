using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ResourcesDataService : IDataService
{

    /*

       Обычный транспорт:   car7(Название- Сломанная машина(Broken car, Зламана машина), XP - 5000, Unlock 5 level, 1000), car 8(Название- Бабушкомобиль (Granny's car, Бабусемобіль), XP - 5000, Unlock 8 level, 1000)

       */

    static public List<Recipe> TransportGood = new List<Recipe>
    {
         new Recipe
        { count = 1,
            id = "horse",
            Category = ItemCategory.Transport,
            RequiredGold = 50000,
            rarity = Resource.Rarity.Legendary,
            RequiredLevel = 30,
            ResultItem = new Item
            {
                id = "horse",
                Category = ItemCategory.Transport,
                count = 1,
                rarity = Resource.Rarity.Legendary,
            },

            ResultXP = 50000
        },

         new Recipe
        { count = 1,
            id = "Car1",
            Category = ItemCategory.Transport,
            RequiredGold = 10000,
            rarity = Resource.Rarity.Rare,
             RequiredLevel = 10,
            ResultItem = new Item
            {
                id = "Car1",
                Category = ItemCategory.Transport,
                count = 1,
                rarity = Resource.Rarity.Rare,
            },

            ResultXP = 10000
        },

         new Recipe
        { count = 1,
            id = "Car2",
            Category = ItemCategory.Transport,
            RequiredGold = 20,
            rarity = Resource.Rarity.Epic,
             RequiredLevel = 20000,
            ResultItem = new Item
            {
                id = "Car2",
                Category = ItemCategory.Transport,
                count = 1,
                rarity = Resource.Rarity.Epic,
            },

            ResultXP = 20000
        },

         new Recipe
        { count = 1,
            id = "Car3",
            Category = ItemCategory.Transport,
            RequiredGold = 20000,
            rarity = Resource.Rarity.Epic,
             RequiredLevel = 25,
            ResultItem = new Item
            {
                id = "Car3",
                Category = ItemCategory.Transport,
                count = 1,
                rarity = Resource.Rarity.Epic,
            },

            ResultXP = 20000
        },

         new Recipe
        { count = 1,
            id = "Car4",
            Category = ItemCategory.Transport,
            RequiredGold = 5000,
            rarity = Resource.Rarity.Common,
             RequiredLevel = 1,
            ResultItem = new Item
            {
                id = "Car4",
                Category = ItemCategory.Transport,
                count = 1,
                rarity = Resource.Rarity.Common,
            },

            ResultXP = 5000
        },

         new Recipe
        { count = 1,
            id = "Car5",
            Category = ItemCategory.Transport,
            RequiredGold = 10000,
            rarity = Resource.Rarity.Rare,
             RequiredLevel = 15,
            ResultItem = new Item
            {
                id = "Car5",
                Category = ItemCategory.Transport,
                count = 1,
                rarity = Resource.Rarity.Rare,
            },

            ResultXP = 10000
        },

         new Recipe
        { count = 1,
            id = "Car6",
            Category = ItemCategory.Transport,
            RequiredGold = 10000,
            rarity = Resource.Rarity.Rare,
             RequiredLevel = 18,
            ResultItem = new Item
            {
                id = "Car6",
                Category = ItemCategory.Transport,
                count = 1,
                rarity = Resource.Rarity.Rare,
            },

            ResultXP = 10000
        },

         new Recipe
        { count = 1,
            id = "Car7",
            Category = ItemCategory.Transport,
            RequiredGold = 5000,
            rarity = Resource.Rarity.Common,
             RequiredLevel = 5,
            ResultItem = new Item
            {
                id = "Car7",
                Category = ItemCategory.Transport,
                count = 1,
                rarity = Resource.Rarity.Common,
            },

            ResultXP = 5000
        },

         new Recipe
        { count = 1,
            id = "Car8",
            Category = ItemCategory.Transport,
            RequiredGold = 5000,
            rarity = Resource.Rarity.Common,
             RequiredLevel = 8,
            ResultItem = new Item
            {
                id = "Car8",
                Category = ItemCategory.Transport,
                count = 1,
                rarity = Resource.Rarity.Common,
            },

            ResultXP = 5000
        },
    };

    static public List<Recipe> ResourceRecipes = new List<Recipe>
    {
        new Recipe { count = 1,
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

        new Recipe { count = 1,
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

        new Recipe { count = 1,
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

    static List<Recipe> AllGoods = new List<Recipe>
    {
        // [101(*)]
        new Recipe
        { count = 1,
            id = "1011",
            name = "Меч героев",

            Category = ItemCategory.Weapon,
            RequiredGold = 2000,
            rarity = Resource.Rarity.Common,


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
        new Recipe
        { count = 1,
            id = "1012",
            name = "Меч героев",
            Category = ItemCategory.Weapon,
            RequiredGold = 4000,
            rarity = Resource.Rarity.Rare,


            ResultItem = new Item
            {
                id = "1012",
                Category = ItemCategory.Weapon,
                count = 1,
                rarity = Resource.Rarity.Rare,
                name = "Меч героев",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+35+1|Permanent|Remove"),
                },
            }
        },
        new Recipe
        { count = 1,
            id = "1013",
            name = "Меч героев",
            Category = ItemCategory.Weapon,
            RequiredGold = 6000,
            rarity = Resource.Rarity.Epic,


            ResultItem = new Item
            {
                id = "1013",
                Category = ItemCategory.Weapon,
                count = 1,
                rarity = Resource.Rarity.Epic,
                name = "Меч героев",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+80+1|Permanent|Remove"),
                },
            }
        },
        new Recipe
        { count = 1,
            id = "1014",
            name = "Меч героев",
            Category = ItemCategory.Weapon,
            RequiredGold = 8000,
            rarity = Resource.Rarity.Legendary,


            ResultItem = new Item
            {
                id = "1014",
                Category = ItemCategory.Weapon,
                count = 1,
                rarity = Resource.Rarity.Legendary,
                name = "Меч героев",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+300+1|Permanent|Remove"),
                },
            }
        },

        // [102(*)]
        new Recipe
        { count = 1,
            id = "1021",
            name = "Царский волкобой",
            Category = ItemCategory.Weapon,
            RequiredGold = 2000,
            rarity = Resource.Rarity.Common,


            ResultItem = new Item
            {
                id = "1021",
                Category = ItemCategory.Weapon,
                count = 1,
                rarity = Resource.Rarity.Common,
                name = "Царский волкобой",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPC|OnAttack|NONE+Const+25+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("HP|OnStart|NONE+Const+-7+1|Permanent|Remove"),
                },
            }
        },
        new Recipe
        { count = 1,
            id = "1022",
            name = "Царский волкобой",
            Category = ItemCategory.Weapon,
            RequiredGold = 4000,
            rarity = Resource.Rarity.Rare,


            ResultItem = new Item
            {
                id = "1022",
                Category = ItemCategory.Weapon,
                count = 1,
                rarity = Resource.Rarity.Rare,
                name = "Царский волкобой",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPC|OnAttack|NONE+Const+70+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("HP|OnStart|NONE+Const+-13+1|Permanent|Remove"),
                },
            }
        },
        new Recipe
        { count = 1,
            id = "1023",
            name = "Царский волкобой",
            Category = ItemCategory.Weapon,
            RequiredGold = 6000,
            rarity = Resource.Rarity.Epic,


            ResultItem = new Item
            {
                id = "1023",
                Category = ItemCategory.Weapon,
                count = 1,
                rarity = Resource.Rarity.Epic,
                name = "Царский волкобой",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPC|OnAttack|NONE+Const+150+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("HP|OnStart|NONE+Const+-30+1|Permanent|Remove"),
                },
            }
        },
        new Recipe
        { count = 1,
            id = "1024",
            name = "Царский волкобой",
            Category = ItemCategory.Weapon,
            RequiredGold = 8000,
            rarity = Resource.Rarity.Legendary,


            ResultItem = new Item
            {
                id = "1024",
                Category = ItemCategory.Weapon,
                count = 1,
                rarity = Resource.Rarity.Legendary,
                name = "Царский волкобой",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPC|OnAttack|NONE+Const+430+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("HP|OnStart|NONE+Const+-99+1|Permanent|Remove"),
                },
            }
        },

        // [1(*)]
        new Recipe
        { count = 1,
            id = "11",
            name = "Меч Храброго сердца",
            Category = ItemCategory.Weapon,
            RequiredGold = 2000,
            rarity = Resource.Rarity.Common,


            ResultItem = new Item
            {
                id = "11",
                Category = ItemCategory.Weapon,
                count = 1,
                rarity = Resource.Rarity.Common,
                name = "Меч Храброго сердца",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPC|OnAttack|NONE+Const+10+1|Permanent|Remove"),
                },
            },
        },
        new Recipe
        { count = 1,
            id = "12",
            name = "Меч Храброго сердца",
            Category = ItemCategory.Weapon,
            RequiredGold = 4000,
            rarity = Resource.Rarity.Rare,

            ResultItem = new Item
            {
                id = "12",
                Category = ItemCategory.Weapon,
                count = 1,
                rarity = Resource.Rarity.Rare,
                name = "Меч Храброго сердца",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPC|OnAttack|NONE+Const+35+1|Permanent|Remove"),
                },
            },
        },
        new Recipe
        { count = 1,
            id = "13",
            name = "Меч Храброго сердца",
            Category = ItemCategory.Weapon,
            RequiredGold = 6000,
            rarity = Resource.Rarity.Epic,


            ResultItem = new Item
            {
                id = "13",
                Category = ItemCategory.Weapon,
                count = 1,
                rarity = Resource.Rarity.Epic,
                name = "Меч Храброго сердца",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPC|OnAttack|NONE+Const+77+1|Permanent|Remove"),
                },
            },
        },
        new Recipe
        { count = 1,
            id = "14",
            name = "Меч Храброго сердца",
            Category = ItemCategory.Weapon,
            RequiredGold = 8000,
            rarity = Resource.Rarity.Legendary,


            ResultItem = new Item
            {
                id = "14",
                Category = ItemCategory.Weapon,
                count = 1,
                rarity = Resource.Rarity.Legendary,
                name = "Меч Храброго сердца",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPC|OnAttack|NONE+Const+170+1|Permanent|Remove"),
                },
            },
        },

        // [2(*)]
        new Recipe
        { count = 1,
            id = "21",
            name = "Серебрянный витой перстень",
            Category = ItemCategory.Thing,
            RequiredGold = 1000,
            rarity = Resource.Rarity.Common,


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
        new Recipe
        { count = 1,
            id = "22",
            name = "Серебрянный витой перстень",
            Category = ItemCategory.Thing,
            RequiredGold = 2000,
            rarity = Resource.Rarity.Rare,

            ResultItem = new Item
            {
                id = "22",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Rare,
                name = "Серебрянный витой перстень",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+20+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("HP|OnStart|NONE+Const+-7+1|Permanent|Remove"),

                },
            }
        },
        new Recipe
        { count = 1,
            id = "23",
            name = "Серебрянный витой перстень",
            Category = ItemCategory.Thing,
            RequiredGold = 3000,
            rarity = Resource.Rarity.Epic,


            ResultItem = new Item
            {
                id = "23",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Epic,
                name = "Серебрянный витой перстень",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+70+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("HP|OnStart|NONE+Const+-15+1|Permanent|Remove"),

                },
            }
        },
        new Recipe
        { count = 1,
            id = "24",
            name = "Серебрянный витой перстень",
            Category = ItemCategory.Thing,
            RequiredGold = 4000,
            rarity = Resource.Rarity.Legendary,


            ResultItem = new Item
            {
                id = "24",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Legendary,
                name = "Серебрянный витой перстень",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+256+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("HP|OnStart|NONE+Const+-25+1|Permanent|Remove"),

                },
            }
        },

        // [3(*)]
        new Recipe
        { count = 1,
            id = "31",
            name = "Тиара сизого сокола",
            Category = ItemCategory.Thing,
            RequiredGold = 1000,
            rarity = Resource.Rarity.Common,

            ResultItem = new Item
            {
                id = "31",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Common,
                name = "Тиара сизого сокола",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+10+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("HP|OnStart|NONE+Const+-5+1|Permanent|Remove"),

                },
            }
        },
        new Recipe
        { count = 1,
            id = "32",
            name = "Тиара сизого сокола",
            Category = ItemCategory.Thing,
            RequiredGold = 2000,
            rarity = Resource.Rarity.Rare,


            ResultItem = new Item
            {
                id = "32",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Rare,
                name = "Тиара сизого сокола",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+27+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("HP|OnStart|NONE+Const+-8+1|Permanent|Remove"),
                },
            }
        },
        new Recipe
        { count = 1,
            id = "33",
            name = "Тиара сизого сокола",
            Category = ItemCategory.Thing,
            RequiredGold = 3000,
            rarity = Resource.Rarity.Epic,

            ResultItem = new Item
            {
                id = "33",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Epic,
                name = "Тиара сизого сокола",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+90+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("HP|OnStart|NONE+Const+-25+1|Permanent|Remove"),
                },
            }
        },
        new Recipe
        { count = 1,
            id = "34",
            name = "Тиара сизого сокола",
            Category = ItemCategory.Thing,
            RequiredGold = 4000,
            rarity = Resource.Rarity.Legendary,


            ResultItem = new Item
            {
                id = "34",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Legendary,
                name = "Тиара сизого сокола",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+394+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("HP|OnStart|NONE+Const+-50+1|Permanent|Remove"),
                },
            }
        },

        // [4(*)]
        new Recipe
        { count = 1,
            id = "41",
            name = "Кубок барского плеча",
            Category = ItemCategory.Thing,
            RequiredGold = 1000,
            rarity = Resource.Rarity.Common,


            ResultItem = new Item
            {
                id = "41",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Common,
                name = "Кубок барского плеча",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("HP|OnStart|NONE+Const+20+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("DPC|OnAttack|NONE+Const+-5+1|Permanent|Remove"),
                },
            }
        },
        new Recipe
        { count = 1,
            id = "42",
            name = "Кубок барского плеча",
            Category = ItemCategory.Thing,
            RequiredGold = 2000,
            rarity = Resource.Rarity.Rare,


            ResultItem = new Item
            {
                id = "42",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Rare,
                name = "Кубок барского плеча",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("HP|OnStart|NONE+Const+45+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("DPC|OnAttack|NONE+Const+-9+1|Permanent|Remove"),
                },
            }
        },
        new Recipe
        { count = 1,
            id = "43",
            name = "Кубок барского плеча",
            Category = ItemCategory.Thing,
            RequiredGold = 3000,
            rarity = Resource.Rarity.Epic,


            ResultItem = new Item
            {
                id = "43",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Epic,
                name = "Кубок барского плеча",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("HP|OnStart|NONE+Const+99+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("DPC|OnAttack|NONE+Const+-17+1|Permanent|Remove"),
                },
            }
        },
        new Recipe
        { count = 1,
            id = "44",
            name = "Кубок барского плеча",
            Category = ItemCategory.Thing,
            RequiredGold = 4000,
            rarity = Resource.Rarity.Legendary,

            ResultItem = new Item
            {
                id = "44",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Legendary,
                name = "Кубок барского плеча",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("HP|OnStart|NONE+Const+229+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("DPC|OnAttack|NONE+Const+-35+1|Permanent|Remove"),
                },
            }
        },

        // [5(*)]
        new Recipe
        { count = 1,
            id = "51",
            name = "Парные катаны",
            Category = ItemCategory.Weapon,
            RequiredGold = 2000,
            rarity = Resource.Rarity.Common,


            ResultItem = new Item
            {
                id = "51",
                Category = ItemCategory.Weapon,
                count = 1,
                rarity = Resource.Rarity.Common,
                name = "Парные катаны",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPC|OnAttack|NONE+Const+17+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("HP|OnStart|NONE+Const+-5+1|Permanent|Remove"),

                },
            }
        },
        new Recipe
        { count = 1,
            id = "52",
            name = "Парные катаны",
            Category = ItemCategory.Weapon,
            RequiredGold = 4000,
            rarity = Resource.Rarity.Rare,


            ResultItem = new Item
            {
                id = "52",
                Category = ItemCategory.Weapon,
                count = 1,
                rarity = Resource.Rarity.Rare,
                name = "Парные катаны",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPC|OnAttack|NONE+Const+45+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("HP|OnStart|NONE+Const+-10+1|Permanent|Remove"),

                },
            }
        },
        new Recipe
        { count = 1,
            id = "53",
            name = "Парные катаны",
            Category = ItemCategory.Weapon,
            RequiredGold = 6000,
            rarity = Resource.Rarity.Epic,


            ResultItem = new Item
            {
                id = "53",
                Category = ItemCategory.Weapon,
                count = 1,
                rarity = Resource.Rarity.Epic,
                name = "Парные катаны",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPC|OnAttack|NONE+Const+95+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("HP|OnStart|NONE+Const+-17+1|Permanent|Remove"),

                },
            }
        },
        new Recipe
        { count = 1,
            id = "54",
            name = "Парные катаны",
            Category = ItemCategory.Weapon,
            RequiredGold = 8000,
            rarity = Resource.Rarity.Legendary,

            ResultItem = new Item
            {
                id = "54",
                Category = ItemCategory.Weapon,
                count = 1,
                rarity = Resource.Rarity.Legendary,
                name = "Парные катаны",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPC|OnAttack|NONE+Const+199+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("HP|OnStart|NONE+Const+-40+1|Permanent|Remove"),

                },
            }
        },

        // [6(*)]
        new Recipe
        { count = 1,
            id = "61",
            name = "Странная вилка",
            Category = ItemCategory.Thing,
            RequiredGold = 1000,
            rarity = Resource.Rarity.Common,


            ResultItem = new Item
            {
                id = "61",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Common,
                name = "Странная вилка",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+5+1|Permanent|Remove"),
                },
            }
        },
        new Recipe
        { count = 1,
            id = "62",
            name = "Странная вилка",
            Category = ItemCategory.Thing,
            RequiredGold = 2000,
            rarity = Resource.Rarity.Rare,


            ResultItem = new Item
            {
                id = "62",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Rare,
                name = "Странная вилка",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+24+1|Permanent|Remove"),
                },
            }
        },
        new Recipe
        { count = 1,
            id = "63",
            name = "Странная вилка",
            Category = ItemCategory.Thing,
            RequiredGold = 3000,
            rarity = Resource.Rarity.Epic,


            ResultItem = new Item
            {
                id = "63",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Epic,
                name = "Странная вилка",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+75+1|Permanent|Remove"),
                },
            }
        },
        new Recipe
        { count = 1,
            id = "64",
            name = "Странная вилка",
            Category = ItemCategory.Thing,
            RequiredGold = 4000,
            rarity = Resource.Rarity.Legendary,


            ResultItem = new Item
            {
                id = "64",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Legendary,
                name = "Странная вилка",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+225+1|Permanent|Remove"),
                },
            }
        },

        // [7(*)]
        new Recipe
        { count = 1,
            id = "71",
            name = "Палка о двух концах",
            Category = ItemCategory.Thing,
            RequiredGold = 1000,
            rarity = Resource.Rarity.Common,

            ResultItem = new Item
            {
                id = "71",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Common,
                name = "Палка о двух концах",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+5+1|Permanent|Remove"),
                },
            }
        },
        new Recipe
        { count = 1,
            id = "72",
            name = "Палка о двух концах",
            Category = ItemCategory.Thing,
            RequiredGold = 2000,
            rarity = Resource.Rarity.Rare,

            ResultItem = new Item
            {
                id = "72",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Rare,
                name = "Палка о двух концах",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+20+1|Permanent|Remove"),
                },
            }
        },
        new Recipe
        { count = 1,
            id = "73",
            name = "Палка о двух концах",
            Category = ItemCategory.Thing,
            RequiredGold = 3000,
            rarity = Resource.Rarity.Epic,


            ResultItem = new Item
            {
                id = "73",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Epic,
                name = "Палка о двух концах",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+80+1|Permanent|Remove"),
                },
            }
        },
        new Recipe
        { count = 1,
            id = "74",
            name = "Палка о двух концах",
            Category = ItemCategory.Thing,
            RequiredGold = 4000,
            rarity = Resource.Rarity.Legendary,


            ResultItem = new Item
            {
                id = "74",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Legendary,
                name = "Палка о двух концах",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+256+1|Permanent|Remove"),
                },
            }
        },

        // [8(*)]
        new Recipe
        { count = 1,
            id = "81",
            name = "Китайские палочки",
            Category = ItemCategory.Thing,
            RequiredGold = 1000,
            rarity = Resource.Rarity.Common,


            ResultItem = new Item
            {
                id = "81",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Common,
                name = "Китайские палочки",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPC|OnAttack|NONE+Const+15+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+-5+1|Permanent|Remove"),
                },
            }
        },
        new Recipe
        { count = 1,
            id = "82",
            name = "Китайские палочки",
            Category = ItemCategory.Thing,
            RequiredGold = 2000,
            rarity = Resource.Rarity.Rare,


            ResultItem = new Item
            {
                id = "82",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Rare,
                name = "Китайские палочки",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPC|OnAttack|NONE+Const+30+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+-17+1|Permanent|Remove"),
                },
            }
        },
        new Recipe
        { count = 1,
            id = "83",
            name = "Китайские палочки",
            Category = ItemCategory.Thing,
            RequiredGold = 3000,
            rarity = Resource.Rarity.Epic,


            ResultItem = new Item
            {
                id = "83",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Epic,
                name = "Китайские палочки",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPC|OnAttack|NONE+Const+99+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+-29+1|Permanent|Remove"),
                },
            }
        },
        new Recipe
        { count = 1,
            id = "84",
            name = "Китайские палочки",
            Category = ItemCategory.Thing,
            RequiredGold = 4000,
            rarity = Resource.Rarity.Legendary,


            ResultItem = new Item
            {
                id = "84",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Legendary,
                name = "Китайские палочки",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPC|OnAttack|NONE+Const+242+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+-49+1|Permanent|Remove"),
                },
            }
        },
    };

    static List<Recipe> AllRecipes = new List<Recipe>
    {
        // [101(*)]
        new Recipe
        { count = 1,
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
        new Recipe
        { count = 1,
            id = "1012",
            name = "Меч героев",
            Category = ItemCategory.Weapon,
            RequiredGold = 0,
            rarity = Resource.Rarity.Rare,
            RequiredResources = new List<Resource>
            {
                 new Resource { rarity = Resource.Rarity.Common, count = 3 },
                 new Resource { rarity = Resource.Rarity.Rare, count = 7 },
            },

            ResultItem = new Item
            {
                id = "1012",
                Category = ItemCategory.Weapon,
                count = 1,
                rarity = Resource.Rarity.Rare,
                name = "Меч героев",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+35+1|Permanent|Remove"),
                },
            }
        },
        new Recipe
        { count = 1,
            id = "1013",
            name = "Меч героев",
            Category = ItemCategory.Weapon,
            RequiredGold = 0,
            rarity = Resource.Rarity.Epic,
            RequiredResources = new List<Resource>
            {
                 new Resource { rarity = Resource.Rarity.Common, count = 2 },
                 new Resource { rarity = Resource.Rarity.Rare, count = 3 },
                 new Resource { rarity = Resource.Rarity.Epic, count = 5 },
            },

            ResultItem = new Item
            {
                id = "1013",
                Category = ItemCategory.Weapon,
                count = 1,
                rarity = Resource.Rarity.Epic,
                name = "Меч героев",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+80+1|Permanent|Remove"),
                },
            }
        },
        new Recipe
        { count = 1,
            id = "1014",
            name = "Меч героев",
            Category = ItemCategory.Weapon,
            RequiredGold = 0,
            rarity = Resource.Rarity.Legendary,
            RequiredResources = new List<Resource>
            {
                 new Resource { rarity = Resource.Rarity.Common, count = 1 },
                 new Resource { rarity = Resource.Rarity.Rare, count = 1 },
                 new Resource { rarity = Resource.Rarity.Epic, count = 3 },
                 new Resource { rarity = Resource.Rarity.Legendary, count = 5 },
            },

            ResultItem = new Item
            {
                id = "1014",
                Category = ItemCategory.Weapon,
                count = 1,
                rarity = Resource.Rarity.Legendary,
                name = "Меч героев",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+300+1|Permanent|Remove"),
                },
            }
        },

        // [102(*)]
        new Recipe
        { count = 1,
            id = "1021",
            name = "Царский волкобой",
            Category = ItemCategory.Weapon,
            RequiredGold = 0,
            rarity = Resource.Rarity.Common,
            RequiredResources = new List<Resource>
            {
                 new Resource { rarity = Resource.Rarity.Common, count = 7 },
                 new Resource { rarity = Resource.Rarity.Rare, count = 3 },
            },

            ResultItem = new Item
            {
                id = "1021",
                Category = ItemCategory.Weapon,
                count = 1,
                rarity = Resource.Rarity.Common,
                name = "Царский волкобой",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPC|OnAttack|NONE+Const+25+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("HP|OnStart|NONE+Const+-7+1|Permanent|Remove"),
                },
            }
        },
        new Recipe
        { count = 1,
            id = "1022",
            name = "Царский волкобой",
            Category = ItemCategory.Weapon,
            RequiredGold = 0,
            rarity = Resource.Rarity.Rare,
            RequiredResources = new List<Resource>
            {
                 new Resource { rarity = Resource.Rarity.Common, count = 3 },
                 new Resource { rarity = Resource.Rarity.Rare, count = 7 },
            },

            ResultItem = new Item
            {
                id = "1022",
                Category = ItemCategory.Weapon,
                count = 1,
                rarity = Resource.Rarity.Rare,
                name = "Царский волкобой",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPC|OnAttack|NONE+Const+70+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("HP|OnStart|NONE+Const+-13+1|Permanent|Remove"),
                },
            }
        },
        new Recipe
        { count = 1,
            id = "1023",
            name = "Царский волкобой",
            Category = ItemCategory.Weapon,
            RequiredGold = 0,
            rarity = Resource.Rarity.Epic,
            RequiredResources = new List<Resource>
            {
                 new Resource { rarity = Resource.Rarity.Common, count = 1 },
                 new Resource { rarity = Resource.Rarity.Rare, count = 4 },
                 new Resource { rarity = Resource.Rarity.Epic, count = 5 },
            },

            ResultItem = new Item
            {
                id = "1023",
                Category = ItemCategory.Weapon,
                count = 1,
                rarity = Resource.Rarity.Epic,
                name = "Царский волкобой",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPC|OnAttack|NONE+Const+150+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("HP|OnStart|NONE+Const+-30+1|Permanent|Remove"),
                },
            }
        },
        new Recipe
        { count = 1,
            id = "1024",
            name = "Царский волкобой",
            Category = ItemCategory.Weapon,
            RequiredGold = 0,
            rarity = Resource.Rarity.Legendary,
            RequiredResources = new List<Resource>
            {
                 new Resource { rarity = Resource.Rarity.Common, count = 1 },
                 new Resource { rarity = Resource.Rarity.Legendary, count = 9 },
            },

            ResultItem = new Item
            {
                id = "1024",
                Category = ItemCategory.Weapon,
                count = 1,
                rarity = Resource.Rarity.Legendary,
                name = "Царский волкобой",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPC|OnAttack|NONE+Const+430+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("HP|OnStart|NONE+Const+-99+1|Permanent|Remove"),
                },
            }
        },

        // [1(*)]
        new Recipe
        { count = 1,
            id = "11",
            name = "Меч Храброго сердца",
            Category = ItemCategory.Weapon,
            RequiredGold = 0,
            rarity = Resource.Rarity.Common,
            RequiredResources = new List<Resource>
            {
                 new Resource { rarity = Resource.Rarity.Common, count = 8 },
                 new Resource { rarity = Resource.Rarity.Rare, count = 2 },
            },

            ResultItem = new Item
            {
                id = "11",
                Category = ItemCategory.Weapon,
                count = 1,
                rarity = Resource.Rarity.Common,
                name = "Меч Храброго сердца",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPC|OnAttack|NONE+Const+10+1|Permanent|Remove"),
                },
            },
        },
        new Recipe
        { count = 1,
            id = "12",
            name = "Меч Храброго сердца",
            Category = ItemCategory.Weapon,
            RequiredGold = 0,
            rarity = Resource.Rarity.Rare,
            RequiredResources = new List<Resource>
            {
                 new Resource { rarity = Resource.Rarity.Common, count = 3 },
                 new Resource { rarity = Resource.Rarity.Rare, count = 7 },
            },

            ResultItem = new Item
            {
                id = "12",
                Category = ItemCategory.Weapon,
                count = 1,
                rarity = Resource.Rarity.Rare,
                name = "Меч Храброго сердца",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPC|OnAttack|NONE+Const+35+1|Permanent|Remove"),
                },
            },
        },
        new Recipe
        { count = 1,
            id = "13",
            name = "Меч Храброго сердца",
            Category = ItemCategory.Weapon,
            RequiredGold = 0,
            rarity = Resource.Rarity.Epic,
            RequiredResources = new List<Resource>
            {
                 new Resource { rarity = Resource.Rarity.Rare, count = 5 },
                 new Resource { rarity = Resource.Rarity.Epic, count = 5 },
            },

            ResultItem = new Item
            {
                id = "13",
                Category = ItemCategory.Weapon,
                count = 1,
                rarity = Resource.Rarity.Epic,
                name = "Меч Храброго сердца",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPC|OnAttack|NONE+Const+77+1|Permanent|Remove"),
                },
            },
        },
        new Recipe
        { count = 1,
            id = "14",
            name = "Меч Храброго сердца",
            Category = ItemCategory.Weapon,
            RequiredGold = 0,
            rarity = Resource.Rarity.Legendary,
            RequiredResources = new List<Resource>
            {
                 new Resource { rarity = Resource.Rarity.Rare, count = 1 },
                 new Resource { rarity = Resource.Rarity.Epic, count = 2 },
                 new Resource { rarity = Resource.Rarity.Legendary, count = 7 },
            },

            ResultItem = new Item
            {
                id = "14",
                Category = ItemCategory.Weapon,
                count = 1,
                rarity = Resource.Rarity.Legendary,
                name = "Меч Храброго сердца",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPC|OnAttack|NONE+Const+170+1|Permanent|Remove"),
                },
            },
        },

        // [2(*)]
        new Recipe
        { count = 1,
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
        new Recipe
        { count = 1,
            id = "22",
            name = "Серебрянный витой перстень",
            Category = ItemCategory.Thing,
            RequiredGold = 0,
            rarity = Resource.Rarity.Rare,
            RequiredResources = new List<Resource>
            {
                 new Resource { rarity = Resource.Rarity.Common, count = 5 },
                 new Resource { rarity = Resource.Rarity.Rare, count = 5 },
            },

            ResultItem = new Item
            {
                id = "22",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Rare,
                name = "Серебрянный витой перстень",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+20+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("HP|OnStart|NONE+Const+-7+1|Permanent|Remove"),

                },
            }
        },
        new Recipe
        { count = 1,
            id = "23",
            name = "Серебрянный витой перстень",
            Category = ItemCategory.Thing,
            RequiredGold = 0,
            rarity = Resource.Rarity.Epic,
            RequiredResources = new List<Resource>
            {
                 new Resource { rarity = Resource.Rarity.Rare, count = 5 },
                 new Resource { rarity = Resource.Rarity.Epic, count = 5 },
            },

            ResultItem = new Item
            {
                id = "23",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Epic,
                name = "Серебрянный витой перстень",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+70+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("HP|OnStart|NONE+Const+-15+1|Permanent|Remove"),

                },
            }
        },
        new Recipe
        { count = 1,
            id = "24",
            name = "Серебрянный витой перстень",
            Category = ItemCategory.Thing,
            RequiredGold = 0,
            rarity = Resource.Rarity.Legendary,
            RequiredResources = new List<Resource>
            {
                 new Resource { rarity = Resource.Rarity.Epic, count = 9 },
                 new Resource { rarity = Resource.Rarity.Legendary, count = 1 },
            },

            ResultItem = new Item
            {
                id = "24",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Legendary,
                name = "Серебрянный витой перстень",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+256+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("HP|OnStart|NONE+Const+-25+1|Permanent|Remove"),

                },
            }
        },

        // [3(*)]
        new Recipe
        { count = 1,
            id = "31",
            name = "Тиара сизого сокола",
            Category = ItemCategory.Thing,
            RequiredGold = 0,
            rarity = Resource.Rarity.Common,
            RequiredResources = new List<Resource>
            {
                 new Resource { rarity = Resource.Rarity.Common, count = 8 },
                 new Resource { rarity = Resource.Rarity.Rare, count = 2 },
            },

            ResultItem = new Item
            {
                id = "31",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Common,
                name = "Тиара сизого сокола",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+10+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("HP|OnStart|NONE+Const+-5+1|Permanent|Remove"),

                },
            }
        },
        new Recipe
        { count = 1,
            id = "32",
            name = "Тиара сизого сокола",
            Category = ItemCategory.Thing,
            RequiredGold = 0,
            rarity = Resource.Rarity.Rare,
            RequiredResources = new List<Resource>
            {
                 new Resource { rarity = Resource.Rarity.Common, count = 6 },
                 new Resource { rarity = Resource.Rarity.Rare, count = 4 },
            },

            ResultItem = new Item
            {
                id = "32",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Rare,
                name = "Тиара сизого сокола",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+27+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("HP|OnStart|NONE+Const+-8+1|Permanent|Remove"),
                },
            }
        },
        new Recipe
        { count = 1,
            id = "33",
            name = "Тиара сизого сокола",
            Category = ItemCategory.Thing,
            RequiredGold = 0,
            rarity = Resource.Rarity.Epic,
            RequiredResources = new List<Resource>
            {
                 new Resource { rarity = Resource.Rarity.Common, count = 3 },
                 new Resource { rarity = Resource.Rarity.Rare, count = 4 },
                 new Resource { rarity = Resource.Rarity.Epic, count = 3 },
            },

            ResultItem = new Item
            {
                id = "33",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Epic,
                name = "Тиара сизого сокола",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+90+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("HP|OnStart|NONE+Const+-25+1|Permanent|Remove"),
                },
            }
        },
        new Recipe
        { count = 1,
            id = "34",
            name = "Тиара сизого сокола",
            Category = ItemCategory.Thing,
            RequiredGold = 0,
            rarity = Resource.Rarity.Legendary,
            RequiredResources = new List<Resource>
            {
                 new Resource { rarity = Resource.Rarity.Rare, count = 4 },
                 new Resource { rarity = Resource.Rarity.Epic, count = 5 },
                 new Resource { rarity = Resource.Rarity.Legendary, count = 1 },
            },

            ResultItem = new Item
            {
                id = "34",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Legendary,
                name = "Тиара сизого сокола",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+394+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("HP|OnStart|NONE+Const+-50+1|Permanent|Remove"),
                },
            }
        },

        // [4(*)]
        new Recipe
        { count = 1,
            id = "41",
            name = "Кубок барского плеча",
            Category = ItemCategory.Thing,
            RequiredGold = 0,
            rarity = Resource.Rarity.Common,
            RequiredResources = new List<Resource>
            {
                 new Resource { rarity = Resource.Rarity.Common, count = 10 },
            },

            ResultItem = new Item
            {
                id = "41",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Common,
                name = "Кубок барского плеча",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("HP|OnStart|NONE+Const+20+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("DPC|OnAttack|NONE+Const+-5+1|Permanent|Remove"),
                },
            }
        },
        new Recipe
        { count = 1,
            id = "42",
            name = "Кубок барского плеча",
            Category = ItemCategory.Thing,
            RequiredGold = 0,
            rarity = Resource.Rarity.Rare,
            RequiredResources = new List<Resource>
            {
                 new Resource { rarity = Resource.Rarity.Rare, count = 10 },
            },

            ResultItem = new Item
            {
                id = "42",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Rare,
                name = "Кубок барского плеча",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("HP|OnStart|NONE+Const+45+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("DPC|OnAttack|NONE+Const+-9+1|Permanent|Remove"),
                },
            }
        },
        new Recipe
        { count = 1,
            id = "43",
            name = "Кубок барского плеча",
            Category = ItemCategory.Thing,
            RequiredGold = 0,
            rarity = Resource.Rarity.Epic,
            RequiredResources = new List<Resource>
            {
                 new Resource { rarity = Resource.Rarity.Epic, count = 10 },
            },

            ResultItem = new Item
            {
                id = "43",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Epic,
                name = "Кубок барского плеча",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("HP|OnStart|NONE+Const+99+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("DPC|OnAttack|NONE+Const+-17+1|Permanent|Remove"),
                },
            }
        },
        new Recipe
        { count = 1,
            id = "44",
            name = "Кубок барского плеча",
            Category = ItemCategory.Thing,
            RequiredGold = 0,
            rarity = Resource.Rarity.Legendary,
            RequiredResources = new List<Resource>
            {
                 new Resource { rarity = Resource.Rarity.Legendary, count = 10 },
            },

            ResultItem = new Item
            {
                id = "44",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Legendary,
                name = "Кубок барского плеча",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("HP|OnStart|NONE+Const+229+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("DPC|OnAttack|NONE+Const+-35+1|Permanent|Remove"),
                },
            }
        },

        // [5(*)]
        new Recipe
        { count = 1,
            id = "51",
            name = "Парные катаны",
            Category = ItemCategory.Weapon,
            RequiredGold = 0,
            rarity = Resource.Rarity.Common,
            RequiredResources = new List<Resource>
            {
                 new Resource { rarity = Resource.Rarity.Common, count = 8 },
                 new Resource { rarity = Resource.Rarity.Rare, count = 2 },
            },

            ResultItem = new Item
            {
                id = "51",
                Category = ItemCategory.Weapon,
                count = 1,
                rarity = Resource.Rarity.Common,
                name = "Парные катаны",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPC|OnAttack|NONE+Const+17+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("HP|OnStart|NONE+Const+-5+1|Permanent|Remove"),

                },
            }
        },
        new Recipe
        { count = 1,
            id = "52",
            name = "Парные катаны",
            Category = ItemCategory.Weapon,
            RequiredGold = 0,
            rarity = Resource.Rarity.Rare,
            RequiredResources = new List<Resource>
            {
                 new Resource { rarity = Resource.Rarity.Common, count = 2 },
                 new Resource { rarity = Resource.Rarity.Rare, count = 8 },
            },

            ResultItem = new Item
            {
                id = "52",
                Category = ItemCategory.Weapon,
                count = 1,
                rarity = Resource.Rarity.Rare,
                name = "Парные катаны",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPC|OnAttack|NONE+Const+45+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("HP|OnStart|NONE+Const+-10+1|Permanent|Remove"),

                },
            }
        },
        new Recipe
        { count = 1,
            id = "53",
            name = "Парные катаны",
            Category = ItemCategory.Weapon,
            RequiredGold = 0,
            rarity = Resource.Rarity.Epic,
            RequiredResources = new List<Resource>
            {
                 new Resource { rarity = Resource.Rarity.Rare, count = 8 },
                 new Resource { rarity = Resource.Rarity.Epic, count = 2 },
            },

            ResultItem = new Item
            {
                id = "53",
                Category = ItemCategory.Weapon,
                count = 1,
                rarity = Resource.Rarity.Epic,
                name = "Парные катаны",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPC|OnAttack|NONE+Const+95+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("HP|OnStart|NONE+Const+-17+1|Permanent|Remove"),

                },
            }
        },
        new Recipe
        { count = 1,
            id = "54",
            name = "Парные катаны",
            Category = ItemCategory.Weapon,
            RequiredGold = 0,
            rarity = Resource.Rarity.Legendary,
            RequiredResources = new List<Resource>
            {
                 new Resource { rarity = Resource.Rarity.Rare, count = 2 },
                 new Resource { rarity = Resource.Rarity.Legendary, count = 8 },
            },

            ResultItem = new Item
            {
                id = "54",
                Category = ItemCategory.Weapon,
                count = 1,
                rarity = Resource.Rarity.Legendary,
                name = "Парные катаны",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPC|OnAttack|NONE+Const+199+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("HP|OnStart|NONE+Const+-40+1|Permanent|Remove"),

                },
            }
        },

        // [6(*)]
        new Recipe
        { count = 1,
            id = "61",
            name = "Странная вилка",
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
                id = "61",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Common,
                name = "Странная вилка",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+5+1|Permanent|Remove"),
                },
            }
        },
        new Recipe
        { count = 1,
            id = "62",
            name = "Странная вилка",
            Category = ItemCategory.Thing,
            RequiredGold = 0,
            rarity = Resource.Rarity.Rare,
            RequiredResources = new List<Resource>
            {
                 new Resource { rarity = Resource.Rarity.Rare, count = 9 },
                 new Resource { rarity = Resource.Rarity.Epic, count = 1 },
            },

            ResultItem = new Item
            {
                id = "62",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Rare,
                name = "Странная вилка",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+24+1|Permanent|Remove"),
                },
            }
        },
        new Recipe
        { count = 1,
            id = "63",
            name = "Странная вилка",
            Category = ItemCategory.Thing,
            RequiredGold = 0,
            rarity = Resource.Rarity.Epic,
            RequiredResources = new List<Resource>
            {
                 new Resource { rarity = Resource.Rarity.Rare, count = 1 },
                 new Resource { rarity = Resource.Rarity.Epic, count = 9 },
            },

            ResultItem = new Item
            {
                id = "63",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Epic,
                name = "Странная вилка",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+75+1|Permanent|Remove"),
                },
            }
        },
        new Recipe
        { count = 1,
            id = "64",
            name = "Странная вилка",
            Category = ItemCategory.Thing,
            RequiredGold = 0,
            rarity = Resource.Rarity.Legendary,
            RequiredResources = new List<Resource>
            {
                 new Resource { rarity = Resource.Rarity.Common, count = 1 },
                 new Resource { rarity = Resource.Rarity.Rare, count = 3 },
                 new Resource { rarity = Resource.Rarity.Epic, count = 5 },
                 new Resource { rarity = Resource.Rarity.Legendary, count = 1 },
            },

            ResultItem = new Item
            {
                id = "64",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Legendary,
                name = "Странная вилка",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+225+1|Permanent|Remove"),
                },
            }
        },

        // [7(*)]
        new Recipe
        { count = 1,
            id = "71",
            name = "Палка о двух концах",
            Category = ItemCategory.Thing,
            RequiredGold = 0,
            rarity = Resource.Rarity.Common,
            RequiredResources = new List<Resource>
            {
                 new Resource { rarity = Resource.Rarity.Common, count = 10 },
            },

            ResultItem = new Item
            {
                id = "71",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Common,
                name = "Палка о двух концах",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+5+1|Permanent|Remove"),
                },
            }
        },
        new Recipe
        { count = 1,
            id = "72",
            name = "Палка о двух концах",
            Category = ItemCategory.Thing,
            RequiredGold = 0,
            rarity = Resource.Rarity.Rare,
            RequiredResources = new List<Resource>
            {
                 new Resource { rarity = Resource.Rarity.Rare, count = 10 },
            },

            ResultItem = new Item
            {
                id = "72",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Rare,
                name = "Палка о двух концах",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+20+1|Permanent|Remove"),
                },
            }
        },
        new Recipe
        { count = 1,
            id = "73",
            name = "Палка о двух концах",
            Category = ItemCategory.Thing,
            RequiredGold = 0,
            rarity = Resource.Rarity.Epic,
            RequiredResources = new List<Resource>
            {
                 new Resource { rarity = Resource.Rarity.Rare, count = 5 },
                 new Resource { rarity = Resource.Rarity.Epic, count = 5 },
            },

            ResultItem = new Item
            {
                id = "73",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Epic,
                name = "Палка о двух концах",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+80+1|Permanent|Remove"),
                },
            }
        },
        new Recipe
        { count = 1,
            id = "74",
            name = "Палка о двух концах",
            Category = ItemCategory.Thing,
            RequiredGold = 0,
            rarity = Resource.Rarity.Legendary,
            RequiredResources = new List<Resource>
            {
                 new Resource { rarity = Resource.Rarity.Rare, count = 6 },
                 new Resource { rarity = Resource.Rarity.Epic, count = 1 },
                 new Resource { rarity = Resource.Rarity.Legendary, count = 3 },
            },

            ResultItem = new Item
            {
                id = "74",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Legendary,
                name = "Палка о двух концах",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+256+1|Permanent|Remove"),
                },
            }
        },

        // [8(*)]
        new Recipe
        { count = 1,
            id = "81",
            name = "Китайские палочки",
            Category = ItemCategory.Thing,
            RequiredGold = 0,
            rarity = Resource.Rarity.Common,
            RequiredResources = new List<Resource>
            {
                 new Resource { rarity = Resource.Rarity.Common, count = 7 },
                 new Resource { rarity = Resource.Rarity.Rare, count = 3 },
            },

            ResultItem = new Item
            {
                id = "81",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Common,
                name = "Китайские палочки",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPC|OnAttack|NONE+Const+15+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+-5+1|Permanent|Remove"),
                },
            }
        },
        new Recipe
        { count = 1,
            id = "82",
            name = "Китайские палочки",
            Category = ItemCategory.Thing,
            RequiredGold = 0,
            rarity = Resource.Rarity.Rare,
            RequiredResources = new List<Resource>
            {
                 new Resource { rarity = Resource.Rarity.Rare, count = 10 },
            },

            ResultItem = new Item
            {
                id = "82",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Rare,
                name = "Китайские палочки",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPC|OnAttack|NONE+Const+30+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+-17+1|Permanent|Remove"),
                },
            }
        },
        new Recipe
        { count = 1,
            id = "83",
            name = "Китайские палочки",
            Category = ItemCategory.Thing,
            RequiredGold = 0,
            rarity = Resource.Rarity.Epic,
            RequiredResources = new List<Resource>
            {
                 new Resource { rarity = Resource.Rarity.Rare, count = 3 },
                 new Resource { rarity = Resource.Rarity.Epic, count = 7 },
            },

            ResultItem = new Item
            {
                id = "83",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Epic,
                name = "Китайские палочки",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPC|OnAttack|NONE+Const+99+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+-29+1|Permanent|Remove"),
                },
            }
        },
        new Recipe
        { count = 1,
            id = "84",
            name = "Китайские палочки",
            Category = ItemCategory.Thing,
            RequiredGold = 0,
            rarity = Resource.Rarity.Legendary,
            RequiredResources = new List<Resource>
            {
                 new Resource { rarity = Resource.Rarity.Rare, count = 3 },
                 new Resource { rarity = Resource.Rarity.Legendary, count = 7 },
            },

            ResultItem = new Item
            {
                id = "84",
                Category = ItemCategory.Thing,
                count = 1,
                rarity = Resource.Rarity.Legendary,
                name = "Китайские палочки",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPC|OnAttack|NONE+Const+242+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+-49+1|Permanent|Remove"),
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
        //AllRecipes.AddRange(ResourceRecipes);
        //AllRecipes.AddRange(TMNTRecipes);
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
        Shuffle(result);
        return result;
    }

    public EnemyData GetEnemyDataForIdAndLevel(string id, int level)
    {
        double base_hp = 10;

        ////TRUCK//
        //base_hp = 0;
        ///

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
        return new EnemyData(hp, 1.0, dmg, new Drop
        {
            xpBaseLevel = level,
            gold = 10 * level,// * Mathf.Pow((float)1.1, level - 1),
            Resources = new List<DropResource> {
            new DropResource { Resource = new Resource { count = 1, rarity = Resource.Rarity.Common },      probability = level <= 25 ? 17 : (level <= 50 ? 4 : ( level <= 75 ? 3 : 2)) },
            new DropResource { Resource = new Resource { count = 1, rarity = Resource.Rarity.Rare },        probability = level <= 25 ? 7 : (level <= 50 ? 14 : ( level <= 75 ? 6 : 4)) },
            new DropResource { Resource = new Resource { count = 1, rarity = Resource.Rarity.Epic },        probability = level <= 25 ? 4 : (level <= 50 ? 8 : ( level <= 75 ? 17 : 7)) },
            new DropResource { Resource = new Resource { count = 1, rarity = Resource.Rarity.Legendary },   probability = level <= 25 ? 2 : (level <= 50 ? 4 : ( level <= 75 ? 4 : 17)) },
        },
            Recipes = RecipesForLevel(level)
        });
    }

    public void Shuffle<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    List<Recipe> CommonRecipes { get { return AllRecipes.FindAll(rec => rec.id == "1011"); } }// { get { return AllRecipes.FindAll(rec => rec.rarity == Resource.Rarity.Common); } }
    List<Recipe> RareRecipes { get { return AllRecipes.FindAll(rec => rec.rarity == Resource.Rarity.Rare); } }
    List<Recipe> EpicRecipes { get { return AllRecipes.FindAll(rec => rec.rarity == Resource.Rarity.Epic); } }
    List<Recipe> LegendaryRecipes { get { return AllRecipes.FindAll(rec => rec.rarity == Resource.Rarity.Legendary); } }

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
            new DropRecipe { Recipe = (Recipe)RandomElement(CommonRecipes).Clone(),    /* probability = 100 }, */ probability = level <= 25 ? 17 / 2.0 : (level <= 50 ? 4/ 2.0 : ( level <= 75 ? 3/ 2.0 : 2/ 2.0)) },
            new DropRecipe { Recipe = (Recipe)RandomElement(RareRecipes).Clone(),      /* probability = 100 }, */ probability = level <= 25 ? 7/ 2.0 : (level <= 50 ? 14/ 2.0 : ( level <= 75 ? 6/ 2.0 : 4/ 2.0)) },
            new DropRecipe { Recipe = (Recipe)RandomElement(EpicRecipes).Clone(),      /* probability = 100 }, */ probability = level <= 25 ? 4/ 2.0 : (level <= 50 ? 8/ 2.0 : ( level <= 75 ? 17/ 2.0 : 7/ 2.0)) },
            new DropRecipe { Recipe = (Recipe)RandomElement(LegendaryRecipes).Clone(), /*probability = 100 }, */ probability = level <= 25 ? 2/ 2.0 : (level <= 50 ? 4/ 2.0 : ( level <= 75 ? 4/ 2.0 : 17/ 2.0)) },
        };


        return res;
    }

    public void GetGoodsList(ItemCategory Category, RecipeList completion)
    {
        var Recipes = new List<Recipe>();
        var player = Services.GetInstance().GetPlayer();
        var level = player.CoolLevel;


        switch (Category)
        {
            case ItemCategory.Thing:
                Recipes.AddRange(new List<Recipe> {
            new Recipe { count = 1,
            id = "common_resource",
            name = "COMMON RESOURCE",
                Category = ItemCategory.Thing,
            RequiredGold = 10,

            ResultResource = new Resource { count = 1, rarity = Resource.Rarity.Common },
            IsPermanent = true

        },

        new Recipe { count = 1,
            id = "rare_resource",
            name = "RARE RESOURCE",
            Category = ItemCategory.Thing,
            RequiredGold = 100,

            ResultResource = new Resource { count = 1, rarity = Resource.Rarity.Rare },
            IsPermanent = true

        },
                new Recipe { count = 1,
            id = "epic_resource",
            name = "EPIC RESOURCE",
            Category = ItemCategory.Thing,
            RequiredGold = 1000,

            ResultResource = new Resource { count = 1, rarity = Resource.Rarity.Epic },
            IsPermanent = true

        },
                new Recipe { count = 1,
            id = "legendary_resource",
            name = "LEGENDARY RESOURCE",
            Category = ItemCategory.Thing,
            RequiredGold = 10000,

            ResultResource = new Resource { count = 1, rarity = Resource.Rarity.Legendary },
            IsPermanent = true

        }});

                Recipes.AddRange(AllGoods.FindAll(good=>{
                    return good.rarity == Resource.Rarity.Common && good.Category == ItemCategory.Thing;
                }));
               
                if (level >= 25) Recipes.AddRange(AllGoods.FindAll(good => {
                    return good.rarity == Resource.Rarity.Rare && good.Category == ItemCategory.Thing;
                }));

                if (level >= 50) Recipes.AddRange(AllGoods.FindAll(good => {
                    return good.rarity == Resource.Rarity.Epic && good.Category == ItemCategory.Thing;
                }));

                if (level >= 75) Recipes.AddRange(AllGoods.FindAll(good => {
                    return good.rarity == Resource.Rarity.Legendary && good.Category == ItemCategory.Thing;
                }));


                break;
            case ItemCategory.Clothes:
                break;
            case ItemCategory.Weapon:
                Recipes.AddRange(AllGoods.FindAll(good => {
                    return good.rarity == Resource.Rarity.Common && good.Category == ItemCategory.Weapon;
                }));

                if (level >= 25) Recipes.AddRange(AllGoods.FindAll(good => {
                    return good.rarity == Resource.Rarity.Rare && good.Category == ItemCategory.Weapon;
                }));

                if (level >= 50) Recipes.AddRange(AllGoods.FindAll(good => {
                    return good.rarity == Resource.Rarity.Epic && good.Category == ItemCategory.Weapon;
                }));

                if (level >= 75) Recipes.AddRange(AllGoods.FindAll(good => {
                    return good.rarity == Resource.Rarity.Legendary && good.Category == ItemCategory.Weapon;
                }));
                break;
            case ItemCategory.Transport:
                var transports = player.Inventory.Items.FindAll(item => item.Category == ItemCategory.Transport);
                Recipes.AddRange(TransportGood.FindAll(transport=>transport.RequiredLevel <=level &&
                                                        transport.id != (player.ActiveTransport == null ? "" : player.ActiveTransport.id) &&
                                                        transports.Find(tr => tr.id == transport.id) == null)
                );
                break;
            case ItemCategory.Skill:
                break;
        }


        completion(Recipes);
    }

    public Sprite GetSpriteForID(string id)
    {
        //var  a = Resources.Load<Sprite>("Sprites/" + id);
        var valideID = id;
        switch (id)
        {
            case "Items/1011":
            case "Items/1012":
            case "Items/1013":
            case "Items/1014":
                valideID = "Items/hero_sword";
                break;
            case "Items/1021":
            case "Items/1022":
            case "Items/1023":
            case "Items/1024":
                valideID = "Items/item_id_10";
                break;
            case "Items/11":
            case "Items/12":
            case "Items/13":
            case "Items/14":
                valideID = "Items/item_id_2";
                break;
            case "Items/21":
            case "Items/22":
            case "Items/23":
            case "Items/24":
                valideID = "Items/item_id_3";
                break;
            case "Items/31":
            case "Items/32":
            case "Items/33":
            case "Items/34":
                valideID = "Items/item_id_4";
                break;
            case "Items/41":
            case "Items/42":
            case "Items/43":
            case "Items/44":
                valideID = "Items/item_id_5";
                break;
            case "Items/51":
            case "Items/52":
            case "Items/53":
            case "Items/54":
                valideID = "Items/item_id_6";
                break;
            case "Items/61":
            case "Items/62":
            case "Items/63":
            case "Items/64":
                valideID = "Items/item_id_7";
                break;
            case "Items/71":
            case "Items/72":
            case "Items/73":
            case "Items/74":
                valideID = "Items/item_id_8";
                break;
            case "Items/81":
            case "Items/82":
            case "Items/83":
            case "Items/84":
                valideID = "Items/item_id_9";
                break;
            default:
                Debug.Log(id);
                break;
        }
        return Resources.Load<Sprite>("Sprites/" + valideID);
    }

    public double GetXpForNextLevel(int currentLevel)
    {
        return 1000 + 500 * currentLevel;
    }

    public Recipe GetRecipeForId(string id)
    {
        return AllRecipes.Find(recipe => recipe.id == id);
    }

    List<int> a = new List<int> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281, 283, 293, 307, 311, 313, 317, 331, 337, 347, 349, 353, 359, 367, 373, 379, 383, 389, 397, 401, 409, 419, 421, 431, 433, 439, 443, 449, 457, 461, 463, 467, 479, 487, 491, 499, 503, 509, 521, 523, 541, 547, 557 };

    public double BaseDamagePerClickForLevel(int level)
    {
        double res = 0;
        for (int i = 0; i <= level; i++)
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

        return player.Gold >= CostForParameterForLevel(parameter, level + 1) && level + 1 < (bigParameter ? 100 : 10);// && level + 1 < (player.CoolLevel + 1) * 5;
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
        heroes.RemoveAll((id) =>
        {
            return player.availableHeroes.Contains(id) || player.CurrentHeroId == id;
        });

        completion(heroes);
    }
}
