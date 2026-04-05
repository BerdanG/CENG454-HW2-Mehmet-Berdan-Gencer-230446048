using UnityEngine;

public class MissileHoming : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private float rotationSpeed = 20f;

    private Transform target;


    public void SetTarget(Transform targetTransform)
    {target = targetTransform;}


    private void Update()
    {
        if (target == null) return;

        Vector3 direction = (target.position - transform.position).normalized;

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        transform.position += transform.forward * speed * Time.deltaTime;
    }
}