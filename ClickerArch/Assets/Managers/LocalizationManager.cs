using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LocalizationManager
{
    public static event VoidFunc languageChanged;

    public static Sprite flagImage(string id)
    {
        return Resources.Load<Sprite>("Sprites/Flags/" + id);
    }

    public static Sprite currentImage
    {
        get
        {
            return flagImage(currentLanguageId);
        }
    }

    public static string currentLanguageId = "";
    static int currentLanguageIndex;

    public static void SetupLanguage(string id)
    {
        var language = languages.Find(x => x.languageCode == id);
        if (language != null)
        {

            currentLanguageId = id;
            currentLanguageIndex = languages.FindIndex(x => x.languageCode == id);

            local = language;
            PlayerPrefs.SetString("Language", id);
            languageChanged?.Invoke();
        }
    }

    public static void NextLanguage()
    {
        if (currentLanguageIndex == languages.Count - 1)
        {
            SetupLanguage(languages[0].languageCode);
        }
        else
        {
            SetupLanguage(languages[currentLanguageIndex + 1].languageCode);
        }


    }

    public static string GetDescriptionForHeroId(string heroId)
    {
        var description = "";
        switch (heroId)
        {
            //COMMON
            //Helper.ColorText("", "")
            case "Adventurer":
                return Helper.ColorText("blue", "Приключенец") + Helper.ColorText("#999999", "(passive)") + "\n" +
                "В своих странствиях Путешественник научился набираться опыта быстрее своих товарищей." + "\n" +
                "Количество получаемого " + Helper.BlueText("EXP") + " при убийстве противника " + Helper.BlueText(" + 10 %") + "." + "\n" +

                Helper.BlueText("За-Ши-Бу") + "(active)" + "\n" +
                "Во время своих странствий Путешественник изучил доселе невиданный стиль боя." + "\n" +
                "Удары становатся сильнее и размашистее, но снижается защита." + "\n" +
                Helper.RedText("DPC + 100 % ") + "," + Helper.BlueText("входящий урон увеличивается на 30 %.") + "\n" +
                Helper.YellowText("Время действия:") + " 10 секунд." + "\n" +
                Helper.YellowText("Перезарядка:") + " 70 секунд." + "\n";

            case "ArenaWarrior":
                return Helper.ColorText("blue", "Охлаждающий пыл") + Helper.ColorText("#999999", "(active)") + "\n" +
                "На арене приходится заботиться не только об атаке, но и о защите." + "\n" +
                "Воин Арены становится в стойку, в которой " + Helper.BlueText("входящий урон") + " уменьшается на " + Helper.BlueText(" 75 %") + "\n" +
                "но вместе с тем и уменьшается на " + Helper.BlueText("25 %") + " его" + Helper.RedText(" DPC") + "." + "\n" +
                Helper.YellowText("Время действия:") + " 10 секунд." + "\n" +
                Helper.YellowText("Перезарядка:") + " 70 секунд." + "\n" +

                Helper.BlueText("Руби с плеча") + "(active)" + "\n" +
                "Воин Арены совершает сокрушительный рубящий удар мечём," + "\n" +
                "нанося противнику разовый урон, равный " + Helper.BlueText("30 %") + "\n" +
                " от максимального запаса здоровья врага." + "\n" +
                Helper.YellowText("Время действия:") + " мгновенно." + "\n" +
                Helper.YellowText("Перезарядка:") + " 25 секунд." + "\n";

            case "ArmorWarrior":
                return Helper.ColorText("blue", "Лучшее нападение - защита") + Helper.ColorText("#999999", "(passive)") + "\n" +
                "У Бронированого Рыцаря своеобразная броня. Окованная мелкими шипами по всей площади," + "\n" +
                "Атакуя Бронированого рыцаря враги получают " + Helper.BlueText("50 %") + "\n" +
                "от нанесённого урона." + "\n" +

                Helper.BlueText("Черепокол") + "(active)" + "\n" +
                "Бронированый рыцарь наносит мощный вертикальный удар своим длинным мечём," + "\n" +
                "нанося противнику" + "\n" + Helper.RedText("1000 %") + " урона от " + Helper.RedText("DPC") + ".\n" +
                Helper.YellowText("Время действия:") + " мгновенно." + "\n" +
                Helper.YellowText("Перезарядка:") + " 35 секунд." + "\n";

            case "Assassin":
                return Helper.ColorText("blue", "Брат Акры") + Helper.ColorText("#999999", "(passive)") + "\n" +
                "Проходя обучение в братстве Акры, ассасин научился быть неуловимым даже в пылу сражения." + "\n" +
                "Каждая  " + Helper.BlueText("3") + "-я атака по ассасину " + Helper.BlueText(" промахивается") + ", не нанося ему повреждений." +"\n" +

                Helper.BlueText("Скрытый клинок") + "(active)" + "\n" +
                "Ассасин смазывет ядом свой клинок, отравляя противников." + "\n" +
                "Противники получают повышенный переодический урон в размере " + Helper.RedText("300% DPS") + "\n" +
                Helper.YellowText("Время действия:") + " 30 секунд." + "\n" +
                Helper.YellowText("Перезарядка:") + " 45 секунд." + "\n";

            case "CityBouncer":
                return Helper.ColorText("blue", "Наболдашник") + Helper.ColorText("#999999", "(active)") + "\n" +
                "Городской Вышибала бьёт противника навершием своего меча по голове, " + Helper.BlueText("оглушая") + " его." + "\n" +
                Helper.YellowText("Время действия:") + " 10 секунд." + "\n" +
                Helper.YellowText("Перезарядка:") + " 40 секунд." + "\n" +

                Helper.BlueText("Улица лучшая школа") + "(active)" + "\n" +
                "Городской Вышибала наносит глубокий рубящий удар, заставляя противника истекать кровью." + "\n" +
                "Противник получает повышеный в " + Helper.RedText("2.5") + " раза " + Helper.RedText(" DPS") + ".\n" +
                Helper.YellowText("Время действия:") + " 20 секунд." + "\n" +
                Helper.YellowText("Перезарядка:") + " 35 секунд." + "\n";

            case "Cyberclockwerk":
                return Helper.ColorText("blue", "Киберимплант") + Helper.ColorText("#999999", "(active)") + "\n" +
                "Киберчасовой активирует свой киберимплант, увеличивая рефлексы," + "\n" +
                "что позволяет ему эффективнее действовать в форс - мажорных ситуациях." + "\n" +
                "Каждая атака становится критической, нанося " + Helper.RedText("200 % урона от DPC") + ".\n" +
                Helper.YellowText("Время действия:") + " 20 секунд." + "\n" +
                Helper.YellowText("Перезарядка:") + " 45 секунд." + "\n" +

                Helper.BlueText("Аккомулятор") + "(passive)" + "\n" +
                "Киберчасовой получает модификацию, которая позволяет ему добывать энергию поверженых врагов." + "\n" +
                "Противник получает повышеный в " + Helper.RedText("2.5") + " раза " + Helper.RedText(" DPS") + ".\n" +
                "Каждый побеждённый противник" + Helper.BlueText("уменьшает время перезарядки умения \"Киберимплант\" на 1 секунду.") + "\n";

            case "Gunslinger":
                return Helper.ColorText("blue", "Ложись!") + Helper.ColorText("#999999", "(active)") + "\n" +
                "Стрелок бросает под ноги врагу свето-шумовую гранату, которая " + Helper.BlueText("оглушает") + " его." + "\n" +
                Helper.YellowText("Время действия:") + " 7 секунд." + "\n" +
                Helper.YellowText("Перезарядка:") + " 35 секунд." + "\n" +

                Helper.BlueText("Усмирительный огонь") + "(active)" + "\n" +
                "Стрелок заряжает свою винтовку особыми разрывными снарядами, увеличивая пассивный урон" +"\n" +
                "в размере " + Helper.RedText("(DPC+DPS)*1.2") + ".\n" +
                Helper.YellowText("Время действия:") + " 15 секунд." + "\n" +
                Helper.YellowText("Перезарядка:") + " 70 секунд." + "\n";

            case "Hastat":
                return Helper.ColorText("blue", "Выпад") + Helper.ColorText("#999999", "(active)") + "\n" +
                "Гастат совершает мощный колющий удар своим гладиусом, нанося огромный урон защите противника." + "\n" +
                "Противник получает разовый урон в размере " + Helper.BlueText("30%") + " от своего " + Helper.BlueText("максимального здоровья.") + "\n" +
                "Если во время применения" + Helper.BlueText("здоровье") + "противника меньше или равно " + Helper.BlueText("30 %") + "-убивает его" + ".\n" +
                Helper.YellowText("Время действия:") + " мгновенно." + "\n" +
                Helper.YellowText("Перезарядка:") + " 30 секунд." + "\n" +

                Helper.BlueText("Строевая подготовка") + "(passive)" + "\n" +
                "Научившись работать в плотном строю, Гастат в совершенстве овладел атакой-выпадом." + "\n" +
                "Каждый раз, когда " + Helper.BlueText("\"Выпад\" добивает противника") + " - умение" + Helper.BlueText("не уходит на перезарядку") + ".\n";

            case "LightBandit":
                return Helper.ColorText("blue", "Навались!") + Helper.ColorText("#999999", "(active)") + "\n" +
                "Бандит свистом призывает свою банду из 5ти негодяев, и вместе с ней избивает недругов." + "\n" +
                Helper.RedText("DPS") + " увеличивается в размере " + Helper.RedText("DPS+(DPC*5)") + "\n" +
                Helper.YellowText("Время действия:") + " 20 секунд." + "\n" +
                Helper.YellowText("Перезарядка:") + " 60 секунд." + "\n" +

                Helper.BlueText("Карманник") + "(passive)" + "\n" +
                "Убивая врага Бандит тщательнее осматривает жертву, вдруг что-то завалялось в паре сапог." + "\n" +
                "Количество получаемого " + Helper.BlueText("GOLD") + " при убийстве противника увеличиваестя на " + Helper.BlueText("10%") + ".\n";

            case "MedievalKing":
                return Helper.ColorText("blue", "Королевский удар") + Helper.ColorText("#999999", "(active)") + "\n" +
                "Меч Короля всегда должен соответствовать статусу, но его реставрация - дело не из дешёвых." + "\n" +
                "Средневековый Король совершает удар с размахом, который наносит противнику " + Helper.RedText("50 % урона от максимального здоровья") + "," + "\n" +
                "однако Средневековый Король теряет " + Helper.BlueText("GOLD") + " в размере 5 % от " + Helper.BlueText("максимального здоровья жертвы.") + "\n" +
                Helper.YellowText("Время действия:") + " мгновенно." + "\n" +
                Helper.YellowText("Перезарядка:") + " 25 секунд." + "\n" +

                Helper.BlueText("Агрессивные переговоры") + "(passive)" + "\n" +
                "Хороший Король всегда должен уметь решить спор не только силой, но и словом." + "\n" +
                "Получаемое с противников " + Helper.BlueText("EXP и GOLD") + " увеличивается на " + Helper.BlueText("7%,") + " но " + Helper.RedText("DPC") + " уменьшается на " + Helper.BlueText("13%") + ".\n";

            case "Ninja":
                return Helper.ColorText("blue", "Маска бога смерти") + Helper.ColorText("#999999", "(active)") + "\n" +
                "Надевая маску, Ниндзя повергает врагов в ужас, а в его движениях чувствуется уверенность." + "\n" +
                "Враги " + Helper.BlueText("оглушаются") + ", а " + Helper.RedText("DPC") + " Ниндзи увеличивается в размере " + Helper.RedText("DPC * 1.5") + ".\n" +
                Helper.YellowText("Время действия:") + " 5 секунд." + "\n" +
                Helper.YellowText("Перезарядка:") + " 25 секунд." + "\n" +

                Helper.BlueText("Мастерство У-Тан Шань") + "(passive)" + "\n" +
                "Обучаясь боевому искусству в школе даосов, Ниндзя научился контролировать своё тело и душу." + "\n" +
                Helper.RedText("DPC") + " и " + Helper.RedText("DPS") + " уравниваются по большему показателю" + ".\n";


            case "Squire":
                return "Базовый персонаж с умениями, которые есть у всех" + "\n" + Helper.ColorText("blue", "Лечение") + Helper.ColorText("#999999", "(active)") + "\n" +
                "Востанавливает половину HP" + "\n" +
                Helper.YellowText("Перезарядка:") + " 120 секунд." + "\n" +

                Helper.BlueText("Фатальный удар") + "(active)" + "\n" +
                "Наноситу урон равный половине HP врага" + "\n" +
                Helper.YellowText("Перезарядка:") + " 80 секунд." + "\n";

            //RARE

            case "Archer": break;

            case "HeroKnight": break;

            case "Janissary": break;

            case "GothicHero": break;

            case "Blacksmith": break;

            case "BlueKing": break;

            case "Monk": break;

            case "Ranger": break;

            case "Robot": break;

            case "RoyalKnight": break;

            case "Samurai": break;

            case "Striker": break;

            case "Wizard": break;

        }
        return description;
    }


    public static string GetDescriptionForItemId(string itemId)
    {
        var description = "";
        switch (itemId)
        {
            case "common_resource":
                return "Материалы обычного качества";
            case "rare_resource":
                return "Материалы редкого качества";
            case "epic_resource":
                return "Материалы епического качества";
            case "legendary_resource":
                return "Материалы легендарного качества";

            case "hero_sword":
                return "Такой острый, что можно порезаться, едва взглянув на него… Ой!!";
        }
        return description;
    }

    public static string GetDescriptionForRecipeId(string recipeId)
    {
        var description = "";
        switch (recipeId)
        {
            case "recipe_common_resource":
                return "Материалы обычного качества";
            case "recipe_rare_resource":
                return "Материалы редкого качества";
            case "recipe_epic_resource":
                return "Материалы епического качества";
            case "recipe_legendary_resource":
                return "Материалы легендарного качества";

            case "recipe_hero_sword":
                return "Такой острый, что можно порезаться, едва взглянув на него… Ой!!";

        }
        return description;
    }



    static List<LocalizateSet> languages = new List<LocalizateSet>()
    {
        new LocalizateSet()
    {
        languageCode = "ru",
        languageName = "Русский",

        Settings = "Настройки",
        Music = "Музыка",
        Sound = "Звуки",
        Language = "Язык",
        Back = "Назад",
        EnterName = "Введите имя...",
        Create = "Создать",
        Pause = "Пауза",
        Exit = "Выйти",

        max = "Максимальный уровень",

        hp = Helper.ColorText("red", "❤"),
        heal = Helper.ColorText("red", "❤+"),
        time = Helper.ColorText("yellow", "время действия"),
        count = Helper.ColorText("yellow", "количество"),
        buff = Helper.ColorText("green", "усиление"),
        damage = Helper.ColorText("red", "урон"),
        countdown = Helper.ColorText("orange", "⌛"),
        duration = Helper.ColorText("#ffa500ff", "длительность"),

        Continue = "Продолжить",
        Upgrade = "Улучшить",

        CreateProfile = "Создайте профиль",

        EndGameMessage = "Поздравляю!\nВы прошли игру. Можете дальше проходить миссии в своё удовольствие",
        DeleteConfirmation = "Вы уверены, что хотите удалить профиль: ",
        CreateError = "Ошибка создания профиля! Имя должно быть не менее 4-х символов, не содержать спец символов и быть уникальным",
        BuyAccept = "Вы уверены, что хотите купить героя: ",
        QuitAccept = "Вы уверены, что хотите выйти?",

        ////

    },
        new LocalizateSet()
    {
        languageCode = "ua",
        languageName = "Українська",

        Settings = "Налаштування",
        Music = "Музика",
        Sound = "Звуки",
        Language = "Мова",
        Back = "Назад",
        EnterName = "Введіть ім'я...",
        Create = "Створити",
        Pause = "Пауза",
        Exit = "Вийти",

        max = "Максимальний рівень",

        hp = Helper.ColorText("red", "❤"),
        heal = Helper.ColorText("red", "❤+"),
        time = Helper.ColorText("yellow", "час дії"),
        count = Helper.ColorText("yellow", "кількість"),
        buff = Helper.ColorText("green", "посилення"),
        damage = Helper.ColorText("red", "шкода"),
        countdown = Helper.ColorText("orange", "⌛"),
        duration = Helper.ColorText("#ffa500ff", "тривалість"),

        Continue = "Продовжити",
        Upgrade = "Вдосконалити",

        CreateProfile = "Створіть профіль",
        //////
EndGameMessage = "Вітаю!\nВи пройшли гру. Можете далі проходити місії в своє задоволення.",
DeleteConfirmation = "Ви впевнені, що хочете видалити профіль:",
CreateError = "Помилка створення профілю! Ім'я повинно бути не менше 4-х і не більше 12-и символів, не містити спецсимволів і бути унікальним",

        BuyAccept = "Ви впевнені, що хочете придбати героя: ",
        QuitAccept = "Ви впевнені, що хочете вийти?",

        ////
    },
        new LocalizateSet()
    {
        languageCode = "en",
        languageName = "English",

        Settings = "Settings",
        Music = "Music",
        Sound = "Sounds",
        Language = "Language",
        Back = "Back",
        EnterName = "Enter name ...",
        Create = "Create",
        Pause = "Pause",
        Exit = "Exit",

        max = "Maximum level",

        hp = Helper.ColorText("red", "❤"),
        heal = Helper.ColorText("red", "❤+"),
        time = Helper.ColorText("yellow", "time of action"),
        count = Helper.ColorText("yellow", "quantity"),
        buff = Helper.ColorText("green", "strengthening"),
        damage = Helper.ColorText("red", "damage"),
        countdown = Helper.ColorText("orange", "⌛"),
        duration = Helper.ColorText("#ffa500ff", "duration"),

        Continue = "Continue",
        Upgrade = "Upgrade",
        CreateProfile = "Create profile",

EndGameMessage = "Congratulations!\nYou passed the game. You can continue to pass missions at your own pleasure",
DeleteConfirmation = "Are you sure you want to delete the profile:",
CreateError = "Error creating profile! Name must be at least 4 and no more than 12 characters, not contain special characters and be unique",
BuyAccept = "Are you sure you want to buy a hero: ",
QuitAccept = "Are you sure you want to quit?"

    }
};

    public static LocalizateSet local = null;



}

public class KeyValue {
    public string Key;
    public string Value;
}



[Serializable]
public class LocalizateSet
{
    bool isBinded = false;
    public string languageCode = "";
    public string languageName = "";

    public string Settings = "";
    public string Music = "";
    public string Sound = "";
    public string Language = "";
    public string Back = "";
    public string EnterName = "";
    public string Create = "";
    public string Pause = "";
    public string Exit = "";
    public string Continue = "";
    public string Upgrade = "";

    public string max = "";

    public string hp = "";
    public string heal = "";
    public string time = "";
    public string count = "";
    public string buff = "";
    public string damage = "";
    public string countdown = "";
    public string duration = "";

    public string EndGameMessage = "";
    public string DeleteConfirmation = "";
    public string CreateError = "";
    public string BuyAccept = "";
    public string QuitAccept = "";
    public string CreateProfile = "";

  
    public Dictionary<string, string> keyValuePairs = new Dictionary<string, string>() {
        { "Truck1", "Truck1Value" },
        { "Truck2", "Truck2Value" },
        { "Truck3", "Truck3Value" },


    };

    [SerializeField]
    public List<KeyValue> keyValueList = new List<KeyValue> {
        new KeyValue { Key = "Truck1", Value = "Truck1Value" },
        new KeyValue { Key = "Truck2", Value = "Truck1Value" },
        new KeyValue { Key = "Truck3", Value = "Truck1Value" },
    };

    public void Bind()
    {
        keyValuePairs["languageName"] = languageName;

        keyValuePairs["Settings"] = Settings;
        keyValuePairs["Music"] = Music;
        keyValuePairs["Sound"] = Sound;
        keyValuePairs["Language"] = Language;
        keyValuePairs["Back"] = Back;
        keyValuePairs["EnterName"] = EnterName;
        keyValuePairs["Create"] = Create;
        keyValuePairs["Pause"] = Pause;
        keyValuePairs["Exit"] = Exit;

        keyValuePairs["hp"] = hp;
        keyValuePairs["heal"] = heal;
        keyValuePairs["time"] = time;
        keyValuePairs["count"] = count;
        keyValuePairs["buff"] = buff;
        keyValuePairs["damage"] = damage;
        keyValuePairs["countdown"] = countdown;
        keyValuePairs["duration"] = duration;

        keyValuePairs["Continue"] = Continue;
        keyValuePairs["Upgrade"] = Upgrade;


        keyValuePairs["EndGameMessage"] = EndGameMessage;
        keyValuePairs["DeleteConfirmation"] = DeleteConfirmation;
        keyValuePairs["CreateError"] = CreateError;
        keyValuePairs["BuyAccept"] = BuyAccept;
        keyValuePairs["QuitAccept"] = QuitAccept;
        keyValuePairs["CreateProfile"] = CreateProfile;

        isBinded = true;
    }

    public string GetValueForId(string id)
    {
        if (!isBinded) Bind();
        return keyValuePairs[id];
    }

    public static void SaveTemplate()
    {
        var empty = new LocalizateSet();
        ReadWriteManager.Save("Localized", "template", empty);
    }



}
