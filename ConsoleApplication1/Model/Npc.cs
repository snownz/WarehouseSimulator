using System.Threading;
using ConsoleApplication1.Actions;

namespace ConsoleApplication1.Model
{
    public class Npc : ObjectBase
    {
        protected Thread _taskRunner;
        protected volatile int _ms;

        public Npc(IAction<int, ActionModelMoveToLocation> move)
        {
            Move = move;
        }

        public IAction<int, ActionModelMoveToLocation> Move;

        public int Ms
        {
            get { return _ms; }
            set { _ms = value; }
        }

        public void Run()
        {
            _taskRunner.Start();
        }
        public void Pause()
        {
            _taskRunner.Abort();
        }
    }
}
