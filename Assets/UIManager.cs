using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    private static int score = 0;
    private static int highScore = 0;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        scoreText.text = "SCORE : "+ score.ToString();
        highScoreText.text = "HIGH SCORE : " + highScore.ToString();
    }

    public static void AddScore(int point) {
        score += point;
        if(score >= highScore) {
            highScore = score;
        }
    }
}
