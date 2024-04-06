using System.Collections;
using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    public void RetrunToMenu()
    {
        var rosConnection = FindObjectOfType<GameSession>();
        rosConnection.GetComponent<ROSConnection>().Disconnect();
        SceneManager.LoadScene("Menu");
    }
}
