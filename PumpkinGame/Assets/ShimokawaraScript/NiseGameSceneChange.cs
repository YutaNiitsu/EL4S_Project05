using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NiseGameSceneChenge : MonoBehaviour
{
    bool CoolTime = true;
    int FCnt = 0;


    // Start is called before the first frame update
    void Start()
    {
        CoolTime = true;
    }

    // Update is called once per frame
    void Update()
    {
        FCnt++;

        if (FCnt > 30)
        {
            CoolTime = false;
        }

        if (!CoolTime)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                //↓ゲームからリザルトに移行したいときに書く処理
                if (SceneChanger.instance)
                {
                    SceneChanger.instance.ChangeScene("ResultScene");
                }
                //↓リザルトにスコアを渡したいときに書く処理
                //（遷移時でも常時でも可能）
                if(Score.instance)
                {
                    Score.instance.SetScore(200);
                }
            }
        }
    }


}
