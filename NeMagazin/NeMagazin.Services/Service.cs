using System;
using System.Collections.Generic;
using System.Text;
using NeMagazin.Data;

namespace NeMagazin.Services
{
    public class Service
    {
        public Service()
        {
            this.Context = new NeMagazinContext();
        }

        protected NeMagazinContext Context { get;}
    }
}
