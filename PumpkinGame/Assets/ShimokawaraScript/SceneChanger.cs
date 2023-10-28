using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    static public�@SceneChanger instance = null;     //�}�l�[�W���[�̃V���O���g����
    public RectTransform Obj;
    string NextStringName;
    float Temp = 0;
    int Cnt = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;         //�����Ȃ�������C���X�^���X�̒��g������悤
            Cnt = 999;
            Temp = Obj.position.y;
        }
        else
        {
            Destroy(gameObject);       //�Q��ڂ̌Ăяo���̍ۂɂ���Ȃ������폜
        }
       


    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);      //���V�[���s�����Ƃ��ɍ폜����Ȃ��悤��
    }

    private void FixedUpdate()
    {
        //20�`620
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
