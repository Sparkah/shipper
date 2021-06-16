using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private BoxCollider[] EnemyWay;
    private int EnemyWayPlatform = 0;
    private CapsuleCollider EnemyShip;
    [SerializeField]
    private float EnemyShipSpeed;

    private void Start()
    {
        EnemyShip = GetComponentInChildren<CapsuleCollider>();
        EnemyWay = GetComponentsInChildren<BoxCollider>();
    }

    private void FixedUpdate()
    {
        if (EnemyShip.transform.position.z != EnemyWay[EnemyWayPlatform].transform.position.z || EnemyShip.transform.position.x != EnemyWay[EnemyWayPlatform].transform.position.x)
        {
            EnemyShip.transform.position = Vector3.MoveTowards(new Vector3(EnemyShip.transform.position.x, EnemyShip.transform.position.y, EnemyShip.transform.position.z), new Vector3(EnemyWay[EnemyWayPlatform].transform.position.x, EnemyShip.transform.position.y, EnemyWay[EnemyWayPlatform].transform.position.z), EnemyShipSpeed);
        }

        if (EnemyShip.transform.position.z == EnemyWay[EnemyWayPlatform].transform.position.z && EnemyShip.transform.position.x == EnemyWay[EnemyWayPlatform].transform.position.x)
        {
            EnemyWayPlatform++;
        }

        if (EnemyWayPlatform>=EnemyWay.Length)
        {
            EnemyWayPlatform = 0;
        }
    }
}