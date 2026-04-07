using UnityEngine;

public class TakeoffArea : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            examManager.OnTakeoff();
        }
    }
}