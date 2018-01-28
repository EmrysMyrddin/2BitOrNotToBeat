using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePersisted : MonoBehaviour
{
  public int level;
  Persisted persisted;

  // Use this for initialization
  void Start()
  {
    persisted = GameObject.Find("currentLevel").GetComponent<Persisted>();
    persisted.currentLevel = level;
  }

  // Update is called once per frame
  void Update()
  {

  }
}
