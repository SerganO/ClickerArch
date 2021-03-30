using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelHandler : MonoBehaviour
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
    public GameObject SkillButtonsList;

    public SceneLoader Loader;

    List<SkillButton> buttons = new List<SkillButton>();

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

    IEnemy enemy;

    IHero AssignedHero;

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
        Bind();
        Restart();

        SetupSkillPanel();
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

        AssignedHero.Skills.ForEach(skill=>
        {
            SkillButton skillButton = Instantiate(SkillButton, SkillButtonsList.transform);
            skillButton.ConfigureForID(skill.ID);

            skillButton.GetComponent<Button>().onClick.AddListener(() => { UseSkill(skill, skillButton); });
            buttons.Add(skillButton);
        });
    }

    private void UseSkill(HeroSkill skill, SkillButton button)
    {
        Debug.LogWarning("Use Skill");
        skill.EnemyEffects.ForEach(efc=> Debug.LogWarning("-=" + efc));
        AssignedHero.AddModificators(skill.HeroModificators);
        AssignedHero.AddEffects(skill.HeroEffects);
        Debug.LogWarning("Enemy: " + CurrentEnemy.GetEnemyModel().Id);
        CurrentEnemy.GetEnemyModel().AddEffects(skill.EnemyEffects);
        Debug.LogWarning("Effecs: " + CurrentEnemy.GetEnemyModel().Effects.Count);
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

        CurrentEnemy.onDie += NextEnemy;

    }

    public void NextLevel()
    {
        currentIndex = -1;

        //Magic change CurrentID
        bool change = false;

        while(!change)
        {
            var tmpCurrentID = mockLevelIDs[Random.Range(0, mockLevelIDs.Count - 1)];

            if(tmpCurrentID != CurrentID)
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
    }

    void Unbind()
    {
        AssignedHero.OnDie -= OnHeroDie;
        AssignedHero.OnHurt -= OnHeroHurt;
        AssignedHero.OnHeal -= OnHeroHeal;
        AssignedHero.AdditionalConstAttack -= OnHeroAdditionalAttack;
        AssignedHero.AdditionalCoefAttack -= OnHeroCoefAdditionalCoefAttack;
    }

    public void LoadMenu()
    {
        Unbind();
        Loader.LoadWithTransparent(SceneLoader.Scene.Main);
    }

}
