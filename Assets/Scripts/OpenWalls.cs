using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWalls : MonoBehaviour
{
    public float speed = 0.001f;
    // Start is called before the first frame update
     void Start()
    {
        StartCoroutine(Open());
    }


    IEnumerator Open()
    {
        yield return new WaitForSeconds(10);
        while (transform.position.x <= 31)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(31, 15.19f, 15.42f), Time.deltaTime);
            yield return null;
        }
       
     

    }
}
