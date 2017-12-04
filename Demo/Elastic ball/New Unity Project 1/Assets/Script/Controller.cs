using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private Transform _rightHand;
    [SerializeField]
    private Transform _leftHand;

    private bool _rightHandRotat;
    private bool _leftHandRotat;
   


    private void FixedUpdate()
    {
       
        if (Input.GetKeyDown(KeyCode.D))
        {
            _rightHandRotat = true;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            _rightHandRotat = false;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _leftHandRotat = true;
        }
        if(Input.GetKeyUp(KeyCode.A))
        {
            _leftHandRotat = false;
        }
        if (_rightHandRotat)
        {
            _rightHand.GetComponent<Rigidbody>().AddRelativeForce(transform.up * 10, ForceMode.Impulse);
        }
        else
        {
            _rightHand.GetComponent<Rigidbody>().AddTorque(new Vector3(0, 0, -1) * 10000,ForceMode.Impulse);
        }
        if (_leftHandRotat)
        {
            _leftHand.GetComponent<Rigidbody>().AddRelativeForce(transform.up * 10, ForceMode.Impulse);
        }
        else
        {
            _leftHand.GetComponent<Rigidbody>().AddTorque(new Vector3(0, 0, 1) * 10000);
        }
    }
}
