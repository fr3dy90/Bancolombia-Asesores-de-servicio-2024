using System;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.UI;

public static class ToolBox
{
    private const int ZERO = 0;
    private const int ONE = 1;
    public static async UniTask SimpleFade(float fromAlpha, float duration,CanvasGroup canvasGroup = null ,Action onComplete = null)
    {
            float elapsedTime = 0;
        if (canvasGroup == null)
        {
            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                await UniTask.Yield();
            }
        }
        else
        {
            float toAlpha = fromAlpha == 0 ? 1 : 0;
            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                float progress = elapsedTime / duration;
                float easeOutProgress = 1 - Mathf.Pow(1 - progress, 2);
                canvasGroup.alpha = Mathf.Lerp(fromAlpha, toAlpha, easeOutProgress);
                await UniTask.Yield();
            }

            canvasGroup.alpha = toAlpha;
            if (toAlpha == 1)
            {
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
            }
            else
            {
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
                canvasGroup.gameObject.SetActive(false);
            }
        }
       
        onComplete?.Invoke();
    }

    public static async UniTask SimpleTransition(float fromAlpha, float toAlpha, float fadeDuration, float transitonDuration, CanvasGroup canvasGroupFrom = null ,CanvasGroup canvasGroupTo = null, Action from = null, Action to = null,Action onComplete= null)
    {
        await SimpleFade( fromAlpha, fadeDuration, canvasGroupFrom, from);
        if (canvasGroupFrom != null)
        {
            canvasGroupFrom.gameObject.SetActive(canvasGroupFrom.alpha >= .1);
        }

        if (canvasGroupTo != null)
        {
            if (toAlpha == 0)
            {
                canvasGroupTo.alpha = 0;
                canvasGroupTo.gameObject.SetActive(true);
            }
        }

        await UniTask.WaitForSeconds(transitonDuration);
        await SimpleFade( toAlpha, fadeDuration, canvasGroupTo, to);
        if(canvasGroupTo != null)
        {
            canvasGroupTo.gameObject.SetActive(canvasGroupTo.alpha >= .1);
        }
        onComplete?.Invoke();
    }

    public static async UniTask SimpleFadeAvatar(float alpha, float duration)
    {
        float to = alpha == 0 ? 1 : 0;
        float elapsedTime = 0;
        while (elapsedTime<duration)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / duration;
            float easeOutProgress = 1 - Mathf.Pow(1 - progress, 2);
            alpha = Mathf.Lerp(alpha, to, easeOutProgress);
            await UniTask.Yield();
        }
    }

    public static async UniTask FadeAvatar(Material mat, string strProperty, float fromAlpha, float duration, Action onComplete = null)
    {
        float toAlpha = fromAlpha == 0 ? 1 : 0;
        float elapsedTime = 0;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / duration;
            float easeOutProgress = 1 - Mathf.Pow(1 - progress, 2);
            mat.SetFloat(strProperty, Mathf.Lerp(fromAlpha, toAlpha, easeOutProgress));  
            await UniTask.Yield();
        }
        onComplete?.Invoke();
    }
    
    public static async void PlayAvatar(Avatar avatar, string MAT_ALPHA, float startTime, float stopTime, Action onComplete = null)
    {
        if (startTime >= 0 && startTime < avatar._videoAvatar.length)
        {
            avatar._videoAvatar.time = startTime;
            avatar._videoAvatar.Play();
        }
        else
        {
            Debug.LogWarning($"Check video time", avatar._videoAvatar.gameObject);
        }
      
        if (avatar._videoAvatar.gameObject.GetComponent<RawImage>().material.GetFloat(MAT_ALPHA) <= .1f)
        {
            await FadeAvatar(avatar._matAvatar, MAT_ALPHA, ZERO, .8f);
        }

        await StopVideo(avatar, stopTime);
      
        await FadeAvatar(avatar._matAvatar, MAT_ALPHA, ONE, .8f);

        onComplete?.Invoke();
    }

    private static async UniTask StopVideo(Avatar avatar ,float stopTime)
    {
        await (UniTask.WaitUntil(()=> avatar._videoAvatar.time > stopTime));
        avatar._videoAvatar.Pause();
    }
    
}
