using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject playerDead;
    [SerializeField] GameObject Spawner;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (Mathf.Abs(horizontalInput) > 0.1f)
        {
            rb.AddForce(Vector2.right * horizontalInput * moveSpeed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trash")
        {
            GameManager.Instance.IsPlayerAlive = false;
            Instantiate(playerDead, gameObject.transform.position, gameObject.transform.rotation);
            Time.timeScale = 0.6f;
            Destroy(this.gameObject);
            Destroy(Spawner);
        }
    }
}
