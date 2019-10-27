using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EditableNode : MonoBehaviour
{
    public Color initialColor;
    public Color hoverColor;
    private Renderer rend;
    public GameObject turret;
    public GameObject upgradedTurret;
    public PlayerManager player;
    public Vector3 positionOffset;
    public SelectUI selectUI;

    void Start()
    {
        rend = GetComponent<Renderer>();
        initialColor = rend.material.color;

        // Turn off mash at start
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        
    }

    void OnMouseEnter()
    {
        if (TurretManager.instance.Turret() != null || turret != null)
        {
            rend.material.color = hoverColor;

            // Turn on mesh
            this.gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    //When click on the node
    private void OnMouseDown()
    {
        //if (EventSystem.current.IsPointerOverGameObject())
        //    return;

        if (turret != null)
        {
            TurretManager.instance.SelectTurret(this);
            return;
        }
        else if (TurretManager.instance.Turret() != null)
        {
            GameObject nextTurret = TurretManager.instance.GetTurret();
            if (nextTurret != null)
            {
                turret = (GameObject)Instantiate(nextTurret, transform.position, transform.rotation);
            }
        }
       
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    private void OnMouseExit()
    {
        rend.material.color = initialColor;
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void UpgradeTurret()
    {
        int upgradePrice = turret.GetComponentInChildren<Turret>().upgradePrice;
        Debug.Log(upgradePrice);
        if (upgradePrice <= player.money)
        {
            player.money -= upgradePrice;
            Destroy(turret);
            GameObject _turret = (GameObject)Instantiate(upgradedTurret, GetBuildPosition(), Quaternion.identity);
            turret = _turret;

            turret.GetComponentInChildren<Turret>().isUpgraded = true;

            Debug.Log("Turret upgraded!");
        }
        Debug.Log("Not enough money");
        selectUI.Hide();
    }

    public void SellTurret()
    {
        int sellPrice = turret.GetComponentInChildren<Turret>().sellPrice;
        Debug.Log("sell $" + sellPrice);
        TurretManager.instance.player.money += sellPrice;
        Destroy(turret);
    }

}
