using System;
using Facebook.Business.Domain.Users;
using Facebook.Data;
using Facebook.Infrastructure.Contracts;
using System.Linq;
using System.Text;

namespace Facebook.Business.Domain.Facade.Internals
{
    public class KeyGenerationService : IKeyGenerationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public KeyGenerationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string CreateKey(User user)
        {
            ContractUtil.NotNull(user);

            var @base = GenerateBase(user);
            string result;

            var entriesRepository = _unitOfWork.Entries;
            var key = entriesRepository.Find(@base);

            if (Equals(key, null))
            {
                entriesRepository.Add(@base);
                result = @base;
            }
            else
            {
                key.Count++;
                result = @base + key.Count;
            }

            _unitOfWork.Commit();

            return result;
        }

        private static string GenerateBase(User user)
        {
            string @base;
            var sb = new StringBuilder();

            if (!(string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName)))
                @base = sb.Append(string.Concat(user.FirstName, user.LastName)
                                        .Split(' ')
                                        .Select(s => s.Trim())
                                        .SelectMany(s => s)
                                        .ToArray())
                          .ToString()
                          .ToLower();
            else if (!string.IsNullOrEmpty(user.EMail))
                @base = sb.Append(user.EMail.TakeWhile(c => c != '@').ToArray()).ToString();
            else
                @base = Guid.NewGuid().ToString();
            
            return @base;
        }
    }
}