using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //あたったオブジェクトが「落下オブジェクト」だったら消す
        GameObject fallingObject = collision.gameObject;
        if (fallingObject.GetComponent<FallingObject>())
        {
            Destroy(fallingObject);
        }
    }
}
