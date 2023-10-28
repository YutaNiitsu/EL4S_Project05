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
                //���Q�[�����烊�U���g�Ɉڍs�������Ƃ��ɏ�������
                if (SceneChanger.instance)
                {
                    SceneChanger.instance.ChangeScene("ResultScene");
                }
                //�����U���g�ɃX�R�A��n�������Ƃ��ɏ�������
                //�i�J�ڎ��ł��펞�ł��\�j
                if(Score.instance)
                {
                    Score.instance.SetScore(200);
                }
            }
        }
    }


}
