using UnityEngine;
using UnityEngine.InputSystem;

public class SavePosition : MonoBehaviour
{
    private Vector3 savedPosition;

    void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard != null)
        {
            // Tecla S para guardar posición
            if (keyboard.sKey.wasPressedThisFrame)
            {
                savedPosition = transform.position;
                Debug.Log("Posición guardada: " + savedPosition);
            }

            // Tecla R para restaurar posición
            if (keyboard.rKey.wasPressedThisFrame)
            {
                transform.position = savedPosition;
                Debug.Log("Posición restaurada: " + savedPosition);
            }
        }
    }
}
