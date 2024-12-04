using Command;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject crosshair;
    private bool _inverted;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveCrosshair(AimCommand aimCommand)
    {
        if(_inverted) aimCommand.InvertAction();
        else aimCommand.PerformAction();
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
}
