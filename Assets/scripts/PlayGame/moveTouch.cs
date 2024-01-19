using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float deltaX, deltaY;
    private Rigidbody2D rb;
    public int maxHealth = 3;  // Set the maximum health here
    private int currentHealth;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (currentHealth > 0)
        {
            HandleTouchInput();
        }
        else
        {
            // Player is dead, return to main menu
            SceneManager.LoadScene("MainMenuScene");
        }
    }

    void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    deltaX = touchPos.x - transform.position.x;
                    deltaY = touchPos.y - transform.position.y;
                    break;

                case TouchPhase.Moved:
                    rb.MovePosition(new Vector2(touchPos.x - deltaX, touchPos.y - deltaY));
                    break;

                case TouchPhase.Ended:
                    rb.velocity = Vector2.zero;
                    break;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Check if the player is dead
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            // Player is dead, you can handle any death effects or logic here
        }
    }
}

//public class player : MonoBehaviour
//{

//    private float deltaX, deltaY;
//    private Rigidbody2D rb;
//    // Start is called before the first frame update
//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if(Input.touchCount > 0) {
//            Touch touch = Input.GetTouch(0);

//            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

//            switch(touch.phase){
//                case TouchPhase.Began:
//                    deltaX = touchPos.x - transform.position.x;
//                    deltaY = touchPos.y - transform.position.y;
//                    break;

//                case TouchPhase.Moved:
//                    rb.MovePosition(new Vector2(touchPos.x - deltaX, touchPos.y - deltaY));
//                    break;

//                case TouchPhase.Ended:
//                    rb.velocity = Vector2.zero;
//                    break;
//            }
//        }
//    }
//}
