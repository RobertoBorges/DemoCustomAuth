# Individual Authentication demo With Custom Attributes manager

This is a demo of how to use the Individual Authentication on AspNet Core with Razor Pages and Identity.

## How to use

With Visual Studio 2022, open the solution

Apply pending migrations from a command prompt at your project directory:

> PM> dotnet ef database update

and run the project.

It should create a local database "aspnet-DemoCustomAuth" and open a browser with the demo page.

For a good test create two users and add some roles on the database.

For my tests I used the following users:

| User | Roles |
| ---- | ----- |
user1@test.com | Admin
user2@test.com | User

## How it works

The demo is based on the default Individual Authentication template with Razor Pages and Identity.

The main part of this code is about the CustomAttribute class:

```csharp

        public string? Role { get; set; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //check access 
            if (CheckPermissions(context))
            {
                //all good, add optional code if you want. Or don't
            }
            else
            {
                //DENIED!
                //return access denied on the razor page
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { area = "Identity", page = "/Account/AccessDenied" }));
            }
        }

        private bool CheckPermissions(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User?.Identity?.IsAuthenticated == true)
            {
                //check if user is in role
                if (!string.IsNullOrEmpty(Role) && context.HttpContext.User.IsInRole(Role))
                {
                    return true;
                }
                //if the user is not in the role, we check if the role is empty
                //if the role is empty, we allow access
                else if (!string.IsNullOrEmpty(Role) && !context.HttpContext.User.IsInRole(Role))
                {
                    return false;
                }
                return true;
            }
            return false;
        }
```

This class receives a request when the user hits a Class with the custom Attribute e.g:

```csharp
[MyAuth(Role = "Admin")]
public class AdminPageModel : PageModel
{
    public void OnGet()
    {

    }
}
```

From here you should be able to implement your own logic to check if the user is allowed to access the page or not.

Feel free to use this code as you wish.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

Thanks to [StackOverflow](https://stackoverflow.com/) for all the help and to [Microsoft](https://www.microsoft.com/) for the great work on .Net Core and Visual Studio 2022.
