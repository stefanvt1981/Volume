namespace VolumeApp.Components
{
    public interface ITextWriter
    {
        string ReadAll();
        void WriteLine(string input);
        void Clear();
    }
}