using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpeed : MonoBehaviour
{
    private Rigidbody rigid;
    [SerializeField]
    private  Transform _rightSuperBounce;
    [SerializeField]
    private Transform _leftSuperBounce;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.name == "Die")
        {
            StartCoroutine(Relive());
        }
        if (collision.transform.name == "LeftSuperBounce")
        {
            rigid.AddRelativeForce(-_leftSuperBounce.right * 10, ForceMode.Impulse);
        }
        if (collision.transform.name == "RightSuperBounce")
        {
            rigid.AddRelativeForce(_rightSuperBounce.right * 10, ForceMode.Impulse);
        }
        if (collision.transform.name == "Cylinder")
        {
            rigid.AddRelativeForce(new Vector3(transform.position.x - collision.transform.position.x, transform.position.y - collision.transform.position.y, 0) * 20, ForceMode.Impulse);
        }
    }

    IEnumerator Relive()
    {
        yield return new WaitForSeconds(2);
        transform.position = new Vector3(-9.3f, 0, 0);
    }
}
