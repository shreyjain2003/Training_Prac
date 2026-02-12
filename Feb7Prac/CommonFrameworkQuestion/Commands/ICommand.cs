namespace Q10_CommandPattern.Commands
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
