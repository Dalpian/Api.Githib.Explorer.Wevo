using Wevo.Github.Explore.Domain.Entities;
using Wevo.Github.Explorer.Github.Model;

namespace Wevo.Github.Explore.Github.Mapper
{
    public static class UserDetailMap
    {
        public static UserDetail Map(UserDetailGithub userDetail) => userDetail == null ? default(UserDetail) : new UserDetail()
        {
            Login = userDetail.Login,
            Id = userDetail.Id,
            Node_id = userDetail.Node_id,
            Avatar_url = userDetail.Avatar_url,
            Gravatar_id = userDetail.Gravatar_id,
            Url = userDetail.Url,
            Html_url = userDetail.Html_url,
            Followers_url = userDetail.Followers_url,
            Following_url = userDetail.Following_url,
            Gists_url = userDetail.Gists_url,
            Starred_url = userDetail.Starred_url,
            Subscriptions_url = userDetail.Subscriptions_url,
            Organizations_url = userDetail.Organizations_url,
            Repos_url = userDetail.Repos_url,
            Events_url = userDetail.Events_url,
            Eeceived_events_url = userDetail.Eeceived_events_url,
            Type = userDetail.Type,
            Site_admin = userDetail.Site_admin,
            Name = userDetail.Name,
            company = userDetail.company,
            Blog = userDetail.Blog,
            Location = userDetail.Location,
            Email = userDetail.Email,
            Hireable = userDetail.Hireable,
            Bio = userDetail.Bio,
            Twitter_username = userDetail.Twitter_username,
            Public_repos = userDetail.Public_repos,
            Public_gists = userDetail.Public_gists,
            Followers = userDetail.Followers,
            Following = userDetail.Following,
            Created_at = userDetail.Created_at,
            Updated_at = userDetail.Updated_at
        };
    }
}
