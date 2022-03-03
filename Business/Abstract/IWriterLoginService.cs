using Entities.Concrete;

namespace Business.Abstract
{
    public interface IWriterLoginService
    {
        Writer GetWriter(string userName, string passwordd);
    }
}
