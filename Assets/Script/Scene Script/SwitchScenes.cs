using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{
    public int noScenes;
    public string nameScenes;

    public bool useNoScenesToLoad = true;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !collision.isTrigger)
        {
            sceneIn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !collision.isTrigger)
        {
            sceneIn = false;
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
