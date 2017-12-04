using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginPower : MonoBehaviour {
    [SerializeField]
    private Transform _ball;

    private bool _begin = true;

	void FixedUpdate()
    {
        if (_begin)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (transform.position.y > -3.5)
                {
                    transform.position -= transform.up * Time.deltaTime;
                }
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                _ball.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 0) * (float)(-1.55 - transform.position.y) * 100, ForceMode.Impulse);
                _begin = false;
                if (transform.position.y < -1.55)
                {
                    StartCoroutine(Back(Time.deltaTime));
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Ball")
        {
            _begin = true;
        }
    }

    IEnumerator Back(float time)
    {
        yield return new WaitForSeconds(time);
        transform.position += transform.up * (float)(-1.55 - transform.position.y); 
    }
}
