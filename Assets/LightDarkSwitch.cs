using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDarkSwitch : MonoBehaviour
{
    public GameObject[] bgList;
    List<Animator> animatorList = new List<Animator>();
    //public Animator animator;
    int EnvironmentState= 1;

    void Start()
    {
        if (bgList.Length >= 1) //make sure list isn't empty
        {
            for (int i = 0; i < bgList.Length; i++) //NOTE: do "valvesList.Length - 1" instead, if you get index out of range error
            {
                animatorList.Add(bgList[i].GetComponent<Animator>()); //fill up your list with animators components from valve gameobjects
                animatorList[i].enabled = true; //turn off each animator component at the start
                animatorList[i].SetBool("New Bool", false);
            }
        }
        else
        {
            return; //if list is empty do nothing
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && EnvironmentState == 1)
        {
            for (int i = 0; i < bgList.Length; i++)
            {
                animatorList[i].SetBool("New Bool", true);
            }
            EnvironmentState = 0;
        }

        else if (col.tag == "Player")
        {
            for (int i = 0; i < bgList.Length; i++)
            {
                animatorList[i].SetBool("New Bool", false);
            }
            EnvironmentState = 1;
        }
        Debug.Log(EnvironmentState);

        
    }
}
