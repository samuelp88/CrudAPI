namespace CrudAPI.Data
{
    public interface IParser<P, R>
    {
        R Parse(P p);
        List<R> Parse(List<P> p);
        P Parse(R r);
        List<P> Parse(List<R> r);
    }
}
