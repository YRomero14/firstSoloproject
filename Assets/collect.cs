using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collect : MonoBehaviour
{
    public GameObject points;
    public AudioSource pickup;

    public void OnTriggerEnter2D(Collider2D other)
    {
    
        {
        Controller controller = other.GetComponent<Controller>();

        if (controller != null)
            {
            pickup.Play();
            controller.ChangeScore(1);
            Destroy(gameObject);
            
            }
        }
    }

}
