using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePersisted : MonoBehaviour
{
  public int level;
  public string language;

  // Use this for initialization
  void Start()
  {
    Persisted.Instance.currentLevel = level;
    Persisted.Instance.language = language;
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void SetLanguage(string language)
  {
    Persisted.Instance.language = language;
  }
}
