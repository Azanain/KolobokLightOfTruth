public class EventManager//������
{
    public delegate void EventManagerDel();
    public static event EventManagerDel NameEvent;

    public delegate void IntEventmanagerDel(int value);
    public static event IntEventmanagerDel LoadGameSceneEvent;

    public static void Name()
    {
        NameEvent?.Invoke();
    }
    public static void LoadGameScene(int idFloor)//����� �����
    {
        LoadGameSceneEvent?.Invoke(idFloor);
    }
}

