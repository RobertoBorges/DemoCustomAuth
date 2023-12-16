namespace DemoCustomAuth.Services;

public interface IIdentityParser<T>
{
    T Parse(IPrincipal principal);
}
