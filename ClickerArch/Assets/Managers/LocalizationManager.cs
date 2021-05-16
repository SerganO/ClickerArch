using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData
{
    public string name = "";
    public string description = "";
}

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

    public static string GetTextDescriptionForParameter(HeroParameter parameter)
    {
        var description = "";
        switch(currentLanguageId)
        {
            case "ru":
                switch (parameter)
                {
                    case HeroParameter.HP:
                        description += "Очки жизниы";
                        break;
                    case HeroParameter.DPC:
                        description += "Урон за клик";
                        break;
                    case HeroParameter.DPS:
                        description += "Урон в секунду";
                        break;
                    case HeroParameter.Block:
                        description += "Блок";
                        break;
                    case HeroParameter.Reflect:
                        description += "Отраженый урон";
                        break;
                    case HeroParameter.AdditionalGold:
                        description += "Дополнительное золото";
                        break;
                    case HeroParameter.AdditionalXP:
                        description += "Дополнительный опыт";
                        break;
                }
                break;
            case "ua":
                switch (parameter)
                {
                    case HeroParameter.HP:
                        description += "Життя";
                        break;
                    case HeroParameter.DPC:
                        description += "Пошкодження за клік";
                        break;
                    case HeroParameter.DPS:
                        description += "Пошкодження в секунду";
                        break;
                    case HeroParameter.Block:
                        description += "Блок";
                        break;
                    case HeroParameter.Reflect:
                        description += "Поверненні пошкодження";
                        break;
                    case HeroParameter.AdditionalGold:
                        description += "Додаткове золото";
                        break;
                    case HeroParameter.AdditionalXP:
                        description += "Додатковий досвід";
                        break;
                }
                break;
            case "en":
                switch (parameter)
                {
                    case HeroParameter.HP:
                        description += "Healt Point";
                        break;
                    case HeroParameter.DPC:
                        description += "Damage per Click";
                        break;
                    case HeroParameter.DPS:
                        description += "Damage per Second";
                        break;
                    case HeroParameter.Block:
                        description += "Block";
                        break;
                    case HeroParameter.Reflect:
                        description += "Reflect";
                        break;
                    case HeroParameter.AdditionalGold:
                        description += "Additional Gold";
                        break;
                    case HeroParameter.AdditionalXP:
                        description += "Additional XP";
                        break;
                }
                break;
        }
        
        return description;
    }

    public static string GetDescriptionForParameter(HeroParameter parameter, bool isUpgrade = true)
    {
        var player = Services.GetInstance().GetPlayer();
        var level = player.LevelForParameter(parameter);
        var dataService = Services.GetInstance().GetDataService();

        var description = GetTextDescriptionForParameter(parameter) + Environment.NewLine;


        if(isUpgrade)
        {
            description = "+";


            description += dataService.ValueForParameterForLevel(parameter, level + 1) - dataService.ValueForParameterForLevel(parameter, level);
            //switch (parameter)
            //{
            //    case HeroParameter.HP:
            //        description += (dataService.MaximumHealthPointForLevel(player.MaximumHealthPointLevel + 1) - dataService.MaximumHealthPointForLevel(player.MaximumHealthPointLevel)).ToString();
            //        break;
            //    case HeroParameter.DPC:
            //        description += (dataService.BaseDamagePerClickForLevel(player.BaseDamagePerClickLevel + 1) - dataService.BaseDamagePerClickForLevel(player.BaseDamagePerClickLevel)).ToString();

            //        break;
            //    case HeroParameter.DPS:
            //        description += (dataService.BaseDamagePerSecondForLevel(player.BaseDamagePerSecondLevel + 1) - dataService.BaseDamagePerSecondForLevel(player.BaseDamagePerSecondLevel)).ToString();

            //        break;
            //    case HeroParameter.Block:
            //        description += (dataService.BaseBlockForLevel(player.BaseBlockLevel + 1) - dataService.BaseBlockForLevel(player.BaseBlockLevel)).ToString();

            //        break;
            //    case HeroParameter.Reflect:
            //        description += (dataService.BaseReflectForLevel(player.BaseReflectLevel + 1) - dataService.BaseReflectForLevel(player.BaseReflectLevel)).ToString();

            //        break;
            //    case HeroParameter.AdditionalGold:
            //        description += (dataService.AdditionalGoldForLevel(player.AdditionalGoldLevel + 1) - dataService.AdditionalGoldForLevel(player.AdditionalGoldLevel)).ToString();

            //        break;
            //    case HeroParameter.AdditionalXP:
            //        description += (dataService.AdditionalXPForLevel(player.AdditionalXPLevel + 1) - dataService.AdditionalXPForLevel(player.AdditionalXPLevel)).ToString();

            //        break;
            //}
        } else
        {
            description += dataService.ValueForParameterForLevel(parameter, level);
            //switch (parameter)
            //{
            //    case HeroParameter.HP:
            //        description += (dataService.MaximumHealthPointForLevel(player.MaximumHealthPointLevel)).ToString();
            //        break;
            //    case HeroParameter.DPC:
            //        description += (dataService.BaseDamagePerClickForLevel(player.BaseDamagePerClickLevel)).ToString();

            //        break;
            //    case HeroParameter.DPS:
            //        description += (dataService.BaseDamagePerSecondForLevel(player.BaseDamagePerSecondLevel)).ToString();

            //        break;
            //    case HeroParameter.Block:
            //        description += (dataService.BaseBlockForLevel(player.BaseBlockLevel)).ToString();

            //        break;
            //    case HeroParameter.Reflect:
            //        description += (dataService.BaseReflectForLevel(player.BaseReflectLevel)).ToString();

            //        break;
            //    case HeroParameter.AdditionalGold:
            //        description += (dataService.AdditionalGoldForLevel(player.AdditionalGoldLevel)).ToString();

            //        break;
            //    case HeroParameter.AdditionalXP:
            //        description += (dataService.AdditionalXPForLevel(player.AdditionalXPLevel)).ToString();

            //        break;
            //}
        }



        return description;

    }


    public static ItemData GetDescriptionForHeroId(string heroId)
    {
        var data = new ItemData();

    switch (currentLanguageId)
        {
            case "ru":
                switch (heroId)
                {
                    //COMMON
                    //Helper.ColorText("", "")
                    case "Adventurer":
                        data.description = Helper.ColorText("blue", "Приключенец") + Helper.ColorText("#999999", "(passive)") + "\n" +
                        "В своих странствиях Путешественник научился набираться опыта быстрее своих товарищей." + "\n" +
                        "Количество получаемого " + Helper.BlueText("EXP") + " при убийстве противника " + Helper.BlueText(" + 10 %") + "." + "\n" +

                        Helper.BlueText("За-Ши-Бу") + "(active)" + "\n" +
                        "Во время своих странствий Путешественник изучил доселе невиданный стиль боя." + "\n" +
                        "Удары становатся сильнее и размашистее, но снижается защита." + "\n" +
                        Helper.RedText("DPC + 100 % ") + "," + Helper.BlueText("входящий урон увеличивается на 30 %.") + "\n" +
                        Helper.YellowText("Время действия:") + " 10 секунд." + "\n" +
                        Helper.YellowText("Перезарядка:") + " 70 секунд." + "\n"; break;

                    case "ArenaWarrior":
                        data.description = Helper.ColorText("blue", "Охлаждающий пыл") + Helper.ColorText("#999999", "(active)") + "\n" +
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
                        Helper.YellowText("Перезарядка:") + " 25 секунд." + "\n"; break;

                    case "ArmorWarrior":
                        data.description = Helper.ColorText("blue", "Лучшее нападение - защита") + Helper.ColorText("#999999", "(passive)") + "\n" +
                        "У Бронированого Рыцаря своеобразная броня. Окованная мелкими шипами по всей площади," + "\n" +
                        "Атакуя Бронированого рыцаря враги получают " + Helper.BlueText("50 %") + "\n" +
                        "от нанесённого урона." + "\n" +

                        Helper.BlueText("Черепокол") + "(active)" + "\n" +
                        "Бронированый рыцарь наносит мощный вертикальный удар своим длинным мечём," + "\n" +
                        "нанося противнику" + "\n" + Helper.RedText("1000 %") + " урона от " + Helper.RedText("DPC") + ".\n" +
                        Helper.YellowText("Время действия:") + " мгновенно." + "\n" +
                        Helper.YellowText("Перезарядка:") + " 35 секунд." + "\n"; break;

                    case "Assassin":
                        data.description = Helper.ColorText("blue", "Брат Акры") + Helper.ColorText("#999999", "(passive)") + "\n" +
                        "Проходя обучение в братстве Акры, ассасин научился быть неуловимым даже в пылу сражения." + "\n" +
                        "Каждая  " + Helper.BlueText("3") + "-я атака по ассасину " + Helper.BlueText(" промахивается") + ", не нанося ему повреждений." + "\n" +

                        Helper.BlueText("Скрытый клинок") + "(active)" + "\n" +
                        "Ассасин смазывет ядом свой клинок, отравляя противников." + "\n" +
                        "Противники получают повышенный переодический урон в размере " + Helper.RedText("300% DPS") + "\n" +
                        Helper.YellowText("Время действия:") + " 30 секунд." + "\n" +
                        Helper.YellowText("Перезарядка:") + " 45 секунд." + "\n"; break;

                    case "CityBouncer":
                        data.description = Helper.ColorText("blue", "Наболдашник") + Helper.ColorText("#999999", "(active)") + "\n" +
                        "Городской Вышибала бьёт противника навершием своего меча по голове, " + Helper.BlueText("оглушая") + " его." + "\n" +
                        Helper.YellowText("Время действия:") + " 10 секунд." + "\n" +
                        Helper.YellowText("Перезарядка:") + " 40 секунд." + "\n" +

                        Helper.BlueText("Улица лучшая школа") + "(active)" + "\n" +
                        "Городской Вышибала наносит глубокий рубящий удар, заставляя противника истекать кровью." + "\n" +
                        "Противник получает повышеный в " + Helper.RedText("2.5") + " раза " + Helper.RedText(" DPS") + ".\n" +
                        Helper.YellowText("Время действия:") + " 20 секунд." + "\n" +
                        Helper.YellowText("Перезарядка:") + " 35 секунд." + "\n"; break;

                    case "Cyberclockwerk":
                        data.description = Helper.ColorText("blue", "Киберимплант") + Helper.ColorText("#999999", "(active)") + "\n" +
                        "Киберчасовой активирует свой киберимплант, увеличивая рефлексы," + "\n" +
                        "что позволяет ему эффективнее действовать в форс - мажорных ситуациях." + "\n" +
                        "Каждая атака становится критической, нанося " + Helper.RedText("200 % урона от DPC") + ".\n" +
                        Helper.YellowText("Время действия:") + " 20 секунд." + "\n" +
                        Helper.YellowText("Перезарядка:") + " 45 секунд." + "\n" +

                        Helper.BlueText("Аккомулятор") + "(passive)" + "\n" +
                        "Киберчасовой получает модификацию, которая позволяет ему добывать энергию поверженых врагов." + "\n" +
                        "Противник получает повышеный в " + Helper.RedText("2.5") + " раза " + Helper.RedText(" DPS") + ".\n" +
                        "Каждый побеждённый противник" + Helper.BlueText("уменьшает время перезарядки умения \"Киберимплант\" на 1 секунду.") + "\n"; break;

                    case "Gunslinger":
                        data.description = Helper.ColorText("blue", "Ложись!") + Helper.ColorText("#999999", "(active)") + "\n" +
                        "Стрелок бросает под ноги врагу свето-шумовую гранату, которая " + Helper.BlueText("оглушает") + " его." + "\n" +
                        Helper.YellowText("Время действия:") + " 7 секунд." + "\n" +
                        Helper.YellowText("Перезарядка:") + " 35 секунд." + "\n" +

                        Helper.BlueText("Усмирительный огонь") + "(active)" + "\n" +
                        "Стрелок заряжает свою винтовку особыми разрывными снарядами, увеличивая пассивный урон" + "\n" +
                        "в размере " + Helper.RedText("(DPC+DPS)*1.2") + ".\n" +
                        Helper.YellowText("Время действия:") + " 15 секунд." + "\n" +
                        Helper.YellowText("Перезарядка:") + " 70 секунд." + "\n"; break;

                    case "Hastat":
                        data.description = Helper.ColorText("blue", "Выпад") + Helper.ColorText("#999999", "(active)") + "\n" +
                        "Гастат совершает мощный колющий удар своим гладиусом, нанося огромный урон защите противника." + "\n" +
                        "Противник получает разовый урон в размере " + Helper.BlueText("30%") + " от своего " + Helper.BlueText("максимального здоровья.") + "\n" +
                        "Если во время применения" + Helper.BlueText("здоровье") + "противника меньше или равно " + Helper.BlueText("30 %") + "-убивает его" + ".\n" +
                        Helper.YellowText("Время действия:") + " мгновенно." + "\n" +
                        Helper.YellowText("Перезарядка:") + " 30 секунд." + "\n" +

                        Helper.BlueText("Строевая подготовка") + "(passive)" + "\n" +
                        "Научившись работать в плотном строю, Гастат в совершенстве овладел атакой-выпадом." + "\n" +
                        "Каждый раз, когда " + Helper.BlueText("\"Выпад\" добивает противника") + " - умение" + Helper.BlueText("не уходит на перезарядку") + ".\n"; break;

                    case "LightBandit":
                        data.description = Helper.ColorText("blue", "Навались!") + Helper.ColorText("#999999", "(active)") + "\n" +
                        "Бандит свистом призывает свою банду из 5ти негодяев, и вместе с ней избивает недругов." + "\n" +
                        Helper.RedText("DPS") + " увеличивается в размере " + Helper.RedText("DPS+(DPC*5)") + "\n" +
                        Helper.YellowText("Время действия:") + " 20 секунд." + "\n" +
                        Helper.YellowText("Перезарядка:") + " 60 секунд." + "\n" +

                        Helper.BlueText("Карманник") + "(passive)" + "\n" +
                        "Убивая врага Бандит тщательнее осматривает жертву, вдруг что-то завалялось в паре сапог." + "\n" +
                        "Количество получаемого " + Helper.BlueText("GOLD") + " при убийстве противника увеличиваестя на " + Helper.BlueText("10%") + ".\n"; break;

                    case "MedievalKing":
                        data.description = Helper.ColorText("blue", "Королевский удар") + Helper.ColorText("#999999", "(active)") + "\n" +
                        "Меч Короля всегда должен соответствовать статусу, но его реставрация - дело не из дешёвых." + "\n" +
                        "Средневековый Король совершает удар с размахом, который наносит противнику " + Helper.RedText("50 % урона от максимального здоровья") + "," + "\n" +
                        "однако Средневековый Король теряет " + Helper.BlueText("GOLD") + " в размере 5 % от " + Helper.BlueText("максимального здоровья жертвы.") + "\n" +
                        Helper.YellowText("Время действия:") + " мгновенно." + "\n" +
                        Helper.YellowText("Перезарядка:") + " 25 секунд." + "\n" +

                        Helper.BlueText("Агрессивные переговоры") + "(passive)" + "\n" +
                        "Хороший Король всегда должен уметь решить спор не только силой, но и словом." + "\n" +
                        "Получаемое с противников " + Helper.BlueText("EXP и GOLD") + " увеличивается на " + Helper.BlueText("7%,") + " но " + Helper.RedText("DPC") + " уменьшается на " + Helper.BlueText("13%") + ".\n"; break;

                    case "Ninja":
                        data.description = Helper.ColorText("blue", "Маска бога смерти") + Helper.ColorText("#999999", "(active)") + "\n" +
                        "Надевая маску, Ниндзя повергает врагов в ужас, а в его движениях чувствуется уверенность." + "\n" +
                        "Враги " + Helper.BlueText("оглушаются") + ", а " + Helper.RedText("DPC") + " Ниндзи увеличивается в размере " + Helper.RedText("DPC * 1.5") + ".\n" +
                        Helper.YellowText("Время действия:") + " 5 секунд." + "\n" +
                        Helper.YellowText("Перезарядка:") + " 25 секунд." + "\n" +

                        Helper.BlueText("Мастерство У-Тан Шань") + "(passive)" + "\n" +
                        "Обучаясь боевому искусству в школе даосов, Ниндзя научился контролировать своё тело и душу." + "\n" +
                        Helper.RedText("DPC") + " и " + Helper.RedText("DPS") + " уравниваются по большему показателю" + ".\n"; break;


                    case "Squire":
                        data.description = "Базовый персонаж с умениями, которые есть у всех" + "\n" + Helper.ColorText("blue", "Лечение") + Helper.ColorText("#999999", "(active)") + "\n" +
                        "Востанавливает половину HP" + "\n" +
                        Helper.YellowText("Перезарядка:") + " 120 секунд." + "\n" +

                        Helper.BlueText("Фатальный удар") + "(active)" + "\n" +
                        "Наноситу урон равный половине HP врага" + "\n" +
                        Helper.YellowText("Перезарядка:") + " 80 секунд." + "\n"; break;

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
                break;
            case "ua":
                switch (heroId)
                {
                    // COMMON
                    //Helper.ColorText ( "", "")
                    case "Adventurer":
                        data.description = Helper.ColorText("blue", "Пріключенец") + Helper.ColorText("# 999999", "(passive)") + "\n" +
                        "У своїх мандрах Мандрівник навчився набиратися досвіду швидше своїх товаришів." + "\n" +
                        "Кількість одержуваного" + Helper.BlueText("EXP") + "при вбивстві супротивника" + Helper.BlueText("+ 10%") + "." + "\n" +

                        Helper.BlueText("За-Ши-Бу") + "(active)" + "\n" +
                        "Під час своїх мандрів Мандрівник вивчив досі небачений стиль бою." + "\n" +
                        "Удари становатся сильніше і розмашисто, але знижується захист." + "\n" +
                        Helper.RedText("DPC + 100%") + "," + Helper.BlueText("вхідний шкоди збільшується на 30%.") + "\n" +
                        Helper.YellowText("Час дії:") + "10 секунд." + "\n" +
                        Helper.YellowText("Перезарядка:") + "70 секунд." + "\n"; break;

                    case "ArenaWarrior":
                        data.description = Helper.ColorText("blue", "охолоджуючий запал") + Helper.ColorText("# 999999", "(active)") + "\n" +
                        "На арені доводиться дбати не тільки про атаку, але і про захист." + "\n" +
                        "Воїн Арени стає в стійку, в якій" + Helper.BlueText("вхідний шкоди") + "зменшується на" + Helper.BlueText("75%") + "\n" +
                        "Але в той же час і зменшується на" + Helper.BlueText("25%") + "його" + Helper.RedText("DPC") + "." + "\n" +
                        Helper.YellowText("Час дії:") + "10 секунд." + "\n" +
                        Helper.YellowText("Перезарядка:") + "70 секунд." + "\n" +

                        Helper.BlueText("Рубі з плеча") + "(active)" + "\n" +
                        "Воїн Арени робить нищівний удар, що рубає мечем," + "\n" +
                        "Завдаючи противнику разовий шкоди, рівний" + Helper.BlueText("30%") + "\n" +
                        "Від максимального запасу здоров'я ворога." + "\n" +
                        Helper.YellowText("Час дії:") + "миттєво." + "\n" +
                        Helper.YellowText("Перезарядка:") + "25 секунд." + "\n"; break;

                    case "ArmorWarrior":
                        data.description = Helper.ColorText("blue", "Краще напад - захист") + Helper.ColorText("# 999999", "(passive)") + "\n" +
                        "У бронювання Лицаря своєрідна броня. Окутої дрібними шипами по всій площі," + "\n" +
                        "Атакуючи бронювання лицаря вороги отримують" + Helper.BlueText("50%") + "\n" +
                        "Від нанесеного шкоди." + "\n" +

                        Helper.BlueText("Черепокол") + "(active)" + "\n" +
                        "Бронювання лицар завдає потужного вертикальний удар своїм довгим мечем," + "\n" +
                        "Завдаючи противнику" + "\n" + Helper.RedText("1000%") + "утрати від" + Helper.RedText("DPC") + ".\n" +
                        Helper.YellowText("Час дії:") + "миттєво." + "\n" +
                        Helper.YellowText("Перезарядка:") + "35 секунд." + "\n"; break;

                    case "Assassin":
                        data.description = Helper.ColorText("blue", "Брат Акри") + Helper.ColorText("# 999999", "(passive)") + "\n" +
                        "Проходячи навчання в братстві Акри, ассасін навчився бути невловимим навіть в запалі бою." + "\n" +
                        "Кожна" + Helper.BlueText("3") + "-я атака по ассасина" + Helper.BlueText("промахується") + ", не завдаючи йому ушкоджень." + "\n" +

                        Helper.BlueText("Прихований клинок") + "(active)" + "\n" +
                        "Ассасин смазивет отрутою свій клинок, отруюючи супротивників." + "\n" +
                        "Противники отримують підвищений переодичними шкоди в розмірі" + Helper.RedText("300% DPS") + "\n" +
                        Helper.YellowText("Час дії:") + "30 секунд." + "\n" +
                        Helper.YellowText("Перезарядка:") + "45 секунд." + "\n"; break;

                    case "CityBouncer":
                        data.description = Helper.ColorText("blue", "наболдашником") + Helper.ColorText("# 999999", "(active)") + "\n" +
                        "Міський Вишибала б'є противника навершием свого меча по голові," + Helper.BlueText("приголомшуючи") + "його." + "\n" +
                        Helper.YellowText("Час дії:") + "10 секунд." + "\n" +
                        Helper.YellowText("Перезарядка:") + "40 секунд." + "\n" +

                        Helper.BlueText("Вулиця найкраща школа") + "(active)" + "\n" +
                        "Міський Вишибала завдає глибокий рубає удар, змушуючи супротивника стікати кров'ю." + "\n" +
                        "Противник отримує підвищений в" + Helper.RedText("2.5") + "рази" + Helper.RedText("DPS") + ".\n" +
                        Helper.YellowText("Час дії:") + "20 секунд." + "\n" +
                        Helper.YellowText("Перезарядка:") + "35 секунд." + "\n"; break;

                    case "Cyberclockwerk":
                        data.description = Helper.ColorText("blue", "Кіберімплант") + Helper.ColorText("# 999999", "(active)") + "\n" +
                        "Кіберчасовой активує свій кіберімплант, збільшуючи рефлекси," + "\n" +
                "Що дозволяє йому ефективніше діяти у форс - мажорних ситуаціях." + "\n" +
                "Кожна атака стає критичною, завдаючи" + Helper.RedText("200% утрати від DPC") + ".\n" +
                Helper.YellowText("Час дії:") + "20 секунд." + "\n" +
                Helper.YellowText("Перезарядка:") + "45 секунд." + "\n" +

                Helper.BlueText("акумулятор") + "(passive)" + "\n" +
                "Кіберчасовой отримує модифікацію, яка дозволяє йому добувати енергію переможених ворогів." + "\n" +
                "Противник отримує підвищений в" + Helper.RedText("2.5") + "рази" + Helper.RedText("DPS") + ".\n" +
                "Кожен переможений противник" + Helper.BlueText("зменшує час перезарядки вміння \" Кіберімплант \"на 1 секунду.") + "\n"; break;

                    case "Gunslinger":
                        data.description = Helper.ColorText("blue", "Лягай!") + Helper.ColorText("# 999999", "(active)") + "\n" +
                        "Стрілець кидає під ноги ворогу світло-шумову гранату, яка" + Helper.BlueText("глушить") + "його." + "\n" +
                        Helper.YellowText("Час дії:") + "7 секунд." + "\n" +
                        Helper.YellowText("Перезарядка:") + "35 секунд." + "\n" +

                        Helper.BlueText("каральні вогонь") + "(active)" + "\n" +
                        "Стрілець заряджає свою гвинтівку особливими розривними снарядами, збільшуючи пасивний шкоди" + "\n" +
                        "В розмірі" + Helper.RedText("(DPC + DPS) * 1.2") + ".\n" +
                        Helper.YellowText("Час дії:") + "15 секунд." + "\n" +
                        Helper.YellowText("Перезарядка:") + "70 секунд." + "\n"; break;

                    case "Hastat":
                        data.description = Helper.ColorText("blue", "Випад") + Helper.ColorText("# 999999", "(active)") + "\n" +
                        "Гастатов робить потужний удар, що коле своїм Гладіус, завдаючи величезної шкоди захисту супротивника." + "\n" +
                        "Противник отримує разовий шкоди в розмірі" + Helper.BlueText("30%") + "від свого" + Helper.BlueText("максимального здоров'я.") + "\n" +
                        "Якщо під час застосування" + Helper.BlueText("здоров'я") + "противника менше або дорівнює" + Helper.BlueText("30%") + "-вбивати його" + ".\n" +
                        Helper.YellowText("Час дії:") + "миттєво." + "\n" +
                        Helper.YellowText("Перезарядка:") + "30 секунд." + "\n" +

                        Helper.BlueText("Стройова підготовка") + "(passive)" + "\n" +
                        "Навчившись працювати в щільному строю, гастатов досконало опанував атакою-випадом." + "\n" +
                        "Кожен раз, коли" + Helper.BlueText("\" Випад \"добиває противника") + " - вміння" + Helper.BlueText("не йде на перезарядку") + ".\n"; break;

                    case "LightBandit":
                        data.description = Helper.ColorText("blue", "навал!") + Helper.ColorText("# 999999", "(active)") + "\n" +
                        "Бандит свистом закликає свою банду з 5ти нагадав, і разом з нею б'є недругів." + "\n" +
                        Helper.RedText("DPS") + "збільшується в розмірі" + Helper.RedText("DPS + (DPC * 5)") + "\n" +
                        Helper.YellowText("Час дії:") + "20 секунд." + "\n" +
                        Helper.YellowText("Перезарядка:") + "60 секунд." + "\n" +

                        Helper.BlueText("Кишеньковий злодій") + "(passive)" + "\n" +
                        "Вбиваючи ворога Бандит ретельніше оглядає жертву, раптом щось завалялося в парі чобіт." + "\n" +
                        "Кількість одержуваного" + Helper.BlueText("GOLD") + "при вбивстві супротивника увелічіваестя на" + Helper.BlueText("10%") + ".\n"; break;

                    case "MedievalKing":
                        data.description = Helper.ColorText("blue", "Королівський удар") + Helper.ColorText("# 999999", "(active)") + "\n" +
                        "Меч Короля завжди повинен відповідати статусу, але його реставрація - справа не з дешевих." + "\n" +
                        "Середньовічний Король робить удар з розмахом, який завдає противнику" + Helper.RedText("50% втрати від максимального здоров'я") + "," + "\n" +
                        "Однак Середньовічний Король втрачає" + Helper.BlueText("GOLD") + "в розмірі 5% від" + Helper.BlueText("максимального здоров'я жертви.") + "\n" +
                        Helper.YellowText("Час дії:") + "миттєво." + "\n" +
                        Helper.YellowText("Перезарядка:") + "25 секунд." + "\n" +

                        Helper.BlueText("Агресивні переговори") + "(passive)" + "\n" +
                        "Хороший Король завжди повинен вміти вирішити спір не тільки силою, але і словом." + "\n" +
                        "Отримуване з супротивників" + Helper.BlueText("EXP і GOLD") + "збільшується на" + Helper.BlueText("7%,") + "але" + Helper.RedText("DPC") + "зменшується на" + Helper.BlueText("13%") + ".\n"; break;

                    case "Ninja":
                        data.description = Helper.ColorText("blue", "Маска бога смерті") + Helper.ColorText("# 999999", "(active)") + "\n" +
                        "Одягаючи маску, Ніндзя валить ворогів в жах, а в його рухах відчувається впевненість." + "\n" +
                "Вороги" + Helper.BlueText("оглушаются") + ", а" + Helper.RedText("DPC") + "Ніндзі збільшується в розмірі" + Helper.RedText("DPC * 1.5") + ".\n" +
                Helper.YellowText("Час дії:") + "5 секунд." + "\n" +
                Helper.YellowText("Перезарядка:") + "25 секунд." + "\n" +

                Helper.BlueText("Майстерність У-Тан Шань") + "(passive)" + "\n" +
                "Навчаючись бойовому мистецтву в школі даосів, Ніндзя навчився контролювати своє тіло і душу." + "\n" +
                Helper.RedText("DPC") + "і" + Helper.RedText("DPS") + "зрівнюються по більшій показником" + ".\n"; break;


                    case "Squire":
                        data.description = "Базовий персонаж з вміннями, які є у всіх" + "\n" + Helper.ColorText("blue", "Лікування") + Helper.ColorText("# 999999", "(active)") + "\n " +
                        "Відновлює половину HP" + "\n" +
                        Helper.YellowText("Перезарядка:") + "120 секунд." + "\n" +

                        Helper.BlueText("Фатальний удар") + "(active)" + "\n" +
                        "Наносіту пошкодження, що дорівнює половині HP ворога" + "\n" +
                        Helper.YellowText("Перезарядка:") + "80 секунд." + "\n"; break;

                    // RARE

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
                break;
            case "en":
                switch (heroId)
                {
                    // COMMON
                    //Helper.ColorText ("", "")
                    case "Adventurer":
                        data.description = Helper.ColorText("blue", "Adventurer") + Helper.ColorText("# 999999", "(passive)") + "\n" +
                        "In his travels, the Traveler has learned to gain experience faster than his companions." + "\n" +
                        "Amount received" + Helper.BlueText("EXP") + "when killing an enemy" + Helper.BlueText("+ 10%") + "." + "\n" +

                        Helper.BlueText("Za-Shi-Boo") + "(active)" + "\n" +
                        "During his travels, the Traveler learned a style of combat never seen before." + "\n" +
                        "The blows get stronger and wider, but the defense decreases." + "\n" +
                        Helper.RedText("DPC + 100%") + "," + Helper.BlueText("incoming damage is increased by 30%.") + "\n" +
                        Helper.YellowText("Action time:") + "10 seconds." + "\n" +
                        Helper.YellowText("Reload:") + "70 seconds." + "\n"; break;

                    case "ArenaWarrior":
                        data.description = Helper.ColorText("blue", "Chilling Dust") + Helper.ColorText("# 999999", "(active)") + "\n" +
                        "In the arena, you have to take care not only of the attack, but also of the defense." + "\n" +
                        "The Arena warrior gets into a stance in which" + Helper.BlueText("incoming damage") + "is reduced by" + Helper.BlueText("75%") + "\n" +
                        "but at the same time it is reduced by" + Helper.BlueText("25%") + "his" + Helper.RedText("DPC") + "." + "\n" +
                        Helper.YellowText("Action time:") + "10 seconds." + "\n" +
                        Helper.YellowText("Reload:") + "70 seconds." + "\n" +

                        Helper.BlueText("Ruby from the shoulder") + "(active)" + "\n" +
                        "Arena warrior makes a crushing slash with his sword," + "\n" +
                        "inflicting one-time damage to the enemy equal to" + Helper.BlueText("30%") + "\n" +
                        "from the enemy's maximum health." + "\n" +
                        Helper.YellowText("Action time:") + "instantly." + "\n" +
                        Helper.YellowText("Cooldown:") + "25 seconds." + "\n"; break;

                    case "ArmorWarrior":
                        data.description = Helper.ColorText("blue", "Best offense is defense") + Helper.ColorText("# 999999", "(passive)") + "\n" +
                        "The Armored Knight has a kind of armor. Formed with small spikes throughout the entire area," + "\n" +
                        "When attacking the Armored Knight, enemies receive" + Helper.BlueText("50%") + "\n" +
                        "from the damage done." + "\n" +

                        Helper.BlueText("Skull") + "(active)" + "\n" +
                        "The Armored Knight delivers a powerful vertical strike with his longsword," + "\n" +
                        "inflicting on the enemy" + "\n" + Helper.RedText("1000%") + "damage from" + Helper.RedText("DPC") + ".\n" +
                        Helper.YellowText("Action time:") + "instantly." + "\n" +
                        Helper.YellowText("Reload:") + "35 seconds." + "\n"; break;

                    case "Assassin":
                        data.description = Helper.ColorText("blue", "Brother Acre") + Helper.ColorText("# 999999", "(passive)") + "\n" +
                        "Through training in the brotherhood of Acre, the Assassin learned to be elusive, even in the heat of battle." + "\n" +
                        "Every" + Helper.BlueText("3") + "th attack on the assassin" + Helper.BlueText("misses") + "without damaging him." + "\n" +

                        Helper.BlueText("Hidden Blade") + "(active)" + "\n" +
                        "The assassin smears poison on his blade, poisoning opponents." + "\n" +
                        "Opponents receive increased periodic damage in the amount of" + Helper.RedText("300% DPS") + "\n" +
                        Helper.YellowText("Action time:") + "30 seconds." + "\n" +
                        Helper.YellowText("Reload:") + "45 seconds." + "\n"; break;

                    case "CityBouncer":
                        data.description = Helper.ColorText("blue", "Naboldashnik") + Helper.ColorText("# 999999", "(active)") + "\n" +
                        "The City Bouncer hits the opponent over the head with the pommel of his sword," + Helper.BlueText("stunning") + "him." + "\n" +
                        Helper.YellowText("Action time:") + "10 seconds." + "\n" +
                        Helper.YellowText("Reload:") + "40 seconds." + "\n" +

                        Helper.BlueText("Street is the best school") + "(active)" + "\n" +
                        "The City Bouncer delivers a deep slash, causing the opponent to bleed out." + "\n" +
                        "The enemy gets promoted by" + Helper.RedText("2.5") + "times" + Helper.RedText("DPS") + ".\n" +
                        Helper.YellowText("Action time:") + "20 seconds." + "\n" +
                        Helper.YellowText("Reload:") + "35 seconds." + "\n"; break;

                    case "Cyberclockwerk":
                        data.description = Helper.ColorText("blue", "Cyberimplant") + Helper.ColorText("# 999999", "(active)") + "\n" +
                        "The cyber-watch activates his cyber-implant, increasing reflexes," + "\n" +
                "which allows him to act more effectively in force majeure situations." + "\n" +
                "Each attack becomes critical, dealing" + Helper.RedText("200% DPC damage") + ".\n" +
                Helper.YellowText("Action time:") + "20 seconds." + "\n" +
                Helper.YellowText("Reload:") + "45 seconds." + "\n" +

                Helper.BlueText("Accumulator") + "(passive)" + "\n" +
                "The Cyber-Sentry receives an enchantment that allows him to harvest the energy of defeated enemies." + "\n" +
                "The enemy gets promoted by" + Helper.RedText("2.5") + "times" + Helper.RedText("DPS") + ".\n" +
                "Each defeated enemy" + Helper.BlueText("reduces the cooldown of the \" Cyberimplant \"skill by 1 second.") + "\n"; break;

                    case "Gunslinger":
                        data.description = Helper.ColorText("blue", "Get down!") + Helper.ColorText("# 999999", "(active)") + "\n" +
                        "The shooter throws a flash and noise grenade at the enemy's feet, which" + Helper.BlueText("stuns") + "him." + "\n" +
                        Helper.YellowText("Action time:") + "7 seconds." + "\n" +
                        Helper.YellowText("Reload:") + "35 seconds." + "\n" +

                        Helper.BlueText("Restraining Fire") + "(active)" + "\n" +
                        "The shooter charges his rifle with special explosive projectiles, increasing passive damage" + "\n" +
                        "in size" + Helper.RedText("(DPC + DPS) * 1.2") + ".\n" +
                        Helper.YellowText("Action time:") + "15 seconds." + "\n" +
                        Helper.YellowText("Reload:") + "70 seconds." + "\n"; break;

                    case "Hastat":
                        data.description = Helper.ColorText("blue", "Lunge") + Helper.ColorText("# 999999", "(active)") + "\n" +
                        "Ghastat unleashes a powerful thrusting blow with his gladius, dealing massive damage to enemy defenses." + "\n" +
                        "The enemy takes one-time damage in the amount of" + Helper.BlueText("30%") + "from his" + Helper.BlueText("maximum health.") + "\n" +
                        "If during the use of" + Helper.BlueText("health") + "enemy is less than or equal to" + Helper.BlueText("30%") + "-kills him" + ".\n" +
                        Helper.YellowText("Action time:") + "instantly." + "\n" +
                        Helper.YellowText("Reload:") + "30 seconds." + "\n" +

                        Helper.BlueText("Training") + "(passive)" + "\n" +
                        "Having learned to work in tight formation, Gastat has mastered the attack-lunge to perfection." + "\n" +
                        "Every time" + Helper.BlueText("\" Lunge \"finishes off the enemy") + " - skill" + Helper.BlueText("does not go to recharge") + ".\n"; break;

                    case "LightBandit":
                        data.description = Helper.ColorText("blue", "They're in!") + Helper.ColorText("# 999999", "(active)") + "\n" +
                        "The bandit whistles to call his gang of 5 villains, and together with it he beats up the enemies." + "\n" +
                        Helper.RedText("DPS") + "increases in size" + Helper.RedText("DPS + (DPC * 5)") + "\n" +
                        Helper.YellowText("Action time:") + "20 seconds." + "\n" +
                        Helper.YellowText("Reload:") + "60 seconds." + "\n" +

                        Helper.BlueText("Pickpocket") + "(passive)" + "\n" +
                        "Killing the enemy, the Bandit examines the victim more carefully, suddenly something is lying around in a pair of boots." + "\n" +
                        "The amount received" + Helper.BlueText("GOLD") + "when killing an enemy increases by" + Helper.BlueText("10%") + ".\n"; break;

                    case "MedievalKing":
                        data.description = Helper.ColorText("blue", "Royal Strike") + Helper.ColorText("# 999999", "(active)") + "\n" +
                        "The King's sword should always match the status, but its restoration is not cheap." + "\n" +
                        "The Medieval King makes a swing that inflicts on the enemy" + Helper.RedText("50% damage from maximum health") + "," + "\n" +
                        "however, the Medieval King loses" + Helper.BlueText("GOLD") + "at the rate of 5% of" + Helper.BlueText("the victim's maximum health.") + "\n" +
                        Helper.YellowText("Action time:") + "instantly." + "\n" +
                        Helper.YellowText("Cooldown:") + "25 seconds." + "\n" +

                        Helper.BlueText("Aggressive negotiations") + "(passive)" + "\n" +
                        "A good King should always be able to resolve a dispute not only by force, but also by word." + "\n" +
                        "Received from opponents" + Helper.BlueText("EXP and GOLD") + "increases by" + Helper.BlueText("7%,") + "but" + Helper.RedText("DPC") + "decreases by" + Helper.BlueText("13%") + ".\n"; break;

                    case "Ninja":
                        data.description = Helper.ColorText("blue", "Death God Mask") + Helper.ColorText("# 999999", "(active)") + "\n" +
                        "By donning the mask, the Ninja will terrify enemies and have confidence in his movements." + "\n" +
                "Enemies" + Helper.BlueText("stunned") + ", and" + Helper.RedText("DPC") + "Ninja increases in size" + Helper.RedText("DPC * 1.5") + ".\n" +
                Helper.YellowText("Action time:") + "5 seconds." + "\n" +
                Helper.YellowText("Cooldown:") + "25 seconds." + "\n" +

                Helper.BlueText("Mastery of Wu-Tang Shan") + "(passive)" + "\n" +
                "By studying martial arts at the Taoist school, the Ninja learned to control his body and soul." + "\n" +
                Helper.RedText("DPC") + "and" + Helper.RedText("DPS") + "are equalized by the higher" + ".\n"; break;


                    case "Squire":
                        data.description = "Base character with skills that everyone has" + "\n" + Helper.ColorText("blue", "Heal") + Helper.ColorText("# 999999", "(active)") + "\n " +
                        "Restores half HP" + "\n" +
                        Helper.YellowText("Cooldown:") + "120 seconds." + "\n" +

                        Helper.BlueText("Fatal blow") + "(active)" + "\n" +
                        "Deals damage equal to half the enemy's HP" + "\n" +
                        Helper.YellowText("Reload:") + "80 seconds." + "\n"; break;

                    // RARE

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
                break;
            default:
                switch (heroId)
                {
                    //COMMON
                    //Helper.ColorText("", "")
                    case "Adventurer":
                        data.description = Helper.ColorText("blue", "Приключенец") + Helper.ColorText("#999999", "(passive)") + "\n" +
                        "В своих странствиях Путешественник научился набираться опыта быстрее своих товарищей." + "\n" +
                        "Количество получаемого " + Helper.BlueText("EXP") + " при убийстве противника " + Helper.BlueText(" + 10 %") + "." + "\n" +

                        Helper.BlueText("За-Ши-Бу") + "(active)" + "\n" +
                        "Во время своих странствий Путешественник изучил доселе невиданный стиль боя." + "\n" +
                        "Удары становатся сильнее и размашистее, но снижается защита." + "\n" +
                        Helper.RedText("DPC + 100 % ") + "," + Helper.BlueText("входящий урон увеличивается на 30 %.") + "\n" +
                        Helper.YellowText("Время действия:") + " 10 секунд." + "\n" +
                        Helper.YellowText("Перезарядка:") + " 70 секунд." + "\n"; break;

                    case "ArenaWarrior":
                        data.description = Helper.ColorText("blue", "Охлаждающий пыл") + Helper.ColorText("#999999", "(active)") + "\n" +
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
                        Helper.YellowText("Перезарядка:") + " 25 секунд." + "\n"; break;

                    case "ArmorWarrior":
                        data.description = Helper.ColorText("blue", "Лучшее нападение - защита") + Helper.ColorText("#999999", "(passive)") + "\n" +
                        "У Бронированого Рыцаря своеобразная броня. Окованная мелкими шипами по всей площади," + "\n" +
                        "Атакуя Бронированого рыцаря враги получают " + Helper.BlueText("50 %") + "\n" +
                        "от нанесённого урона." + "\n" +

                        Helper.BlueText("Черепокол") + "(active)" + "\n" +
                        "Бронированый рыцарь наносит мощный вертикальный удар своим длинным мечём," + "\n" +
                        "нанося противнику" + "\n" + Helper.RedText("1000 %") + " урона от " + Helper.RedText("DPC") + ".\n" +
                        Helper.YellowText("Время действия:") + " мгновенно." + "\n" +
                        Helper.YellowText("Перезарядка:") + " 35 секунд." + "\n"; break;

                    case "Assassin":
                        data.description = Helper.ColorText("blue", "Брат Акры") + Helper.ColorText("#999999", "(passive)") + "\n" +
                        "Проходя обучение в братстве Акры, ассасин научился быть неуловимым даже в пылу сражения." + "\n" +
                        "Каждая  " + Helper.BlueText("3") + "-я атака по ассасину " + Helper.BlueText(" промахивается") + ", не нанося ему повреждений." + "\n" +

                        Helper.BlueText("Скрытый клинок") + "(active)" + "\n" +
                        "Ассасин смазывет ядом свой клинок, отравляя противников." + "\n" +
                        "Противники получают повышенный переодический урон в размере " + Helper.RedText("300% DPS") + "\n" +
                        Helper.YellowText("Время действия:") + " 30 секунд." + "\n" +
                        Helper.YellowText("Перезарядка:") + " 45 секунд." + "\n"; break;

                    case "CityBouncer":
                        data.description = Helper.ColorText("blue", "Наболдашник") + Helper.ColorText("#999999", "(active)") + "\n" +
                        "Городской Вышибала бьёт противника навершием своего меча по голове, " + Helper.BlueText("оглушая") + " его." + "\n" +
                        Helper.YellowText("Время действия:") + " 10 секунд." + "\n" +
                        Helper.YellowText("Перезарядка:") + " 40 секунд." + "\n" +

                        Helper.BlueText("Улица лучшая школа") + "(active)" + "\n" +
                        "Городской Вышибала наносит глубокий рубящий удар, заставляя противника истекать кровью." + "\n" +
                        "Противник получает повышеный в " + Helper.RedText("2.5") + " раза " + Helper.RedText(" DPS") + ".\n" +
                        Helper.YellowText("Время действия:") + " 20 секунд." + "\n" +
                        Helper.YellowText("Перезарядка:") + " 35 секунд." + "\n"; break;

                    case "Cyberclockwerk":
                        data.description = Helper.ColorText("blue", "Киберимплант") + Helper.ColorText("#999999", "(active)") + "\n" +
                        "Киберчасовой активирует свой киберимплант, увеличивая рефлексы," + "\n" +
                        "что позволяет ему эффективнее действовать в форс - мажорных ситуациях." + "\n" +
                        "Каждая атака становится критической, нанося " + Helper.RedText("200 % урона от DPC") + ".\n" +
                        Helper.YellowText("Время действия:") + " 20 секунд." + "\n" +
                        Helper.YellowText("Перезарядка:") + " 45 секунд." + "\n" +

                        Helper.BlueText("Аккомулятор") + "(passive)" + "\n" +
                        "Киберчасовой получает модификацию, которая позволяет ему добывать энергию поверженых врагов." + "\n" +
                        "Противник получает повышеный в " + Helper.RedText("2.5") + " раза " + Helper.RedText(" DPS") + ".\n" +
                        "Каждый побеждённый противник" + Helper.BlueText("уменьшает время перезарядки умения \"Киберимплант\" на 1 секунду.") + "\n"; break;

                    case "Gunslinger":
                        data.description = Helper.ColorText("blue", "Ложись!") + Helper.ColorText("#999999", "(active)") + "\n" +
                        "Стрелок бросает под ноги врагу свето-шумовую гранату, которая " + Helper.BlueText("оглушает") + " его." + "\n" +
                        Helper.YellowText("Время действия:") + " 7 секунд." + "\n" +
                        Helper.YellowText("Перезарядка:") + " 35 секунд." + "\n" +

                        Helper.BlueText("Усмирительный огонь") + "(active)" + "\n" +
                        "Стрелок заряжает свою винтовку особыми разрывными снарядами, увеличивая пассивный урон" + "\n" +
                        "в размере " + Helper.RedText("(DPC+DPS)*1.2") + ".\n" +
                        Helper.YellowText("Время действия:") + " 15 секунд." + "\n" +
                        Helper.YellowText("Перезарядка:") + " 70 секунд." + "\n"; break;

                    case "Hastat":
                        data.description = Helper.ColorText("blue", "Выпад") + Helper.ColorText("#999999", "(active)") + "\n" +
                        "Гастат совершает мощный колющий удар своим гладиусом, нанося огромный урон защите противника." + "\n" +
                        "Противник получает разовый урон в размере " + Helper.BlueText("30%") + " от своего " + Helper.BlueText("максимального здоровья.") + "\n" +
                        "Если во время применения" + Helper.BlueText("здоровье") + "противника меньше или равно " + Helper.BlueText("30 %") + "-убивает его" + ".\n" +
                        Helper.YellowText("Время действия:") + " мгновенно." + "\n" +
                        Helper.YellowText("Перезарядка:") + " 30 секунд." + "\n" +

                        Helper.BlueText("Строевая подготовка") + "(passive)" + "\n" +
                        "Научившись работать в плотном строю, Гастат в совершенстве овладел атакой-выпадом." + "\n" +
                        "Каждый раз, когда " + Helper.BlueText("\"Выпад\" добивает противника") + " - умение" + Helper.BlueText("не уходит на перезарядку") + ".\n"; break;

                    case "LightBandit":
                        data.description = Helper.ColorText("blue", "Навались!") + Helper.ColorText("#999999", "(active)") + "\n" +
                        "Бандит свистом призывает свою банду из 5ти негодяев, и вместе с ней избивает недругов." + "\n" +
                        Helper.RedText("DPS") + " увеличивается в размере " + Helper.RedText("DPS+(DPC*5)") + "\n" +
                        Helper.YellowText("Время действия:") + " 20 секунд." + "\n" +
                        Helper.YellowText("Перезарядка:") + " 60 секунд." + "\n" +

                        Helper.BlueText("Карманник") + "(passive)" + "\n" +
                        "Убивая врага Бандит тщательнее осматривает жертву, вдруг что-то завалялось в паре сапог." + "\n" +
                        "Количество получаемого " + Helper.BlueText("GOLD") + " при убийстве противника увеличиваестя на " + Helper.BlueText("10%") + ".\n"; break;

                    case "MedievalKing":
                        data.description = Helper.ColorText("blue", "Королевский удар") + Helper.ColorText("#999999", "(active)") + "\n" +
                        "Меч Короля всегда должен соответствовать статусу, но его реставрация - дело не из дешёвых." + "\n" +
                        "Средневековый Король совершает удар с размахом, который наносит противнику " + Helper.RedText("50 % урона от максимального здоровья") + "," + "\n" +
                        "однако Средневековый Король теряет " + Helper.BlueText("GOLD") + " в размере 5 % от " + Helper.BlueText("максимального здоровья жертвы.") + "\n" +
                        Helper.YellowText("Время действия:") + " мгновенно." + "\n" +
                        Helper.YellowText("Перезарядка:") + " 25 секунд." + "\n" +

                        Helper.BlueText("Агрессивные переговоры") + "(passive)" + "\n" +
                        "Хороший Король всегда должен уметь решить спор не только силой, но и словом." + "\n" +
                        "Получаемое с противников " + Helper.BlueText("EXP и GOLD") + " увеличивается на " + Helper.BlueText("7%,") + " но " + Helper.RedText("DPC") + " уменьшается на " + Helper.BlueText("13%") + ".\n"; break;

                    case "Ninja":
                        data.description = Helper.ColorText("blue", "Маска бога смерти") + Helper.ColorText("#999999", "(active)") + "\n" +
                        "Надевая маску, Ниндзя повергает врагов в ужас, а в его движениях чувствуется уверенность." + "\n" +
                        "Враги " + Helper.BlueText("оглушаются") + ", а " + Helper.RedText("DPC") + " Ниндзи увеличивается в размере " + Helper.RedText("DPC * 1.5") + ".\n" +
                        Helper.YellowText("Время действия:") + " 5 секунд." + "\n" +
                        Helper.YellowText("Перезарядка:") + " 25 секунд." + "\n" +

                        Helper.BlueText("Мастерство У-Тан Шань") + "(passive)" + "\n" +
                        "Обучаясь боевому искусству в школе даосов, Ниндзя научился контролировать своё тело и душу." + "\n" +
                        Helper.RedText("DPC") + " и " + Helper.RedText("DPS") + " уравниваются по большему показателю" + ".\n"; break;


                    case "Squire":
                        data.description = "Базовый персонаж с умениями, которые есть у всех" + "\n" + Helper.ColorText("blue", "Лечение") + Helper.ColorText("#999999", "(active)") + "\n" +
                        "Востанавливает половину HP" + "\n" +
                        Helper.YellowText("Перезарядка:") + " 120 секунд." + "\n" +

                        Helper.BlueText("Фатальный удар") + "(active)" + "\n" +
                        "Наноситу урон равный половине HP врага" + "\n" +
                        Helper.YellowText("Перезарядка:") + " 80 секунд." + "\n"; break;

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
                break;
        }

        return data;
    }


    public static ItemData GetDataForItemId(string itemId)
    {
        var data = new ItemData();
        switch (currentLanguageId)
        {
            case "ru":
                switch (itemId)
                {
                    case "recipe_common_resource":
                    case "common_resource":
                        data.name = "Обычные материалы";
                        data.description = "Материалы обычного качества";
                        break;
                    case "recipe_rare_resource":
                    case "rare_resource":
                        data.name = "Редкие материалы";
                        data.description = "Материалы редкого качества";
                        break;
                    case "recipe_epic_resource":
                    case "epic_resource":
                        data.name = "Епические материалы";
                        data.description = "Материалы епического качества";
                        break;
                    case "recipe_legendary_resource":
                    case "legendary_resource":
                        data.name = "Легендарные материалы";
                        data.description = "Материалы легендарного качества";
                        break;
                    case "1011":
                    case "1012":
                    case "1013":
                    case "1014":
                    case "recipe_hero_sword":
                        data.name = "Меч героев";
                        data.description = "Такой острый, что можно порезаться, едва взглянув на него… Ой!!";
                        break;
                    case "1021":
                    case "1022":
                    case "1023":
                    case "1024":
                        data.name = "Царский волкобой";
                        data.description = "Про это оружие ходит множество мифов, но никто не уверен насколько они правдивы";
                        break;
                    case "11":
                    case "12":
                    case "13":
                    case "14":
                        data.name = "Меч Храброго сердца";
                        data.description = "Только истинный король может достать этот меч из ножен";
                        break;
                    case "21":
                    case "22":
                    case "23":
                    case "24":
                        data.name = "Серебрянный витой перстень";
                        data.description = "Напоминает кольца бамбукового питона";
                        break;
                    case "31":
                    case "32":
                    case "33":
                    case "34":
                        data.name = "Тиара сизого сокола";
                        data.description = "Миниатюрная корона, предназначеная для юных принцесс";
                        break;
                    case "41":
                    case "42":
                    case "43":
                    case "44":
                        data.name = "Кубок барского плеча";
                        data.description = "Он всегда наполовину пуст или наполовину полон?";
                        break;
                    case "51":
                    case "52":
                    case "53":
                    case "54":
                        data.name = "Парные катаны";
                        data.description = "Их носитель часто слышыт: на кой те 2 меча";
                        break;
                    case "61":
                    case "62":
                    case "63":
                    case "64":
                        data.name = "Странная вилка";
                        data.description = "Странно, но эта вилка имеет только 3 зубца";
                        break;
                    case "71":
                    case "72":
                    case "73":
                    case "74":
                        data.name = "Палка о двух концах";
                        data.description = "Палица с перебинтованной серединой для удобного хвата";
                        break;
                    case "81":
                    case "82":
                    case "83":
                    case "84":
                        data.name = "Китайские палочки";
                        data.description = "Есть этим сложно, но в глаз тыкнуть можно. Но почему они связаны ниткой?";
                        break;
                    case "horse":
                        data.name = "Буцефал";
                        data.description = "";
                        break;
                    case "Car1":
                        data.name = "Херби";
                        data.description = "";
                        break;
                    case "Car2":
                        data.name = "Бэтмобиль";
                        data.description = "";
                        break;
                    case "Car3":
                        data.name = "Автомобиль охотников за демонами";
                        data.description = "";
                        break;
                    case "Car4":
                        data.name = "Buick";
                        data.description = "";
                        break;
                    case "Car5":
                        data.name = "Полицейский автомобиль";
                        data.description = "";
                        break;
                    case "Car6":
                        data.name = "Спорткар";
                        data.description = "";
                        break;
                    case "Car7":
                        data.name = "Сломанная машина";
                        data.description = "";
                        break;
                    case "Car8":
                        data.name = "Бабушкомобиль";
                        data.description = "";
                        break;
                    default:
                        Debug.Log(itemId);
                        break;

                }
                break;
            case "ua":
                switch (itemId)
                {
                    case "recipe_common_resource":
                    case "common_resource":
                        data.name = "Звічайні матеріали";
                        data.description = "Матеріали звічайної якості";
                        break;
                    case "recipe_rare_resource":
                    case "rare_resource":
                        data.name = "Рідкісні матеріали";
                        data.description = "Матеріали рідкісної якості";
                        break;
                    case "recipe_epic_resource":
                    case "epic_resource":
                        data.name = "Епічні матеріали";
                        data.description = "Матеріали епічної якості";
                        break;
                    case "recipe_legendary_resource":
                    case "legendary_resource":
                        data.name = "Легендарної матеріали";
                        data.description = "Матеріали легендарної якості";
                        break;
                    case "1011":
                    case "1012":
                    case "1013":
                    case "1014":
                    case "recipe_hero_sword":
                        data.name = "Меч героїв";
                        data.description = "Такий Гостра, что можна порізатіся, только-но глянули на него ... Ой !!";
                        break;
                    case "1021":
                    case "1022":
                    case "1023":
                    case "тисяча двадцять чотири":
                        data.name = "Царський Волкобой";
                        data.description = "Про це зброя ходить безліч міфів, але ніхто не впевнений наскільки вони правдиві";
                        break;
                    case "11":
                    case "12":
                    case "13":
                    case "14":
                        data.name = "Меч Хороброго серця";
                        data.description = "Тільки істинний король може дістати цей меч з піхов";
                        break;
                    case "21":
                    case "22":
                    case "23":
                    case "24":
                        data.name = "Срібний кручений перстень";
                        data.description = "Нагадує кільця бамбукового пітона";
                        break;
                    case "31":
                    case "32":
                    case "33":
                    case "34":
                        data.name = "Тіара сизого сокола";
                        data.description = "Мініатюрна корона, призначена для юних принцес";
                        break;
                    case "41":
                    case "42":
                    case "43":
                    case "44":
                        data.name = "Кубок панського плеча";
                        data.description = "Він завжди наполовину порожній або наполовину повний?";
                        break;
                    case "51":
                    case "52":
                    case "53":
                    case "54":
                        data.name = "Парні катани";
                        data.description = "Їх носій часто чуємо: на кой ті 2 меча";
                        break;
                    case "61":
                    case "62":
                    case "63":
                    case "64":
                        data.name = "Дивна вилка";
                        data.description = "Дивно, але ця вилка має тільки 3 зубці";
                        break;
                    case "71":
                    case "72":
                    case "73":
                    case "74":
                        data.name = "Палка з двома кінцями";
                        data.description = "Палиця з перебинтованою серединою для зручного хвата";
                        break;
                    case "81":
                    case "82":
                    case "83":
                    case "84":
                        data.name = "Китайські палички";
                        data.description = "Є цим складно, але в око тицьнути можна. Але чому вони пов'язані ниткою?";
                        break;
                    case "horse":
                        data.name = "Буцефал";
                        data.description = "";
                        break;
                    case "Car1":
                        data.name = "Хербі";
                        data.description = "";
                        break;
                    case "Car2":
                        data.name = "Бетмобіль";
                        data.description = "";
                        break;
                    case "Car3":
                        data.name = "Автомобіль мисливців за демонами";
                        data.description = "";
                        break;
                    case "Car4":
                        data.name = "Buick";
                        data.description = "";
                        break;
                    case "Car5":
                        data.name = "Поліцейський автомобіль";
                        data.description = "";
                        break;
                    case "Car6":
                        data.name = "Спорткар";
                        data.description = "";
                        break;
                    case "Car7":
                        data.name = "Зламана машина";
                        data.description = "";
                        break;
                    case "Car8":
                        data.name = "Бабушкомобіль";
                        data.description = "";
                        break;
                    default:
                        Debug.Log(itemId);
                        break;
                }
                break;
            case "en":
                switch (itemId)
                {
                    case "recipe_common_resource":
                    case "common_resource":
                        data.name = "Common materials";
                        data.description = "Common quality materials";
                        break;
                    case "recipe_rare_resource":
                    case "rare_resource":
                        data.name = "Rare materials";
                        data.description = "Rare quality materials";
                        break;
                    case "recipe_epic_resource":
                    case "epic_resource":
                        data.name = "Epic materials";
                        data.description = "Epic quality materials";
                        break;
                    case "recipe_legendary_resource":
                    case "legendary_resource":
                        data.name = "Legendary materials";
                        data.description = "Legendary quality materials";
                        break;
                    case "1011":
                    case "1012":
                    case "1013":
                    case "1014":
                    case "recipe_hero_sword":
                        data.name = "Sword of heroes";
                        data.description = "So sharp that you can cut yourself by barely looking at it ... Oops !!";
                        break;
                    case "1021":
                    case "1022":
                    case "1023":
                    case "1024":
                        data.name = "Tsar's wolf-killer";
                        data.description = "There are many myths about this weapon, but no one is sure how true they are";
                        break;
                    case "11":
                    case "12":
                    case "13":
                    case "14":
                        data.name = "Sword of the Braveheart";
                        data.description = "Only a true king can draw this sword from its scabbard";
                        break;
                    case "21":
                    case "22":
                    case "23":
                    case "24":
                        data.name = "Twisted Silver Ring";
                        data.description = "Resembles bamboo python rings";
                        break;
                    case "31":
                    case "32":
                    case "33":
                    case "34":
                        data.name = "Gray Falcon Tiara";
                        data.description = "Miniature crown designed for young princesses";
                        break;
                    case "41":
                    case "42":
                    case "43":
                    case "44":
                        data.name = "Lord's Shoulder Cup";
                        data.description = "Is it always half empty or half full?";
                        break;
                    case "51":
                    case "52":
                    case "53":
                    case "54":
                        data.name = "Paired Katanas";
                        data.description = "Their bearer is often heard: why are those 2 swords";
                        break;
                    case "61":
                    case "62":
                    case "63":
                    case "64":
                        data.name = "Strange Fork";
                        data.description = "Strange, this fork only has 3 prongs";
                        break;
                    case "71":
                    case "72":
                    case "73":
                    case "74":
                        data.name = "A double-edged club";
                        data.description = "Club with bandaged middle for a comfortable grip";
                        break;
                    case "81":
                    case "82":
                    case "83":
                    case "84":
                        data.name = "Chinese sticks";
                        data.description = "It is difficult to eat with this, but you can poke your eye. But why are they tied with a thread?";
                        break;
                    case "horse":
                        data.name = "Bucephalus";
                        data.description = "";
                        break;
                    case "Car1":
                        data.name = "Herbie";
                        data.description = "";
                        break;
                    case "Car2":
                        data.name = "Batmobile";
                        data.description = "";
                        break;
                    case "Car3":
                        data.name = "Demon Hunter Vehicle";
                        data.description = "";
                        break;
                    case "Car4":
                        data.name = "Buick";
                        data.description = "";
                        break;
                    case "Car5":
                        data.name = "Police car";
                        data.description = "";
                        break;
                    case "Car6":
                        data.name = "Sports car";
                        data.description = "";
                        break;
                    case "Car7":
                        data.name = "Broken car";
                        data.description = "";
                        break;
                    case "Car8":
                        data.name = "Granny's car";
                        data.description = "";
                        break;
                    default:
                        Debug.Log(itemId);
                        break;
                }
                break;
        }

        return data;
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
        Start = "Старт",
        StartRound = "В путь",
        Level = "УРОВЕНЬ",
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
        Start = "Старт",
        StartRound = "Розпочати!",
        Level = "РІВЕНЬ",
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
        Start = "Start",
        StartRound = "Go!",
        Level = "LEVEL",
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
    public string Start = "";
    public string StartRound = "";
    public string Level = "";
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


    public Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

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
        keyValuePairs["Start"] = Start;
        keyValuePairs["StartRound"] = StartRound;
        keyValuePairs["Level"] = Level;
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
