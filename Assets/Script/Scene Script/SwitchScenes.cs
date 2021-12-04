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
            Debug.Log("player nabrak pintu");
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
