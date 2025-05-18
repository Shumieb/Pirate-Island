using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoamingStartPointsManager : MonoBehaviour
{

    [SerializeField] Transform greyShipStartPosition;
    [SerializeField] Transform yellowShipStartPosition;

    private static EnemyRoamingStartPointsManager _instance;

    public static EnemyRoamingStartPointsManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public Transform GetStartPosition(string ship) {
        return ship switch
        {
            "greyShip" => greyShipStartPosition,
            "yellowShip" => yellowShipStartPosition,
            _ => null,
        };
    }
    
}
