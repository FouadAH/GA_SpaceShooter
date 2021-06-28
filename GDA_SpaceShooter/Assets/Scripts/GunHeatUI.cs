using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunHeatUI : MonoBehaviour
{
    public Slider gunHeat;
    public BulletLauncher bulletLauncher;

    // Start is called before the first frame update
    void Start()
    {
        gunHeat.value = 0;
        gunHeat.maxValue = bulletLauncher.maxGunHeat;
    }

    // Update is called once per frame
    void Update()
    {
        gunHeat.value = bulletLauncher.gunHeat;
    }
}
