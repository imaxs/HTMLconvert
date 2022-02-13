namespace HTMLconvert.Core
{
    using Settings;
    public interface IBaseConverter
    {
        event EventHandler<PhaseChangedArgs> PhaseChanged;
        event EventHandler<ProgressChangedArgs> ProgressChanged;
        event EventHandler<FinishedArgs> Finished;
        event EventHandler<ErrorArgs> Error;
        event EventHandler<WarningArgs> Warning;
        byte[] Convert(ISettings global, string htmlContent, params ISettings[] objects);
        byte[] Convert(ISettings global, string htmlContent);
        byte[] Convert(ISettings global, params ISettings[] objects);
    }
}