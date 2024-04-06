using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;

public class MenuControls : MonoBehaviour
{
    public void PlayPressed()
    {
        var rosConnection = FindObjectOfType<GameSession>().GetComponent<ROSConnection>();
        var ip = rosConnection.RosIPAddress;
        var port = rosConnection.RosPort;
        if (!rosConnection.HasConnectionThread)
            rosConnection.Connect(ip, port);
        SceneManager.LoadScene("Game");
    }

    public void ExitPressed()
    {
        Application.Quit();
        Debug.Log("Exit pressed!");
    }
}
