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

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

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
                    StartCoroutine(LoadAsyncScene());
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
        //Debug.Log(name + ": Playing music.");
        AudioManager.instance.PlayMusicWithLead(introLead, introMusic);
    }

    IEnumerator LoadAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("SelectionMenu");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    private enum State { WaitingToFade, FadingIn, FadingOut, Loading }
}