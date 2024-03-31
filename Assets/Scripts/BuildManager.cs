using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private TurretBlueprint turretToBuild;

    public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;

    public GameObject buildEffect;

    public bool canBuild { get { return turretToBuild != null; } }
    public bool hasMoney { get { return PlayerStats.money >= turretToBuild.cost; } }

    public static BuildManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("More than one BuildManager in scene!");
            Destroy(this.gameObject);
        }
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void BuildTurretOn(Node node)
    {
        if(PlayerStats.money < turretToBuild.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        PlayerStats.money -= turretToBuild.cost;

        GameObject turret = Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);

        Debug.Log("Turret build! Money left: " + PlayerStats.money);

    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
