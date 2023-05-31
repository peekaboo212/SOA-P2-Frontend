using Domain.Entities;
using Domain.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IEmployee
    {
        List<EmpleadoVM> GetAll();
        string CreateEmployee(RequestPostCreateEmployee newEmployee);
    }
}
