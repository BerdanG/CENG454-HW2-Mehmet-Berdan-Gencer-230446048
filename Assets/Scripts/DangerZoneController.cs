using UnityEngine;
using System.Collections;


public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private float missileDelay = 5f;

    private Coroutine countdownCoroutine;
    private bool isPlayerInside = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;

            examManager.EnterDangerZone();

            if (countdownCoroutine == null)
            {countdownCoroutine = StartCoroutine(StartCountdown());}
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;

            examManager.ExitDangerZone();

            if (countdownCoroutine != null)
            {
                StopCoroutine(countdownCoroutine);
                countdownCoroutine = null;
            }
        }
    }


    private IEnumerator StartCountdown()
    {
        yield return new WaitForSeconds(missileDelay);

        if (isPlayerInside)
        {Debug.Log("MISSILE SHOULD SPAWN NOW");}

        countdownCoroutine = null;
    }
}