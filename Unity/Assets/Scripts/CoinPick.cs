using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinPick : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100;

    public TextMeshProUGUI score;

    public AudioSource pick;

    private void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        gameObject.SetActive(false);
        pick.Play();
        int n = int.Parse(score.text);
        score.text = (++n).ToString();
    }
}
