using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationHelper : MonoBehaviour
{
  public void PlayGame(string lvl)
  {
    SceneManager.LoadScene("lvl" + lvl);
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
}