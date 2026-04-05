using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform player;


    public void LaunchMissile()
    {
        GameObject missile = Instantiate(missilePrefab, spawnPoint.position, spawnPoint.rotation);

        MissileHoming homing = missile.GetComponent<MissileHoming>();
        if (homing != null)
        {homing.SetTarget(player);}
    }
}