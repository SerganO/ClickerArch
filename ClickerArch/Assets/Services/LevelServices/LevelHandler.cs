using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelHandler : MonoBehaviour, ILevelHandler
{
    public Transform SpawnPoint;
    public string StartLevelID;
    public int StartLevel;
    public Image BackgroundImage;
    public Text Level;

    public Text DPCText;
    public Text DPSText;

    public Image HPImage;

    public GameObject DiePanel;

    public SkillButton SkillButton;
    public SkillButton PassiveSkillButton;
    public GameObject SkillButtonsList;

    public SceneLoader Loader;

    List<SkillButton> buttons = new List<SkillButton>();

    public Image XPImage;
    public Text CoolLevelText;

    string CurrentID;
    int CurrentLevel;

    double SECOND = 1.0;
    double secondTick = 0;

    bool gameContinued = true;

    List<string> mockLevelIDs = new List<string>()
    {
        "Level1",
        "Level2",
        "Level3",
        "Level4",
        "Level5",
        "Level6",
        "Level7",
        "Level8",
        "Level9",
        "Level10",
        "Level11",
        "Level12",
        "Level13",
        "Level14",
        "Level15"
    };


    List<string> enemiesIDs = new List<string>();
    IEnemy CurrentEnemy;
    ILevelScene CurrentLevelScene = new CommonLevelScene();

    IEnemy enemy;

    IHero AssignedHero;
    Player AssignedPlayer;

    float HeroRatio
    {
        get
        {
            return (float)AssignedHero.CurrentHealthPoint / (float)AssignedHero.MaximumHealthPoint;
        }
    }

    private void Start()
    {
        AssignedHero = Services.GetInstance().GetHeroService().Hero;
        AssignedHero.StartSetup();
        AssignedPlayer = Services.GetInstance().GetPlayer();
        Bind();
        Restart();

        SetupSkillPanel();
        LocalizateSet.SaveTemplate();
    }

    private void OnHeroCoefAdditionalCoefAttack(double value, bool mustBeShown)
    {
        CurrentEnemy.Hurt(CurrentEnemy.GetEnemyModel().MaximumHealthPoint * value, mustBeShown);
    }

    void SetupSkillPanel()
    {
        foreach (Transform child in SkillButtonsList.transform)
        {
            Destroy(child.gameObject);
        }

        AssignedHero.ActiveSkills.ForEach(skill =>
        {
            SkillButton skillButton = Instantiate(SkillButton, SkillButtonsList.transform);
            skillButton.ConfigureForID(skill.ID);

            skillButton.GetComponent<Button>().onClick.AddListener(() => { UseSkill(skill, skillButton); });
            buttons.Add(skillButton);
        });

        AssignedHero.PassiveSkills.ForEach(skill =>
        {
            SkillButton skillButton = Instantiate(PassiveSkillButton, SkillButtonsList.transform);
            skillButton.ConfigureForID(skill.ID);
            skillButton.interactable = false;
            skillButton.GetComponent<Button>().onClick.AddListener(() => { UseSkill(skill, skillButton); });
            buttons.Add(skillButton);
        });
    }

    private void UseSkill(HeroSkill skill, SkillButton button)
    {
        AssignedHero.AddModificators(skill.HeroModificators);
        AssignedHero.AddEffects(skill.HeroEffects);

        CurrentLevelScene.AddTotalModificators(skill.SceneModificators);
        CurrentLevelScene.AddTotalEffects(skill.SceneEffects);

        CurrentEnemy.GetEnemyModel().AddModificators(skill.EnemyModificators);
        CurrentEnemy.GetEnemyModel().AddModificators(skill.SceneModificators);
        CurrentEnemy.GetEnemyModel().AddEffects(skill.EnemyEffects);
        CurrentEnemy.GetEnemyModel().AddEffects(skill.SceneEffects);




        button.Countdown(skill.Countdown);

    }

    private void OnHeroAdditionalAttack(double value, bool mustBeShown)
    {
        CurrentEnemy.Hurt(value, mustBeShown);
    }

    private void Update()
    {
        if (!gameContinued) return;

        DPCText.text = AssignedHero.CurrentDamagePerClick.ToString();
        DPSText.text = AssignedHero.CurrentDamagePerSecond.ToString();


        secondTick += Time.deltaTime;
        if (secondTick >= SECOND)
        {
            secondTick -= SECOND;

            AssignedHero.PassiveAttack(CurrentEnemy);
        }

        AssignedHero.UpdateOnTick(Time.deltaTime);
        CurrentLevelScene.UpdateOnTick(Time.deltaTime);
    }


    private void OnHeroHurt()
    {
        HPImage.fillAmount = HeroRatio;
    }

    private void OnHeroHeal()
    {
        HPImage.fillAmount = HeroRatio;
    }

    private void OnHeroDie()
    {
        Debug.Log("YouDie");
        gameContinued = false;
        if (CurrentEnemy != null)
        {
            Destroy(CurrentEnemy.gameObject);
        }

        DiePanel.SetActive(true);
    }

    int currentIndex = -1;

    void SetupForIdAndLevel(string ID, int level)
    {
        var instance = Services.GetInstance();
        BackgroundImage.sprite = instance.GetLevelService().GetLevelViewForId(ID).GetBackgroundImage();
        var model = instance.GetLevelService().GetLevelModelForId(ID);
        model.ConfigureForLevel(level);
        enemiesIDs = model.GetEnemiesIDs();

        enemy = Services.GetInstance().GetEnemyService().GetEnemyPreset();

    }

    public void GetDropFromCurrentEnemy()
    {
        Debug.Log("Get Drop");
        var drop = CurrentEnemy.GetEnemyModel().drop;

        var xp = 100.0 * (10.0 + drop.xp - Services.GetInstance().GetPlayer().CoolLevel) / (10.0 + Services.GetInstance().GetPlayer().CoolLevel);
        xp = Mathf.Max(1, (float)xp);

        
        Debug.Log("Gold: " + drop.gold);

        AssignedHero.AddXP(xp);
        AssignedHero.AddGold(drop.gold);
        Debug.Log("Res:");
        var res = drop.GetResourcesAfterProbability();
        res.ForEach(r =>
        {
            Debug.Log("Concrete res: " + r.rarity + " " + r.count);
        });


        Services.GetInstance().GetPlayer().Inventory.AddResources(res);
        Services.GetInstance().GetPlayer().Inventory.AddItems(drop.GetItemsAfterProbability());


    }

    public void NextEnemy()
    {
        currentIndex++;
        if (currentIndex >= enemiesIDs.Count)
        {
            NextLevel();
            return;
        }

        CurrentEnemy = Instantiate(enemy, SpawnPoint);

        Services.GetInstance().GetEnemyService().ConfigureEnemyForId(CurrentEnemy, enemiesIDs[currentIndex]);
        CurrentEnemy.ConfigureForLevel(CurrentLevel);

        CurrentEnemy.GetEnemyModel().AddModificators(CurrentLevelScene.SceneModificators);
        CurrentEnemy.GetEnemyModel().AddEffects(CurrentLevelScene.SceneEffects);

        CurrentEnemy.onDie += () => {
            GetDropFromCurrentEnemy();
            NextEnemy();
        };
        CurrentEnemy.handler = this;

    }

    public void NextLevel()
    {
        currentIndex = -1;

        //Magic change CurrentID
        bool change = false;

        while (!change)
        {
            var tmpCurrentID = mockLevelIDs[Random.Range(0, mockLevelIDs.Count - 1)];

            if (tmpCurrentID != CurrentID)
            {
                CurrentID = tmpCurrentID;
                change = true;
            }
        }


        ////

        CurrentLevel++;

        Level.text = CurrentLevel.ToString();
        SetupForIdAndLevel(CurrentID, CurrentLevel);
        NextEnemy();
    }


    public void OnClick()
    {
        AssignedHero.Attack(CurrentEnemy);
    }

    public void OnSkillButton()
    {

    }

    void DropLevelInfo()
    {
        CurrentID = StartLevelID;
        CurrentLevel = StartLevel;
        currentIndex = -1;

        AssignedHero.CurrentHealthPoint = AssignedHero.MaximumHealthPoint;
        HPImage.fillAmount = HeroRatio;
    }

    public void Restart()
    {
        SetCoolLevelUI();
        DropLevelInfo();
        DiePanel.SetActive(false);
        NextLevel();
        gameContinued = true;
        buttons.ForEach((button) => button.Countdown(0));
    }

    void Bind()
    {
        AssignedHero.OnDie += OnHeroDie;
        AssignedHero.OnHurt += OnHeroHurt;
        AssignedHero.OnHeal += OnHeroHeal;
        AssignedHero.AdditionalConstAttack += OnHeroAdditionalAttack;
        AssignedHero.AdditionalCoefAttack += OnHeroCoefAdditionalCoefAttack;

        AssignedHero.handler = this;

        AssignedPlayer.OnXPRaise += AssignedPlayer_OnXPRaise;
    }

    void SetCoolLevelUI()
    {
        CoolLevelText.text = AssignedPlayer.CoolLevel.ToString();
        XPImage.fillAmount = (float)(AssignedPlayer.XP / Services.GetInstance().GetDataService().GetXpForNextLevel(AssignedPlayer.CoolLevel));

    }

    private void AssignedPlayer_OnXPRaise()
    {
        SetCoolLevelUI();
    }

    void Unbind()
    {
        AssignedHero.OnDie -= OnHeroDie;
        AssignedHero.OnHurt -= OnHeroHurt;
        AssignedHero.OnHeal -= OnHeroHeal;
        AssignedHero.AdditionalConstAttack -= OnHeroAdditionalAttack;
        AssignedHero.AdditionalCoefAttack -= OnHeroCoefAdditionalCoefAttack;

        AssignedPlayer.OnXPRaise -= AssignedPlayer_OnXPRaise;
    }

    private void OnDestroy()
    {
        Unbind();
    }

    public void LoadMenu()
    {
        Loader.LoadWithTransparent(SceneLoader.Scene.Main);
    }

    public double GetCommonParameters(Modificator.Parameter parameter)
    {
        switch (parameter)
        {
            case Modificator.Parameter.EnemyHP:
                return CurrentEnemy.GetEnemyModel().MaximumHealthPoint;
            case Modificator.Parameter.HeroDPC:
                return AssignedHero.CurrentDamagePerClick;
        }

        return 0;
    }
}

public interface ILevelScene
{
    List<Modificator> TotalModificators { get; set; }
    List<Effect> TotalEffects { get; set; }

    List<Modificator> SceneModificators { get;}
    List<Effect> SceneEffects { get;}


    void AddTotalModificators(List<Modificator> modificators);
    void RemoveTotalModificators(List<Modificator> modificators);

    void AddTotalEffects(List<Effect> effects);
    void RemoveTotalEffects(List<Effect> effects);

    void UpdateOnTick(double time);
}

public class CommonLevelScene : ILevelScene
{
    public static List<Modificator> StaticTotalModificators { get; set; } = new List<Modificator>();


    public List<Modificator> TotalModificators
    {
        get
        {
            return StaticTotalModificators;
        }
        set
        {
            StaticTotalModificators = value;
        }
    }

    public static List<Effect> StaticTotalEffects { get; set; } = new List<Effect>();

    public List<Effect> TotalEffects
    {
        get
        {
            return StaticTotalEffects;
        }
        set
        {
            StaticTotalEffects = value;
        }
    }

    public List<Modificator> SceneModificators
    {
        get
        {
            var temp = new List<Modificator>();

            TotalModificators.ForEach(mod => temp.Add(mod.Clone()));

            return temp;
        }
    }

    public List<Effect> SceneEffects
    {
        get
        {
            var temp = new List<Effect>();

            TotalEffects.ForEach(efc => temp.Add(efc.Clone()));

            return temp;
        }
    }

    public void AddTotalModificators(List<Modificator> modificators)
    {
        modificators.ForEach(mod => TotalModificators.Add(mod));

    }

    public void RemoveTotalModificators(List<Modificator> modificators)
    {
        modificators.ForEach(mod => TotalModificators.Remove(mod));

    }


    public void AddTotalEffects(List<Effect> effects)
    {
        effects.ForEach(efc => TotalEffects.Add(efc));

    }

    public void RemoveTotalEffects(List<Effect> effects)
    {
        effects.ForEach(efc => TotalEffects.Remove(efc));

    }


    List<Modificator> TickTotalModificators
    {
        get
        {
            return TotalModificators.FindAll(mod => mod.activationType == Modificator.ActivationType.Tick); ;
        }
    }

    List<Modificator> OneShotTotalModificators
    {
        get
        {
            return TotalModificators.FindAll(mod => mod.activationType == Modificator.ActivationType.Immediately); ;
        }
    }

    public void UpdateOnTick(double time)
    {

        UpdateModificators(time);
        UpdateEffects(time);
    }

    public void UpdateModificators(double time)
    {

        var tempMods = TotalModificators.FindAll(mod => mod.checker.endCheckType != Modificator.CheckObject.EndCheckType.Permanent);

        tempMods.ForEach(mod =>
        {
            mod.UpdateTime(time);
        });


        var modsForRemove = TotalModificators.FindAll(mod => mod.Check());
        RemoveTotalModificators(modsForRemove);

    }

    public void UpdateEffects(double time)
    {

        var tempEfc = TotalEffects.FindAll(efc => efc.checker.endCheckType != Effect.CheckObject.EndCheckType.Permanent);
        tempEfc.ForEach(mod => mod.UpdateTime(time));


        var efcsForRemove = TotalEffects.FindAll(efc => efc.Check());
        RemoveTotalEffects(efcsForRemove);

    }
}

public interface ILevelHandler
{
    double GetCommonParameters(Modificator.Parameter parameter);
}
