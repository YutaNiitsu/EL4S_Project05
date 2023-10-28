using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectManager : MonoBehaviour
{
    [Header("�C���Q�[��")]
    [SerializeField] private List<GameObject> _prefabList = new List<GameObject>();//�����I�u�W�F�N�g�̃v���n�u
    [SerializeField] private GameObject _setParentObject;//�����I�u�W�F�N�g�̒ǉ���
    [SerializeField] private Transform _basicStartTransform;//�����J�n�ʒu�̊�_
    [SerializeField] private Transform _leftLimitTransform;//�����J�n�ʒu�̌��E�_
    [SerializeField] private Transform _rightLimitTransform;//�����J�n�ʒu�̌��E�_
    private static List<Vector3> _hitObjectPositionList = new List<Vector3>();//�q�b�g�����I�u�W�F�N�g���Ǘ�����
    private static int _createObjectIndex;
    private GameObject currentOperatedInstance;//���ݗ��������悤�Ƃ��Ă���I�u�W�F�N�g
    [Header("UI")]
    [SerializeField] private ScoreScript _scoreScript;
    [SerializeField] private NextScript nextScript;
    private static int _createObjectScore;
    private int _nextIndex;

    private void Start()
    {
        currentOperatedInstance = null;
        _createObjectIndex = 0;
        _createObjectScore = 0;

    }

    void Update()
    {
        PlayerOperation();
        Hit();
    }

    private void PlayerOperation()
    {
        //�}�E�X�������ꂽ�琶������
        if (Input.GetMouseButtonDown(0))
        {
            //�����ʒu�����߂�
            Vector3 startPosition;
            startPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            startPosition = new Vector3(startPosition.x, _basicStartTransform.position.y, 0.0f);
            //�X�e�[�W���O�ł͐������Ȃ�
            if (startPosition.x < _leftLimitTransform.position.x || _rightLimitTransform.position.x < startPosition.x)
                return;
            //��������
            currentOperatedInstance = Instantiate(_prefabList[_nextIndex], startPosition, Quaternion.identity);
            currentOperatedInstance.GetComponent<Rigidbody2D>().gravityScale = 0;

            NextIcon();
        }

        if (currentOperatedInstance)
        {
            //�}�E�X�ɒǏ]����
            Vector3 startPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            startPosition = new Vector3(startPosition.x, _basicStartTransform.position.y, 0.0f);
            //�X�e�[�W���O�ɂ͒Ǐ]���Ă����Ȃ�
            if (startPosition.x < _leftLimitTransform.position.x || _rightLimitTransform.position.x < startPosition.x)
                return;
            //�ʒu���X�V����
            currentOperatedInstance.transform.position = startPosition;

            //����������
            if (Input.GetMouseButtonUp(0))
            {
                Rigidbody2D rigidBoyde2d = currentOperatedInstance.GetComponent<Rigidbody2D>();
                rigidBoyde2d.gravityScale = 1;
                currentOperatedInstance = null;
            }
        }
    }

    private void Hit()
    {
        if (_hitObjectPositionList.Count >= 2)
        {
            ////�V�����I�u�W�F�N�g�̐���(�Ԃ������I�u�W�F�N�g���m���u�ő�̃I�u�W�F�N�g�v�ł���ΐ������Ȃ�)
            if (_createObjectIndex < _prefabList.Count)
            {
                //�V�����I�u�W�F�N�g�̐���
                //�@�����ʒu�����߂�
                Vector3 newPosition = Vector3.Lerp(_hitObjectPositionList[0], _hitObjectPositionList[1], 0.5f);
                //�A��ނ����肵�Đ�������
                GameObject fallingObject = _prefabList[_createObjectIndex + 1];
                Instantiate(fallingObject, newPosition, Quaternion.identity);
                //�B�X�R�A�����Z����
                _scoreScript.AddScore(_createObjectScore);
            }
            //���삪�I������̂ō������Ă���q�b�g�I�u�W�F�N�g�̃��X�g��Clear����
            _hitObjectPositionList.Clear();
            _createObjectIndex = 0;
            _createObjectScore = 0;
        }
    }

    public static void NewObjectInformation(Vector3 position,int index,int score)
    {
        _hitObjectPositionList.Add(position);
        _createObjectIndex = index;
        _createObjectScore = score;
    }

    private void NextIcon()
    {
        //�����
        _nextIndex = Random.Range(0, 3);
        string name = null;
        switch (_nextIndex)
        {
            case 0:
                name = "candy";
                break;
            case 1:
                name = "gumi";
                break;
            case 2:
                name = "choco";
                break;
            case 3:
                name = "cokkie";
                break;
            case 4:
                name = "jack";
                break;
        }

        nextScript.SetNextIcon(name);
    }
}
