using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    private GameObject turret;
    public static TurretManager instance;

    public PlayerManager player;
    //public GameObject turretOne;


    // Only one TurretManger of the game and can be referenced anywhere
    private void Awake()
    {
        if (instance != null) Debug.Log("More than one turret manger");
        instance = this;
    }

    public GameObject GetTurret()
    {
        int turretPrice = turret.GetComponentInChildren<Turret>().price;
        if (turretPrice <= player.money)
        {
            player.money -= turretPrice;
            return turret;
        }
        Debug.Log("Not enough money");
        return null;

    }

    public void SetTurret(GameObject newTurret)
    {
        turret = newTurret;
    }

    void Start()
    {
        //turret = turretOne;
    }


}
