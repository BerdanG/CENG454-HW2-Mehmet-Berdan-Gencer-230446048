using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform player;
    [SerializeField] private AudioSource launchAudio;

    public void LaunchMissile()
    {
        GameObject missile = Instantiate(missilePrefab, spawnPoint.position, spawnPoint.rotation);

        if (launchAudio != null)
        {launchAudio.Play();}

        MissileHoming homing = missile.GetComponent<MissileHoming>();
        if (homing != null)
        {homing.SetTarget(player);}
    }
}