using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private Paddle paddle;
    private bool hasStarted = false;

    private Vector3 paddleToBallVector;

    // Use this for initialization
    void Start()
    {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            // Lock The Ball Relative to the paddle
            this.transform.position = paddle.transform.position + paddleToBallVector;

            // Wait for the Mouse Press to Launch
            if (Input.GetMouseButtonDown(0))
            {
                // print("Mouse Clicked, launching ball");
                hasStarted = true;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(6f, 8f);

            }

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0.1f, 0.2f), Random.Range(0.1f, 0.2f));


        if (hasStarted == true)
        {
            GetComponent<AudioSource>().Play();
            // rigidbody2D.velocity += tweak;
            GetComponent<Rigidbody2D>().velocity += tweak;
        }
    }
}
