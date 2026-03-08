namespace ZenBlog.API.Endpoints.Registration
{
    public static class EndpointRegistrations
    {
        public static void RegisterEndpoints(this IEndpointRouteBuilder app)
        {
            
            app.RegisterCategoryEndpoints();
            app.RegisterBlogEndpoints();
            app.RegisterUserEndpoints();
            app.RegisterCommentEndpoints();
            app.RegisterSubCommentEndpoints();
            app.RegisterContactInfoEndpoints();
            app.RegisterMessageEndpoints();
            app.RegisterSocialEndpoints();

        }
    }
}
