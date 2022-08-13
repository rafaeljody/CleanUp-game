using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // karena player pakai physics dari rigid body, maka kita access rigidbody
    Rigidbody2D rb;
    public float ms;
    public float jf;
    public float fu;

    void Start()
    {
        // ambil komponen rigidbody dulu
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        // atur cara geraknya
        float horiz = Input.GetAxisRaw("Horizontal");

        //atur kecepatan geraknya selama player pencet input
        rb.velocity = new Vector2(horiz * ms, rb.velocity.y);

        // atur player agar keatas
        rb.AddForce(new Vector2(0, fu));

        // atur lompat
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0, -jf));
        }

    }

    // ending
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        SceneManager.LoadScene(1);
    }


}
