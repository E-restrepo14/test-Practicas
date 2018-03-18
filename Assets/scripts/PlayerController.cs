using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //player controller, unicamente se encarga de mover al jugador por la escena

    public float speed = 6.0F;

    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float htranslation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        htranslation *= Time.deltaTime;

        transform.Translate(htranslation, 0, translation);       
    }
    

}
