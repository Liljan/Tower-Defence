using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    // Turrets
    private GameObject turrentToBuild;
    public GameObject STANDARD_TURRET_PREFAB;


    void Awake()
    {
        if (instance)
        {
            return;
        }
        instance = this;
    }

    public void Start()
    {
        turrentToBuild = STANDARD_TURRET_PREFAB;
    }
    // Update is called once per frame
    void Update()
    {

    }

    public GameObject GetTurretToBuild()
    {
        return turrentToBuild;
    }
}
