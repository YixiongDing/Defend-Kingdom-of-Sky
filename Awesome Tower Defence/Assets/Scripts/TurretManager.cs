using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    private GameObject turret;
    public static TurretManager instance;
    public GameObject turretOne;


    // Only one TurretManger of the game and can be referenced anywhere
    private void Awake()
    {
        if (instance != null) Debug.Log("More than one turret manger");
        instance = this;
    }

    public GameObject GetTurret()
    {
        return turret;
    }

    void Start()
    {
        turret = turretOne;
    }


}
