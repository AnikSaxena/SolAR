
using UnityEngine;
using UnityEngine.SceneManagement;

public class changescene : MonoBehaviour
{
    private selection selection;

    private void Start()
    {
        selection = FindObjectOfType<selection>();
    }
    private void Update()
    {
    }
    public void btnclicked(string scene)
    {
        data.planetname = selection.select.name;
        SceneManager.LoadScene(scene);
    }
    public void backbtn(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Arbtn(string scene)
    {
        SceneManager.LoadScene(scene);
        Screen.orientation = ScreenOrientation.Portrait;
    }
}
