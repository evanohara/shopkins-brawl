using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScreen : MonoBehaviour
{

    private Animator animator;
    public AudioClip introLead;
    public AudioClip introMusic;

    private State state = State.WaitingToFade;


    public float TIMETOFADEIN = 1f;
    public float TIMETOFADEOUT = 2f;
    public float TIMETOSCENELOAD = 7f;

    private float elapsedTime = 0f;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if (Game.instance.TestModeOn)
        {
            Game.instance.testHelper.enabled = true;
            Game.instance.testHelper.testInjector.InjectAssignments();
            Game.instance.LoadScene("03 - StreetsOfShopville");
        }

        switch (state)
        {
            case State.WaitingToFade:
                if (elapsedTime > TIMETOFADEIN)
                {
                    StartFadeInAnimation();
                    state = State.FadingIn;
                }
                break;
            case State.FadingIn:
                if (elapsedTime > TIMETOFADEOUT)
                {
                    StartFadeOutAnimation();
                    PlayMusic();
                    state = State.FadingOut;
                }
                break;
            case State.FadingOut:
                if (elapsedTime > TIMETOSCENELOAD)
                {
                    Game.instance.LoadScene("01 - MainMenu");
                    state = State.Loading;
                }
                break;
            case State.Loading:
                break;
        }

    }

    void StartFadeInAnimation()
    {
        animator.SetTrigger("FadeIn");
    }

    void StartFadeOutAnimation()
    {
        animator.SetTrigger("FadeOut");
    }

    void PlayMusic()
    {
        Debug.Log(name + ": Play Music Called.");
        AudioManager.instance.PlayMusicWithLead(introLead, introMusic);
    }


    private enum State { WaitingToFade, FadingIn, FadingOut, Loading }
}