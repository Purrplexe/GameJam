using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader Instance;  // Singleton instance

    public Image transitionImage;  // Drag the transition Image here (from UI)
    public float transitionTime = 1f;  // Duration of the transition

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);  // Only one instance of LevelLoader
        }
    }


    private static IEnumerator InvokeDelay(System.Action f, float delay)
    {
        yield return new WaitForSeconds(delay);
        f();
    }

    public void LoadonDelay(string levelName)
    {
        //loads next level after 10s
        StartCoroutine(InvokeDelay(() => LoadLevel(""), 10));
    }

    // Call this to start the scene transition
    public void LoadLevel(string levelName)
    {
        StartCoroutine(TransitionToLevel(levelName));
    }

    private IEnumerator TransitionToLevel(string levelName)
    {
        // Fade to black
        yield return StartCoroutine(Fade(1f));

        // Load the new scene
        SceneManager.LoadScene(levelName);

        // Wait for the scene to load
        yield return null;

        // Fade in
        yield return StartCoroutine(Fade(0f));
    }

    // Handle the fade effect
    private IEnumerator Fade(float targetAlpha)
    {
        float timeElapsed = 0f;
        Color currentColor = transitionImage.color;

        while (timeElapsed < transitionTime)
        {
            timeElapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(currentColor.a, targetAlpha, timeElapsed / transitionTime);
            transitionImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
            yield return null;
        }

        transitionImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, targetAlpha);
    }
}



