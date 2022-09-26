﻿using FinanceBag.Models;

namespace FinanceBag.Services
{
    public interface IRequestHandlerService<T0, T1>
    { 
        public T0 ExToVM(IEnumerable<dynamic> data0, IEnumerable<T1> data1);
    }
}