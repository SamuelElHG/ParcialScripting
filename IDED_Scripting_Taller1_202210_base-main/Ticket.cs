namespace TestProject1
{
    internal struct Ticket
    {
        internal enum ERequestType
        {
            Subscription,
            Payment,
            Cancellation
        }

        public ERequestType RequestType { get; private set; }

        public int Turn { get; private set; }

        public Ticket(ERequestType requestType, int turn) 
        {
            RequestType = requestType;
            Turn = turn;
        }
    }
}