using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowScript : MonoBehaviour
{


    public GameObject arrow, hitPoint, cam;

    public float shootForce;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 direction = cam.transform.forward;

            GameObject arrowClone = Instantiate(arrow, hitPoint.transform.position, cam.transform.rotation);

            arrowClone.GetComponent<Rigidbody>().AddForce(direction * shootForce, ForceMode.Impulse);
        }
    }
}
