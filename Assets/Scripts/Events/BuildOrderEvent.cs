namespace Events
{
    public class BuildOrderEvent : IEvent
    {
        private readonly Cell _cell;
        private readonly Building _building;

        public BuildOrderEvent(Cell cell, Building building)
        {
            _cell = cell;
            _building = building;
        }

        public EventType GetEventType()
        {
            return EventType.BuildOrder;
        }

        public Cell Cell
        {
            get { return _cell; }
        }

        public Building Building
        {
            get { return _building; }
        }
    }
}