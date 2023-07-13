using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Utilities.Result.Abstract
{
    public interface IDataResult<out T> : IResult
    {
        public T Data { get; }    //Kullanılımı
                                  //new DataResult<Category>(ResultStatus.Success, category);
                                  //new DataResult<List<Category>>(ResultStatus.Success, category);
    }
}
