using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGun : MonoBehaviour
{
    public GameObject gunA, gunB, gunC;
    
  private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            gunA.SetActive(false);
            gunB.SetActive(false);
            gunC.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gunA.SetActive(true);
            gunB.SetActive(false);
            gunC.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            gunA.SetActive(false);
            gunB.SetActive(true);
            gunC.SetActive(false);
        }
    }
}
