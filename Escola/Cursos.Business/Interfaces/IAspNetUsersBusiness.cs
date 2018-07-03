using Cursos.ViewModel;

namespace Cursos.Business
{
    public interface IAspNetUsersBusiness
    {
        AspNetUsersViewModel GetUserByName(string username);
        RefreshtokenViewModel GetByRefreshToken(string refreshToken);
    }
}