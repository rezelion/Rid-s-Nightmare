using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{
    public int noScenes;
    public string nameScenes;

    public bool useNoScenesToLoad;
    private bool sceneIn;

    private void Update()
    {
        if (sceneIn) {
            if (Input.GetKeyDown("w"))
            {
                LoadScene();
            }
        
        }

        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player") && !collision.isTrigger)
        {
            sceneIn = true;
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
