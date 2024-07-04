using System;
using UnityEngine;
using Cysharp.Threading.Tasks;

public static class ToolBox
{
    public static async UniTask SimpleFade(CanvasGroup canvasGroup, float fromAlpha, float duration, Action onComplete)
    {
        float toAlpha = fromAlpha == 0 ? 1 : 0;
        float elapsedTime = 0;
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
        onComplete?.Invoke();
    }

    public static async UniTask SimpleTransition(CanvasGroup canvasGroupFrom, float fromAlpha, CanvasGroup canvasGroupTo, float toAlpha, float fadeDuration, float transitonDuration,Action onComplete)
    {
        await SimpleFade(canvasGroupFrom, fromAlpha, fadeDuration, null);
        canvasGroupFrom.gameObject.SetActive(canvasGroupFrom.alpha >= .1);
        if (toAlpha == 0)
        {
            canvasGroupTo.alpha = 0;
            canvasGroupTo.gameObject.SetActive(true);
        }

        await UniTask.WaitForSeconds(transitonDuration);
        await SimpleFade(canvasGroupTo, toAlpha, fadeDuration, onComplete);
        canvasGroupTo.gameObject.SetActive(canvasGroupTo.alpha >= .1);
    }
}
