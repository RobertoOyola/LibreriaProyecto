﻿using EntityLayer.Models.DTO;
using EntityLayer.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Prestamo
{
    public interface IPrestamoRepository
    {
        public Task<Response> ObtenerPrestamo();
    }
}
