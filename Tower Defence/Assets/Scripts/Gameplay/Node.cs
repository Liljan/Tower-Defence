using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    public Color hoverColor;

    private GameObject turret;

    private Renderer renderer;
    private Color defaultColor;

    // Use this for initialization
    void Start()
    {
        renderer = GetComponent<Renderer>();
        defaultColor = renderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown()
    {
        if (turret)
        {
            Debug.Log("Can't build here, you fuck!");
        }

        GameObject turrentToBuild = BuildManager.instance.GetTurretToBuild();
        turret = Instantiate(turrentToBuild,transform.position,transform.rotation);
    }

    public void OnMouseEnter()
    {
        renderer.material.color = hoverColor;
    }

    public void OnMouseExit()
    {
        renderer.material.color = defaultColor;
    }
}
