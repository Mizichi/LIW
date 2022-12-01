using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_MenuScenes : MonoBehaviour
{
    public GameObject buttonName; //for keeping track of current level

    private void Start()
    {

    }

    public void LoadLevel()
    {
        //scene change: LEVEL SELECT
        if (this.gameObject.tag == "levelSelect")
        {
            SceneManager.LoadScene("Level Select");
        }

        if (this.gameObject.tag == "level1")
        {
            SceneManager.LoadScene("Level 1");

        }

        if (this.gameObject.tag == "level2")
        {
            SceneManager.LoadScene("Level 2");
        }

        if (this.gameObject.tag == "level3")
        {
            SceneManager.LoadScene("Level 3");
        }

        //scene change: LORE/GAMEPLAY
        if (this.gameObject.tag == "lore")
        {
            SceneManager.LoadScene("Lore");
        }

        //scene change: RETURN TO TITLE
        if (this.gameObject.tag == "returnTitle")
        {
            SceneManager.LoadScene("Title");
        }
    }
}
