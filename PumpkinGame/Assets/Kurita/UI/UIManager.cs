using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private float _frame = 0;
    private bool first = true;

    private void Update()
    {
        _frame += Time.deltaTime;

        if (_frame > 2)
        {
            _frame = 0;
            Debug.Log("�V�[����ǂݍ��݂܂�");
            if (first)
            {
                first = false;
                SceneManager.LoadScene("");
            }
            //SceneManager.LoadScene("");
        }
    }
}
