namespace UIFrame.Base
{
    public interface INotifier
    {
        void SendNotification(string notificationName);
        void SendNotification(string notificationName, object body);
    }
}