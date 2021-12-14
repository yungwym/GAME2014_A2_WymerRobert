using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePlatform : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider;

    bool collidedWithPlayer = false;

    float t = 0;
    float duration = 150;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (collidedWithPlayer)
        {
            MeltPlatform();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            collidedWithPlayer = true;
        }
    }

    private void MeltPlatform()
    {
        Color tmp = spriteRenderer.color;
        tmp.a = 0;
        spriteRenderer.color = Color.Lerp(spriteRenderer.color, tmp, Mathf.PingPong(Time.deltaTime, duration));

        if (spriteRenderer.color.a < 0.1)
        {
            Destroy(gameObject);
        }
    }
}
