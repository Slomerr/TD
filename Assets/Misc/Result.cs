namespace TD.Assets.Misc
{
    public class Result<T>
    {
        private bool m_Success;
        private T m_Result;
        
        public Result(bool success, T result)
        {
            m_Success = success;
            m_Result = result;
        }

        public bool IsSuccess()
        {
            return m_Success;
        }

        public T GetResult()
        {
            return m_Result;
        }
    }
}
