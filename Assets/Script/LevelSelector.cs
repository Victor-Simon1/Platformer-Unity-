using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{

  public Button[] levelButtons;

  void Start()
  {
    int levelReached = PlayerPrefs.GetInt("levelReached",1);
    for (int i = levelReached; i < levelButtons.Length; i++)
    {
      levelButtons[i].interactable = false;
    }
  }
  public void LoadLevelPassed(string levelName)
  {
    SceneManager.LoadScene(levelName);
  }
}
