using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    static public Score instance = null;     //マネージャーのシングルトン化

    int m_Score = 0;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;         //何もなかったらインスタンスの中身を入れるよう
        }
        else
        {
            Destroy(gameObject);       //２回目の呼び出しの際にいらない分を削除
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        //m_Score = 0;
        DontDestroyOnLoad(gameObject);      //他シーン行ったときに削除されないように
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetScore(int score)
    {
        m_Score = score;
    }

    public int GetScore()
    {
        return m_Score;
    }
}
