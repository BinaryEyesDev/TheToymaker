namespace TheToymaker.Data
{
    public struct FrameTime
    {
        public readonly float Elapsed;
        public readonly float Scale;
        public readonly float ElapsedScaled;

        public FrameTime(float elapsed, float scale)
        {
            Elapsed = elapsed;
            Scale = scale;
            ElapsedScaled = Elapsed*Scale;
        }
    }
}
