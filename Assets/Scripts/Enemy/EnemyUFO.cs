using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUFO : MonoBehaviour
{
    [SerializeField] private GameObject floatingTextPrefab;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletsPos;
    [SerializeField] private Slider health;
    

    public Color fullHealthColor = Color.green;
    public Color lowHealthColor = Color.yellow;
    public Color menimumHealthColor = Color.red;

    private float timer;
    void Start()
    {
        health.maxValue = 100;
        health.value = health.maxValue;
        health.fillRect.GetComponent<Image>().color = fullHealthColor;
    }

    
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            timer = 0;
            Shoot();            
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDame(10);
        }
    }

    public void Shoot()
    {
        Instantiate(bullet, bulletsPos.position, Quaternion.identity);
    }

    public void TakeDame(int dame)
    {
        ShowDamage(dame.ToString());
        if (dame < 0)
        {
            return;
        }
        health.value -= dame;
        UpdateHealthColor();
    }

    public void ShowDamage(string text)
    {
        if (floatingTextPrefab)
        {
            GameObject prefab = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = text;

            Destroy(prefab, 1f);
        }
    }

    void UpdateHealthColor()
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
}
