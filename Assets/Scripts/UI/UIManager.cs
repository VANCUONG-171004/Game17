using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Intance;
    [SerializeField] private Statf statf;
    [Header("Panel")]
    [SerializeField] private GameObject panelInventory;
    [SerializeField] private GameObject panelStatf;
    [Header("Heath")]
    [SerializeField] private Image heathImage;
    [SerializeField] private Image manaImage;
    [SerializeField] private Image exptImage;


    [Header("Text MP")]
    [SerializeField] private TextMeshProUGUI heathTMP;
    [SerializeField] private TextMeshProUGUI manaTMP;
    [SerializeField] private TextMeshProUGUI expTMP;
    [SerializeField] private TextMeshProUGUI levelTMP;

    [Header("Panel Statf")]
    [SerializeField] private TextMeshProUGUI capdoTMP_DES;
    [SerializeField] private TextMeshProUGUI healthTMP_DES;
    [SerializeField] private TextMeshProUGUI manaTMP_DES;
    [SerializeField] private TextMeshProUGUI damageTMP_DES;
    [SerializeField] private TextMeshProUGUI VelocityTMP_DES;

    private float currtenheath;
    private float maxheath;

    private float currtenmana;
    private float maxmana;

    private float expcurrten;
    private float expmax;
    private void Awake()
    {
        Intance = this;
    }
    void Start()
    {

    }


    void Update()
    {
        DoDulieu();
        PanelStatf();
    }


    public void DoDulieu()
    {
        heathImage.fillAmount = Mathf.Lerp(heathImage.fillAmount, currtenheath / maxheath, 10 * Time.deltaTime);
        manaImage.fillAmount = Mathf.Lerp(manaImage.fillAmount, currtenmana / maxmana, 10 * Time.deltaTime);
        exptImage.fillAmount = Mathf.Lerp(exptImage.fillAmount, expcurrten / expmax, 10 * Time.deltaTime);
        
        
        heathTMP.text = $"{currtenheath}/{maxheath}";
        manaTMP.text = $"{currtenmana}/{maxmana}";
        expTMP.text = $"{((expcurrten/ expmax) * 100):F2}%";
        levelTMP.text = $"{statf.CapDo}";
    }

    public void PanelStatf()
    {
        if (panelStatf.activeSelf == false)
        {
            return;
        }
        capdoTMP_DES.text = statf.CapDo.ToString();
        healthTMP_DES.text = statf.maxheath.ToString();
        manaTMP_DES.text = statf.manamax.ToString();
        VelocityTMP_DES.text = statf.velocity.ToString();
        damageTMP_DES.text = $"{statf.minDamage} - {statf.maxDamage}";
    }

    public void CapNhatLuongMau(float mauhientai, float mautoida)
    {
        currtenheath = mauhientai;
        maxheath = mautoida;
    }
    public void CapNhatMana(float manahientai, float manatoida)
    {
        currtenmana = manahientai;
        maxmana = manatoida;
    }
    public void CapNhaExp(float exphientai, float exptoida)
    {
        expcurrten = exphientai;
        expmax = exptoida;
    }

    public void showPanelInventory()
    {
        panelInventory.SetActive(!panelInventory.activeSelf);
    }
    public void ShowPanelStatf()
    {
        panelStatf.SetActive(!panelStatf.activeSelf);
    }
}
