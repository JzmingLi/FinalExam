using Command;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject crosshair;
    private bool _inverted;
    private int _ammo;
    private bool _shotThisFrame;
    private bool _shotLastFrame; //avoid calling getcomponenet on update
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_shotThisFrame)
        {
            _shotThisFrame = false;
            _shotLastFrame = true;
        }
        else if(_shotLastFrame)
        {
            _shotLastFrame = false;
            crosshair.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void MoveCrosshair(AimCommand aimCommand)
    {
        if(_inverted) aimCommand.InvertAction();
        else aimCommand.PerformAction();
    }

    public void Shoot()
    {
        /*
        if (_ammo > 0)
        {
            _ammo--;
            _shotThisFrame = true;
            crosshair.GetComponent<BoxCollider2D>().enabled = true;
        }
        */
        _shotThisFrame = true;
        crosshair.GetComponent<BoxCollider2D>().enabled = true;
    }
    
    public void InvertAim()
    {
        _inverted = true;
    }

    public void DeInvertAim()
    {
        _inverted = false;
    }

    public void ResetCrosshairPosition()
    {
        crosshair.transform.position = Vector3.zero;
    }

    public void RefillAmmo()
    {
        _ammo = 3;
    }
}
