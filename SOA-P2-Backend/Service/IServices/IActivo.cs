using Domain.Entities;
using Domain.Request;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IActivo
    {
        List<Activo> GetAll();
        string AddActivo(RequestPostCreateActivo newActivo);
        string UpdateStatusActivo(RequestPatchUpdateStatusActivo newStatus);
    }
}
