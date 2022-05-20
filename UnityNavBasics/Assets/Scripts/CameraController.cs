using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraSpeed = 30f;
    public float speedH = 6.0f;
    public float speedV = 6.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    

    public float rayLength = 100.0f;
    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)){
                GameObject objHit = hit.collider.gameObject; 
                if (objHit.CompareTag("Agents")){
                    objHit.GetComponent<Collider>().gameObject.GetComponent<Renderer>().material.color = Color.red;
                }
                if (objHit.CompareTag("Wall")){
                    objHit.GetComponent<Collider>().gameObject.GetComponent<Renderer>().material.color = Color.green;
                }
                }
        }

        Vector3 pos = transform.position;

        if (Input.GetKey("w")){
            pos.z += cameraSpeed * Time.deltaTime;
        }

        if (Input.GetKey("s")){
            pos.z -= cameraSpeed * Time.deltaTime;
        }

        if (Input.GetKey("d")){
            pos.x += cameraSpeed * Time.deltaTime;
        }

        if (Input.GetKey("a")){
            pos.x -= cameraSpeed * Time.deltaTime;
        }

        if (Input.GetKey("space")){
            pos.y += cameraSpeed * Time.deltaTime;
        }

        if (Input.GetKey("left shift")){
            pos.y -= cameraSpeed * Time.deltaTime;
        }

        transform.position = pos;


        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
