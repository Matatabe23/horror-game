using UnityEngine;

public class TimeOfDayController : MonoBehaviour
{
    public Light directionalLight; // Объект Directional Light
    public Color dayColor = Color.white; // Цвет света днем
    public Color nightColor = Color.blue; // Цвет света ночью

    public float dayIntensity = 1.0f; // Интенсивность света днем
    public float nightIntensity = 0.2f; // Интенсивность света ночью
    public float transitionDuration = 5.0f; // Продолжительность перехода

    private float transitionTime = 0.0f; // Время, прошедшее с начала перехода
    private bool transitioning = false; // Флаг перехода
    private Color startColor; // Начальный цвет
    private Color endColor; // Конечный цвет
    private float startIntensity; // Начальная интенсивность
    private float endIntensity; // Конечная интенсивность

    private void Update()
    {
        if (transitioning)
        {
            transitionTime += Time.deltaTime;

            float t = Mathf.Clamp01(transitionTime / transitionDuration);

            if (directionalLight != null)
            {
                directionalLight.color = Color.Lerp(startColor, endColor, t);
                directionalLight.intensity = Mathf.Lerp(startIntensity, endIntensity, t);
            }

            if (t >= 1.0f)
            {
                transitioning = false;
            }
        }
    }

    public void SetDay()
    {
        if (directionalLight == null)
        {
            Debug.LogWarning("Directional Light not assigned!");
            return;
        }

        if (!transitioning)
        {
            StartTransition(dayColor, dayIntensity);
        }
        else
        {
            Debug.LogWarning("Already transitioning!");
        }
    }

    public void SetNight()
    {
        if (directionalLight == null)
        {
            Debug.LogWarning("Directional Light not assigned!");
            return;
        }

        if (!transitioning)
        {
            StartTransition(nightColor, nightIntensity);
        }
        else
        {
            Debug.LogWarning("Already transitioning!");
        }
    }

    private void StartTransition(Color targetColor, float targetIntensity)
    {
        startColor = directionalLight.color;
        endColor = targetColor;

        startIntensity = directionalLight.intensity;
        endIntensity = targetIntensity;

        transitionTime = 0.0f;
        transitioning = true;
    }
}
