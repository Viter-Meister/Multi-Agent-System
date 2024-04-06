using System.Collections.Generic;
using TMPro;
using Unity.Robotics.ROSTCPConnector;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    [SerializeField]
    private bool isFullScreen = false;

    [SerializeField]
    private AudioMixer am;

    private Resolution[] rsl;
    private List<string> resolutions;
    [SerializeField]
    private TMP_Dropdown dropdown;

    [SerializeField]
    private TMP_InputField inputField;
    private ROSConnection rosConnection;

    public void Awake()
    {
        rosConnection = FindObjectOfType<GameSession>().GetComponent<ROSConnection>();
        inputField.text = rosConnection.RosIPAddress;

        resolutions = new List<string>();
        rsl = Screen.resolutions;
        foreach (var i in rsl)
        {
            if (!resolutions.Contains(i.width + "x" + i.height))
                resolutions.Add(i.width + "x" + i.height);
        }
        dropdown.ClearOptions();
        dropdown.AddOptions(resolutions);
    }

    public void FullScreenToggle()
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
        Debug.Log(isFullScreen);
    }

    public void AudioVolume(float sliderValue)
    {
        am.SetFloat("masterVolume", sliderValue);
    }

    public void Quality(int q)
    {
        QualitySettings.SetQualityLevel(q);
    }

    public void Resolution(int r)
    {
        Screen.SetResolution(rsl[r].width, rsl[r].height, isFullScreen);
    }

    public void GetInputText()
    {
        string text = inputField.text;
        rosConnection.RosIPAddress = text;
        Debug.Log("Input Text: " + text);
    }
}
