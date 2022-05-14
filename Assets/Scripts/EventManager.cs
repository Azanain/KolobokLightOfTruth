public class EventManager//евенты
{
    public delegate void EventManagerDel();
    public static event EventManagerDel NameEvent;

    public delegate void IntEventmanagerDel(int value);
    public static event IntEventmanagerDel LoadGameSceneEvent;

    public static void Name()
    {
        NameEvent?.Invoke();
    }
    public static void LoadGameScene(int idStage)//номер этажа
    {
        LoadGameSceneEvent?.Invoke(idStage);
    }
}

