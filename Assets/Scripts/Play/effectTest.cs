using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class effectTest : MonoBehaviour
{
    Image sprite;
    Vector2 direction;
    public float moveSpeed;
    public float minSize;
    public float maxSize;
    public float sizeSpeed;
    public Color[] colors;
    public float colorSpeed;


    void Start()
    {
        sprite = GetComponent<Image>();
        direction = new Vector2(Random.Range(-1.0f,1.0f),Random.Range(-1.0f,1.0f));
        float size = Random.Range(minSize,maxSize);
        transform.localScale = new Vector2(size,size);
        sprite.color = colors[Random.Range(0,colors.Length)];
    }

    
    void Update()
    {
        transform.Translate(direction * moveSpeed);
        transform.localScale = Vector2.Lerp(transform.localScale, Vector2.zero, Time.deltaTime * sizeSpeed);
        Color color = sprite.color;
        color.a = Mathf.Lerp(sprite.color.a,0, Time.deltaTime * colorSpeed);
        sprite.color = color;

        if(sprite.color.a <=0.01f)
        {
            Destroy(gameObject);
        }
    }
}
