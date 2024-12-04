using UnityEngine;
using UnityEngine.UIElements;

namespace Command
{
    public class AimCommand : IInputCommand
    {
        private GameObject _crosshair;
        private Vector2 _delta;
        
        public AimCommand(GameObject crosshair, Vector2 delta)
        {
            _crosshair = crosshair;
            _delta = delta;
        }
        
        public void PerformAction()
        {
            _crosshair.transform.position += new Vector3(_delta.x, _delta.y, 0);
        }

        public void InvertAction()
        {
            _crosshair.transform.position -= new Vector3(_delta.x, _delta.y, 0);
        }
    }
}