using Zenject;

namespace Props.Shared.States
{
    public class EmptyState : State
    {
        public class Factory : PlaceholderFactory<EmptyState>
        {

        }
    }
}
