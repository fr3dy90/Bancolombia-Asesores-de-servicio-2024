using UnityEngine;

public class UIAnimationManager : MonoBehaviour
{
    public static UIAnimationManager Instance { get; private set; }

    [SerializeField] private RectTransform uiElement;
    [SerializeField] private RectTransform targetPosition;
    [SerializeField] private float animationDuration = 1f;
    [SerializeField] private AnimationCurve easingCurve;
    [SerializeField] private Vector2 _controlPoint;
    

    private void Awake()
    {
        // Singleton Pattern
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        uiElement.gameObject.SetActive(false);
    }

    public void StartUIAnimation()
    {
        uiElement.gameObject.SetActive(true);

        // Obtener la posición inicial en coordenadas locales
        Vector2 startPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)uiElement.parent,
            Input.mousePosition,
            null,
            out startPos
        );
        uiElement.anchoredPosition = startPos;

        // Definir el punto de control para la curva de Bezier
        Vector2 controlPoint = startPos + (targetPosition.anchoredPosition - startPos) / 2 + _controlPoint;

        StartCoroutine(AnimateUIElement(uiElement, startPos, controlPoint, targetPosition.anchoredPosition, animationDuration));
    }

    private System.Collections.IEnumerator AnimateUIElement(RectTransform element, Vector2 startPos, Vector2 controlPoint, Vector2 endPos, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            t = easingCurve.Evaluate(t); // Aplicar la curva de easing

            // Calcular la posición en la curva de Bezier
            Vector2 currentPos = CalculateQuadraticBezierPoint(t, startPos, controlPoint, endPos);
            element.anchoredPosition = currentPos;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        element.anchoredPosition = endPos;
        uiElement.gameObject.SetActive(false);
    }

    private Vector2 CalculateQuadraticBezierPoint(float t, Vector2 p0, Vector2 p1, Vector2 p2)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;

        Vector2 point = uu * p0;        // (1 - t)^2 * P0
        point += 2 * u * t * p1;        // 2 * (1 - t) * t * P1
        point += tt * p2;               // t^2 * P2

        return point;
    }
}
