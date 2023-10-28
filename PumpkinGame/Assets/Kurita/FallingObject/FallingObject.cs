using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    [SerializeField] private int _index = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.gameObject.tag == collision.gameObject.tag) 
        {
            Manager.SetPosition(collision.gameObject.transform.position, _index);
            Destroy(this.gameObject);
        }
    }

    public int GetIndex()
    {
        return _index;
    }
}
