using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyCanvas : MonoBehaviour
{
    static public DontDestroyCanvas instance = null;     //�}�l�[�W���[�̃V���O���g����

    int m_Score = 0;

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
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
