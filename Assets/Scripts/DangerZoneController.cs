using UnityEngine;
using System.Collections;


public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private MissileLauncher missileLauncher;
    [SerializeField] private float missileDelay = 5f;
    [SerializeField] private AudioSource escapeAudio;
    [SerializeField] private AudioSource warningAudio;

    private Coroutine countdownCoroutine;
    private bool isPlayerInside = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            warningAudio?.Play();
            isPlayerInside = true;
            examManager.EnterDangerZone();

            if (countdownCoroutine == null)
            {
            countdownCoroutine = StartCoroutine(StartCountdown());
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {        
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
            examManager.ExitDangerZone();
            
            if (escapeAudio != null)
            {
            escapeAudio.Play();
            }

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
        {missileLauncher.LaunchMissile();}

        countdownCoroutine = null;
    }
}