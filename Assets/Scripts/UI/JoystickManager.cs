using UnityEngine;

public class JoystickManager : MonoBehaviour
{
    [SerializeField] private GameObject joystickMove;
    [SerializeField] private GameObject joystickLaser;

    private void Awake()
    {
        EventManager.ChangeJoystickEvent += ChangeJoystick;
    }
    private void ChangeJoystick(byte numberJoystick)//1 - move, 2 - laser
    {
        switch (numberJoystick)
        {
            case 1:
                joystickMove.SetActive(true);
                joystickLaser.SetActive(false);
                break;
            case 2:
                joystickMove.SetActive(false);
                joystickLaser.SetActive(true);
                break;

            default:
                joystickMove.SetActive(true);
                joystickLaser.SetActive(false);
                break;
        }
    }
    private void OnDestroy()
    {
        EventManager.ChangeJoystickEvent -= ChangeJoystick;
    }
}
