using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{ 
    [Header("JUMP")]
    public Rigidbody rb;
    private bool canJump;

    [Header("OTHER SCRIPTS")]
    public ChangeValues ChangeValues;




    void Start()
    {
        canJump = true;
        rb = GetComponent<Rigidbody>();
    }


    public void Jumping()
    {
        if (canJump) 
        {
            canJump = false;
            Physics.gravity = new Vector3(0, ChangeValues.gravity.value, 0);
            rb.AddRelativeForce(transform.up * ChangeValues.force.value, ForceMode.Impulse);
        }
    }


    //FINALIZAR JUEGO

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {

        }   
    }
}
