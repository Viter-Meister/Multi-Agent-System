using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float time;
    [SerializeField]
    private bool start;
    [SerializeField]
    private TextMeshProUGUI timeText;

    void Start()
    {
        time = 0;
        start = true;
    }

    void Update()
    {
        if (start)
        {
            time += Time.deltaTime;
            float minutes = Mathf.FloorToInt(time / 60);
            float seconds = Mathf.FloorToInt(time % 60);
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    public void StartTimer()
    {
        start = true;
    }

    public void StopTimer()
    {
        start = false;
    }
}
