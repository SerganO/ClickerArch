using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(AudioSource))]
//[RequireComponent(typeof(Animator))]

public class CommonEnemyView : MonoBehaviour, IEnemyView
{

    Animator animator;
    AudioSource audioSource;

    static AudioClip idleClip;// = Services.GetInstance().GetDataService().GetAudioClipForID("idle");
    static AudioClip hurtClip;// = Services.GetInstance().GetDataService().GetAudioClipForID("hurt");
    static AudioClip attackClip;// = Services.GetInstance().GetDataService().GetAudioClipForID("attack");
    static AudioClip deathClip;// = Services.GetInstance().GetDataService().GetAudioClipForID("death");

    //AudioClip idleClip;
    //AudioClip hurtClip;
    //AudioClip attackClip;
    //AudioClip deathClip;

    private void Start()
    {
        animator = GetComponent<Animator>();
        idleClip = Services.GetInstance().GetDataService().GetAudioClipForID("idle");
        hurtClip = Services.GetInstance().GetDataService().GetAudioClipForID("hurt");
        attackClip = Services.GetInstance().GetDataService().GetAudioClipForID("attack");
        deathClip = Services.GetInstance().GetDataService().GetAudioClipForID("death");
        audioSource = GetComponent<AudioSource>();
    }

    public void Attack()
    {
        animator.Play("attack");
        StartCoroutine(Helper.Wait(0.1f, () => { Debug.Log("0-0"); Idle(); }));
    }

    public void ConfigureForId(string id)
    {
        Debug.Log("--=--");
        //var dataServices = Services.GetInstance().GetDataService();
        //idleClip = dataServices.GetAudioClipForID(id + "/idle");
        //hurtClip = dataServices.GetAudioClipForID(id + "/hurt");
        //attackClip = dataServices.GetAudioClipForID(id + "/attack");
        //deathClip = dataServices.GetAudioClipForID(id + "/death");
    }

    public void Death()
    {
        animator.Play("death");
        //audioSource.clip = deathClip;
        //audioSource.Play();
    }

    public void Hurt()
    {
        animator.Play("hurt");
        StartCoroutine(Helper.Wait(0.1f, () => { Debug.Log("0-0"); Idle(); }));
        //audioSource.clip = hurtClip;
        //audioSource.Play();
    }

    public void Idle()
    {
        animator.Play("idle");
    }
}
