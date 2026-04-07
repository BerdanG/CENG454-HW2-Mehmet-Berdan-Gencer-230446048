using UnityEngine;


public class AircraftThreatHandler : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private float respawnDelay = 2f;
    [SerializeField] private AudioSource hitAudio;

    private bool isDead = false;
    private Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Missile"))
        {
            HandleHit();
        }
    }


    private void HandleHit()
    {
        if (isDead) return;
        isDead = true;
        Debug.Log("PLAYER HIT - FAIL");
        
        if (hitAudio != null)
        {hitAudio.Play();}
        
        examManager.OnPlayerHit();

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        GetComponent<FlightController>().enabled = false;

        StartCoroutine(RespawnAfterDelay());
    }


    private System.Collections.IEnumerator RespawnAfterDelay()
    {
        yield return new WaitForSeconds(respawnDelay);

        transform.position = respawnPoint.position;
        transform.rotation = respawnPoint.rotation;

        GetComponent<FlightController>().enabled = true;

        isDead = false;
    }
}
