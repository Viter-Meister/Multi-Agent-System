using UnityEngine;
using UnityEngine.UI;

public class CoinPick : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100;

    //public Text Score;
    //private int score;

    public AudioSource pick;

    private void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        Destroy(gameObject);
        pick.Play();
        //score += 1;
        //Score.text = score.ToString();
    }
}
