using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine;
using System;

//When we show every data structre case we need to jump from scene to scene
//this script does this job

public class SceneController : MonoBehaviour
{
    [SerializeField] private float transitionTime;
    [SerializeField] private CanvasGroup blackScreen;

    public static SceneController instance;
    public static event Action onTransitionStart;
    public static event Action onTransitionEnd;

    public bool inTransition;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    private void Update()
    {
        string userInput = Input.inputString;
        switch (userInput)
        {
            case "1": StartSceneTransition("Array"); break;
            case "2": StartSceneTransition("LinkedList"); break;
            case "3": StartSceneTransition("Stack"); break;
            case "4": StartSceneTransition("Queue"); break;
            case "5": StartSceneTransition("BinaryTree"); break;
        }
    }

    public void StartSceneTransition(string newSceneName)
    {
        if(instance.inTransition) return;

        instance.inTransition = true;
        instance.StartCoroutine(SceneTransition(newSceneName));
    }

    static IEnumerator SceneTransition(string newSceneName)
    {
        onTransitionStart?.Invoke();
        instance.blackScreen.gameObject.SetActive(true);
        FindObjectOfType<EventSystem>().enabled = false;

        yield return instance.StartCoroutine(Fade(1f));
        SceneManager.LoadScene(newSceneName);

        onTransitionEnd?.Invoke();
        yield return instance.StartCoroutine(Fade(0f));

        instance.blackScreen.gameObject.SetActive(false);

        instance.inTransition = false;
    }

    static IEnumerator Fade(float finalAlpha)
    {
        float fadeSpeed = 1 / instance.transitionTime;
        while (!Mathf.Approximately(instance.blackScreen.alpha, finalAlpha))
        {
            instance.blackScreen.alpha = Mathf.MoveTowards(instance.blackScreen.alpha, finalAlpha, fadeSpeed * Time.deltaTime);
            yield return null;
        }
        instance.blackScreen.alpha = finalAlpha;
    }
}