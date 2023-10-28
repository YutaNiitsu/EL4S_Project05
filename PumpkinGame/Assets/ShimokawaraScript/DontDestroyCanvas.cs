using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyCanvas : MonoBehaviour
{
    static public DontDestroyCanvas instance = null;     //マネージャーのシングルトン化

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
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
