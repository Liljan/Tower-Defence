using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 10.0f;
    public float damage = 1.0f;
    public float explosionRadius = 0.0f;

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

        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (target)
            transform.LookAt(target);
    }

    public void SetTarget(Transform t)
    {
        target = t;
    }

    public void Kill()
    {
        if (explosionRadius > 0.0f)
        {
            Explode();
            
        }
            Destroy(gameObject);
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        Debug.Log(colliders.Length);

        for (int i = 0; i < colliders.Length; i++)
        {
            Enemy e = colliders[i].GetComponent<Enemy>();
            if(e)
            {
                e.TakeDamage(damage);
            }
        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
