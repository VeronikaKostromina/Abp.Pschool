using Volo.Abp;

namespace Abp.Pschool.Teachers
{
    public class TeacherAlreadyExistsException : BusinessException
    {
        public TeacherAlreadyExistsException(string firstName, string lastName) :
            base(PschoolDomainErrorCodes.TeacherAlreadyExists)
        {
            WithData("name", $"{firstName} {lastName}");
        }
    }
}
