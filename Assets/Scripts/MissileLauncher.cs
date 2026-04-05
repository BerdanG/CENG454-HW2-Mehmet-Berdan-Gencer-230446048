using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private Transform spawnPoint;


    public void LaunchMissile()
    {Instantiate(missilePrefab, spawnPoint.position, spawnPoint.rotation);}
}