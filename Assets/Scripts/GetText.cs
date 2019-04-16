using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetText : MonoBehaviour
{
    [SerializeField] private Text hp;
    [SerializeField] private Text energy;
    [SerializeField] private Text CanonTime;
    [SerializeField] private Text CanonDamage;
    [SerializeField] private Text CanonRange;
    [SerializeField] private Text CanonePrice;
    [SerializeField] private Text GatlinTime;
    [SerializeField] private Text GatlinDamage;
    [SerializeField] private Text GatlinRange;
    [SerializeField] private Text GatlinPrice;
    [SerializeField] private Text RocketTime;
    [SerializeField] private Text RocketDamage;
    [SerializeField] private Text RocketRange;
    [SerializeField] private Text RocketPrice;
    [SerializeField] private GameObject Canon;
    [SerializeField] private GameObject Gatlin;
    [SerializeField] private GameObject Rocket;
    private towerScript CanonInf;
    private towerScript GatlinInf;
    private towerScript RocketInf;

    private void Awake()
    {
        CanonInf = Canon.GetComponent<towerScript>();
        GatlinInf = Gatlin.GetComponent<towerScript>();
        RocketInf = Rocket.GetComponent<towerScript>();
    }

    private void FixedUpdate()
    {
        hp.text = gameManager.gm.playerHp.ToString();
        energy.text = gameManager.gm.playerEnergy.ToString();
        CanonTime.text = CanonInf.fireRate.ToString();
        CanonDamage.text = CanonInf.damage.ToString();
        CanonRange.text = CanonInf.range.ToString();
        CanonePrice.text = CanonInf.energy.ToString();
        GatlinTime.text = GatlinInf.fireRate.ToString();
        GatlinDamage.text = GatlinInf.damage.ToString();
        GatlinRange.text = GatlinInf.range.ToString();
        GatlinPrice.text = GatlinInf.energy.ToString();
        RocketTime.text = RocketInf.fireRate.ToString();
        RocketDamage.text = RocketInf.damage.ToString();
        RocketRange.text = RocketInf.range.ToString();
        RocketPrice.text = RocketInf.energy.ToString();
    }
}
