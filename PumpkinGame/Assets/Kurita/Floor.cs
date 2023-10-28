using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] private GameObject UI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //���������I�u�W�F�N�g���u�����I�u�W�F�N�g�v�����������
        GameObject fallingObject = collision.gameObject;
        if (fallingObject.GetComponent<FallingObject>())
        {
            Instantiate(UI);
            Destroy(fallingObject);
        }
    }
}
