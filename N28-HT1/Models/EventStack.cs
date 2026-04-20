using N28_HT1.Interfaces;

namespace N28_HT1.Models
{
    public class EventStack<T> where T : IEvent
    {
        private List<T> _events;

        public EventStack()
        {
            _events = new List<T>();
        }

        public void Push(T eventItem)
        {
            if (_events.All(x => x.Date < eventItem.Date))
            {
                _events.Add(eventItem);
                return;
            }

            throw new Exception("Event date must be greater than all existing events in the stack.");
        }

        public T Peek()
        {
            if (_events.Count == 0)
            {
                throw new Exception("Event stack is empty.");
            }
            return _events.Last();
        }

        public void Pop()
        {
            if (_events.Count == 0)
            {
                throw new Exception("Event stack is empty.");
            }
            _events.RemoveAt(_events.Count - 1);
        }
    }
}
