using System.Collections;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] backgrounds;
    [SerializeField] private float displayTime = 20f;
    [SerializeField] private float fadeDuration = 5f;

    private int currentIndex = 0;

    private void Start()
    {
        StartCoroutine(CycleBackgrounds());
    }

    private IEnumerator CycleBackgrounds()
    {
        while (true)
        {
            yield return new WaitForSeconds(displayTime);
            int nextIndex = (currentIndex + 1) % backgrounds.Length;
            yield return StartCoroutine(FadeBetween(backgrounds[currentIndex], backgrounds[nextIndex]));
            currentIndex = nextIndex;
        }
    }

    private IEnumerator FadeBetween(SpriteRenderer current, SpriteRenderer next)
    {
        float timer = 0f;

        Color currentColor = current.color;
        Color nextColor = next.color;

        nextColor.a = 0;
        next.color = nextColor;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;

            float t = timer / fadeDuration;

            currentColor.a = Mathf.Lerp(1, 0, t);
            nextColor.a = Mathf.Lerp(0, 1, t);
            current.color = currentColor;
            next.color = nextColor;

            yield return null;
        }
    }
}