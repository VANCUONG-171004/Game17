using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Exp : MonoBehaviour
{
    public static Exp Intance;
    [SerializeField] private Statf statf;
    [SerializeField] private int capdoMax;
    [SerializeField] private int expCanDat; //Số kinh nghiệm cần để đạt cấp độ 1.
    [SerializeField] private int HeSoTangTruong;

    private void Awake() 
    {
        Intance = this;    
    }
    void Start()
    {
        
        
        CapNhaExp();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            ThangCap(2);
        }
    }

    public void ThangCap(float expNhanDuoc)
    {
        if (expNhanDuoc >0f)
        {
            float expConlai = statf.SoKinhNghiemCanDat - statf.exphientai;
            if (expNhanDuoc >= expConlai)
            {
                expNhanDuoc -= expConlai;
                statf.exp += expNhanDuoc;
                CapNhatCapDo();
                ThangCap(expNhanDuoc);
            }
            else
            {
                statf.exp += expNhanDuoc;
                statf.exphientai += expNhanDuoc;
                if (statf.exphientai == statf.SoKinhNghiemCanDat)
                {
                    CapNhatCapDo();
                }
            }
        }

        CapNhaExp();

    }

    public void CapNhatCapDo()
    {
        if (statf.CapDo < capdoMax)
        {
            statf.CapDo++;
            statf.exphientai = 0f;
            statf.SoKinhNghiemCanDat *= statf.HeSoTangTruong;

        }
    }

    private void CapNhaExp()
    {
        UIManager.Intance.CapNhaExp(statf.exphientai,statf.SoKinhNghiemCanDat);
    }
}
