using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    private Rigidbody2D myRB;

    private bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        myRB.velocity = new Vector2(speed, myRB.velocity.y);

        if(Input.GetMouseButtonDown(0) && !isJumping)
        {
            myRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.layer == 8)
        {
            isJumping = false;
        }
    }
}
