using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveObj : MonoBehaviour
{
    enum DIRECTION
    {
        Right,
        Left,
        Up,
        Down,
        RightUp,
        RightDown,
        LeftUp,
        LeftDown
    }

    [Header("�I�u�W�F�N�g�̓�������")]
    [SerializeField] DIRECTION Direction;
    [Header("�I�u�W�F�N�g�̕Г�����(�b��)")]
    [SerializeField] float TimeRenge;
    [Header("�I�u�W�F�N�g�̕Г��ړ���")]
    [SerializeField] float MoveRenge;

    //[Header("���v�����i�[�͐G��Ȃ�")]
    /*public*/
    bool isMove = true;

    Vector3 MoveDirection;//��������
    float m_Time;//�o�ߎ���
    float PlayerHitThickness = 0.5f;//�v���C���[�T���̌���
    float NormalizeTime; //���݂̌o�ߕ���0 ~1�Ɏ������l
    float OldNormalizeTime;

    // Start is called before the first frame update
    void Start()
    {
        m_Time = 0;
        VelDirection();
        NormalizeTime = 0.0f;
        OldNormalizeTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        FixedGame();


    }

    void FixedGame()
    {
        //�ߋ��ۑ�
        OldNormalizeTime = NormalizeTime;
        //�o�ߎ��ԉ��Z
        m_Time += Time.deltaTime;
        //���݂̌o�ߕ���0~1�Ɏ���
        NormalizeTime = Mathf.Min(1.0f, m_Time / TimeRenge);
        //���݂̈ړ��ʌv�Z
        float NowMove = Easing.EasingTypeFloat(EASING_TYPE.SINE_INOUT, NormalizeTime, 1, 0, MoveRenge) -
            Easing.EasingTypeFloat(EASING_TYPE.SINE_INOUT, OldNormalizeTime, 1, 0, MoveRenge);

#if false
        //�u���b�N�T�C�Y���
        Vector3 ThisSize = transform.GetComponent<MeshRenderer>().bounds.size;

        //�u���b�N�̔����̌��݂ŁA�u���b�N��ʂ��烌�C���X�^�[�g����
        //�{�b�N�X�L���X�g�Z���^�[
        Vector3 CenterPos = new Vector3(transform.position.x, transform.position.y + ThisSize.y * 0.25f, transform.position.z);
        //�{�b�N�X�L���X�g�X�P�[��
        Vector3 HalfExetents = new Vector3(ThisSize.x * 0.5f, ThisSize.y * 0.25f, ThisSize.z * 0.5f);
        //�v���C���[�T��
        foreach (RaycastHit hit in
        Physics.BoxCastAll(CenterPos, HalfExetents,
        transform.up, Quaternion.identity, PlayerHitThickness))
        {
            if (hit.collider.gameObject.GetComponent<Player>())
            {
                //�n��Ȃ�
                if (hit.collider.gameObject.GetComponent<Player>().GetisGround())
                {
                    //�u���b�N�̈ړ��ɍ��킹�Ĉړ�
                    hit.collider.gameObject.GetComponent<Player>().AddPosition((MoveDirection * NowMove));
                }
            }

            if (hit.collider.gameObject.GetComponent<Enemy>())
            {
                //�n��Ȃ�
                if (hit.collider.gameObject.GetComponent<Enemy>().GetisGround())
                {
                    //�u���b�N�̈ړ��ɍ��킹�Ĉړ�
                    hit.collider.gameObject.GetComponent<Enemy>().AddPosition((MoveDirection * NowMove));
                }
            }

            if (hit.collider.gameObject.GetComponent<Sacrifice>())
            {
                //�n��Ȃ�
                //if (hit.collider.gameObject.GetComponent<Sacrifice>().GetisGround())
                {
                    //�u���b�N�̈ړ��ɍ��킹�Ĉړ�
                    hit.collider.gameObject.GetComponent<Sacrifice>().AddPosition((MoveDirection * NowMove));
                }
            }
        }
#endif
        //���W�ړ�
        GetComponent<RectTransform>().position += (MoveDirection * NowMove);

        //�܂�Ԃ�
        if (m_Time >= TimeRenge)
        {
            m_Time = 0;
            MoveDirection *= -1;
            NormalizeTime = 0;
            OldNormalizeTime = 0;
        }
    }
    void VelDirection()
    {
        switch (Direction)
        {
            case DIRECTION.Right:
                MoveDirection = Vector3.right;
                break;

            case DIRECTION.Left:
                MoveDirection = Vector3.left;
                break;

            case DIRECTION.Up:
                MoveDirection = Vector3.up;
                break;

            case DIRECTION.Down:
                MoveDirection = Vector3.down;
                break;

            case DIRECTION.RightUp:
                MoveDirection = new Vector3(1, 1, 0);
                break;

            case DIRECTION.RightDown:
                MoveDirection = new Vector3(1, -1, 0);
                break;

            case DIRECTION.LeftUp:
                MoveDirection = new Vector3(-1, 1, 0);
                break;

            case DIRECTION.LeftDown:
                MoveDirection = new Vector3(-1, -1, 0);
                break;
        }
    }
}
