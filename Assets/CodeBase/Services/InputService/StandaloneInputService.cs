using UnityEngine;

namespace Assets.CodeBase.Services.InputService
{
    public class StandaloneInputService : MonoBehaviour, IInputService
    {
        public StandaloneInputService()
        {
            Debug.Log("StandaloneInputService");
        }
    }
}