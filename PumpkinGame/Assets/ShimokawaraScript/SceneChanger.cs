using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    static public　SceneChanger instance = null;     //マネージャーのシングルトン化
    public RectTransform Obj;
    string NextStringName;
    float Temp = 0;
    int Cnt = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;         //何もなかったらインスタンスの中身を入れるよう
            Cnt = 999;
            Temp = Obj.position.y;
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

    private void FixedUpdate()
    {
        //20～620
        Cnt ++;
        switch (Cnt)
        {
            case 1:
                Obj.position = new Vector3(Obj.position.x, Temp +  820, 0);
                break;
            case 2:
                Obj.position = new Vector3(Obj.position.x, Temp + 520, 0);
                break;
            case 3:
                Obj.position = new Vector3(Obj.position.x, Temp + 420, 0);
                break;
            case 4:
                Obj.position = new Vector3(Obj.position.x, Temp + 320, 0);
                break;
            case 5:
                Obj.position = new Vector3(Obj.position.x, Temp + 220, 0);
                break;
            case 6:
                Obj.position = new Vector3(Obj.position.x, Temp + 120, 0);
                break;
            case 7:
                Obj.position = new Vector3(Obj.position.x, Temp + 20, 0);
                break;
            case 8:
                SceneManager.LoadScene(NextStringName);
                break;
            case 9:
                Obj.position = new Vector3(Obj.position.x, Temp + 20, 0);
                break;
            case 10:
                Obj.position = new Vector3(Obj.position.x, Temp + 120, 0);
                break;
            case 11:
                Obj.position = new Vector3(Obj.position.x, Temp + 220, 0);
                break;
            case 12:
                Obj.position = new Vector3(Obj.position.x, Temp + 320, 0);
                break;
            case 13:
                Obj.position = new Vector3(Obj.position.x, Temp + 420, 0);
                break;
            case 14:
                Obj.position = new Vector3(Obj.position.x, Temp + 520, 0);
                break;
            case 15:
                Obj.position = new Vector3(Obj.position.x, Temp + 820, 0);
                break;
            default:
                Obj.position = new Vector3(Obj.position.x, Temp + 820, 0);
                break;




        }
    }

    public void ChangeScene(string sceneName)
    {
        //SceneManager.LoadScene(sceneName);
        NextStringName = sceneName;
        Cnt = 0;
    }

}
