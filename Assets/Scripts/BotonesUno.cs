/*using UnityEngine;
using UnityEngine.UI;

public class ShootModeUI : MonoBehaviour
{
    public WeaponController weaponController; 
    public Button singleButton;
    public Button burstButton;
    public Button autoButton;

    private void Start()
    {
       
        singleButton.onClick.AddListener(SetSingleMode);
        burstButton.onClick.AddListener(SetBurstMode);
        autoButton.onClick.AddListener(SetAutoMode);
    }

    
    public void SetSingleMode()
    {
        weaponController.currentShootType = WeaponController.ShootType.Single;
    }

    
    public void SetBurstMode()
    {
        weaponController.currentShootType = WeaponController.ShootType.Burst;
    }

   
    public void SetAutoMode()
    {
        weaponController.currentShootType = WeaponController.ShootType.Auto;
    }
}
*/