using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    static public�@SceneChanger instance = null;     //�}�l�[�W���[�̃V���O���g����

    void Awake()
    {
        if (instance == null)
        {
            instance = this;         //�����Ȃ�������C���X�^���X�̒��g������悤
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


    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
