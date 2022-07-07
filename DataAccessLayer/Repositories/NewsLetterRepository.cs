using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFrameworkRepository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class NewsLetterRepository : EntityRepositoryBase<NewsLetter>, INewsLetterRepository
    {
    }
}
