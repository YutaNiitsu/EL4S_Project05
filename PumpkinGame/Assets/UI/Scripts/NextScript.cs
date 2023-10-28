using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class SerializableKeyPair<TKey, TValue>
{
    [SerializeField] private TKey key;
    [SerializeField] private TValue value;

    public TKey Key => key;
    public TValue Value => value;
}

public class NextScript : MonoBehaviour
{
    [SerializeField]
    public GameObject Next;
    [SerializeField]
    public SerializableKeyPair<string, Sprite>[] Icons;

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = Next.GetComponent<SpriteRenderer>();

        SetNextIcon("tomato");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // アイコンのスプライトを設定
    public void SetNextIcon(string name)
    {
        for (int i = 0; i < Icons.Length; i++)
        {
            if (Icons[i].Key == name)
            {
                spriteRenderer.sprite = Icons[i].Value;
                break;
            }
        }
        
    }
}
