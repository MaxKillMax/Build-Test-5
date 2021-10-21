using UnityEngine;

public sealed class DayTime : MonoBehaviour
{
    [SerializeField] private Light dayLight;

    private float endDayTime = 60;
    private float currentDayTime = 0;

    /*
     * 00-20 (>0/6) - dawn
     * 20-40 (>1/6) - day
     * 40-60 (>5/6) - sunset
     */

    private void Update()
    {
        currentDayTime += Time.deltaTime;

        if (currentDayTime > endDayTime * 5 / 6)
        {
            dayLight.intensity -= Time.deltaTime * endDayTime / 2400;

            if (currentDayTime >= endDayTime)
            {
                currentDayTime = 0;
                dayLight.intensity = 0;
            }
        }
        else if (currentDayTime < endDayTime / 6)
        {
            dayLight.intensity += Time.deltaTime * endDayTime / 2400;
        }
    }
}
