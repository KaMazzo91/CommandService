namespace CommandsService.EventProcessing
{
    public interface IEventProcessor
    {
        void ProcessEvemt(string message);
    }
}