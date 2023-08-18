
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proyecto.Api.DataAccess.Contracts.Repositories
{
  public  interface IRepository<T> where T : class
    {
      //envia los datos a la base 
        Task<long> Add(T element);
        //actualiza los datos a la base
        Task<long> Update(T element);
        //elimina  lista de datos
        Task<long> Delete( List<long> ids);

    }
}
