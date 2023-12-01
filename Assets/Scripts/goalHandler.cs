using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalHandler: MonoBehaviour
{
public GameObject player;

   void OnCollisionEnter(Collision col)
   {
      Debug.Log("Interaccion");
      if (col.gameObject == player)
      {
      SceneManager.LoadScene("premio");
      Debug.Log("Yes");
      }
   } 
}