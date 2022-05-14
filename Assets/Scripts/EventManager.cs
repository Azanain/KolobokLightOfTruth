public class EventManager//евенты
{
    public delegate void EventManagerDel();
    public static event EventManagerDel NameEvent;
    public static event EventManagerDel NameEvent2;

    public delegate void EventManagerDel2(int value);
    public static event EventManagerDel2 NameEventas;

    public static void Name()
    {
        NameEvent?.Invoke();
    }
}

public class afbhs//кнопка
{
    private void Awake()
    { 
        EventManager.Name();
    }
}

public class jdfnhdf//действие кнопки
{
    private void Awake()
    {
        EventManager.NameEvent += Name;
    }
    private void Name()
    { 
    
    }
    void OnDestroy()
    {
        EventManager.NameEvent -= Name;
    }
}
