using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float deltaX, deltaY;

    private Rigidbody2D rb;
    public float force;

    private Transform player;
    // Start is called before the first frame update
    void Start()
    {

        // GameObject playerObject = GameObject.Find("Player");
        // player = playerObject.transform;
        // Vector2 playerPos = Camera.main.ScreenToWorldPoint(player.position);

        Touch touch = Input.GetTouch(0);

        Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

        rb = GetComponent<Rigidbody2D>();
        if (Input.touchCount > 0)
        {

            deltaX = touchPos.x - transform.position.x;
            deltaY = touchPos.y - transform.position.y;

            // deltaX = playerPos.x - transform.position.x;
            // deltaY = playerPos.y - transform.position.y;

            // rotX = transform.position.x - playerPos.x;
            // rotY = transform.position.y - playerPos.y;

            rb.velocity = new Vector2(deltaX, deltaY).normalized * force;
            // float rot = Mathf.Atan2(rotX , rotY ) * Mathf.Rad2Deg;
            // transform.rotation = Quaternion.Euler(0, 0, rot * 90);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<enemyDamage>(out enemyDamage enemyComponent))
        {
            enemyComponent.TakeDamage(1);
        }

        Destroy(this.gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


}
