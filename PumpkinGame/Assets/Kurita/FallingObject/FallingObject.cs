using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    [SerializeField] private int _index = 0;
    [SerializeField] private int _score = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_index == 6)
            return;

        if (this.gameObject.tag == collision.gameObject.tag) 
        {
            FallingObjectManager.NewObjectInformation(collision.gameObject.transform.position, _index, _score);
            Destroy(this.gameObject);
        }
    }
}
