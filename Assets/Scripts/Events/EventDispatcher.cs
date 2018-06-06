using System.Collections.Generic;

public class EventDispatcher
{
    private List<ISubscriber> _subscribers = new List<ISubscriber>();
    private static EventDispatcher _eventDispatcher = null;

    private EventDispatcher()
    {
    }

    public static EventDispatcher GetInstance()
    {
        if (_eventDispatcher == null)
        {
            _eventDispatcher = new EventDispatcher();
        }

        return _eventDispatcher;
    }

    public void Subscribe(ISubscriber subscriber)
    {
        _subscribers.Add(subscriber);
    }

    public void Unsubscribe(ISubscriber subscriber)
    {
        _subscribers.Remove(subscriber);
    }

    public void AddEvent(IEvent e)
    {
        foreach (var subscriber in _subscribers)
        {
            subscriber.Notify(e);
        }
    }
}