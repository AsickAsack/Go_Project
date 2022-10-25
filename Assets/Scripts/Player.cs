using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 StartDir = Vector2.zero;
    Vector3 EndDir = Vector2.zero;


    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartDir = Input.mousePosition;
        }

        if(Input.GetMouseButton(0))
        {
            Debug.Log(Vector3.Distance(StartDir, Input.mousePosition));
        }

        if (Input.GetMouseButtonUp(0))
        {
            EndDir = Input.mousePosition;

            GoForward(Vector3.Distance(StartDir, EndDir));
        }
    }

    public void GoForward(float Power)
    {
        this.GetComponent<Rigidbody>().AddForce(this.transform.forward* Power);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Enemy"))
        {
            Ray ray = new Ray();
            ray.origin = this.transform.position;
            ray.direction = this.transform.forward;
            if(Physics.Raycast(ray,out RaycastHit hit,1.0f))
            {
                this.GetComponent<Rigidbody>().velocity = Vector3.zero;
                collision.transform.GetComponent<Rigidbody>().AddForce(hit.point * 10.0f);
            }
        }
    }

}
