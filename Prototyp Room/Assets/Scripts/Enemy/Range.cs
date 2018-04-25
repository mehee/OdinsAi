using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour {

    private EnemyBehaviour parent;

    private void Start()
    {
        parent = GetComponentInParent<EnemyBehaviour>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if(collision.gameObject.name == "Player")
        {
            Debug.Log("triggerd");
            parent.Target = collision.transform;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("triggerd");
            parent.Target = null;

        }
    }
}
