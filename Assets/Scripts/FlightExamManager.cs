using UnityEngine;
using TMPro;


public class FlightExamManager : MonoBehaviour
{
    [SerializeField] private TMP_Text statusText;

    private bool isInDangerZone = false;
    private bool hasTakenOff = false;
    private bool threatCleared = false;
    private bool missionComplete = false;
    private bool missionFailed = false;


    public void EnterDangerZone()
    {
        isInDangerZone = true;
        statusText.text = "Entered a Dangerous Zone!";
    }


    public void ExitDangerZone()
    {
    isInDangerZone = false;

        if (!missionFailed)
        {
            threatCleared = true;
            statusText.text = "Threat Escaped!";
        }
    }


    public void OnPlayerHit()
    {
        missionFailed = true;
        statusText.text = "MISSION FAILED!";
    }


    public void OnTakeoff()
    {
    hasTakenOff = true;
    statusText.text = "Takeoff Successful";
    }


    public void OnLanding()
    {
        if (hasTakenOff && threatCleared && !missionFailed)
        {
            missionComplete = true;
            statusText.text = "MISSION COMPLETE!";
        }
        
        else
        {
            statusText.text = "Landing Invalid!";
        }
}
}