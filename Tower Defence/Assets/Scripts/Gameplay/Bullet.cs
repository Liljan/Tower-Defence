using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 10.0f;

    public Vector3 direction = Vector3.forward;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
            direction = target.position - transform.position;

        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

    public void SetTarget(Transform t)
    {
        target = t;
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
