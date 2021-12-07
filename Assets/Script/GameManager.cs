using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int CollectedAnak, KondisiMenang = 2;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(this);
        }
    }
    private static GameManager instance;
    public static GameManager Myinstance
    {
        get
        {
            if (instance == null)
                instance = new GameManager();
            return instance;
        }
    }
    private void Start()
    {
        UIManager.Myinstance.UpdateAnakUi(CollectedAnak, KondisiMenang);
    }
    public void AddAnak(int _Anak)
    {
        CollectedAnak += _Anak;
        UIManager.Myinstance.UpdateAnakUi(CollectedAnak, KondisiMenang);
    }
    public void TempatAman()
    {
        if(CollectedAnak >= KondisiMenang)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            UIManager.Myinstance.ShowKondisiMenang(CollectedAnak, KondisiMenang);
        }
    }

}
