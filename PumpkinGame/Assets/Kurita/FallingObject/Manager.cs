using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _prefabList = new List<GameObject>();//落下オブジェクトのプレハブ
    [SerializeField] private GameObject _setParentObject;//落下オブジェクトの追加先
    [SerializeField] private Transform _basicStartTransform;//落下開始位置の基準点
    [SerializeField] private Transform _leftLimitTransform;//落下開始位置の限界点
    [SerializeField] private Transform _rightLimitTransform;//落下開始位置の限界点
    private static List<Vector3> _hitObjectPositionList = new List<Vector3>();//ヒットしたオブジェクトを管理する
    private static int _createObjectIndex = 0;
    private GameObject currentOperatedInstance = null;//現在落下させようとしているオブジェクト

    void Update()
    {
        PlayerOperation();
        Hit();
    }

    private void PlayerOperation()
    {
        //マウスが押されたら生成する
        if (Input.GetMouseButtonDown(0))
        {
            //生成するオブジェクトの種類を決める
            int index = Random.Range(0, 2);
            //生成位置を決める
            Vector3 startPosition;
            startPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            startPosition = new Vector3(startPosition.x, _basicStartTransform.position.y, 0.0f);
            //ステージより外では生成しない
            if (startPosition.x < _leftLimitTransform.position.x || _rightLimitTransform.position.x < startPosition.x)
                return;
            //生成する
            currentOperatedInstance = Instantiate(_prefabList[index], startPosition, Quaternion.identity);
            currentOperatedInstance.GetComponent<Rigidbody2D>().gravityScale = 0;
        }

        if (currentOperatedInstance)
        {
            //マウスに追従する
            Vector3 startPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            startPosition = new Vector3(startPosition.x, _basicStartTransform.position.y, 0.0f);
            //ステージより外には追従していかない
            if (startPosition.x < _leftLimitTransform.position.x || _rightLimitTransform.position.x < startPosition.x)
                return;
            //位置を更新する
            currentOperatedInstance.transform.position = startPosition;

            //落下させる
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
        if (_hitObjectPositionList.Count == 2)
        {
            ////新しいオブジェクトの生成(ぶつかったオブジェクト同士が「最大のオブジェクト」であれば生成しない)
            if (_createObjectIndex < _prefabList.Count)
            {
                //新しいオブジェクトの生成
                //�@生成位置を決める
                Vector3 newPosition = Vector3.Lerp(_hitObjectPositionList[0], _hitObjectPositionList[1], 0.5f);
                //�A生成する種類を決定する
                GameObject fallingObject = _prefabList[_createObjectIndex + 1];
                Instantiate(fallingObject, newPosition, Quaternion.identity);
            }
            //�B操作が終わったので今扱っているヒットオブジェクトのリストをClearする
            _hitObjectPositionList.Clear();
            _createObjectIndex = 0;
        }
    }

    public static void SetPosition(Vector3 position,int index)
    {
        _hitObjectPositionList.Add(position);
        _createObjectIndex = index;
    }
}
