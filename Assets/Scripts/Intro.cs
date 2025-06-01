using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using System.Collections;

public class IntroSequence : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public VideoClip[] introClips;
    public string nextScene;
    public CanvasGroup fadePanel;

    private int currentIndex = 0;
    private bool isFadingOut = false;

    void Start()
    {
        StartCoroutine(PlayVideoWithFade());
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        videoPlayer.loopPointReached -= OnVideoFinished;

        currentIndex++;

        if (currentIndex < introClips.Length)
        {
            StartCoroutine(PlayVideoWithFade());
        }
        else if (!isFadingOut)
        {
            isFadingOut = true;
            StartCoroutine(EndSequence());
        }
    }

    IEnumerator PlayVideoWithFade()
    {
        yield return StartCoroutine(Fade(1f));

        videoPlayer.clip = introClips[currentIndex];
        videoPlayer.Play();

        while (!videoPlayer.isPrepared)
        {
            yield return null;
        }

        yield return null;

        yield return StartCoroutine(Fade(0f));

        videoPlayer.loopPointReached += OnVideoFinished;
    }

    IEnumerator EndSequence()
    {
        yield return StartCoroutine(Fade(1f));
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(nextScene);
    }

    IEnumerator Fade(float targetAlpha)
    {
        float duration = 2f;
        float startAlpha = fadePanel.alpha;
        float time = 0f;

        while (time < duration)
        {
            fadePanel.alpha = Mathf.Lerp(startAlpha, targetAlpha, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        fadePanel.alpha = targetAlpha;
    }
}