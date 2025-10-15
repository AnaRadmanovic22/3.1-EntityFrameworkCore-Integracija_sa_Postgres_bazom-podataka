namespace BookstoreApplication.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(int id): base($"Item withid {id} could not be found.") { }
    }
}
