using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScreenHandler : MonoBehaviour
{
    public SceneLoader Loader;
    public Image XPImage;
    public Text CoolLevelText;

    public Animator HeroAnimator;
    public Animator TransportAnimator;

    Player AssignedPlayer;

    public string BackgroundClipName;
    AudioClip BackgroundClip;

    private void Start()
    {
        BackgroundClip = Services.GetInstance().GetDataService().GetAudioClipForID(BackgroundClipName);
        MusicManager.instance.Play(BackgroundClipName, BackgroundClip);



        AssignedPlayer = Services.GetInstance().GetPlayer();

        AssignedPlayer.OnXPRaise += AssignedPlayer_OnXPRaise;
        SetCoolLevelUI();

        var runtimeAnimator = Resources.Load<RuntimeAnimatorController>("Animators/Heroes/" + AssignedPlayer.CurrentHeroId + "AnimatorController");
        HeroAnimator.runtimeAnimatorController = runtimeAnimator;

        if(AssignedPlayer.ActiveTransport != null)
        {
            var trRuntimeAnimator = Resources.Load<RuntimeAnimatorController>("Animators/Transport/" + AssignedPlayer.ActiveTransport.id + "AnimatorController");
            if (trRuntimeAnimator != null)
            {
                TransportAnimator.runtimeAnimatorController = trRuntimeAnimator;
            }
            else
            {
                var sprite = Services.GetInstance().GetDataService().GetSpriteForID("Transport/" + AssignedPlayer.ActiveTransport.id);
                TransportAnimator.gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
            }
        }
        

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
        AssignedPlayer.OnXPRaise -= AssignedPlayer_OnXPRaise;
    }

    private void OnDestroy()
    {
        Unbind();
    }

    public void LoadLevel()
    {
        Services.GetInstance().GetHeroService().ConfigureForHeroId(Services.GetInstance().GetPlayer().CurrentHeroId);
        Loader.Load(SceneLoader.Scene.Level);
    }

    public void LoadStore()
    {
        Loader.Load(SceneLoader.Scene.Store);
    }

    public void LoadInventory()
    {
        Loader.Load(SceneLoader.Scene.Inventory);
    }

    public void LoadCraft()
    {
        Loader.Load(SceneLoader.Scene.Craft);
    }


}
