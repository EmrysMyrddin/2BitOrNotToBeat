using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationHelper : MonoBehaviour
{
  public Persisted persisted;
  void Start()
  {
    persisted = GameObject.Find("currentLevel").GetComponent<Persisted>();
  }
  public void PlayGame(int lvl)
  {
    SceneManager.LoadScene("lvl" + lvl);
  }

  public void NextLevel()
  {
    PlayGame(persisted.currentLevel + 1);
  }

  public void ReloadLevel()
  {
    PlayGame(persisted.currentLevel);
  }

  public void TutoGame()
  {
    SceneManager.LoadScene("Tuto");
  }

  public void WinGame()
  {
    SceneManager.LoadScene("Win");
  }

  public void LooseGame()
  {
    SceneManager.LoadScene("Loose");
  }

  public void CreditGame()
  {
    SceneManager.LoadScene("Credit");
  }

  public void LvlMenuGame()
  {
    SceneManager.LoadScene("lvlMenu");
  }

  public void MainGame()
  {
    SceneManager.LoadScene("Start");
  }

  public void SettingsGame()
  {
    SceneManager.LoadScene("settings");
  }
}