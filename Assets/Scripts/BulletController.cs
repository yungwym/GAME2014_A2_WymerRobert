using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [Header("Bullet Properties")]
    public Vector3 direction;
    public float speed;
    public float duration;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = duration;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {
            Destroy(this.gameObject);
        }
        MoveBullet();
    }

    private void MoveBullet()
    {
        direction.z = 0.0f;
        transform.position += direction * speed * Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Platform":
                Destroy(this.gameObject);
                break;
            case "Player":
                Destroy(this.gameObject);
                break;
        }

    }
}
