using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectUI : MonoBehaviour
{
    public GameObject ui;

    //public Text upgradePrice;
    //public Button upgradeButton;

    public Text sellPrice;

    private EditableNode selectedNode;

    public void setSelectedNode(EditableNode node)
    {
        selectedNode = node;
        transform.position = selectedNode.GetPosition() + new Vector3(0, 2, 0);

        //if (!selectedNode.turret.GetComponentInChildren<Turret>().isUpgraded)
        //{
        //    upgradePrice.text ="Upgrade\n$" + selectedNode.turret.GetComponentInChildren<Turret>().upgradePrice;
        //    upgradeButton.interactable = true;
        //}
        //else
        //{
        //    upgradePrice.text = "DONE";
        //    upgradeButton.interactable = false;
        //}

        sellPrice.text = "Sell\n$" + selectedNode.turret.GetComponentInChildren<Turret>().sellPrice;

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        selectedNode.UpgradeTurret();
        TurretManager.instance.DeselectTurret();
    }

    public void Sell()
    {
        Debug.Log("Call Sell Function");
        selectedNode.SellTurret();
        this.Hide();
        TurretManager.instance.DeselectTurret();
    }
}
