using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    private GameObject turret;
    public static TurretManager instance;

    public PlayerManager player;
    //public GameObject turretOne;
    public SelectUI selectUI;

    private EditableNode selectedTurret;

    // Only one TurretManger of the game and can be referenced anywhere
    private void Awake()
    {
        if (instance != null) Debug.Log("More than one turret manger");
        instance = this;
    }

    //public GameObject SetUpgradeTurret(GameObject newTurret)
    //{
    //    turret = newTurret;
    //}

    //public void UpgradeTurret(GameObject newTurret)
    //{
    //    int upgradePrice = selectedTurret.turret.GetComponentInChildren<Turret>().upgradePrice;
    //    Debug.Log(upgradePrice);
    //    if (upgradePrice <= player.money)
    //    {
    //        player.money -= upgradePrice;
    //        Destroy(selectedTurret.turret);
    //        if (newTurret != null)
    //        {
    //            turret = (GameObject)Instantiate(newTurret, selectedTurret.transform.position, selectedTurret.transform.rotation);
    //        }
    //    }
    //    Debug.Log("Not enough money");
    //    selectUI.Hide();
    //}

    //public void SellTurret()
    //{
    //    int sellPrice = selectedTurret.turret.GetComponentInChildren<Turret>().sellPrice;
    //    player.money += sellPrice;
    //    Destroy(selectedTurret.turret);
    //    selectUI.Hide();
    //}

    public GameObject GetTurret()
    {
        //if (turret != null)
        //{
        int turretPrice = turret.GetComponentInChildren<Turret>().price;
        if (turretPrice <= player.money)
        {
            player.money -= turretPrice;
            return turret;
        }
        Debug.Log("Not enough money");
        //}
        return null;

    }

    public void SetTurret(GameObject newTurret)
    {
        turret = newTurret;
        selectedTurret = null;
        selectUI.Hide();
    }

    public void ReleaseTurret()
    {
        turret = null;
    }

    public GameObject Turret()
    {
        return turret;
    }

    public void SelectTurret(EditableNode node)
    {
        if (selectedTurret == node)
        {
            DeselectTurret();
            return;
        }
        selectedTurret = node;
        turret = null;
        selectUI.setSelectedNode(node);
    }

    public void DeselectTurret()
    {
        selectedTurret = null;
        selectUI.Hide();
    }

    void Start()
    {
        //turret = turretOne;
    }


}
