using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;

    private GameObject turret;

    private Renderer renderer;
    private Color defaultColor;

    private BuildManager buildManager;

    // Use this for initialization
    void Start()
    {
        renderer = GetComponent<Renderer>();
        defaultColor = renderer.material.color;

        buildManager = BuildManager.instance;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (buildManager.GetTurretToBuild() == null)
            return;

        if (turret)
        {
            Debug.Log("Can't build here, you fuck!");
        }

        GameObject turrentToBuild = buildManager.GetTurretToBuild();
        turret = Instantiate(turrentToBuild, transform.position, transform.rotation);
    }

    public void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (buildManager.GetTurretToBuild() == null)
            return;

        renderer.material.color = hoverColor;
    }

    public void OnMouseExit()
    {
        renderer.material.color = defaultColor;
    }
}
