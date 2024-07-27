using UnityEngine;

public class RotateObject : MonoBehaviour
{
    float rotate_speed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * rotate_speed * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * rotate_speed * Mathf.Deg2Rad;

        transform.Rotate(Vector3.up, -rotX, Space.World);
        transform.Rotate(Vector3.right, rotY, Space.World);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
