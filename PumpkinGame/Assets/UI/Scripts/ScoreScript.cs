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

    // Start is called before the first frame update
    void Start()
    {
        txtScore = Score.GetComponent<Text>();
        SetScore(33);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // ÉXÉRÉAê›íË
    public void SetScore(int score)
    {
        txtScore.text = score.ToString();
    }
}
