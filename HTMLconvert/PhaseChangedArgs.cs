namespace HTMLconvert
{
    public class PhaseChangedArgs : EventArgs
    {
        public int PhaseCount { get; set; }
        public int CurrentPhase { get; set; }
        public string Description { get; set; }
    }
}