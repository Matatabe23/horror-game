using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class TimeOfDayController : MonoBehaviour
{
    [SerializeField] Gradient directionalLightGradient;
    [SerializeField] Gradient ambientLightGradient;

    [SerializeField, Range(1, 3600)] float timeDayInSeconds = 60;
    [SerializeField, Range(0f, 1f)] float timeProgress;

    [SerializeField] Light dirLight;

    [SerializeField] bool isTimeRunning = true;

    Vector3 defaultAngles;

    void Start() => defaultAngles = dirLight.transform.localEulerAngles;

    void Update()
    {
        if (Application.isPlaying)
        {
            if (isTimeRunning)
            {
                timeProgress += Time.deltaTime / timeDayInSeconds;

                if (timeProgress > 1f)
                    timeProgress = 0f;
            }
        }

        dirLight.color = directionalLightGradient.Evaluate(timeProgress);
        RenderSettings.ambientLight = ambientLightGradient.Evaluate(timeProgress);

        dirLight.transform.localEulerAngles = new Vector3(360f * timeProgress - 90, defaultAngles.x, defaultAngles.z);
    }

    public void StopTime()
    {
        isTimeRunning = false;
    }

    public void StartTime()
    {
        isTimeRunning = true;
    }

    public void SetTime(float newTimeProgress)
    {
        timeProgress = Mathf.Clamp01(newTimeProgress);
        ApplyTimeChanges();
    }

    public void RewindTime(float targetTimeProgress)
    {
        StartCoroutine(RewindTimeCoroutine(targetTimeProgress));
    }

    IEnumerator RewindTimeCoroutine(float targetTimeProgress)
    {
        float initialTimeProgress = timeProgress;

        float elapsedTime = 0f;
        float duration = Mathf.Abs(targetTimeProgress - initialTimeProgress);

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            timeProgress = Mathf.Lerp(initialTimeProgress, targetTimeProgress, elapsedTime / duration);
            ApplyTimeChanges();
            yield return null;
        }

        timeProgress = targetTimeProgress;
        ApplyTimeChanges();
    }

    void ApplyTimeChanges()
    {
        dirLight.color = directionalLightGradient.Evaluate(timeProgress);
        RenderSettings.ambientLight = ambientLightGradient.Evaluate(timeProgress);

        dirLight.transform.localEulerAngles = new Vector3(360f * timeProgress - 90, defaultAngles.x, defaultAngles.z);
    }
}
