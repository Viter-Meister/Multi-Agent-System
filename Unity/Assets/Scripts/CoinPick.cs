using TMPro;
using UnityEngine;

public class CoinPick : MonoBehaviour
{
    [SerializeField] 
    private float rotationSpeed = 100;
    [SerializeField]
    private TextMeshProUGUI score;
    [SerializeField]
    private AudioSource pick;

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
