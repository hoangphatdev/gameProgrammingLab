using UnityEngine;
using TMPro;

public class ScoreManager: MonoBehaviour{
    public TMP_Text scoreText;
    private float score = 0;

    void Start(){
        UpdateScore(score);
    }

    void Update()
    {
        score = Time.deltaTime;
        UpdateScore(score);
    }

    public void UpdateScore(float newScore){
        score = newScore;
        scoreText.text = "Score: " + score;
    }

    public void AddScore(float amount){
        score += amount;
        UpdateScore(score);
    }

}