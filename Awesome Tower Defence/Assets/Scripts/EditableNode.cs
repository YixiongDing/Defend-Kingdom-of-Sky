using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditableNode : MonoBehaviour
{
    public Color initialColor;
    public Color hoverColor;
    private Renderer rend;
    private GameObject turret;
    public PlayerManager player;

    void Start()
    {
        rend = GetComponent<Renderer>();
        initialColor = rend.material.color;

        // Turn off mash at start
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;

    }

    void OnMouseEnter()
    {
        rend.material.color = hoverColor;

        // Turn on mesh
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
    }

    //When click on the node
    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("can't build here");
            return;
        }

        GameObject nextTurret = TurretManager.instance.GetTurret();
        if (nextTurret != null)
        {
            turret = (GameObject)Instantiate(nextTurret, transform.position, transform.rotation);
        }
    }

    private void OnMouseExit()
    {
        rend.material.color = initialColor;
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
}
