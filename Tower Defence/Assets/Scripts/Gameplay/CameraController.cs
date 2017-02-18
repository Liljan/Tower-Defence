using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30.0f;
    public float panBorderThickness = 10.0f;

    private bool isMoveable = true;

    public float minY = 5.0f;
    public float maxY = 80.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isMoveable = !isMoveable;
        }

        if (!isMoveable)
        {
            return;
        }

        if (Input.GetButton("Up") || Input.mousePosition.y > Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetButton("Down") || Input.mousePosition.y < panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetButton("Right") || Input.mousePosition.x > Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetButton("Left") || Input.mousePosition.x < panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        // Somehow the scrolling is not-responsive

        float scroll = Input.GetAxis("MS");

        Vector3 pos = transform.position;
        pos.y -= scroll * 1000.0f * Time.deltaTime;

        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }
}
