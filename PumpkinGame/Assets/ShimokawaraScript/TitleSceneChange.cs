using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSceneChange : MonoBehaviour
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

        if(FCnt > 30)
        {
            CoolTime = false;
        }

        if (!CoolTime)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                //ƒV[ƒ“‘JˆÚ‚ğ‘‚­
                if (SceneChanger.instance)
                {
                    SceneChanger.instance.ChangeScene("Game");
                }
            }
        }
    }

    
}
