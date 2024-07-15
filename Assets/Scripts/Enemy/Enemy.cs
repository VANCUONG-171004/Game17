using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    public static Enemy Intance;
    [SerializeField] protected GameObject floatingTextPrefab;
    [SerializeField] protected Slider health;
    [SerializeField] protected GameObject HeathPrefab;
    [SerializeField] protected GameObject ManaPrefab;
    [SerializeField] protected GameObject coinPrefab;
    [SerializeField] protected ParticleSystem hiteffect;

    protected  Color fullHealthColor = Color.green;
    protected Color lowHealthColor = Color.yellow;
    protected Color menimumHealthColor = Color.red;

    public EntityFX entityFX;


    private void Awake() 
    {
        Intance = this;    
    }
    private void Start()
    {
        entityFX = GetComponent<EntityFX>();    
    }
    public virtual void UpdateHealthColor()
    {
        float healthPercentage = health.value / health.maxValue;

        if (healthPercentage <= 0.3f) // Dưới 30%
        {
            health.fillRect.GetComponent<Image>().color = menimumHealthColor;
        }
        else if (healthPercentage <= 0.7f) // Dưới 70%
        {
            health.fillRect.GetComponent<Image>().color = lowHealthColor;
        }
        else // Trên 70%
        {
            health.fillRect.GetComponent<Image>().color = fullHealthColor;
        }
    }

    public virtual void TakeDame(int dame)
    {
        // entityFX.StartCoroutine("FlashFX");
        ShowDamage(dame.ToString());
        if (dame < 0)
        {
            return;
        }
        health.value -= dame;
        if (health.value <= 0)
        {
            health.value = 100;
            
            gameObject.SetActive(false);
            SinhRaVatPham();
        }
        UpdateHealthColor();
    }
    public virtual void ShowDamage(string text)
    {
        if (floatingTextPrefab)
        {
            GameObject prefab = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = text;

            Destroy(prefab, 1f);
        }
    }

    public virtual void SinhRaVatPham()
    {
        float random = Random.Range(1,4);
        switch (random)
        {
            case 1: 
            break;
            case 2: 
            Instantiate(HeathPrefab, transform.position, Quaternion.identity);
            Instantiate(coinPrefab, transform.position, Quaternion.identity);
            break;
            case 3: 
            Instantiate(HeathPrefab, transform.position, Quaternion.identity);
            break;
            
        }
    }

    public virtual void PlayHitEffect()
    {
        if (hiteffect != null)
        {
            ParticleSystem intance = Instantiate(hiteffect,transform.position,Quaternion.identity);
            Destroy(intance.gameObject,1f);
        }
    }
}
