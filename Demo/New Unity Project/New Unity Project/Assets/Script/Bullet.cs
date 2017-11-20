using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed=5;
    public GameObject motherObject;
	void Update ()
    {
        if (motherObject == null)
        {
            Destroy(gameObject);
        }
        Move();
    }
    void Move()
    {
        transform.position += transform.right*speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Wall4")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "boundary")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Home")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            
        }
        if (motherObject.tag == "Player")
        {
            if (collision.gameObject.tag == "Monster")
            {
                Destroy(gameObject);
                collision.gameObject.GetComponent<AiMonster>().Die();
            }
        }
        if (motherObject.tag == "Monster")
        {
            if (collision.gameObject.tag == "Player")
            {
                Destroy(gameObject);
                collision.gameObject.GetComponent<Character>().Die();
            }
        }
    }

}
