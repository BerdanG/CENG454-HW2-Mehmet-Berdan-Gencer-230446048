using UnityEngine;
using TMPro;


public class FlightExamManager : MonoBehaviour
{
    [SerializeField] private TMP_Text statusText;

    private bool isInDangerZone = false;


    public void EnterDangerZone()
    {
        isInDangerZone = true;
        statusText.text = "Entered a Dangerous Zone!";
    }


    public void ExitDangerZone()
    {
        isInDangerZone = false;
        statusText.text = "";
    }
}