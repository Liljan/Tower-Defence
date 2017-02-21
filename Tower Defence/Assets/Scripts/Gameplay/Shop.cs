using UnityEngine;

public class Shop : MonoBehaviour {

    BuildManager buildManager;

    public void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseStandardTurret()
    {
        Debug.Log("Standard");
        // To be changed later orn.
        buildManager.SetTurretToBuild(buildManager.STANDARD_TURRET_PREFAB);
    }

    public void PurchaseMissileTurret()
    {
        Debug.Log("Missile");
        //buildManager.SetTurretToBuild(buildManager.MISSLE_TURRET_PREFAB);
    }
}
