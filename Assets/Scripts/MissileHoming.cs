using UnityEngine;

public class MissileHoming : MonoBehaviour
{
    [SerializeField] private float speed = 60f;
    [SerializeField] private float rotationSpeed = 10f;

    private Transform target;


    public void SetTarget(Transform targetTransform)
    {target = targetTransform;}


    private void Start()
    {
        Destroy(gameObject, 10f);
    }


    private void Update()
    {
        if (target == null) return;

        Vector3 direction = (target.position - transform.position).normalized;

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        transform.position += transform.forward * speed * Time.deltaTime;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
        Destroy(gameObject);
        }
    }
}
