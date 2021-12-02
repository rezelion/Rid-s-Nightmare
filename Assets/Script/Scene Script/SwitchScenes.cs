using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{
    public int noScenes;
    public string nameScenes;

    public bool useNoScenesToLoad;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !collision.isTrigger)
        {
            if (Input.GetKeyDown("w"))
            {
                LoadScene();
            }
        }
    }

    void LoadScene()
    {
        if (useNoScenesToLoad)
        {
            SceneManager.LoadScene(noScenes);
        }
        else
        {
            SceneManager.LoadScene(nameScenes);
        }
    }

}
