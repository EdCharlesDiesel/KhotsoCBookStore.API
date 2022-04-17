namespace StarPeace.Extensions
{
    public interface ISearchContact
    {
        public static List<T> SearchByCountry(string country);

        public static List<T> SearchByCompanyName(string company);

        public static List<T> SearchByContactName(string contact);

    }
}