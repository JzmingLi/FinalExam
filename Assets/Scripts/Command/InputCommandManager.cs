using System;
using Command;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputCommandManager : MonoBehaviour
{
    [SerializeField] InputActionAsset inputActionAsset;
    [SerializeField] Player player;
    [SerializeField] float sensitivity;
    
    private InputActionMap _playerActions;
    

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        inputActionAsset.Enable();

        _playerActions = inputActionAsset.FindActionMap("Player");
        _playerActions.Enable();
    }

    private void Update()
    {
        Vector2 aimDelta = _playerActions.FindAction("Aim").ReadValue<Vector2>();
        aimDelta *= sensitivity;
        AimCommand aimCommand = new AimCommand(player.crosshair, aimDelta);
        player.MoveCrosshair(aimCommand);
    }
}
