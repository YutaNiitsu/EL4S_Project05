using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    [SerializeField]
    public GameObject Score;
    private Text txtScore;
    private int _score;

    // Start is called before the first frame update
    void Start()
    {
        txtScore = Score.GetComponent<Text>();
        _score = 0;
        AddScore(_score);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // ÉXÉRÉAê›íË
    public void AddScore(int score)
    {
        _score += score;
        txtScore.text = _score.ToString();
    }
}
