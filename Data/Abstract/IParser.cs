namespace CrudAPI.Data
{
    public interface IParser<P, R>
    {
        R Parse(P p);
        List<R> Parse(List<P> p);
        bool TryParse(P p, out R r);
        bool TryParse(List<P> p, out List<R> r);

        P Parse(R r);
        List<P> Parse(List<R> r);
        bool TryParse(R r, out P p);
        bool TryParse(List<R> r, out List<P> p);

    }
}
