using UnityEngine;
using UnityEngine.UI;

public class Mole : MonoBehaviour
{
    public int scoreAmount = 10;
    private Score score;

    void Start()
    {
        score = GameObject.FindObjectOfType<Score>();
        GetComponent<Button>().onClick.AddListener(Clicked);
    }

    void Clicked()
    {
        score.IncreaseScore(scoreAmount);
        Destroy(gameObject);
    }
}
