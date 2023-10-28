using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    static public　SceneChanger instance = null;     //マネージャーのシングルトン化

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
        DontDestroyOnLoad(gameObject);      //他シーン行ったときに削除されないように
    }


    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
