using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txtAnak, txtMenangCondisi;
    [SerializeField] GameObject KondisiMenang;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(this);
        }
    }
    private static UIManager instance;
    public static UIManager Myinstance
    {
        get
        {
            if (instance == null)
                instance = new UIManager();
            return instance;
        }
    }
    public void UpdateAnakUi(int _Anak, int _MenangKondisi)
    {
        txtAnak.text = "Anak : " + _Anak + " / " + _MenangKondisi;
    }

    public void ShowKondisiMenang(int _Anak, int _MenangKondisi)
    {
        KondisiMenang.SetActive(true);
        txtMenangCondisi.text = "Kamu Harus Mencari " + (_MenangKondisi - _Anak) + " Anak Lagi";
    }

    public void HideKondisiMenang()
    {
        KondisiMenang.SetActive(false);
    }
        
}
