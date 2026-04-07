using UnityEngine;

public class LandingArea : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            examManager.OnLanding();
        }
    }
}