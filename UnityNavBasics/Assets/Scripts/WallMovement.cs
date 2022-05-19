using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    public Material defMaterial;
    private float wallSpeed = 4.0f;


    void Update()
    {
        if (gameObject.GetComponent<Renderer>().material.color==Color.green){
            Vector3 pos = transform.position;

            if (Input.GetKey(KeyCode.LeftArrow)){
                {
                    pos.x -= wallSpeed * Time.deltaTime;
                }
            }
            if (Input.GetKey(KeyCode.RightArrow)){
                {
                    pos.x += wallSpeed * Time.deltaTime;
                }
            }
            if (Input.GetKey(KeyCode.UpArrow)){
                {
                    pos.z += wallSpeed * Time.deltaTime;
                }
            }
            if (Input.GetKey(KeyCode.DownArrow)){
                {
                    pos.z -= wallSpeed * Time.deltaTime;
                }
            }
            

            transform.position = pos;
            

        }

        if (Input.GetKey("return")){
            gameObject.GetComponent<Renderer>().material = defMaterial;
        }
    }
}
