using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    static public Score instance = null;     //�}�l�[�W���[�̃V���O���g����

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
        //m_Score = 0;
        DontDestroyOnLoad(gameObject);      //���V�[���s�����Ƃ��ɍ폜����Ȃ��悤��
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
