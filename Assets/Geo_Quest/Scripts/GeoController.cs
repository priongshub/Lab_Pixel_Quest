using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class GeoController : MonoBehaviour
{
    public int counter = 0;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;

    public float speed = 5;
    public string nextLevel = "Level 2";

    // Colors scaled 0–1
    Color[] colors = {
        new Color(1f,0f,0f), // Red
        new Color(0f,1f,0f), // Green
        new Color(0f,0f,1f)  // Blue
    };

    // Start is called before the first frame update
    void Start()
    {
        float playerSpeed = 5.5f;
        Debug.Log("Hello World");

        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xInput * speed, rb.velocity.y);

        // Color switching mechanic
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            spriteRenderer.color = colors[0];
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            spriteRenderer.color = colors[1];
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            spriteRenderer.color = colors[2];
        }

        /*
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position += new Vector3(0, 1, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0);
            if (Input.GetKeyDown(KeyCode.S))
            {
                transform.position += new Vector3(0, -1, 0);
                if (Input.GetKeyDown(KeyCode.D))
                {
                    transform.position += new Vector3(1, 0, 0);
                }
            }
        }
        */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit");
        switch (collision.tag)
        {
            case "Death":
                string thislevel = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(thislevel);
                break;

            case "Finish":
                SceneManager.LoadScene(nextLevel);
                break;
        }
    }
}
